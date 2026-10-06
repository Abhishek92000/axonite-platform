using Polypus.Web.Models;

namespace Polypus.Web.Services;

/// <summary>
/// The single source of truth for pricing. Every place the site shows a plan
/// (/plans, /contact dropdown, comparison table) reads from here.
/// </summary>
/// <remarks>
/// To change pricing, edit the list below only. To add a tier, add a <see cref="Plan"/>
/// entry - the UI iterates the collection, so no markup changes are needed.
/// </remarks>
public static class PlanCatalog
{
    /// <summary>Plan ids offered in the contact form when no plan was preselected.</summary>
    public static readonly string[] Volumes =
    [
        "Under 1,000",
        "1,000 - 5,000",
        "5,000 - 20,000",
        "20,000 - 100,000",
        "Over 100,000"
    ];

    public static readonly string[] SapLandscapes =
    [
        "SAP S/4HANA (on-premise)",
        "SAP S/4HANA Cloud (private)",
        "SAP S/4HANA Cloud (public)",
        "SAP ECC 6.0 / EHP",
        "SAP Business One",
        "Not decided yet"
    ];

    public static readonly IReadOnlyList<Plan> All =
    [
        new Plan
        {
            Id = "basic",
            Name = "Basic",
            Tagline = "For one team automating a single document type.",
            MonthlyPrice = "$499",
            AnnualPrice = "$409",
            PriceNote = "per month, per tenant",
            DocumentsPerMonth = "2,000 documents / month",
            BestFor = "One legal entity, one document type, one SAP company code",
            Includes =
            [
                "Up to 2,000 documents per month",
                "Invoice and credit-note extraction",
                "One SAP connector (IDoc or BAPI)",
                "Standard review queue for exceptions",
                "Email support, next business day",
                "99.5% platform uptime target"
            ],
            CtaLabel = "Choose Basic",
            CtaNote = "30-day sandbox with your own documents",
            SortOrder = 1
        },
        new Plan
        {
            Id = "growth",
            Name = "Growth",
            Tagline = "For shared service centres running at volume.",
            MonthlyPrice = "$1,450",
            AnnualPrice = "$1,190",
            PriceNote = "per month, per tenant",
            DocumentsPerMonth = "10,000 documents / month",
            BestFor = "Multi-entity finance teams with review workflows",
            IsPopular = true,
            Badge = "Most chosen",
            Includes =
            [
                "Up to 10,000 documents per month",
                "All document types: invoices, POs, delivery notes, credit notes",
                "IDoc, BAPI and OData connectors",
                "Duplicate, tax and PO tolerance checks",
                "Configurable approval routing",
                "Named support engineer, 4-hour response"
            ],
            CtaLabel = "Choose Growth",
            CtaNote = "Includes a guided pilot and tuning sprint",
            SortOrder = 2
        },
        new Plan
        {
            Id = "business",
            Name = "Business",
            Tagline = "For groups that need control, scale and reporting.",
            MonthlyPrice = "$3,200",
            AnnualPrice = "$2,650",
            PriceNote = "per month, per tenant",
            DocumentsPerMonth = "40,000 documents / month",
            BestFor = "Multi-country operations with audit and SLA obligations",
            Includes =
            [
                "Up to 40,000 documents per month",
                "Multi-entity and multi-currency posting",
                "Custom validation and tolerance rules",
                "Role-based access with SSO (SAML / OIDC)",
                "Operational dashboards and saved exports",
                "99.9% uptime SLA and quarterly business reviews"
            ],
            CtaLabel = "Choose Business",
            CtaNote = "Security review pack available on request",
            SortOrder = 3
        },
        new Plan
        {
            Id = "enterprise",
            Name = "Enterprise",
            Tagline = "For programmes with volume, residency or compliance demands.",
            CustomPriceLabel = "Custom",
            PriceNote = "priced on volume, entities and deployment model",
            DocumentsPerMonth = "Unlimited, committed volume",
            BestFor = "Regulated groups, private cloud or on-premise deployments",
            Includes =
            [
                "Unlimited committed document volume",
                "Single-tenant or on-premise deployment",
                "Custom SLAs and disaster-recovery design",
                "SAP VIM and Ariba co-existence",
                "Dedicated delivery manager and roadmap input",
                "Region-specific data residency"
            ],
            CtaLabel = "Design my programme",
            CtaNote = "Response within one business day",
            SortOrder = 4
        }
    ];

    /// <summary>
    /// Extra names users or old links might use. Keeps /contact?plan=starter working
    /// even though the plan is now called Basic.
    /// </summary>
    private static readonly Dictionary<string, string> Aliases = new(StringComparer.OrdinalIgnoreCase)
    {
        ["starter"] = "basic",
        ["basic-plan"] = "basic",
        ["pro"] = "growth",
        ["professional"] = "growth",
        ["scale"] = "business",
        ["enterprise-plan"] = "enterprise",
        ["custom"] = "enterprise"
    };

    /// <summary>Plans that can be picked in a dropdown (all of them).</summary>
    public static IReadOnlyList<Plan> Selectable => All;

    /// <summary>
    /// Resolves a plan id coming from a query string. Returns null when the value is
    /// empty or unknown so the contact form can simply leave the dropdown unselected.
    /// </summary>
    public static Plan? Find(string? planId)
    {
        if (string.IsNullOrWhiteSpace(planId))
        {
            return null;
        }

        var key = planId.Trim();
        if (Aliases.TryGetValue(key, out var canonical))
        {
            key = canonical;
        }

        return All.FirstOrDefault(p => string.Equals(p.Id, key, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>True when the id maps to a real plan. Used to validate form posts.</summary>
    public static bool IsKnown(string? planId) => Find(planId) is not null;

    /// <summary>Display label used in the contact form dropdown and confirmation panel.</summary>
    public static string Describe(Plan plan) =>
        plan.CustomPriceLabel is null
            ? $"{plan.Name} - {plan.MonthlyPrice} {plan.PriceNote}"
            : $"{plan.Name} - {plan.CustomPriceLabel} ({plan.PriceNote})";
}
