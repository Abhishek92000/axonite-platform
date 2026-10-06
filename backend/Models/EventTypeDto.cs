namespace Calid.Api.Models;

/// <summary>
/// The subset of a Cal.id event type the booking UI needs.
/// </summary>
public class EventTypeDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public int Length { get; set; }

    public string Description { get; set; } = string.Empty;

    public bool Hidden { get; set; }
}
