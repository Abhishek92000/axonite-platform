namespace Polypus.Web.Models;

/// <summary>
/// Static facts about the Polypus product itself: positioning copy, headline metrics and
/// the list of integrations referenced across the site.
/// </summary>
public static class ProductProfile
{
    public const string Name = "Polypus";

    public const string Owner = CompanyProfile.Name;

    public const string Positioning = "Intelligent document processing and controlled SAP automation";

    public const string MetaDescription =
        "Polypus reads invoices, purchase orders, delivery notes and contracts, then posts them into " +
        "SAP through governed, audit-ready automations. A product by Axonite.";

    public const string HeroEyebrow = "Polypus \u00b7 Intelligent Document Processing for SAP, Odoo & IFS";
    // public const string HeroEyebrow = "Polypus \u00b7 Intelligent Document Processing for ERP";

    public const string HeroHeadline = "Automate the Journey from Document to ERP.";

    public const string HeroLead =
        "Polypus intelligently processes supplier documents, extracts and validates data, identifies exceptions requiring human attention, and routes approved information into your ERP systems through controlled automation." +
        "Built for visibility, accuracy, and auditability, Polypus integrates with SAP, Odoo, and IFS without disrupting your existing ERP workflows. Start with one document type, validate the results, and scale with confidence.";


    public static readonly IReadOnlyList<Stat> Metrics =
    [
        new("500k", "documents processed in the last 12 months", "across 60+ enterprise tenants"),
        new("90+ %", "field-level accuracy on standard invoices", "measured after human review"),
        new("85+ %", "of invoices posted without a human touch", "customer median after 90 days"),
        new("4.1x", "Efficiency in end-to-end process handling", "compared to manual invoice review")
    ];

    /// <summary>Document types listed in the hero strip, in the order procurement teams meet them.</summary>
    public static readonly IReadOnlyList<string> HeroDocumentTypes =
    [
        "Purchase Requisition",
        "Billing",
        "Purchase Order",
        "Goods Receipt",
        "Service Entry Sheet",
        "PO-Based Invoice",
        "Non-PO Invoice"
    ];

    /// <summary>Document types listed in the "what Polypus reads" strip.</summary>
    public static readonly IReadOnlyList<string> DocumentTypes =
    [
        "Purchase Requisition",
        "Billing",
        "Purchase Order",
        "Goods Receipt",
        "Service Entry Sheet",
        "PO-Based Invoice",
        "Non-PO Invoice"
    ];

    /// <summary>SAP surfaces and interfaces Polypus talks to.</summary>
    public static readonly IReadOnlyList<CapabilityChip> IntegrationSurfaces =
    [
        new("IDoc", "INVOIC02, ORDERS05, DESADV"),
        new("BAPI / RFC", "BAPI_INCOMINGINVOICE_CREATE and custom wrappers"),
        new("IFS", "Connect Polypus with IFS for controlled document and transaction automation."),
        new("SAP VIM", "Co-exists with your existing invoice workflow"),
        new("Ariba & Fieldglass", "Inbound document queues"),
        new("Odoo", "Connect Polypus with Odoo for validated document and transaction processing.")
    ];

    /// <summary>Sectors used in the "trusted by" strip. Text only - no third-party logos are shipped.</summary>
    public static readonly IReadOnlyList<string> Customers =
    [
        "Meridian Industrial",
        "Trident Chemicals",
        "Northwind Logistics",
        "Vertex Components",
        "Halcyon Foods",
        "Baltic Freight Group"
    ];
}
