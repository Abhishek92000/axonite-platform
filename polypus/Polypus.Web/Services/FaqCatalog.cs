using Polypus.Web.Models;

namespace Polypus.Web.Services;

/// <summary>
/// Support content for the help centre and the home page FAQ teaser.
/// <see cref="Faq.FeaturedOnHome"/> decides which items appear on the home page.
/// </summary>
public static class FaqCatalog
{
    public static readonly IReadOnlyList<Faq> All =
    [
        new Faq
        {
            Category = "Getting started",
            Question = "How long does a typical rollout take?",
            Answer = "Most teams are extracting in a sandbox inside a week, running in shadow mode " +
                     "beside their current process for two to three weeks, and posting their first " +
                     "live documents in week five. A multi-entity Enterprise programme with SAP VIM " +
                     "co-existence usually lands between ten and fourteen weeks.",
            FeaturedOnHome = true
        },
        new Faq
        {
            Category = "Getting started",
            Question = "Do we need to change our SAP system?",
            Answer = "No. Polypus posts through standard interfaces - IDoc, BAPI/RFC and OData - so " +
                     "there are no kernel changes and no modifications to core objects. Your BASIS " +
                     "team gets an inventory of the interfaces and authorisations used before the " +
                     "first live posting.",
            FeaturedOnHome = true
        },
        new Faq
        {
            Category = "Accuracy",
            Question = "How accurate is the extraction, really?",
            Answer = "On standard supplier invoices we average 99.2% field-level accuracy, measured " +
                     "after human review. More importantly, every field carries a confidence score, " +
                     "so anything below your threshold is routed to a reviewer instead of being " +
                     "posted silently. Accuracy is reported per supplier and per document type, not " +
                     "as a single marketing number.",
            FeaturedOnHome = true
        },
        new Faq
        {
            Category = "Accuracy",
            Question = "What happens when a supplier changes their invoice layout?",
            Answer = "Nothing you need to action. Extraction is layout-aware rather than " +
                     "template-based, so a new layout is handled on first sight. If a document " +
                     "arrives outside your configured tolerances it is routed to the review queue " +
                     "with the reason recorded.",
            FeaturedOnHome = true
        },
        new Faq
        {
            Category = "Billing",
            Question = "Can we change plans later?",
            Answer = "Yes. Plans can be upgraded at any time and the difference is pro-rated. " +
                     "Downgrades take effect at the end of the current term. Document volumes are " +
                     "counted per tenant per month and unused volume does not roll over.",
            FeaturedOnHome = true
        },
        new Faq
        {
            Category = "Billing",
            Question = "What counts as a document?",
            Answer = "One uploaded file processed by the pipeline counts as one document, regardless " +
                     "of page count, up to 200 pages. Re-processing the same file after a rule change " +
                     "is free for 30 days. Test and sandbox documents are never billed.",
            FeaturedOnHome = true
        },
        new Faq
        {
            Category = "Security",
            Question = "Where is our data stored?",
            Answer = "By default in your chosen region - EU (Frankfurt), India (Mumbai) or US " +
                     "(Virginia). Enterprise customers can select a single-tenant or on-premise " +
                     "deployment. Data residency is fixed for the life of the tenant and documented " +
                     "in the order form.",
            FeaturedOnHome = false
        },
        new Faq
        {
            Category = "Security",
            Question = "Do you use our documents to train shared models?",
            Answer = "No. Customer documents are never used to train models shared with other " +
                     "tenants. Tuning is applied inside your tenant, and on Enterprise deployments " +
                     "model artefacts stay within your environment.",
            FeaturedOnHome = false
        },
        new Faq
        {
            Category = "Operations",
            Question = "What support is included?",
            Answer = "Basic includes next-business-day email support. Growth adds a named support " +
                     "engineer with a four-hour response target. Business and Enterprise include " +
                     "24x7 severity-1 cover, a documented incident process and quarterly reviews.",
            FeaturedOnHome = false
        },
        new Faq
        {
            Category = "Operations",
            Question = "Can Polypus run alongside our existing invoice workflow?",
            Answer = "Yes. In co-existence mode Polypus handles extraction and validation while your " +
                     "existing SAP workflow keeps approval and posting. Many customers stay in this " +
                     "mode for a quarter before moving posting across.",
            FeaturedOnHome = false
        },
        new Faq
        {
            Category = "Integrations",
            Question = "Which systems can Polypus pull documents from?",
            Answer = "Shared mailboxes, SFTP drop folders, SAP Ariba and Fieldglass queues, an " +
                     "authenticated REST API and direct upload from the review console. Scanned " +
                     "post and multifunction devices can forward straight to a tenant inbox.",
            FeaturedOnHome = false
        },
        new Faq
        {
            Category = "Integrations",
            Question = "Is there an API for our own tooling?",
            Answer = "Yes. A REST API with OpenAPI documentation covers document submission, status, " +
                     "extracted fields, review decisions and posting results. Webhooks push events " +
                     "into your own systems.",
            FeaturedOnHome = false
        }
    ];

    /// <summary>Questions shown in the home page FAQ teaser.</summary>
    public static IReadOnlyList<Faq> HomeHighlights => All.Where(f => f.FeaturedOnHome).ToList();

    /// <summary>Category names in first-seen order, used to build help centre filter chips.</summary>
    public static IReadOnlyList<string> Categories =>
        All.Select(f => f.Category).Distinct().ToList();

    /// <summary>Filter helper used by the help centre search and category chips.</summary>
    public static IReadOnlyList<Faq> Search(string? term, string? category)
    {
        return All
            .Where(f => f.Matches(term))
            .Where(f => string.IsNullOrWhiteSpace(category)
                        || string.Equals(f.Category, category, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
