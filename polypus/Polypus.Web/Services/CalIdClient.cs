using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Polypus.Web.Services;

/// <summary>
/// Client service for communicating with Calid.Api backend for meeting scheduling,
/// with automatic resilient fallback to direct Cal.id API if Calid.Api is offline.
/// </summary>
public class CalIdClient
{
    private const string CalIdApiKey = "calid_d7ee826f02525257341a36356384da7a";
    private const string CalIdBaseUrl = "https://api.cal.id/";
    private const string DefaultTimeZone = "Asia/Kolkata";

    private readonly HttpClient _localClient;
    private readonly HttpClient _directClient;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public CalIdClient(HttpClient? httpClient = null, string? baseUrl = null)
    {
        var localUrl = !string.IsNullOrWhiteSpace(baseUrl) ? baseUrl : "http://localhost:5000";
        // Configure a 30-second timeout for Calid.Api calls. Calid.Api creates the booking upstream
        // and then polls Cal.id for video link enrichment (Google Meet), which takes several seconds.
        _localClient = httpClient ?? new HttpClient
        {
            BaseAddress = new Uri(localUrl.TrimEnd('/') + "/"),
            Timeout = TimeSpan.FromSeconds(30)
        };

        _directClient = new HttpClient
        {
            BaseAddress = new Uri(CalIdBaseUrl),
            Timeout = TimeSpan.FromSeconds(15)
        };
        _directClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", CalIdApiKey);
    }

    /// <summary>
    /// Fetches configured event types and returns only public meeting types
    /// (Quick Meeting — 15 min, Standard Meeting — 30 min), keeping Private Meeting hidden.
    /// </summary>
    public async Task<IReadOnlyList<CalIdEventType>> GetPublicEventTypesAsync(CancellationToken cancellationToken = default)
    {
        // 1. Try Calid.Api backend
        try
        {
            var response = await _localClient.GetFromJsonAsync<EventTypesResponse>("api/meeting/event-types", JsonOptions, cancellationToken);
            if (response?.EventTypes is { Count: > 0 } types)
            {
                return FilterPublicTypes(types);
            }
        }
        catch
        {
            // Backend unavailable, fallback to direct Cal.id
        }

        // 2. Direct Cal.id fallback
        try
        {
            using var response = await _directClient.GetAsync("event-types", cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync(cancellationToken);
                var node = JsonNode.Parse(content);
                if (node?["data"] is JsonArray arr)
                {
                    var types = arr.OfType<JsonObject>().Select(et => new CalIdEventType
                    {
                        Id = et["id"]?.GetValue<int>() ?? 0,
                        Title = et["title"]?.GetValue<string>() ?? string.Empty,
                        Slug = et["slug"]?.GetValue<string>() ?? string.Empty,
                        Length = et["length"]?.GetValue<int>() ?? 15,
                        Description = et["description"]?.GetValue<string>() ?? string.Empty,
                        Hidden = et["hidden"]?.GetValue<bool>() ?? false
                    }).ToList();

                    return FilterPublicTypes(types);
                }
            }
        }
        catch
        {
            // Ignore and use default
        }

        // 3. Guaranteed fallback
        return
        [
            new CalIdEventType { Id = 111709, Title = "Quick Meeting", Slug = "quick-meeting", Length = 15, Hidden = false },
            new CalIdEventType { Id = 111710, Title = "Standard Meeting", Slug = "standard-meeting", Length = 30, Hidden = false }
        ];
    }

    private static IReadOnlyList<CalIdEventType> FilterPublicTypes(IEnumerable<CalIdEventType> types) =>
        types.Where(t => !t.Hidden && !t.Slug.Contains("private", StringComparison.OrdinalIgnoreCase))
             .OrderBy(t => t.Length)
             .ToList();

    /// <summary>
    /// Fetches slots from Calid.Api (or Cal.id directly) and applies generic overlap conflict logic
    /// against existing bookings for that day.
    /// </summary>
    public async Task<IReadOnlyList<CalIdSlot>> GetAvailableSlotsWithConflictCheckAsync(
        string date,
        int eventTypeId,
        int durationMinutes,
        CancellationToken cancellationToken = default)
    {
        IReadOnlyList<CalIdSlot> rawSlots = [];

        // 1. Try local Calid.Api for available slots
        try
        {
            var url = $"api/meeting/available-slots?startDate={Uri.EscapeDataString(date)}&endDate={Uri.EscapeDataString(date)}&eventTypeId={eventTypeId}";
            var slotsResponse = await _localClient.GetFromJsonAsync<SlotsResponse>(url, JsonOptions, cancellationToken);
            rawSlots = slotsResponse?.Slots ?? [];
        }
        catch
        {
            // Local backend offline; try direct Cal.id slots
            rawSlots = await FetchRawSlotsDirectAsync(date, eventTypeId, cancellationToken);
        }

        if (rawSlots.Count == 0)
        {
            // Check direct upstream in case local had 0 or was offline
            rawSlots = await FetchRawSlotsDirectAsync(date, eventTypeId, cancellationToken);
        }

        if (rawSlots.Count == 0)
        {
            return [];
        }

        // 2. Fetch existing bookings to check for overlaps
        IReadOnlyList<CalIdBooking> bookings = [];
        try
        {
            var bookingsResponse = await _localClient.GetFromJsonAsync<BookingsResponse>("api/meeting/bookings", JsonOptions, cancellationToken);
            bookings = bookingsResponse?.Bookings ?? [];
        }
        catch
        {
            // Direct Cal.id bookings fallback
            bookings = await FetchBookingsDirectAsync(cancellationToken);
        }

        if (bookings.Count == 0)
        {
            bookings = await FetchBookingsDirectAsync(cancellationToken);
        }

        // Parse target date
        DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var targetDt);

        // 3. Filter active bookings that occur on or overlap the target day
        var activeBookings = bookings
            .Where(b => !string.Equals(b.Status, "CANCELLED", StringComparison.OrdinalIgnoreCase))
            .Select(b => new
            {
                Booking = b,
                HasValidStart = TryParseUtc(b.StartTime, out var start),
                Start = start,
                HasValidEnd = TryParseUtc(b.EndTime, out var end),
                End = end
            })
            .Where(b => b.HasValidStart && b.HasValidEnd)
            .ToList();

        // 4. Overlap check: a slot at [slotStart, slotEnd) is available ONLY IF it does not overlap
        // any existing booking [bookingStart, bookingEnd):
        // Overlap occurs when: (slotStart < bookingEnd) && (slotEnd > bookingStart)
        var filteredSlots = new List<CalIdSlot>();
        foreach (var slot in rawSlots)
        {
            if (!TryParseUtc(slot.Time, out var slotStart))
            {
                continue;
            }

            var slotEnd = slotStart.AddMinutes(durationMinutes);

            var hasConflict = activeBookings.Any(b => slotStart < b.End && slotEnd > b.Start);
            if (!hasConflict)
            {
                filteredSlots.Add(slot);
            }
        }

        return filteredSlots;
    }

    private async Task<IReadOnlyList<CalIdSlot>> FetchRawSlotsDirectAsync(string date, int eventTypeId, CancellationToken cancellationToken)
    {
        try
        {
            var start = $"{date}T00:00:00.000Z";
            var end = $"{date}T23:59:59.999Z";
            var query = $"slots?eventTypeId={eventTypeId}&start={Uri.EscapeDataString(start)}&end={Uri.EscapeDataString(end)}&timeZone={Uri.EscapeDataString(DefaultTimeZone)}";

            using var response = await _directClient.GetAsync(query, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return [];
            }

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            var node = JsonNode.Parse(content);
            var slotsObj = node?["data"]?["slots"] as JsonObject;
            if (slotsObj is null)
            {
                return [];
            }

            var result = new List<CalIdSlot>();
            foreach (var (dayKey, dayVal) in slotsObj)
            {
                if (dayVal is JsonArray dayArr)
                {
                    foreach (var s in dayArr.OfType<JsonObject>())
                    {
                        var time = s["time"]?.GetValue<string>();
                        if (!string.IsNullOrEmpty(time))
                        {
                            result.Add(new CalIdSlot { Date = dayKey, Time = time });
                        }
                    }
                }
            }

            return result;
        }
        catch
        {
            return [];
        }
    }

    private async Task<IReadOnlyList<CalIdBooking>> FetchBookingsDirectAsync(CancellationToken cancellationToken)
    {
        try
        {
            using var response = await _directClient.GetAsync("booking", cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return [];
            }

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            var node = JsonNode.Parse(content);
            var dataArr = node?["data"] as JsonArray;
            if (dataArr is null)
            {
                return [];
            }

            return dataArr.OfType<JsonObject>().Select(b => new CalIdBooking
            {
                Id = b["id"]?.GetValue<int>() ?? 0,
                StartTime = b["startTime"]?.GetValue<string>(),
                EndTime = b["endTime"]?.GetValue<string>(),
                Status = b["status"]?.GetValue<string>(),
                Title = b["title"]?.GetValue<string>()
            }).ToList();
        }
        catch
        {
            return [];
        }
    }

    /// <summary>
    /// Books a meeting slot via POST /api/meeting/book (with direct Cal.id fallback).
    /// </summary>
    public async Task<BookMeetingResult> BookMeetingAsync(
        BookMeetingRequest request,
        CancellationToken cancellationToken = default)
    {
        // 1. Try local Calid.Api
        try
        {
            using var response = await _localClient.PostAsJsonAsync("api/meeting/book", request, JsonOptions, cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var doc = JsonDocument.Parse(content);
                var message = doc.RootElement.TryGetProperty("message", out var msgProp)
                    ? msgProp.GetString()
                    : "Meeting booked successfully!";
                return new BookMeetingResult { Success = true, Message = message };
            }
            else
            {
                string? errorMessage = null;
                try
                {
                    var doc = JsonDocument.Parse(content);
                    if (doc.RootElement.TryGetProperty("error", out var errProp))
                    {
                        errorMessage = errProp.GetString();
                    }
                }
                catch { }

                return new BookMeetingResult
                {
                    Success = false,
                    Error = errorMessage ?? $"Scheduling failed with status {(int)response.StatusCode}."
                };
            }
        }
        catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
        {
            // Booking is a non-idempotent operation. A timeout does not prove
            // that the booking failed because the backend may still be processing
            // the request. Do not automatically submit the same booking again,
            // otherwise Cal.id may create the first booking successfully and reject
            // the second request because the time slot is already occupied.
            return new BookMeetingResult
            {
                Success = false,
                Error = "The booking request timed out while communicating with the server. Please check your schedule before retrying."
            };
        }
        catch (HttpRequestException ex) when (IsConnectionFailure(ex))
        {
            // Fallback is strictly reserved for when the local Calid.Api backend is genuinely
            // offline or unreachable (e.g. connection refused or host unresolved).
            // This ensures frontend resiliency without creating duplicate bookings on transient latency.
            return await BookMeetingDirectAsync(request, cancellationToken);
        }
        catch (Exception ex)
        {
            return new BookMeetingResult
            {
                Success = false,
                Error = $"Failed to communicate with booking service: {ex.Message}"
            };
        }
    }

    private async Task<BookMeetingResult> BookMeetingDirectAsync(BookMeetingRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var payload = new JsonObject
            {
                ["start"] = request.StartTime,
                ["end"] = request.EndTime,
                ["eventTypeId"] = request.EventTypeId ?? 111709,
                ["timeZone"] = DefaultTimeZone,
                ["responses"] = new JsonObject
                {
                    ["name"] = request.Name,
                    ["email"] = request.Email,
                    ["notes"] = request.Notes ?? string.Empty
                }
            };

            using var content = new StringContent(payload.ToJsonString(), Encoding.UTF8, "application/json");
            using var response = await _directClient.PostAsync("booking/", content, cancellationToken);
            var body = await response.Content.ReadAsStringAsync(cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return new BookMeetingResult
                {
                    Success = true,
                    Message = "Meeting booked successfully! Google Meet link has been generated."
                };
            }

            string? error = null;
            try
            {
                var node = JsonNode.Parse(body);
                error = node?["message"]?.GetValue<string>();
            }
            catch { }

            return new BookMeetingResult
            {
                Success = false,
                Error = error ?? $"Booking rejected with status {(int)response.StatusCode}: {body}"
            };
        }
        catch (Exception ex)
        {
            return new BookMeetingResult
            {
                Success = false,
                Error = $"Unable to book meeting: {ex.Message}"
            };
        }
    }

    private static bool TryParseUtc(string? value, out DateTimeOffset instant)
    {
        if (!string.IsNullOrWhiteSpace(value) &&
            DateTimeOffset.TryParse(value, CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out instant))
        {
            return true;
        }

        instant = default;
        return false;
    }

    private static bool IsConnectionFailure(HttpRequestException ex) =>
        ex.HttpRequestError == HttpRequestError.ConnectionError ||
        ex.HttpRequestError == HttpRequestError.NameResolutionError ||
        ex.InnerException is System.Net.Sockets.SocketException;

    private sealed class EventTypesResponse
    {
        [JsonPropertyName("eventTypes")]
        public List<CalIdEventType>? EventTypes { get; set; }
    }

    private sealed class SlotsResponse
    {
        [JsonPropertyName("slots")]
        public List<CalIdSlot>? Slots { get; set; }
    }

    private sealed class BookingsResponse
    {
        [JsonPropertyName("bookings")]
        public List<CalIdBooking>? Bookings { get; set; }
    }
}

public class CalIdEventType
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public int Length { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool Hidden { get; set; }

    public string DisplayName => Length > 0 ? $"{Title} — {Length} min" : Title;
}

public class CalIdSlot
{
    public string Date { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty;
}

public class CalIdBooking
{
    public int Id { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
    public string? Status { get; set; }
    public string? Title { get; set; }
}

public class BookMeetingRequest
{
    public string StartTime { get; set; } = string.Empty;
    public string? EndTime { get; set; }
    public int? Duration { get; set; }
    public int? EventTypeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Notes { get; set; }
}

public class BookMeetingResult
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public string? Error { get; set; }
}
