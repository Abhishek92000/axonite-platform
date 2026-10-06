using System.Text.Json.Nodes;

namespace Calid.Api.Models;

/// <summary>
/// Outcome of a booking attempt. The service always returns one of these instead
/// of throwing for upstream failures, so the controller only has to map it to a status code.
/// </summary>
public class MeetingScheduleResponse
{
    public bool Success { get; init; }

    public string? Message { get; init; }

    public BookingDto? Booking { get; init; }

    /// <summary>Raw Cal.id error body when the upstream call failed.</summary>
    public JsonNode? Details { get; init; }

    public static MeetingScheduleResponse Ok(BookingDto booking) => new()
    {
        Success = true,
        Message = "Meeting booked successfully.",
        Booking = booking
    };

    public static MeetingScheduleResponse Fail(string message, JsonNode? details = null) => new()
    {
        Success = false,
        Message = message,
        Details = details
    };
}
