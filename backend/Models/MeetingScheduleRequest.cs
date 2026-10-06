using System.ComponentModel.DataAnnotations;

namespace Calid.Api.Models;

/// <summary>
/// Body of POST /api/meeting/book.
/// </summary>
public class MeetingScheduleRequest
{
    /// <summary>Start of the chosen slot, as an ISO-8601 instant (e.g. 2026-09-25T03:30:00.000Z).</summary>
    [Required(ErrorMessage = "startTime is required.")]
    public string StartTime { get; set; } = string.Empty;

    /// <summary>Start of the meeting in ISO-8601. Derived from <see cref="DurationMinutes"/> when omitted.</summary>
    public string? EndTime { get; set; }

    /// <summary>Meeting length in minutes. Defaults to the event type's length when omitted.</summary>
    [Range(1, 24 * 60, ErrorMessage = "duration must be between 1 and 1440 minutes.")]
    public int? Duration { get; set; }

    /// <summary>Cal.id event type to book. Defaults to the configured event type when omitted.</summary>
    [Range(1, int.MaxValue, ErrorMessage = "eventTypeId must be a positive number.")]
    public int? EventTypeId { get; set; }

    [Required(ErrorMessage = "name is required.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "email is required.")]
    [EmailAddress(ErrorMessage = "email must be a valid email address.")]
    public string Email { get; set; } = string.Empty;

    public string? Notes { get; set; }
}
