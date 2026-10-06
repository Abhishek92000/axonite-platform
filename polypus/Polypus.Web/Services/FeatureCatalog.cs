using Polypus.Web.Models;

namespace Polypus.Web.Services;

/// <summary>
/// The product capability list. Used by the home page grid (first six), the
/// /features page (all, with detail bullets) and the product overview page.
/// </summary>
public static class FeatureCatalog
{
    // Previous catalog kept for reference:
    // public static readonly IReadOnlyList<Feature> All =
    // [
    //     new Feature
    //     {
    //         Id = "extraction",
    //         Icon = "scan",
    //         Title = "Layout-aware extraction",
    //         Summary = "Reads invoices, purchase orders, delivery notes and contracts - including " +
    //                   "scans, photographs and 40-year-old PDFs - without a template per supplier.",
    //         Details =
    //         [
    //             "Vision and text models combine so skewed scans and stamp overlays still resolve",
    //             "Header, line-item and tax breakdown captured at field level with confidence scores",
    //             "New supplier layouts handled on first sight - no template build required",
    //             "Handles multi-page, multi-invoice and continuation-sheet documents"
    //         ]
    //     },
    //     new Feature
    //     {
    //         Id = "sap-posting",
    //         Icon = "plug",
    //         Title = "Governed SAP posting",
    //         Summary = "Posts through the interfaces your BASIS team already supports: IDoc, BAPI/RFC " +
    //                   "and OData. No modifications, no kernel patches, no custom Z-tables in core.",
    //         Details =
    //         [
    //             "IDoc INVOIC02, ORDERS05 and DESADV out of the box",
    //             "BAPI_INCOMINGINVOICE_CREATE with parked-document option",
    //             "OData services for S/4HANA, with automatic retry and idempotency keys",
    //             "Master data lookups for supplier, PO, tax code and cost centre"
    //         ]
    //     },
    //     new Feature
    //     {
    //         Id = "review",
    //         Icon = "user-check",
    //         Title = "Exception handling people actually use",
    //         Summary = "Only low-confidence or rule-breaking documents reach a human. Reviewers see the " +
    //                   "original page next to the extracted fields and fix in seconds, not minutes.",
    //         Details =
    //         [
    //             "Side-by-side document viewer with bounding-box highlighting",
    //             "Corrections feed back into tuning without a release cycle",
    //             "Queue assignment by entity, supplier or value threshold",
    //             "Keyboard-first review mode for high-volume processors"
    //         ]
    //     },
    //     new Feature
    //     {
    //         Id = "validation",
    //         Icon = "shield-check",
    //         Title = "Validation and duplicate control",
    //         Summary = "Every document passes a configurable rule set before it can post: three-way " +
    //                   "match, tax checks, tolerance limits and duplicate detection.",
    //         Details =
    //         [
    //             "Two-way and three-way matching against PO and goods receipt",
    //             "Duplicate detection across invoice number, amount, date and supplier",
    //             "Tolerance and variance rules with entity-level overrides",
    //             "Blocked and parked document routing with reason codes"
    //         ]
    //     },
    //     new Feature
    //     {
    //         Id = "audit",
    //         Icon = "history",
    //         Title = "Auditable by design",
    //         Summary = "Each posting carries its source document, model version, rule set, reviewer and " +
    //                   "SAP response. Auditors get evidence, not screenshots.",
    //         Details =
    //         [
    //             "Immutable decision log per document and per field",
    //             "Replay any historical run against a new model or rule set",
    //             "SOC 2 Type II and ISO 27001 aligned controls",
    //             "Data retention and residency configuration per tenant"
    //         ]
    //     },
    //     new Feature
    //     {
    //         Id = "analytics",
    //         Icon = "chart",
    //         Title = "Straight-through processing analytics",
    //         Summary = "See where automation holds and where it does not: by supplier, entity, document " +
    //                   "type or reviewer, with the numbers finance reports upwards.",
    //         Details =
    //         [
    //             "STP rate, touch time and cost-per-invoice dashboards",
    //             "Supplier scorecards on document quality and exception reasons",
    //             "Volume and effort forecasts for capacity planning",
    //             "Scheduled exports to Power BI, Snowflake or CSV"
    //         ]
    //     },
    //     new Feature
    //     {
    //         Id = "workflow",
    //         Icon = "flow",
    //         Title = "Configurable workflows",
    //         Summary = "Route documents by value, supplier, entity or risk score. No code changes when " +
    //                   "your approval matrix changes.",
    //         Details =
    //         [
    //             "Visual routing designer with version history",
    //             "Delegation, escalation and out-of-office handling",
    //             "SLA timers with reminders to Slack, Teams or email",
    //             "Bulk actions for month-end peaks"
    //         ]
    //     },
    //     new Feature
    //     {
    //         Id = "security",
    //         Icon = "lock",
    //         Title = "Enterprise security posture",
    //         Summary = "SSO, role-based access, field-level encryption and complete tenant isolation, " +
    //                   "with the evidence pack your security team will ask for.",
    //         Details =
    //         [
    //             "SAML 2.0 and OIDC single sign-on with SCIM provisioning",
    //             "Row-level tenant isolation in a shared or single-tenant deployment",
    //             "Encryption in transit and at rest; customer-managed keys on Enterprise",
    //             "Penetration test summaries and DPA available under NDA"
    //         ]
    //     }
    // ];

    public static readonly IReadOnlyList<Feature> All =
    [
        new Feature
        {
            Id = "intelligent-document-extraction",
            Icon = "scan",
            Title = "Intelligent Document Extraction",
            Summary = "Extract key information from invoices and other business documents using AI. Capture header fields and line items with source evidence for easy verification.",
            Details =
            [
                "Read invoices, purchase orders, delivery notes and other business documents with AI-powered extraction",
                "Capture header fields and line items with supporting source evidence for verification",
                "Handle unstructured and semi-structured documents without a template per supplier",
                "Preserve context for downstream validation, routing and audit review"
            ]
        },
        new Feature
        {
            Id = "automated-document-classification-routing",
            Icon = "route",
            Title = "Automated Document Classification & Routing",
            Summary = "Automatically identify document types and route transactions to the appropriate processing workflow, reviewer or approval stage.",
            Details =
            [
                "Classify incoming documents by type, source and business context",
                "Trigger the right workflow, reviewer queue or approval stage automatically",
                "Support routing by document characteristics, value thresholds and business rules",
                "Improve throughput by eliminating manual triage and rework"
            ]
        },
        new Feature
        {
            Id = "intelligent-validation-error-detection",
            Icon = "shield-check",
            Title = "Intelligent Validation & Error Detection",
            Summary = "Validate mandatory fields, invoice totals, tax codes and business rules. Identify discrepancies early and route exceptions for review.",
            Details =
            [
                "Check mandatory fields, totals, tax codes and financial consistency before posting",
                "Flag discrepancies early to reduce downstream rework and SAP failures",
                "Apply configurable business rules to each document and workflow stage",
                "Route exceptions to the correct reviewer or approval queue"
            ]
        },
        new Feature
        {
            Id = "duplicate-detection-prevention",
            Icon = "copy",
            Title = "Duplicate Detection & Prevention",
            Summary = "Detect duplicate documents and transactions using document hashes and business identifiers, helping prevent duplicate SAP postings.",
            Details =
            [
                "Use document hashes and business identifiers to identify duplicate submissions",
                "Prevent repeated SAP postings created by duplicate or re-submitted documents",
                "Compare key attributes such as supplier, amount, invoice number and date",
                "Escalate suspected duplicates for review before transaction creation"
            ]
        },
        new Feature
        {
            Id = "sap-master-data-mapping",
            Icon = "database",
            Title = "SAP Master Data Mapping",
            Summary = "Match extracted document values with SAP master data, resolve business identifiers and validate records before posting.",
            Details =
            [
                "Match extracted values against SAP master data such as suppliers, cost centres and tax codes",
                "Resolve business identifiers and validate record integrity before posting",
                "Reduce posting errors caused by inconsistent or incomplete information",
                "Support cleaner downstream approval and posting decisions"
            ]
        },
        new Feature
        {
            Id = "controlled-sap-automation",
            Icon = "plug",
            Title = "Controlled SAP Automation",
            Summary = "Automate SAP posting through configurable approval gates, controlled posting modes, retry policies and safeguards against duplicate transactions.",
            Details =
            [
                "Post to SAP through controlled and configurable approval gates",
                "Use controlled posting modes with retry policies and retry-safe transaction handling",
                "Prevent duplicate transactions with built-in safeguards and idempotency controls",
                "Keep automated posting aligned with finance and operational controls"
            ]
        },
        new Feature
        {
            Id = "human-review-exception-management",
            Icon = "user-check",
            Title = "Human Review & Exception Management",
            Summary = "Give reviewers a unified workspace to verify extracted data, correct errors, approve transactions and resolve SAP posting exceptions.",
            Details =
            [
                "Provide a unified workspace for reviewing extracted data and corrections",
                "Let teams approve transactions and resolve SAP posting exceptions in context",
                "Capture reviewer decisions and comments for accountability and traceability",
                "Reduce the gap between automation and operational control"
            ]
        },
        new Feature
        {
            Id = "ai-powered-sap-error-resolution",
            Icon = "sparkles",
            Title = "AI-Powered SAP Error Resolution",
            Summary = "Classify SAP errors, generate evidence-based correction proposals and support an approval-and-retry workflow while preserving previous attempts.",
            Details =
            [
                "Classify SAP errors and identify likely failure patterns quickly",
                "Generate evidence-based correction proposals grounded in document and workflow context",
                "Support approval-and-retry workflows without losing the prior attempt history",
                "Improve recovery speed while preserving operational traceability"
            ]
        },
        new Feature
        {
            Id = "audit-trail-compliance",
            Icon = "history",
            Title = "Audit Trail & Compliance",
            Summary = "Maintain a traceable history of document processing, data changes, approvals and SAP responses, with timestamps, actors and reasons.",
            Details =
            [
                "Track document processing history, approvals, data changes and SAP responses",
                "Capture timestamps, actors and reasons for all material decisions",
                "Strengthen governance, compliance and operational accountability",
                "Build a reliable evidence trail for audits and investigations"
            ]
        },
        new Feature
        {
            Id = "unified-document-workflow",
            Icon = "flow",
            Title = "Unified Document Workflow",
            Summary = "Process documents, web forms and API submissions through one configurable workflow with a shared transaction ID, consistent statuses and a common audit trail.",
            Details =
            [
                "Support documents, web forms and API submissions in one end-to-end workflow",
                "Use a shared transaction ID for consistent status tracking and traceability",
                "Maintain a common audit trail across all submission channels",
                "Enable consistent operational monitoring and governance"
            ]
        }
    ];

    /// <summary>The subset rendered in the compact grid on the home page.</summary>
    public static IReadOnlyList<Feature> HomeHighlights => All.Take(6).ToList();

    /// <summary>Icon keys in display order, used by the icon legend on /features.</summary>
    public static IReadOnlyList<string> IconKeys => All.Select(f => f.Icon).Distinct().ToList();
}
