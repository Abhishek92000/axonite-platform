namespace Polypus.Web.Models;

/// <summary>
/// A product capability shown on the home page grid and on the Features page.
/// <see cref="Icon"/> maps to a key in <see cref="Components.Shared.AppIcon"/>.
/// </summary>
public sealed record Feature
{
    public required string Id { get; init; }

    public required string Icon { get; init; }

    public required string Title { get; init; }

    public required string Summary { get; init; }

    /// <summary>Short supporting bullets rendered inside the Features page card.</summary>
    public required IReadOnlyList<string> Details { get; init; }
}
