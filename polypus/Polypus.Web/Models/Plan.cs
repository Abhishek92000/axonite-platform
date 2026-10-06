namespace Polypus.Web.Models;

/// <summary>
/// How a plan price is displayed. Used by <see cref="Components.Shared.PlanCard"/> and the
/// billing toggle on the /plans page.
/// </summary>
public enum BillingCycle
{
    Monthly,
    Annual
}

/// <summary>
/// A commercial plan (Starter / Growth / Business / Enterprise).
/// All values are plain strings so marketing copy can be edited without touching the UI.
/// </summary>
public sealed record Plan
{
    /// <summary>URL friendly key. Used as /contact?plan={Id}.</summary>
    public required string Id { get; init; }

    public required string Name { get; init; }

    /// <summary>One line describing who the plan is for.</summary>
    public required string Tagline { get; init; }

    /// <summary>Headline price when billed monthly, e.g. "$499". Empty for "Custom" plans.</summary>
    public string? MonthlyPrice { get; init; }

    /// <summary>Headline price when billed annually, e.g. "$409".</summary>
    public string? AnnualPrice { get; init; }

    /// <summary>Shown under the price, e.g. "per month, billed annually".</summary>
    public required string PriceNote { get; init; }

    /// <summary>Displayed price for plans that are not self-serve (Enterprise).</summary>
    public string? CustomPriceLabel { get; init; }

    public required string DocumentsPerMonth { get; init; }

    public required string BestFor { get; init; }

    /// <summary>Renders the card with the accent treatment. Only one plan should set this.</summary>
    public bool IsPopular { get; init; }

    public string? Badge { get; init; }

    public required IReadOnlyList<string> Includes { get; init; }

    public required string CtaLabel { get; init; }

    /// <summary>Small print under the button, e.g. "No credit card. 30-day sandbox."</summary>
    public required string CtaNote { get; init; }

    public int SortOrder { get; init; }
}
