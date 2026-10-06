namespace Calid.Api.Models;

/// <summary>
/// A confirmed Cal.id booking, flattened to the fields the booking UI consumes.
/// Cal.id nests the video link under "metadata", so it is lifted to the top level here.
/// </summary>
public class BookingDto
{
    public int Id { get; init; }

    public string? Uid { get; init; }

    public string? Status { get; init; }

    public string? Title { get; init; }

    public string? StartTime { get; init; }

    public string? EndTime { get; init; }

    public string? Description { get; init; }

    public string? VideoCallUrl { get; init; }

    public string? VideoProvider { get; init; }

    /// <summary>Attendee the booking was created for, when Cal.id echoes it back.</summary>
    public BookingAttendeeDto? Attendee { get; init; }
}

public class BookingAttendeeDto
{
    public string? Name { get; init; }

    public string? Email { get; init; }
}
