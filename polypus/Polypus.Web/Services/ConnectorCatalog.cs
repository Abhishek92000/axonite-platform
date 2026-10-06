using Polypus.Web.Models;

namespace Polypus.Web.Services;

/// <summary>
/// The content of the ERP/AP connector pages, rendered by
/// Components/Shared/ConnectorPage.razor.
///
/// Every connector page uses the same reference layout - a hero, a centred
/// "How it works" card grid, a "Why choose" card grid, a security band and a
/// closing CTA - so only the copy differs and lives here.
/// </summary>
public static class ConnectorCatalog
{
    public static readonly ConnectorPageModel Sap = new()
    {
        Eyebrow = "Get started with Polypus for SAP",
        Title = "SAP x Polypus",
        PartnerName = "SAP",
        MetaDescription = "The SAP-certified Polypus connector for autonomous accounts payable, " +
                          "master data management and document processing.",
        HowItWorksLead = "The Polypus SAP Connector is an SAP\u00ae-certified add-on that seamlessly " +
                         "integrates with your SAP system to deliver autonomous accounts payable " +
                         "processes, master data management, and advanced document processing.",
        Diagram = new IntegrationDiagram
        {
            ApiLabel = "API",
            PostingLabel = "Posting Data",
            MasterSourceLabel = "Suppliers / Company codes /",
            MasterSourceSubLabel = "Purchase orders",
            ContextPill = "Context Data",
            MasterPill = "Master Data",
            AgentsTitle = "Invoice Processing AI Agents",
            Agents =
            [
                "Document Extraction",
                "Approver Prediction",
                "GL Account Prediction",
                "Cost Center Prediction",
                "Supplier Prediction",
                "Company Code Prediction",
                "PO Matching"
            ],
            Output = "Extracted / Enriched document data",
            ExtractedTitle = "Extracted / Enriched document data",
            ExtractedFlowLabel = "Extracted / Enriched document data",
            ExtractedFlowSubLabel = "Purchase orders",
            OutboundTitle = "Outbound Integration:",
            OutboundItems = ["Master data integration", "Outbound document integration", "Purchase order integration", "Posting data integration"],
            InboundTitle = "Inbound Integration:",
            InboundItems = ["Inbound document integration"],
            Caption = "SAP master and posting data flow out to Polypus, the agents extract, predict and match, and the enriched documents flow back for posting or review."
        },
        WhyTitle = "Why Choose Polypus for SAP?",
        TrustLabel = "Trust Center",
        Certifications = ["ISO 27001", "SOC 2 Type II", "HIPAA", "GDPR", "CCPA", "STAR Level 1"],
        CtaTitle = "Boost SAP efficiency with Polypus",
        CtaCopy = "Be the first to know about releases and industry news and insights.",
        HowItWorks =
        [
            new("Master Data Integration", "Sync vendor and company code master data with Polypus for accurate invoice coding, supplier and customer data validation, and streamlined operations."),
            new("Document Workflow", "Fetch the AP documents processed by Polypus and ensure a direct hand-over to the Accounts Payable workflow to trigger an auto-posting, or handle via HITL."),
            new("Purchase Order Integration", "Automatically transfer PO data for enhanced line-item matching and reconciliation."),
            new("Posting Data Integration", "No need to worry about collecting posting and archive data and building a complex integration process to send it to us. Our SAP Connector takes care of all of this."),
            new("Constant Feedback Loop", "A feedback cycle of monitoring Polypus-processed documents until posting in SAP. After posting, changes made in the AP workflow are sent back to us to ensure knowledge update and improving accuracy over time.")
        ],
        WhyChoose =
        [
            new("Better Accuracy", "Automatically match data against vendor records, purchase orders, and previous invoices to reduce errors and avoid costly discrepancies."),
            new("Less Risk", "Fetch the AP documents processed by Polypus and ensure a direct hand-over to the Accounts Payable workflow to trigger an auto-posting, or handle via HITL."),
            new("Purchase Order Integration", "Automatically transfer PO data for enhanced line-item matching and reconciliation."),
            new("Posting Data Integration", "No need to worry about collecting posting and archive data and building a complex integration process to send it to us. Our SAP Connector takes care of all of this.")
        ]
    };

    public static readonly ConnectorPageModel Coupa = new()
    {
        Eyebrow = "Get started with Polypus for Coupa",
        Title = "Coupa x Polypus",
        PartnerName = "Coupa",
        MetaDescription = "The Coupa-certified Polypus connector for invoice processing, duplicate " +
                          "check, fraud detection and accounting coding.",
        HowItWorksLead = "Polypus AI agents for invoice processing are Coupa-certified and ready to " +
                         "enhance your accounts payable workflows.",
        Diagram = new IntegrationDiagram
        {
            ApiLabel = "API",
            PostingLabel = "Posting Data",
            MasterSourceLabel = "Suppliers / Company codes /",
            MasterSourceSubLabel = "Purchase orders",
            ContextPill = "Context Data",
            MasterPill = "Master Data",
            AgentsTitle = "Invoice Processing AI Agents",
            Agents =
            [
                "Document Extraction",
                "Approver Prediction",
                "GL Account Prediction",
                "Cost Center Prediction",
                "Supplier Prediction",
                "Company Code Prediction",
                "PO Matching"
            ],
            Output = "Extracted / Enriched document data",
            ExtractedTitle = "Extracted / Enriched document data",
            ExtractedFlowLabel = "Extracted / Enriched document data",
            ExtractedFlowSubLabel = "Purchase orders",
            OutboundTitle = "Outbound Integration:",
            OutboundItems = ["Master data integration", "Outbound document integration", "Purchase order integration", "Posting data integration"],
            InboundTitle = "Inbound Integration:",
            InboundItems = ["Inbound document integration"],
            Caption = "Coupa master and posting data flow out to Polypus, the agents extract, predict and match, and the enriched documents flow back into the Coupa AP workflow."
        },
        WhyTitle = "Why Choose Polypus for Coupa?",
        TrustLabel = "Trust Report",
        Certifications = ["ISO 27001", "SOC 2 Type II", "HIPAA", "GDPR", "CCPA", "STAR Level 1"],
        CtaTitle = "Agentic process automation for Coupa with Polypus",
        CtaCopy = "Achieve new levels of processing efficiency and accuracy.",
        HowItWorks =
        [
            new("Supplier Document Capture", "Automatically process and categorize invoices, credit notes, and payment reminders within Coupa. Extract key data, including line items and custom fields, in any language, and send it directly to the Coupa accounts payable workflow."),
            new("Duplicate Check", "Identify duplicate invoices, credit notes, and payment reminders based on file content. Configure flexible criteria for duplicate detection to match your specific needs and prevent errors before they occur."),
            new("Fraud Detection", "Detect and flag fraudulent invoices before they enter the Coupa workflow. Fraud detection includes supplier and payment detail validation, purchase order cross-checking, and content analysis to identify suspicious patterns."),
            new("Accounting Coding", "Predict and populate accounting dimensions such as General Ledger Accounts, Cost Centers, and Projects for non-PO invoices, reducing manual entry in Coupa. Automate coding decisions while keeping full control to review and adjust before final posting."),
            new("PO Matching & Reconciliation", "Perform advanced 2-way PO line matching, generating and pre-populating the necessary posting lines in Coupa to complete a 3-way matching when needed and finalize the posting."),
            new("Master Data Matching", "Automatically assign company codes, legal entities, and supplier master data, even when significant deviations exist in the document. Ensure data availability and accuracy within the Coupa workflow.")
        ],
        WhyChoose =
        [
            new("Faster Processing", "Eliminate manual tasks with AI-driven invoice processing, ensuring rapid approvals and smooth payments."),
            new("Improved Accuracy", "Leverage synchronized master and transactional data to enhance predictions, reducing errors in invoice coding and PO matching."),
            new("Smart Compliance \u200b& Fraud Prevention", "Automatically detect duplicate or fraudulent invoices before they reach Coupa, strengthening compliance and mitigating financial risks."),
            new("Seamless Automation", "Connect Polypus with Coupa for an effortless, two-way data exchange, reducing bottlenecks and increasing efficiency."),
            new("Enhanced Visibility", "Gain real-time insights into AP workflows, supplier performance, and financial data, ensuring better decision-making.")
        ]
    };

    public static readonly ConnectorPageModel Ifs = new()
    {
        Eyebrow = "Get started with Polypus for IFS",
        Title = "IFS x Polypus",
        PartnerName = "IFS",
        MetaDescription = "The certified two-way Polypus connector for IFS.",
        HowItWorksLead = "Seamlessly integrate Polypus AI agents into your IFS Cloud system. With " +
                         "certified, two-way integration, our IFS connector transforms your document " +
                         "and accounts payable workflows into a fully automated, intelligent process.",
        Diagram = new IntegrationDiagram
        {
            ApiLabel = "API",
            PostingLabel = "Posting Data",
            MasterSourceLabel = "Suppliers / Company codes /",
            MasterSourceSubLabel = "Purchase orders",
            ContextPill = "Context Data",
            MasterPill = "Master Data",
            AgentsTitle = "Invoice Processing AI Agents",
            Agents =
            [
                "Document Extraction",
                "Approver Prediction",
                "GL Account Prediction",
                "Cost Center Prediction",
                "Supplier Prediction",
                "Company Code Prediction",
                "PO Matching"
            ],
            Output = "Extracted / Enriched document data",
            ExtractedTitle = "Extracted / Enriched document data",
            ExtractedFlowLabel = "Extracted / Enriched document data",
            ExtractedFlowSubLabel = "Purchase orders",
            OutboundTitle = "Outbound Integration:",
            OutboundItems = ["Master data integration", "Outbound document integration", "Purchase order integration", "Posting data integration"],
            InboundTitle = "Inbound Integration:",
            InboundItems = ["Inbound document integration"],
            Caption = "IFS master and posting data flow out to Polypus, the agents extract, predict and match, and the enriched documents flow back for posting or review."
        },
        WhyTitle = "Why Choose Polypus for IFS?",
        TrustLabel = "Trust Report",
        Certifications = ["ISO 27001", "SOC 2 Type II", "HIPAA", "GDPR", "CCPA", "STAR Level 1"],
        CtaTitle = "Agentic process automation for IFS",
        CtaCopy = "Achieve new levels of transaction processing efficiency.",
        HowItWorks =
        [
            new("Invoice Processing & Export", "Documents processed by a Polypus AI agent are enriched, validated, and exported seamlessly to IFS, ensuring fast and accurate handling."),
            new("Master Data Enrichment Workflow", "Automatically sync supplier and organizational data from IFS to Polypus, enriching invoice coding and supplier predictions. Runs periodically to keep data accurate and up-to-date."),
            new("Posting Data Integration", "Transfer posting data from IFS to the Polypus Enrichment Service to support AI agent self-improvement. Enhance predictions for cost centres, spend categories, and other accounting attributes."),
            new("PO Matching & Reconciliation", "Automatically extract PO numbers and invoice lines, match them against PO data, and handle deviations like partial fulfilment, price changes, or unplanned costs."),
            new("Document Archiving", "Archive original invoices securely in Polypus Cloud Document Management. Generate accessible URLs for retrieval and audit compliance, seamlessly integrated with IFS.")
        ],
        WhyChoose =
        [
            new("Accelerated Workflows", "Eliminate manual tasks with seamless, automated invoice processing, enrichment, and export. Speed up approvals and improve turnaround times."),
            new("Data-Driven Accuracy", "Leverage synchronized master and posting data to enhance predictions, ensuring precise invoice coding, supplier validation, and accounting attributes."),
            new("Smart Reconciliation", "Automate complex PO matching and flag discrepancies early, minimizing delays and reducing costly errors."),
            new("Enhanced Visibility and Control", "Gain operational transparency with real-time insights into AP workflows and supplier performance, enabling more informed decisions."),
            new("Compliance and Audit Readiness", "Securely archive documents with Polypus Cloud Document Management. Ensure compliance and streamline audits with instant access to organized, audit-ready data.")
        ]
    };

    public static readonly ConnectorPageModel Odoo = new()
    {
        Eyebrow = "Get started with Polypus for Odoo",
        Title = "Odoo x Polypus",
        PartnerName = "Odoo",
        MetaDescription = "The Polypus connector for Odoo: intelligent extraction, matching and " +
                          "coding for complex invoices.",
        HowItWorksLead = "Remove bottlenecks and manual effort when processing even the most complex " +
                         "invoices with the combined power of Odoo and Polypus. Make best-in-class " +
                         "AI the most trusted sidekick of business services teams.",
        Diagram = new IntegrationDiagram
        {
            ApiLabel = "API",
            PostingLabel = "Posting Data",
            MasterSourceLabel = "Suppliers / Company codes /",
            MasterSourceSubLabel = "Purchase orders",
            ContextPill = "Context Data",
            MasterPill = "Master Data",
            AgentsTitle = "Invoice Processing AI Agents",
            Agents =
            [
                "Document Extraction",
                "Approver Prediction",
                "GL Account Prediction",
                "Cost Center Prediction",
                "Supplier Prediction",
                "Company Code Prediction",
                "PO Matching"
            ],
            Output = "Extracted / Enriched document data",
            ExtractedTitle = "Extracted / Enriched document data",
            ExtractedFlowLabel = "Extracted / Enriched document data",
            ExtractedFlowSubLabel = "Purchase orders",
            OutboundTitle = "Outbound Integration:",
            OutboundItems = ["Master data integration", "Outbound document integration", "Purchase order integration", "Posting data integration"],
            InboundTitle = "Inbound Integration:",
            InboundItems = ["Inbound document integration"],
            Caption = "Odoo master and posting data flow out to Polypus, the agents extract, predict and match, and the enriched documents flow back for posting or review."
        },
        WhyTitle = "Why Choose Polypus for Odoo?",
        TrustLabel = "Trust Report",
        Certifications = ["ISO 27001", "SOC 2 Type II", "HIPAA", "GDPR", "CCPA", "STAR Level 1"],
        CtaTitle = "Agentic process automation for Odoo with Polypus",
        CtaCopy = "Unleash the potential of your business services operations.",
        HowItWorks =
        [
            new("Intelligent Data Extraction", "Extracts header and line-item details from invoices with market-leading accuracy, ensuring seamless processing regardless of format or supplier."),
            new("Invoice Classification", "Identifies document type, company code, and target system while routing non-AP documents to the right teams, preventing misclassification."),
            new("Matching & Validation", "Matches PO invoices with purchase orders, validates supplier details, and detects duplicates or errors before they enter the workflow."),
            new("Coding & Approval Routing", "Applies GL account coding, tax categorization, and approver assignment using AI-driven predictions, eliminating manual effort."),
            new("ERP Integration & Compliance", "Ensures direct handover of validated invoices to ERP systems like SAP and IFS, maintaining compliance with audit-ready tracking and real-time analytics.")
        ],
        WhyChoose =
        [
            new("Complex Transactions Made Easy", "Handle complex tasks where traditional systems fall short. Accounting coding, PO line matching, tax compliance, fraud detection - Polypus goes beyond rule-based automation and doesn't require re-training."),
            new("Superb Accuracy. Quality Decisions.", "Leverage synchronized master and transactional data to enhance predictions, reducing errors in invoice coding and PO matching."),
            new("Global & Scalable Automation", "No more model training barriers to achieve high automation rates across multiple languages and regions. Polypus adapts effortlessly to your workflows - AP or otherwise - without complex configurations."),
            new("No More Barriers to \"Touchless\"", "Thanks to intelligent input management, Polypus streamlines AP operations, enabling fully automated transactions without altering existing processes."),
            new("Deep Integration That Fits Seamlessly", "Connect with your core setup - from big brand ERP systems to workflow tools. Gain full transparency and control with real-time analytics, ensuring compliance and audit readiness.")
        ]
    };

    /// <summary>Every connector page by route.</summary>
    public static readonly IReadOnlyDictionary<string, ConnectorPageModel> ByRoute =
        new Dictionary<string, ConnectorPageModel>(StringComparer.OrdinalIgnoreCase)
        {
            ["/integrations/sap"] = Sap,
            ["/integrations/coupa"] = Coupa,
            ["/integrations/ifs"] = Ifs,
            ["/integrations/odoo"] = Odoo
        };
}
