namespace Calid.Api.Models;

/// <summary>
/// A flattened availability slot: the date Cal.id grouped it under plus its start time.
/// </summary>
public class SlotDto
{
    public string Date { get; set; } = string.Empty;

    public string Time { get; set; } = string.Empty;
}
