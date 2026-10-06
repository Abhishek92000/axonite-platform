namespace Polypus.Web.Models;

/// <summary>
/// A customer quote. Sample content only - see the README before publishing.
/// </summary>
public sealed record Testimonial
{
    public required string Quote { get; init; }

    public required string Author { get; init; }

    public required string Role { get; init; }

    public required string Company { get; init; }

    /// <summary>Industry tag shown as a pill on the card.</summary>
    public required string Sector { get; init; }

    /// <summary>The headline number highlighted on the card, e.g. "18,000".</summary>
    public required string Metric { get; init; }

    public required string MetricLabel { get; init; }

    /// <summary>Exactly one testimonial should be featured - it gets the larger dark card.</summary>
    public bool IsFeatured { get; init; }

    /// <summary>Initials used for the avatar circle.</summary>
    public string Initials
    {
        get
        {
            var parts = Author.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return parts.Length switch
            {
                0 => "?",
                1 => parts[0][..1].ToUpperInvariant(),
                _ => string.Concat(parts[0][..1], parts[^1][..1]).ToUpperInvariant()
            };
        }
    }
}
