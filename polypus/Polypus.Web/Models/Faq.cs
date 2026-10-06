namespace Polypus.Web.Models;

/// <summary>
/// A question/answer pair. Used by the help centre search and the home page FAQ teaser.
/// </summary>
public sealed record Faq
{
    public required string Category { get; init; }

    public required string Question { get; init; }

    public required string Answer { get; init; }

    /// <summary>True when the item is also worth showing on the home page.</summary>
    public bool FeaturedOnHome { get; init; }

    /// <summary>
    /// Helper used by the help centre search box so filtering stays in one place
    /// instead of being duplicated in the component.
    /// </summary>
    public bool Matches(string? term)
    {
        if (string.IsNullOrWhiteSpace(term))
        {
            return true;
        }

        return Question.Contains(term, StringComparison.OrdinalIgnoreCase)
            || Answer.Contains(term, StringComparison.OrdinalIgnoreCase)
            || Category.Contains(term, StringComparison.OrdinalIgnoreCase);
    }
}
