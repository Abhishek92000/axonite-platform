namespace Polypus.Web.Models;

/// <summary>A single headline number, e.g. "5L documents processed last year".</summary>
public sealed record Stat(string Value, string Label, string? Footnote = null);

/// <summary>One step of the "how it works" timeline.</summary>
public sealed record ProcessStep(string Number, string Title, string Summary, string Duration);

/// <summary>A label/value pair used in comparison tables.</summary>
public sealed record ComparisonRow(string Label, IReadOnlyList<string> Values);

/// <summary>A group of comparison rows, e.g. "Extraction" or "SAP integration".</summary>
public sealed record ComparisonGroup(string Title, IReadOnlyList<ComparisonRow> Rows);

/// <summary>A link inside the footer or a navigation dropdown.</summary>
public sealed record NavLink(string Label, string Href, string? Description = null);

/// <summary>A titled column of links in the footer.</summary>
public sealed record FooterColumn(string Title, IReadOnlyList<NavLink> Links);

/// <summary>
/// One entry inside a header dropdown, e.g. "Workforce Overview" or "Integrations".
/// <see cref="Children"/> holds the optional indented sub-links shown beneath it.
/// </summary>
public sealed record NavMenuItem
{
    public required string Label { get; init; }

    public required string Href { get; init; }

    /// <summary>Icon key resolved by Components/Shared/AppIcon.razor.</summary>
    public required string Icon { get; init; }

    public string? Description { get; init; }

    public IReadOnlyList<NavLink> Children { get; init; } = [];
}

/// <summary>A top-level header navigation entry and the dropdown panel it opens.</summary>
public sealed record NavMenu
{
    public required string Label { get; init; }

    /// <summary>Destination when the trigger itself is activated, e.g. from the mobile accordion.</summary>
    public required string Href { get; init; }

    public required IReadOnlyList<NavMenuItem> Items { get; init; }

    /// <summary>Renders the wider two-column panel used by Resources.</summary>
    public bool Wide { get; init; }

    /// <summary>Optional promotional card shown beside the link list in a wide panel.</summary>
    public NavLink? Highlight { get; init; }
}

/// <summary>
/// One block of a reference content page: an optional heading plus a list of titled items.
/// </summary>
public sealed record ContentSection(
    string? Eyebrow,
    string? Title,
    string? Description,
    IReadOnlyList<ContentItem> Items,
    string? Id = null);

/// <summary>A single titled card within a <see cref="ContentSection"/>.</summary>
public sealed record ContentItem(string Title, string Body, string? Icon = null);

/// <summary>
/// The content of a page reached from the header (Workforce, Platform, Resources, ...).
/// Rendered by Components/Shared/ContentPage.razor so every page shares one layout.
/// </summary>
public sealed record ContentPageModel
{
    public required string Section { get; init; }

    public required string Eyebrow { get; init; }

    public required string Title { get; init; }

    public required string Lead { get; init; }

    public required string MetaDescription { get; init; }

    public IReadOnlyList<string> Pills { get; init; } = [];

    public IReadOnlyList<ContentSection> Sections { get; init; } = [];

    public IReadOnlyList<Faq> Faqs { get; init; } = [];
}

/// <summary>A titled card inside a <see cref="ConnectorPageModel"/> section.</summary>
public sealed record ConnectorCard(string Title, string Text);
/// <summary>
/// A section of a connector page: a centred heading, a lead paragraph and a grid of cards.
/// Rendered by Components/Shared/ConnectorPage.razor.
/// </summary>
public sealed record ConnectorSection(string Title, string? Lead, IReadOnlyList<ConnectorCard> Cards);

/// <summary>One labelled group of items inside an integration-diagram panel.</summary>
public sealed record DiagramGroup(string? Heading, IReadOnlyList<string> Items);

/// <summary>
/// The integration diagram shown under "How it works" on a connector page.
/// Mirrors the reference connector diagram exactly: an API box wired to the partner
/// logo, an outbound annotation list, two outlined pills (Context Data / Master Data)
/// joined by elbow wires into the agent band, then the extracted-data API box and the
/// bow-tie gateway leading to the inbound annotation list.
/// </summary>
public sealed record IntegrationDiagram
{
    /// <summary>Text inside the top API box, e.g. "API".</summary>
    public required string ApiLabel { get; init; }

    /// <summary>Flow annotation above the master-data pills, e.g. "Posting Data".</summary>
    public required string PostingLabel { get; init; }

    /// <summary>Flow annotation above the master-data pill, e.g. "Suppliers / Company codes /".</summary>
    public required string MasterSourceLabel { get; init; }

    /// <summary>Second line of the master source annotation, e.g. "Purchase orders".</summary>
    public required string MasterSourceSubLabel { get; init; }

    /// <summary>Left pill in the master-data row.</summary>
    public required string ContextPill { get; init; }

    /// <summary>Right pill in the master-data row.</summary>
    public required string MasterPill { get; init; }

    /// <summary>Heading of the agent band.</summary>
    public required string AgentsTitle { get; init; }

    /// <summary>The agent tiles shown in the band.</summary>
    public required IReadOnlyList<string> Agents { get; init; }

    /// <summary>Output line at the foot of the agent band.</summary>
    public required string Output { get; init; }

    /// <summary>Title of the extracted-data API box.</summary>
    public required string ExtractedTitle { get; init; }

    /// <summary>Annotation beside the extracted-data arrow.</summary>
    public required string ExtractedFlowLabel { get; init; }

    /// <summary>Second line of the extracted-data annotation, e.g. "Purchase orders".</summary>
    public required string ExtractedFlowSubLabel { get; init; }

    /// <summary>Title of the outbound annotation list on the right.</summary>
    public required string OutboundTitle { get; init; }

    public required IReadOnlyList<string> OutboundItems { get; init; }

    /// <summary>Title of the inbound annotation list on the right.</summary>
    public required string InboundTitle { get; init; }

    public required IReadOnlyList<string> InboundItems { get; init; }

    /// <summary>One-line caption under the diagram.</summary>
    public required string Caption { get; init; }
}

/// <summary>
/// The content of an ERP/AP connector page (SAP, Coupa, IFS, Odoo).
/// Every connector page shares one layout, so only the content differs.
/// </summary>
public sealed record ConnectorPageModel
{
    public required string Eyebrow { get; init; }

    public required string Title { get; init; }

    /// <summary>Partner name for the "Polypus × Partner" lockup, e.g. "SAP".</summary>
    public required string PartnerName { get; init; }

    public required string MetaDescription { get; init; }

    public required string HowItWorksLead { get; init; }

    /// <summary>The architecture diagram shown under the How it works heading.</summary>
    public required IntegrationDiagram Diagram { get; init; }

    public required string WhyTitle { get; init; }

    /// <summary>Optional lead for the "why choose" section; usually null.</summary>
    public string? WhyLead { get; init; }

    public required IReadOnlyList<ConnectorCard> HowItWorks { get; init; }

    public required IReadOnlyList<ConnectorCard> WhyChoose { get; init; }

    /// <summary>Label for the trust action, e.g. "Trust Center" or "Trust Report".</summary>
    public required string TrustLabel { get; init; }

    /// <summary>Certification labels drawn in the security illustration.</summary>
    public required IReadOnlyList<string> Certifications { get; init; }

    public required string CtaTitle { get; init; }

    public required string CtaCopy { get; init; }
}

/// <summary>An office address shown in the company section.</summary>
public sealed record Office(string City, string Country, string Address, string Role);

/// <summary>A product capability strip item, e.g. "IDoc, BAPI, RFC, OData".</summary>
public sealed record CapabilityChip(string Label, string Detail);

/// <summary>
/// One numbered part of a long-form legal document (Privacy Policy, Terms of Service, ...).
/// Rendered by Components/Shared/LegalDocument.razor.
/// </summary>
public sealed record LegalSection(string Id, string Heading, IReadOnlyList<string> Paragraphs)
{
    /// <summary>Bullet points shown under the paragraphs, if any.</summary>
    public IReadOnlyList<string> Bullets { get; init; } = [];

    /// <summary>Optional callout shown at the end of the section, e.g. a contact address.</summary>
    public string? Note { get; init; }
}

/// <summary>One article in the blog index.</summary>
public sealed record BlogPost
{
    public required string Title { get; init; }

    public required string Excerpt { get; init; }

    public required string Author { get; init; }

    public required string Date { get; init; }

    /// <summary>Human read time, e.g. "4 min. read". May be empty.</summary>
    public string ReadTime { get; init; } = string.Empty;

    /// <summary>Cover art URL. Empty when the post has no image.</summary>
    public string Image { get; init; } = string.Empty;

    /// <summary>Full tag names as shown on the card, e.g. "Global Business Services".</summary>
    public IReadOnlyList<string> Tags { get; init; } = [];

    /// <summary>Primary filter key, e.g. "gbs".</summary>
    public required string Category { get; init; }

    /// <summary>Every filter key this post belongs to; a post can carry more than one tag.</summary>
    public IReadOnlyList<string> CategoryKeys { get; init; } = [];

    /// <summary>Short tag labels shown as chips on the card, e.g. "GBS".</summary>
    public IReadOnlyList<string> CategoryLabels { get; init; } = [];
}

/// <summary>A blog filter chip: a key and its visible label.</summary>
public sealed record BlogCategory(string Key, string Label);

/// <summary>One question on the FAQ page, with optional paragraphs and bullets.</summary>
public sealed record FaqEntry
{
    public required string Question { get; init; }

    public IReadOnlyList<string> Paragraphs { get; init; } = [];

    public IReadOnlyList<string> Bullets { get; init; } = [];
}

/// <summary>
/// A sub-section of a FAQ group, e.g. the "SAP" questions inside
/// "Integrations &amp; Connectors". <see cref="SubTitle"/> is null when the group
/// has no sub-sections.
/// </summary>
public sealed record FaqSubGroup
{
    public string? SubTitle { get; init; }

    public IReadOnlyList<FaqEntry> Items { get; init; } = [];
}

/// <summary>A titled group of questions on the FAQ page; also drives the table of contents.</summary>
public sealed record FaqGroup
{
    public required string Title { get; init; }

    public IReadOnlyList<FaqSubGroup> Subs { get; init; } = [];
}
