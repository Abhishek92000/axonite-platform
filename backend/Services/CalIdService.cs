using System.Globalization;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Calid.Api.Models;
using Microsoft.Extensions.Options;

namespace Calid.Api.Services;

/// <summary>
/// Talks to the Cal.id REST API. All Cal.id specific behaviour lives here:
/// URL building, auth, error handling and reshaping Cal.id's responses into
/// the flat shapes the frontend expects.
/// </summary>
public class CalIdService : ICalIdService
{
    private const int MinimumBookingNoticeMinutes = 120;

    private readonly HttpClient _httpClient;
    private readonly CalIdOptions _options;
    private readonly ILogger<CalIdService> _logger;

    public CalIdService(
        HttpClient httpClient,
        IOptions<CalIdOptions> options,
        ILogger<CalIdService> logger)
    {
        _httpClient = httpClient;
        _options = options.Value;
        _logger = logger;

        _httpClient.BaseAddress = new Uri(_options.ApiBaseUrl.TrimEnd('/') + "/");
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _options.ApiKey);
    }

    public async Task<IReadOnlyList<EventTypeDto>> GetEventTypesAsync(CancellationToken cancellationToken = default)
    {
        var payload = await GetJsonAsync("event-types", cancellationToken);
        var data = payload?["data"] as JsonArray;

        if (data is null)
        {
            return [];
        }

        return data
            .OfType<JsonObject>()
            .Select(et => new EventTypeDto
            {
                Id = GetInt(et, "id") ?? 0,
                Title = GetString(et, "title") ?? string.Empty,
                Slug = GetString(et, "slug") ?? string.Empty,
                Length = GetInt(et, "length") ?? _options.BaseBookingDurationMinutes,
                Description = GetString(et, "description") ?? string.Empty,
                Hidden = et["hidden"]?.GetValue<bool>() ?? false
            })
            .ToList();
    }

    public async Task<IReadOnlyList<SlotDto>> GetAvailableSlotsAsync(
        string? startDate,
        string? endDate,
        int? eventTypeId,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(startDate) || string.IsNullOrWhiteSpace(endDate))
        {
            throw new CalIdValidationException(
                "startDate and endDate query params are required (YYYY-MM-DD or ISO-8601).");
        }

        var start = ToInstant(startDate, "startDate", endOfDay: false);
        var end = ToInstant(endDate, "endDate", endOfDay: true);

        if (end <= start)
        {
            throw new CalIdValidationException("endDate must be later than startDate.");
        }

        // Cal.id needs an event type reference: either the numeric eventTypeId, or a slug
        // prefixed with its owner ("<username>/<slug>"). A bare slug is rejected.
        var eventTypeReference = eventTypeId is > 0
            ? $"eventTypeId={eventTypeId.Value}"
            : _options.EventTypeId > 0
                ? $"eventTypeId={_options.EventTypeId}"
                : $"eventTypeSlug={Uri.EscapeDataString($"{_options.Username}/{_options.EventSlug}")}";

        var query =
            $"slots?{eventTypeReference}" +
            $"&start={Uri.EscapeDataString(start.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture))}" +
            $"&end={Uri.EscapeDataString(end.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture))}" +
            $"&timeZone={Uri.EscapeDataString(_options.TimeZone)}";

        _logger.LogDebug("Requesting slots with {EventTypeReference}", eventTypeReference);

        var payload = await GetJsonAsync(query, cancellationToken);
        var slots = payload?["data"]?["slots"] as JsonObject;

        if (slots is null)
        {
            return [];
        }

        // Cal.id groups slots by date; flatten to one entry per slot.
        var flatSlots = new List<SlotDto>();
        foreach (var (date, value) in slots)
        {
            if (value is not JsonArray daySlots)
            {
                continue;
            }

            foreach (var slot in daySlots.OfType<JsonObject>())
            {
                flatSlots.Add(new SlotDto
                {
                    Date = date,
                    Time = GetString(slot, "time") ?? string.Empty
                });
            }
        }

        return flatSlots;
    }

    public async Task<MeetingScheduleResponse> BookMeetingAsync(
        MeetingScheduleRequest request,
        CancellationToken cancellationToken = default)
    {
        if (!TryParseInstant(request.StartTime, out var start))
        {
            throw new CalIdValidationException(
                "startTime must be a valid ISO-8601 instant, e.g. 2026-09-25T03:30:00.000Z.");
        }

        var duration = request.Duration ?? _options.BaseBookingDurationMinutes;
        var end = TryParseInstant(request.EndTime, out var parsedEnd) ? parsedEnd : start.AddMinutes(duration);

        if (end <= start)
        {
            throw new CalIdValidationException("endTime must be later than startTime.");
        }

        // Business rule: Enforce a minimum 2-hour notice window before the meeting start.
        // This prevents bookings from occurring without sufficient lead time for attendees.
        var earliestSlot = DateTimeOffset.UtcNow.AddMinutes(MinimumBookingNoticeMinutes);
        if (start < earliestSlot)
        {
            throw new CalIdValidationException(
                $"This event type requires at least {MinimumBookingNoticeMinutes / 60} hours notice. " +
                "Pick a slot further ahead.");
        }

        var payload = new JsonObject
        {
            ["start"] = FormatInstant(start),
            ["end"] = FormatInstant(end),
            ["eventTypeId"] = request.EventTypeId ?? _options.EventTypeId,
            ["timeZone"] = _options.TimeZone,
            ["responses"] = new JsonObject
            {
                ["name"] = request.Name,
                ["email"] = request.Email,
                ["notes"] = request.Notes ?? string.Empty
            }
        };

        using var content = new StringContent(payload.ToJsonString(), Encoding.UTF8, "application/json");
        using var response = await _httpClient.PostAsync("booking/", content, cancellationToken);
        var body = await response.Content.ReadAsStringAsync(cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Cal.id rejected the booking ({StatusCode}): {Body}", response.StatusCode, body);
            return MeetingScheduleResponse.Fail("Failed to book the meeting on Cal.id.", ParseNode(body));
        }

        var booking = MapBooking(ParseNode(body)?["data"] as JsonObject);
        booking = await EnrichWithVideoLinkAsync(booking, cancellationToken);

        return MeetingScheduleResponse.Ok(booking);
    }

    public async Task<IReadOnlyList<BookingDto>> GetBookingsAsync(CancellationToken cancellationToken = default)
    {
        var payload = await GetJsonAsync("booking", cancellationToken);
        var data = payload?["data"] as JsonArray;

        if (data is null)
        {
            return [];
        }

        return data
            .OfType<JsonObject>()
            .Select(MapBooking)
            .ToList();
    }

    /// <summary>
    /// Re-reads a freshly created booking until Cal.id has attached the Google Meet link.
    /// Cal.id creates the calendar booking immediately, but external video integration (Google Meet)
    /// generates asynchronously. Polling allows returning the live join URL in the immediate response.
    /// Failures or timeouts during polling never fail the booking — the meeting is already confirmed.
    /// </summary>
    private async Task<BookingDto> EnrichWithVideoLinkAsync(BookingDto booking, CancellationToken cancellationToken)
    {
        if (booking.Id <= 0 || !string.IsNullOrEmpty(booking.VideoCallUrl) || _options.VideoLinkPollAttempts <= 0)
        {
            return booking;
        }

        for (var attempt = 0; attempt < _options.VideoLinkPollAttempts; attempt++)
        {
            await Task.Delay(_options.VideoLinkPollDelayMs, cancellationToken);

            try
            {
                var payload = await GetJsonAsync($"booking/{booking.Id}", cancellationToken);

                if (payload?["data"] is JsonObject details)
                {
                    var refreshed = MapBooking(details);
                    if (!string.IsNullOrEmpty(refreshed.VideoCallUrl))
                    {
                        return refreshed;
                    }
                }
            }
            catch (CalIdApiException ex)
            {
                _logger.LogWarning(
                    "Could not read back booking {BookingId} for its video link: {Body}",
                    booking.Id, ex.ResponseBody);
                return booking;
            }
        }

        _logger.LogWarning("Booking {BookingId} is confirmed but Cal.id has not published a video link yet.", booking.Id);
        return booking;
    }

    private async Task<JsonNode?> GetJsonAsync(string relativeUrl, CancellationToken cancellationToken)
    {
        using var response = await _httpClient.GetAsync(relativeUrl, cancellationToken);
        var body = await response.Content.ReadAsStringAsync(cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Cal.id request to {Url} failed ({StatusCode}): {Body}", relativeUrl, response.StatusCode, body);
            throw new CalIdApiException("Cal.id request failed.", body);
        }

        return ParseNode(body);
    }

    private static BookingDto MapBooking(JsonObject? booking)
    {
        if (booking is null)
        {
            return new BookingDto();
        }

        var metadata = booking["metadata"] as JsonObject;
        var attendee = (booking["attendees"] as JsonArray)?.OfType<JsonObject>().FirstOrDefault();

        return new BookingDto
        {
            Id = GetInt(booking, "id") ?? 0,
            Uid = GetString(booking, "uid"),
            Status = GetString(booking, "status"),
            Title = GetString(booking, "title"),
            StartTime = GetString(booking, "startTime"),
            EndTime = GetString(booking, "endTime"),
            Description = GetString(booking, "description"),
            VideoCallUrl = GetString(metadata, "videoCallUrl"),
            VideoProvider = GetString(metadata, "videoProvider"),
            Attendee = attendee is null ? null : new BookingAttendeeDto
            {
                Name = GetString(attendee, "name"),
                Email = GetString(attendee, "email")
            }
        };
    }

    /// <summary>
    /// Normalises a date-only value (YYYY-MM-DD) or a full ISO-8601 instant to UTC.
    /// </summary>
    private static DateTimeOffset ToInstant(string value, string fieldName, bool endOfDay)
    {
        if (TryParseInstant(value, out var instant))
        {
            return instant;
        }

        if (DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out var dateOnly))
        {
            var time = endOfDay ? new TimeSpan(23, 59, 59) : TimeSpan.Zero;
            return new DateTimeOffset(dateOnly.Date + time, TimeSpan.Zero);
        }

        throw new CalIdValidationException(
            $"{fieldName} must be YYYY-MM-DD or an ISO-8601 instant, e.g. 2026-09-25 or 2026-09-25T03:30:00.000Z.");
    }

    private static bool TryParseInstant(string? value, out DateTimeOffset instant)
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

    private static string FormatInstant(DateTimeOffset value) =>
        value.UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);

    private static string? GetString(JsonObject? obj, string property) =>
        obj?[property]?.GetValue<string>();

    /// <summary>
    /// Parses a Cal.id response body. Non-JSON bodies (HTML error pages, plain text)
    /// are wrapped as a JSON string so the raw upstream message still reaches the client.
    /// </summary>
    private static JsonNode? ParseNode(string body)
    {
        if (string.IsNullOrWhiteSpace(body))
        {
            return null;
        }

        try
        {
            return JsonNode.Parse(body);
        }
        catch (JsonException)
        {
            return JsonValue.Create(body);
        }
    }

    private static int? GetInt(JsonObject? obj, string property)
    {
        var node = obj?[property];
        if (node is null)
        {
            return null;
        }

        return node.GetValueKind() switch
        {
            JsonValueKind.Number => node.GetValue<int>(),
            JsonValueKind.String when int.TryParse(node.GetValue<string>(), out var parsed) => parsed,
            _ => null
        };
    }
}
