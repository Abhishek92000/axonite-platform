using Polypus.Web.Models;

namespace Polypus.Web.Services;

/// <summary>
/// The content of every page reached from the header: Workforce, Platform, Resources,
/// Company sub-pages, FAQ and the integration connectors.
///
/// The copy mirrors the reference navigation's information architecture so the header
/// structure and the pages behind it tell the same story. Each entry is rendered by
/// Components/Shared/ContentPage.razor, so adding a destination is a catalog entry.
/// </summary>
public static class ContentPageCatalog
{
    // ---------------------------------------------------------------------
    // Workforce
    // ---------------------------------------------------------------------

    public static readonly ContentPageModel Workforce = new()
    {
        Section = "Workforce",
        Eyebrow = "Workforce",
        Title = "The workforce that runs your document-heavy processes",
        Lead = "A team of Polypus agents that runs document-heavy finance and operations processes " +
               "from intake to a controlled action in your system of record. Agents combine reusable " +
               "skills, work inside your approval guidelines and connect to your ERP, so the work " +
               "gets done while your team supervises outcomes and exceptions.",
        MetaDescription = "A team of Polypus agents running document-heavy finance and operations " +
                          "processes from intake to a controlled action in your system of record.",
        Pills = ["Inside the workforce", "Skills, agents and controls"],
        Sections =
        [
            new ContentSection(
                "How it works",
                "What you select, what we deploy, what you get",
                "Working with us is like hiring. Tell us which tasks need handling - validation, " +
                "matching, prediction, compliance - and we bring the agents to execute them.",
                [
                    new ContentItem("Skills", "Select the skills your process needs to cover.", "sparkle"),
                    new ContentItem("Agents", "We staff agents that match your skills picks.", "user-check"),
                    new ContentItem("Workforce", "Agents with the right skills become your workforce in production.", "users")
                ]),
            new ContentSection(
                "Pre-packaged bundles",
                "Your workforce, ready to deploy",
                "Start with a standard workforce - trialled, tested and built agentic from the ground " +
                "up for the most common scenarios.",
                [
                    new ContentItem("Invoice Processing", "A workforce that captures, codes, matches and validates every invoice.", "scan"),
                    new ContentItem("Order Confirmations", "A workforce catching and matching every line, price and quantity.", "check-circle"),
                    new ContentItem("Delivery Notes", "A workforce turning delivery notes into validated receipts.", "layers"),
                    new ContentItem("Order Management", "A workforce validating sales orders against catalogue, pricing and volume.", "flow"),
                    new ContentItem("Dunning Letters", "A workforce that captures, matches and resolves every dunning letter.", "mail"),
                    new ContentItem("Build Your Own", "Create your own workforce directly on the Polypus platform.", "sparkle")
                ]),
            new ContentSection(
                "Scale",
                "A workforce that can help you scale",
                "Deploy seamless workflows across every major pillar: from procurement and sales to " +
                "accounts payable and receivable. The Polypus workforce has built-in controls and " +
                "explainable decisions, so you can release human capacity to focus on the tasks only " +
                "people can do.",
                []),
            new ContentSection(
                "Where humans stay in control",
                "Every exception has an owner",
                "Nothing is forced through to keep a process moving. Each exception is logged with a " +
                "specific reason and routed to a named owner, and every decision leaves a trail: what " +
                "the agent read, what it decided, and what the system of record did.",
                []),
            new ContentSection(
                "Getting started",
                "How large enterprises usually start",
                "With a land-and-expand approach: the first workforce takes on the highest-volume, " +
                "most error-prone document type or process - the one creating disruptive manual " +
                "reconciliation work. Once the results pass the agreed acceptance checks, the " +
                "workforce expands to further entities, or an adjacent workforce is deployed.",
                [])
        ],
        Faqs =
        [
            new Faq
            {
                Category = "Workforce",
                Question = "What is an agentic workforce?",
                Answer = "A team of Polypus agents that runs document-heavy finance and operations " +
                         "processes from intake to a controlled action in your system of record. " +
                         "Agents combine reusable skills, work inside your approval guidelines and " +
                         "connect to your ERP, so the work gets done while your team supervises " +
                         "outcomes and exceptions."
            },
            new Faq
            {
                Category = "Workforce",
                Question = "How is this different from buying more software?",
                Answer = "A tool asks your process to fit the scenarios and document variations it was " +
                         "built for. An agentic workforce with language understanding works the other " +
                         "way around: it runs on high-level guidance and produces the next step or the " +
                         "outcome - a document posted, confirmed or flagged. Your team manages the " +
                         "exceptions instead of the blind spots of a tool."
            },
            new Faq
            {
                Category = "Workforce",
                Question = "Which processes can the workforce run?",
                Answer = "Pre-packaged, ready-to-deploy bundles for invoice processing, order " +
                         "confirmations, delivery notes, sales order management and dunning letter " +
                         "automation. Teams can also build their own workforce to capture documents " +
                         "beyond the standard list."
            },
            new Faq
            {
                Category = "Workforce",
                Question = "Does it work with our existing ERP and systems?",
                Answer = "Yes. A workforce connects to major enterprise systems through native " +
                         "connectors and acts inside your existing process: validations, approvals " +
                         "and postings follow the procedures your organization already has in place."
            },
            new Faq
            {
                Category = "Workforce",
                Question = "What does Build Your Own Workforce mean?",
                Answer = "Build Your Own is the offer for documents outside the available named " +
                         "solutions. You get build access to the Polypus platform and create your own " +
                         "workforce for entirely new document types, with the same controls and " +
                         "integrations available across the standard offering."
            },
            new Faq
            {
                Category = "Workforce",
                Question = "How does a workforce keep humans in control?",
                Answer = "Every exception is logged with a specific reason and routed to a named owner. " +
                         "Approvals follow your authority rules, and each decision leaves a trail: what " +
                         "the agent read, what it decided, and what the system of record did. Reviewers " +
                         "work in the review console, where people see each case, decide, and have " +
                         "their revision recorded."
            }
        ]
    };

    public static readonly ContentPageModel Skills = new()
    {
        Section = "Skills",
        Eyebrow = "Workforce",
        Title = "Scaled operations run on the right skills",
        Lead = "Polypus offers a growing library of pre-packaged skills. Pick the ones your process " +
               "needs and our agents will deliver them.",
        MetaDescription = "A growing library of pre-packaged GBS skills that agents combine to run " +
                          "a process end to end.",
        Pills = ["Pre-packaged", "Low to expert complexity"],
        Sections =
        [
            new ContentSection(
                "Complexity",
                "Skills vary in complexity to match every step of your process",
                null,
                [
                    new ContentItem("Low complexity", "Skills that follow fixed rules, such as routing a document or checking a field is filled in correctly.", "check"),
                    new ContentItem("Medium complexity", "Skills that read and interpret content, such as classifying a document type or extracting data from it.", "scan"),
                    new ContentItem("High complexity", "Skills that cross-check information across systems, such as matching an invoice to a purchase order.", "layers"),
                    new ContentItem("Expert complexity", "Skills that require specialized knowledge, such as validating tax compliance or handling country-specific regulations.", "shield-check")
                ]),
            new ContentSection(
                "In production",
                "A library of skills ready to go live",
                null,
                [
                    new ContentItem("Input Validation", "Check that everything is in order at the door. Agents flag errors before they disrupt downstream processes.", "shield-check"),
                    new ContentItem("Document Routing", "Send it where it belongs. Agents route documents to the right agent or escalate to a human operator.", "flow"),
                    new ContentItem("Document Classification", "Sort with intelligence. Agents identify document types at scale, no templates needed.", "layers"),
                    new ContentItem("Document Splitting", "Agents detect multi-doc files and auto-split them into clean, process-ready pages.", "scan"),
                    new ContentItem("Information Extraction", "Find what matters, fast. Agents pull key data from any format with high accuracy.", "search"),
                    new ContentItem("Duplicate Prevention", "No more double entries. Agents detect and block duplicates before they hurt your bottom line.", "check-circle"),
                    new ContentItem("e-Invoicing", "Mandates are here - comply with xRechnung, ZUGFeRD 2.3, Factur-X, FatturaPA, RO e-Factura and more.", "download"),
                    new ContentItem("Account Coding", "Books that balance themselves. Agents predict GL accounts, cost centres and coding dimensions.", "chart"),
                    new ContentItem("VAT Tax Compliance Validation", "Compliant invoices, confident audits. Agents check VAT rules and statutory requirements, leaving an explainable trail.", "check")
                ])
        ],
        Faqs =
        [
            new Faq
            {
                Category = "Skills",
                Question = "What is a skill?",
                Answer = "A reusable capability specialized in doing one job: validating input, " +
                         "classifying a document, extracting information, preventing duplicates and " +
                         "so on. Skills are the building blocks agents combine to run a process."
            },
            new Faq
            {
                Category = "Skills",
                Question = "What do the complexity levels mean?",
                Answer = "Skills span four levels of task complexity: low, medium, high and expert. A " +
                         "low-complexity skill runs a fixed check; an expert skill weighs specialized " +
                         "context before posting an outcome. The higher levels are what let teams " +
                         "handle true end-to-end processes rather than just capture documents."
            },
            new Faq
            {
                Category = "Skills",
                Question = "Are the skills ready to use?",
                Answer = "Yes. The library is live in production, and each skill is built to fit the " +
                         "workforce you go live with."
            },
            new Faq
            {
                Category = "Skills",
                Question = "Can skills be combined?",
                Answer = "Yes. Skills define what your selected workforce will do and come " +
                         "pre-packaged in it. You choose which of the pre-packaged skills go live and " +
                         "which are left out, so you do not pay for what you do not use."
            }
        ]
    };

    public static readonly ContentPageModel InvoiceProcessing = new()
    {
        Section = "Workforce / Invoice Processing",
        Eyebrow = "Workforce",
        Title = "Don't let invoices cost more than their face value.",
        Lead = "An invoice can take 70+ actions to post. If done manually, that means more errors and " +
               "slower cycles. The workforce handles every step - capture, matching, coding, approval, " +
               "compliance - flagging mismatches before they become write-offs, duplicate payments or fines.",
        MetaDescription = "A workforce that captures, codes, matches and validates every invoice " +
                          "before it posts.",
        Sections =
        [
            new ContentSection(
                "How it works",
                "A workforce shielding margins from the cost of mismanaged invoices",
                null,
                []),
            new ContentSection(
                "Skills",
                "Skills for touchless invoice posting",
                null,
                [
                    new ContentItem("Input Validation", "Check that everything is in order at the door. Agents flag errors before they disrupt downstream processes.", "shield-check"),
                    new ContentItem("Document Routing", "Send it where it belongs. Agents route documents to the right agent or escalate to a human operator.", "flow"),
                    new ContentItem("Document Classification", "Sort with intelligence. Agents identify document types at scale, no templates needed.", "layers"),
                    new ContentItem("Information Extraction", "Find what matters, fast. Agents pull key data from any format with high accuracy.", "search"),
                    new ContentItem("Duplicate Prevention", "No more double entries. Agents detect and block duplicates before they hurt your bottom line.", "check-circle"),
                    new ContentItem("e-Invoicing", "Mandates are here. Agents help you comply with xRechnung, ZUGFeRD 2.3, Factur-X, FatturaPA and more.", "download"),
                    new ContentItem("Supplier Master Enrichment", "Know your vendor, instantly. Agents match every supplier record and enrich it with IDs and banking details.", "users"),
                    new ContentItem("PO Enrichment", "Match faster, with fewer errors. Agents automate accuracy across every PO line.", "layers"),
                    new ContentItem("Approver Enrichment", "Agents get transactions in front of the correct approver instantly, from your authority matrix and policy.", "user-check")
                ]),
            new ContentSection(
                "Outcomes",
                "Get invoices posted in days, not weeks",
                null,
                [])
        ],
        Faqs =
        [
            new Faq
            {
                Category = "Invoice Processing",
                Question = "What does the invoice processing workforce do?",
                Answer = "It captures invoices, classifies and splits documents, extracts and validates " +
                         "the data, resolves the supplier, checks for duplicates and prepares a " +
                         "correct, controlled posting in your ERP, applying the applicable tax and " +
                         "e-invoicing rules per line. Exceptions route to the right owner with their " +
                         "reason attached."
            },
            new Faq
            {
                Category = "Invoice Processing",
                Question = "Which invoice formats and languages are supported?",
                Answer = "Scans, PDFs and e-invoices, including multi-document files that need " +
                         "splitting. A translation skill handles foreign-language invoices, so " +
                         "international suppliers follow the same process as local ones."
            },
            new Faq
            {
                Category = "Invoice Processing",
                Question = "How are exceptions handled?",
                Answer = "Each exception gets a specific reason, such as supplier unresolved or " +
                         "duplicate suspected, and routes to the owner who can act on it. Nothing is " +
                         "forced into the ledger to keep a process moving."
            },
            new Faq
            {
                Category = "Invoice Processing",
                Question = "Can it prevent duplicate payments?",
                Answer = "Yes. The Duplicate Prevention skill checks new invoices against what is " +
                         "already in the system and blocks double entries before they post, raising a " +
                         "warning a reviewer can confirm or dismiss with the evidence in front of them."
            },
            new Faq
            {
                Category = "Invoice Processing",
                Question = "What type of files can the workforce handle?",
                Answer = "Invoices in any format - image, PDF, XML/JSON, Word or Excel - regardless of " +
                         "whether they come in by email, scan, e-invoicing or API."
            }
        ]
    };

    public static readonly ContentPageModel OrderConfirmations = new()
    {
        Section = "Workforce / Order Confirmations",
        Eyebrow = "Workforce",
        Title = "Ensure your POs turn into correct deliveries, every time.",
        Lead = "Purchase orders are structured, but acknowledgments are not. From PDFs to emails, the " +
               "workforce turns unstructured supplier replies into ERP-ready confirmations - fast, " +
               "accurate and touchless.",
        MetaDescription = "A workforce catching and matching every line, price and quantity on " +
                          "supplier order confirmations.",
        Sections =
        [
            new ContentSection(
                "How it works",
                "A workforce for instant clarity on order status",
                null,
                []),
            new ContentSection(
                "Skills",
                "Skills to get every order confirmed",
                null,
                [
                    new ContentItem("Input Validation", "Check that everything is in order at the door. Agents flag errors before they disrupt downstream processes.", "shield-check"),
                    new ContentItem("Document Routing", "Send it where it belongs. Agents route documents to the right agent or escalate to a human operator.", "flow"),
                    new ContentItem("Document Classification", "Sort with intelligence. Agents identify document types at scale, no templates needed.", "layers"),
                    new ContentItem("Information Extraction", "Find what matters, fast. Agents pull key data from any format with high accuracy.", "search"),
                    new ContentItem("Duplicate Prevention", "No more double entries. Agents detect and block duplicates before they hurt your bottom line.", "check-circle"),
                    new ContentItem("PO Enrichment", "Match faster, with fewer errors. Agents automate accuracy across every PO line.", "layers"),
                    new ContentItem("Supplier Master Enrichment", "Know your vendor, instantly. Agents match every supplier record and enrich it.", "users"),
                    new ContentItem("Supplier & Approver Communication", "No more chasing. Agents send the right message to the right person at the right time.", "mail"),
                    new ContentItem("Company Master Enrichment", "Every transaction has one true owner. Agents assign the correct legal entity using ERP and MDM data.", "building")
                ]),
            new ContentSection(
                "Outcomes",
                "Manage every purchase order with confidence",
                null,
                [])
        ],
        Faqs =
        [
            new Faq
            {
                Category = "Order Confirmations",
                Question = "What does the Order Confirmations workforce do?",
                Answer = "It reads supplier order confirmations, matches them against the purchase " +
                         "order on price, quantity and dates, and gives procurement clarity on which " +
                         "orders are confirmed as expected and which deviate."
            },
            new Faq
            {
                Category = "Order Confirmations",
                Question = "Why automate order confirmations at all?",
                Answer = "An unread confirmation hides a late or wrong delivery until it hurts your " +
                         "process downstream. Processing every confirmation as it arrives surfaces " +
                         "delivery risks early, while there is still time to react."
            },
            new Faq
            {
                Category = "Order Confirmations",
                Question = "What happens when a confirmation deviates from the PO?",
                Answer = "When the workforce cannot resolve a deviation with the current business " +
                         "knowledge, it escalates the case as an exception to the owner, with the " +
                         "reason and the context needed to resolve it."
            },
            new Faq
            {
                Category = "Order Confirmations",
                Question = "Does the workforce communicate with suppliers?",
                Answer = "Yes. A dedicated Supplier & Approver Communication skill handles " +
                         "clarifications and follow-ups inside the process instead of in scattered " +
                         "channels."
            }
        ]
    };

    public static readonly ContentPageModel DeliveryNotes = new()
    {
        Section = "Workforce / Delivery Notes",
        Eyebrow = "Workforce",
        Title = "For finance teams who are done guessing pay or hold.",
        Lead = "Agents capture delivery notes from email, EDI, carrier portal or scan, and validate " +
               "them against the PO. Mismatches are flagged and resolved before AP sees the invoice. " +
               "Once posted, the goods receipt and decision log keep Finance, Procurement and " +
               "suppliers aligned.",
        MetaDescription = "A workforce turning delivery notes into validated receipts and reliable " +
                          "goods receipts.",
        Sections =
        [
            new ContentSection(
                "How it works",
                "A workforce making even partial deliveries a breeze",
                null,
                []),
            new ContentSection(
                "Skills",
                "Skills turning delivery notes into reliable receipts",
                null,
                [
                    new ContentItem("Input Validation", "Check that everything is in order at the door. Agents flag errors before they disrupt downstream processes.", "shield-check"),
                    new ContentItem("Document Routing", "Send it where it belongs. Agents route documents to the right agent or escalate to a human operator.", "flow"),
                    new ContentItem("Document Classification", "Sort with intelligence. Agents identify document types at scale, no templates needed.", "layers"),
                    new ContentItem("Information Extraction", "Find what matters, fast. Agents pull key data from any format with high accuracy.", "search"),
                    new ContentItem("Duplicate Prevention", "No more double entries. Agents detect and block duplicates before they hurt your bottom line.", "check-circle"),
                    new ContentItem("PO Enrichment", "Match faster, with fewer errors. Agents automate accuracy across every PO line.", "layers"),
                    new ContentItem("Supplier Master Enrichment", "Know your vendor, instantly. Agents match every supplier record and enrich it.", "users"),
                    new ContentItem("Company Master Enrichment", "Every transaction has one true owner. Agents assign the correct legal entity using ERP and MDM data.", "building"),
                    new ContentItem("Supplier & Approver Communication", "No more chasing. Agents send the right message to the right person at the right time.", "mail")
                ]),
            new ContentSection(
                "Outcomes",
                "Receipts Finance can act on",
                null,
                [])
        ],
        Faqs =
        [
            new Faq
            {
                Category = "Delivery Notes",
                Question = "What does the Delivery Notes workforce do?",
                Answer = "It turns delivery notes into validated goods receipts: capturing the " +
                         "document, matching lines against the order, and recording what actually " +
                         "arrived, so finance decides pay or hold on facts."
            },
            new Faq
            {
                Category = "Delivery Notes",
                Question = "How does it handle partial deliveries?",
                Answer = "Line by line. A partial delivery is recorded as exactly that, so the receipt " +
                         "reflects reality and the next delivery reconciles against what remains."
            },
            new Faq
            {
                Category = "Delivery Notes",
                Question = "Why do delivery notes matter for accounts payable?",
                Answer = "They are the evidence between the order and the invoice. Reliable receipts " +
                         "make invoice matching decisions grounded instead of guessed, which protects " +
                         "both margins and supplier relationships."
            }
        ]
    };

    public static readonly ContentPageModel OrderManagement = new()
    {
        Section = "Workforce / Order Management",
        Eyebrow = "Workforce",
        Title = "Capture all new business. Do 0% manual work.",
        Lead = "Orders come in from email, portals, EDI and more. Agents identify, classify and match " +
               "each to the latest catalogue, even with typos or outdated codes, then decide how to " +
               "route it using data from every connected system.",
        MetaDescription = "A workforce validating sales orders against catalogue, pricing and volume " +
                          "before they enter the ERP.",
        Sections =
        [
            new ContentSection(
                "How it works",
                "A workforce for sales order consistency - peak season or slow",
                null,
                []),
            new ContentSection(
                "Skills",
                "Skills for smooth order management",
                null,
                [
                    new ContentItem("Input Validation", "Check that everything is in order at the door. Agents flag errors before they disrupt downstream processes.", "shield-check"),
                    new ContentItem("Document Classification", "Sort with intelligence. Agents identify document types at scale, no templates needed.", "layers"),
                    new ContentItem("Information Extraction", "Find what matters, fast. Agents pull key data from any format with high accuracy.", "search"),
                    new ContentItem("Duplicate Prevention", "No more double entries. Agents detect and block duplicates before they hurt your bottom line.", "check-circle"),
                    new ContentItem("Customer Master Enrichment", "Know your customer, instantly. Agents unify and reconcile account records across systems.", "users"),
                    new ContentItem("Product Matching", "No surprises in sales. Agents validate every order with the latest product or material master data.", "check-circle"),
                    new ContentItem("Shipping Address Enrichment", "Ship with certainty. Agents match and enrich every ship-to record at header and line level.", "map-pin"),
                    new ContentItem("Responsibility Determination", "Every item finds its owner. Agents assign the right team, person or queue based on account, channel and SLA.", "user-check")
                ]),
            new ContentSection(
                "Outcomes",
                "Manage every sales order with speed",
                null,
                [])
        ],
        Faqs =
        [
            new Faq
            {
                Category = "Order Management",
                Question = "What does the Order Management workforce do?",
                Answer = "It captures incoming sales orders, validates them against catalogue, pricing " +
                         "and volume rules, routes exceptions to the right owner and creates clean " +
                         "orders in your ERP."
            },
            new Faq
            {
                Category = "Order Management",
                Question = "What gets validated on every order?",
                Answer = "Product references against the catalogue, prices against agreements, " +
                         "quantities against expected volumes, and customer data against your master " +
                         "records. Deviations become specific exceptions rather than downstream " +
                         "surprises."
            },
            new Faq
            {
                Category = "Order Management",
                Question = "How does it cope with seasonal peaks?",
                Answer = "It is designed for both peak season and quiet periods: it scales with order " +
                         "volume rather than depending on manual capacity."
            },
            new Faq
            {
                Category = "Order Management",
                Question = "Can it handle orders arriving as documents?",
                Answer = "Yes. Orders arriving as documents are captured, classified and extracted " +
                         "with the same document skills, then validated and routed like any other " +
                         "order."
            }
        ]
    };

    public static readonly ContentPageModel BuildYourOwn = new()
    {
        Section = "Workforce / Build Your Own",
        Eyebrow = "Workforce",
        Title = "Build your own workforce on the Polypus platform",
        Lead = "Define the process and the skills your operation needs. We staff agents equipped to " +
               "run them, with the same controls and integrations available across the standard " +
               "offering.",
        MetaDescription = "Build access to the Polypus platform to create your own workforce for " +
                          "entirely new document types.",
        Sections =
        [
            new ContentSection(
                "The offer",
                "For documents outside the standard list",
                "Build Your Own is the offer for documents outside the available named solutions. You " +
                "get build access to the Polypus platform and create your own workforce for entirely " +
                "new document types.",
                []),
            new ContentSection(
                "What you get",
                "The same controls as the standard offering",
                null,
                [
                    new ContentItem("Same controls", "The same supervision model, approvals and audit trail as the out-of-the-box bundles.", "shield-check"),
                    new ContentItem("Same integrations", "Native connectors to your ERP and inbound channels, configured per tenant.", "plug"),
                    new ContentItem("Natural language setup", "Instruct agents in plain language inside the review console - no black boxes.", "sparkle")
                ])
        ],
        Faqs =
        [
            new Faq
            {
                Category = "Build Your Own",
                Question = "What does Build Your Own Workforce mean?",
                Answer = "Build Your Own is the offer for documents outside the available named " +
                         "solutions. You get build access to the Polypus platform and create your own " +
                         "workforce for entirely new document types, with the same controls and " +
                         "integrations available across the standard offering."
            },
            new Faq
            {
                Category = "Build Your Own",
                Question = "Can we build our own agents?",
                Answer = "Yes. You can get builder access to the Polypus platform to create your own " +
                         "agents to classify, extract and enrich documents, supported by the same " +
                         "supervision model and controls as the out-of-the-box workforce bundles."
            }
        ]
    };

    // ---------------------------------------------------------------------
    // Platform
    // ---------------------------------------------------------------------

    public static readonly ContentPageModel Platform = new()
    {
        Section = "Platform",
        Eyebrow = "Platform",
        Title = "The mission control for your agent pipeline",
        Lead = "Agents are orchestrated on the Polypus platform - with the models, tools, context, " +
               "guardrails and integrations needed to turn transaction-heavy processes into working " +
               "business solutions.",
        MetaDescription = "The Polypus platform orchestrates agents with the models, tools, context, " +
                          "guardrails and integrations needed for transaction-heavy processes.",
        Pills = ["Auditable", "Explainable", "Secure", "Scalable"],
        Sections =
        [
            new ContentSection(
                "Platform capabilities",
                "Not just an agent platform - one purpose-built for business services",
                "Transactions covered from the moment they arrive to the moment they are compliant " +
                "and complete.",
                [
                    new ContentItem("Input Management", "Classifies, splits, routes and normalizes incoming transactions across documents, emails, structured data and other input formats.", "layers"),
                    new ContentItem("Document Processing", "OCR built to read what generic OCR cannot: low-quality scans, handwriting, faxed copies, mixed layouts and every format a real inbox receives.", "scan"),
                    new ContentItem("Transaction Matching & Data Enrichment", "Connects transactions to suppliers, customers, POs, products and companies to add the context required for processing.", "plug"),
                    new ContentItem("Expert Task Automation", "Understands the transaction in its broader business context and applies organizational knowledge, policies and historical patterns.", "sparkle"),
                    new ContentItem("Transaction Assurance", "Checks transactions for correctness, completeness and compliance; identifies duplicates, inconsistencies and other exceptions.", "shield-check"),
                    new ContentItem("Transaction Execution", "Turns the resulting decision into action - routing, requesting approval, communicating, rejecting or handing over to downstream systems.", "flow")
                ]),
            new ContentSection(
                "The four levers",
                "Auditable, explainable, secure and scalable",
                "The platform comes with business services in its DNA. Generic agent builders hand you " +
                "nodes and triggers. Here you deploy specialized coworkers, not robots you have to " +
                "micromanage.",
                [
                    new ContentItem("AI Agents", "Digital workers for business support. Each agent performs an expert task for processing a transaction, with one job: to complete it compliantly.", "user-check"),
                    new ContentItem("Workforce HITL", "Inspect every transaction, down to the decisions. Review and correct results, surface where agents need human input, and manage work queues.", "users"),
                    new ContentItem("Setup", "Choose from a broad catalogue of models to power your agents, manage the tools they use, and test and deploy them securely.", "layers"),
                    new ContentItem("Knowledge Management", "Teach agents how your business works: instruct them in natural language, feed know-how on the go, and ground them in business history.", "sparkle")
                ]),
            new ContentSection(
                "Integrations",
                "Live data from your systems, with no limits",
                "Integrations connect agents to the private information your business already runs on, " +
                "so they never act on a stale data point.",
                [
                    new ContentItem("Inbound channels", "Email, Outlook or API - transactions get ingested wherever they originate.", "mail"),
                    new ContentItem("Standard connectors", "SAP, Coupa, Workday and xSuite.", "plug"),
                    new ContentItem("No-code connectors", "Boomi and n8n plug straight into the platform, extending your existing automation stack.", "flow"),
                    new ContentItem("Open APIs", "A broad set of REST endpoints for building highly tailored integrations.", "layers"),
                    new ContentItem("Agentic integrations", "Give agents access to your agents and resources via A2C and MCP.", "user-check")
                ]),
            new ContentSection(
                "Assurance",
                "Enterprise-grade security and controls",
                "The platform maintains ISO 27001 certification and SOC 2 Type II attestation, is " +
                "HIPAA, GDPR and CCPA-compliant, and its cloud services sit on a STAR Level 1 Registry.",
                [])
        ],
        Faqs =
        [
            new Faq
            {
                Category = "Platform",
                Question = "How autonomous are agents?",
                Answer = "Autonomy is a configuration choice. Each agent operates within a defined " +
                         "harness: what it may complete on its own and where it stops and asks, and " +
                         "what context it has access to. Exceptions and approvals reach a human owner."
            },
            new Faq
            {
                Category = "Platform",
                Question = "How do agents work together?",
                Answer = "Each agent owns a step and hands the case to the next with full context, " +
                         "forming a workforce for the whole process. The handoffs keep the context of " +
                         "each case intact from step to step."
            },
            new Faq
            {
                Category = "Platform",
                Question = "What is a Polypus agent?",
                Answer = "A digital coworker that runs a step within a process or a workflow. An agent " +
                         "reasons about its task, uses tools, accesses core systems and master data, " +
                         "and collaborates with the other agents within a workforce."
            }
        ]
    };

    public static readonly ContentPageModel Agents = new()
    {
        Section = "Platform / Agents",
        Eyebrow = "Platform",
        Title = "Agents built to solve tasks, not become one",
        Lead = "The agents are specialists in business support. They understand language and nuance " +
               "like people, then reason and act on your transactional layer.",
        MetaDescription = "Polypus agents are digital coworkers that reason, use tools and " +
                          "collaborate to run a process step.",
        Sections =
        [
            new ContentSection(
                "How agents work",
                "Collaborate, reason and use tools",
                null,
                [
                    new ContentItem("Collaborate", "Agents work together, validating decisions, handling exceptions and escalating to each other, or when needed, to a human.", "users"),
                    new ContentItem("Reason", "Each agentic decision is backed by clear reasoning, enabling full traceability and audit readiness.", "sparkle"),
                    new ContentItem("Use tools", "Agents access databases, coding libraries, handbooks and integrations to complete work without system re-engineering.", "plug")
                ]),
            new ContentSection(
                "The workforce",
                "Agents working together to form a workforce",
                "Explore the pre-packaged workforce bundles, designed for the most common scenarios.",
                [
                    new ContentItem("Invoice Processing", "A workforce that captures, codes, matches and validates every invoice.", "scan"),
                    new ContentItem("Order Confirmations", "A workforce catching and matching every line, price and quantity.", "check-circle"),
                    new ContentItem("Delivery Notes", "A workforce turning delivery notes into validated receipts.", "layers"),
                    new ContentItem("Order Management", "A workforce validating sales orders against catalogue, pricing and volume.", "flow"),
                    new ContentItem("Dunning Letters", "A workforce that captures, matches and resolves every dunning letter.", "mail"),
                    new ContentItem("Build Your Own", "Define the process and skills your operation needs. We staff agents equipped to run them.", "sparkle")
                ])
        ],
        Faqs =
        [
            new Faq
            {
                Category = "Agents",
                Question = "What is a Polypus agent?",
                Answer = "A digital coworker that runs a step within a process or a workflow. An agent " +
                         "reasons about its task, uses tools, accesses core systems and master data, " +
                         "and collaborates with the other agents within a workforce."
            },
            new Faq
            {
                Category = "Agents",
                Question = "How do agents work together?",
                Answer = "Each agent owns a step and hands the case to the next with full context, " +
                         "forming a workforce for the whole process. The handoffs keep the context of " +
                         "each case intact from step to step."
            },
            new Faq
            {
                Category = "Agents",
                Question = "Can we build our own agents?",
                Answer = "Yes. You can get builder access to the Polypus platform to create your own " +
                         "agents to classify, extract and enrich documents, supported by the same " +
                         "supervision model and controls as the out-of-the-box workforce bundles."
            }
        ]
    };

    // ---------------------------------------------------------------------
    // Resources
    // ---------------------------------------------------------------------

    public static readonly ContentPageModel Blog = new()
    {
        Section = "Resources / Blog",
        Eyebrow = "Resources",
        Title = "Polypus Blog",
        Lead = "Stay updated with the latest insights on agentic AI, business services and more.",
        MetaDescription = "Insights on agentic AI, global business services and document-heavy " +
                          "operations.",
        Sections =
        [
            new ContentSection(
                "Featured",
                "Latest articles",
                "Perspectives on the governance, operating model and economics of agentic automation.",
                [
                    new ContentItem("The Governance Gap: 5 Considerations For Building A Controls Framework for Agentic AI", "How do you fit agentic AI into your internal controls framework? Which controls are built in and which do you need to configure yourself?", "shield-check"),
                    new ContentItem("Back-Office Automation in Practice: Exploring the Reality Behind the GBS AI Hype", "Setting the record straight. How far has the industry come with agentic AI and how can we bridge the gap from ambition to reality.", "chart"),
                    new ContentItem("Token costs are the new budget risk in agentic AI. Here's how to plan for them", "Token pricing can vary 20x between models. Why outcome-based pricing, not token tracking, is the safer bet for leaders.", "sparkle"),
                    new ContentItem("How Agentic AI Affects Your Workforce", "Understand how agentic AI affects your workforce when 90% of work is automated and what it is like to work in a blended agent and human team.", "users"),
                    new ContentItem("Stop Automating the Old Process: Why Agentic AI Demands a New Way of Thinking", "Don't make the same mistakes twice. How processes should change to fully embrace agentic AI.", "flow"),
                    new ContentItem("How to Scale Agentic AI Without Things Breaking", "Expert advice on orchestration, technology and change management when moving from pilots to scale.", "layers"),
                    new ContentItem("The GPO Is Now the Most Important Role in Your Agentic AI Transformation", "Most organisations hand agentic AI to IT and wonder why it fails. Why the Global Process Owner is the most critical role.", "user-check"),
                    new ContentItem("Why User Experience Is the Secret Weapon of High-Performing Teams", "Why user experience is critical to success and how empowering every team member to shape daily interactions drives better operations.", "star"),
                    new ContentItem("Redesigning the Operating Model for Agentic GBS", "Agentic AI requires a redesigned operating model centred on end-to-end process ownership, structured work instructions and strong knowledge governance.", "building")
                ])
        ]
    };

    public static readonly ContentPageModel Webinars = new()
    {
        Section = "Resources / Webinars & Events",
        Eyebrow = "Resources",
        Title = "Webinars & Events",
        Lead = "Where to connect and meet us - live sessions, on-demand recordings and past on-site events.",
        MetaDescription = "Upcoming events, on-demand recordings and past on-site events on agentic " +
                          "AI for business services.",
        Sections =
        [
            new ContentSection(
                "Upcoming events",
                "Where to connect and learn",
                null,
                [
                    new ContentItem("How Agentic AI Is Rewriting the Rules of Consulting", "Online · November 3, 2026 · Watch expert-led sessions anytime, anywhere.", "calendar")
                ]),
            new ContentSection(
                "On demand",
                "Watch expert-led sessions anytime",
                null,
                [
                    new ContentItem("Controls as a design input", "Learn why internal controls need to be part of the design input for your agentic AI strategy, not an afterthought.", "shield-check"),
                    new ContentItem("Scaling with zero-trust security", "Discover how to securely scale agentic AI with zero-trust security, governance and human oversight.", "lock"),
                    new ContentItem("The finance team of 2030", "By 2030, an estimated 90% of transactional finance work will be handled by AI agents capable of reasoning, deciding and acting independently.", "chart"),
                    new ContentItem("From capture to exception handling", "How agentic AI helps AP teams move beyond invoice capture to automate complex exception handling, lifting straight-through processing from 50-60% to 85%+.", "flow"),
                    new ContentItem("Stop automating the old process", "Don't make the same mistakes twice. How processes should change to fully embrace agentic AI.", "sparkle"),
                    new ContentItem("The e-invoicing landscape", "The e-invoicing landscape is becoming ever more complicated. This webinar brings clarity to the newest rules.", "download"),
                    new ContentItem("Success factors for scaling", "Understand the three most important success factors for scaling agentic AI across your enterprise.", "layers")
                ]),
            new ContentSection(
                "Past on-site events",
                "Take a look at how some events went",
                null,
                [
                    new ContentItem("Accounting Summit", "Join the premier event where CFOs, shared service leaders and automation experts explore what is truly possible with agentic AI.", "calendar"),
                    new ContentItem("Digital Finance Forum", "Participation in the Digital Finance Forum, October 17-18.", "building"),
                    new ContentItem("World Finance Forum Miami", "At the Miami Beach Convention Center in Florida, April 25.", "globe"),
                    new ContentItem("SSOW Orlando", "Leading the wave of autonomous finance in shared service centres with next-gen AI.", "users")
                ])
        ]
    };

    public static readonly ContentPageModel Podcast = new()
    {
        Section = "Resources / Podcast",
        Eyebrow = "Resources",
        Title = "How Agentic AI is Rewriting Leadership",
        Lead = "As agentic AI reshapes the operating model, one question keeps coming up: what does an " +
               "agentic or intelligent service organisation actually look like in practice? GBS " +
               "executives and transformation leaders share real-world lessons.",
        MetaDescription = "GBS Rewired: conversations with leaders reinventing global business " +
                          "services for the age of AI.",
        Sections =
        [
            new ContentSection(
                "Episodes",
                "Recent conversations",
                null,
                [
                    new ContentItem("Managing Token Costs: Agentic AI's Invisible Expense", "Why token economics matter, how they influence build-versus-buy decisions, and what leaders can do to prevent AI costs from spiralling.", "headset"),
                    new ContentItem("DHL's GBS Rewired: Bots, Agents, and 6,000 People", "How one of the world's largest GBS organisations supports global operations with 6,000 people, 160 automation bots and AI-driven innovation.", "users"),
                    new ContentItem("From Cost Center to Value Engine: Reimagining GBS in the Age of AI", "Where agentic AI is already moving the needle on revenue and customer outcomes, and who is accountable when autonomous agents get it wrong.", "chart"),
                    new ContentItem("The Big Data Conversation", "What it actually takes to be AI-ready: what bad data really costs, who owns the problem, and the unglamorous foundational work that decides success.", "layers"),
                    new ContentItem("Getting Buy-In and Downstream Impact from AI Initiatives", "What separates genuine AI transformation from a flashy demo, from securing executive buy-in to managing change on the ground.", "user-check"),
                    new ContentItem("How to Scale Agentic AI", "The operational, governance and architectural challenges of scaling agentic AI, and how to ensure your organisation beats the odds.", "flow")
                ]),
            new ContentSection(
                "About the podcast",
                "For leaders reinventing global business services",
                "In each episode, executives and transformation leaders share real-world lessons on " +
                "redesigning operating models, modernising data, simplifying processes and reshaping " +
                "talent to unlock AI at scale. No hype; just what works.",
                [
                    new ContentItem("AI-ready operating models", "Practical guidance on the operating model that agentic work demands.", "building"),
                    new ContentItem("Data foundations that deliver value", "The unglamorous groundwork that determines whether AI succeeds or fails.", "layers"),
                    new ContentItem("Workforce reskilling and redeployment", "Leading hybrid human and agent teams without losing your people.", "users")
                ])
        ],
        Faqs =
        [
            new Faq
            {
                Category = "Podcast",
                Question = "Who is this podcast for?",
                Answer = "Service leaders, shared services executives, transformation heads, digital " +
                         "and AI leads, CFO organisations and enterprise change-makers."
            },
            new Faq
            {
                Category = "Podcast",
                Question = "What makes this podcast different?",
                Answer = "It focuses on execution. Less theory, more lived experience: real examples, " +
                         "real obstacles, real outcomes."
            }
        ]
    };

    public static readonly ContentPageModel CaseStudies = new()
    {
        Section = "Resources / Case Studies",
        Eyebrow = "Resources",
        Title = "See who's building with us",
        Lead = "Dive deep into how companies across industries have processed millions of documents " +
               "and billions in transactions every year.",
        MetaDescription = "How companies across industries automate document-heavy finance and " +
                          "operations processes.",
        Sections =
        [
            new ContentSection(
                "Featured stories",
                "From our customers",
                null,
                [
                    new ContentItem("Healthcare leader automates 1M+ invoices from 15,000 suppliers", "One of DACH's largest private healthcare networks consolidated fragmented AP operations into a single, compliant system processing invoices for 15,000 suppliers across 150 legal entities.", "chart"),
                    new ContentItem("Repeatable transformation for an energy leader in 30+ countries", "A major EU energy company with 500+ company codes across 30+ countries faced fragmented processes with no standardized workflows. AI agents were deployed for end-to-end invoice processing.", "globe"),
                    new ContentItem("Global rollout of PO matching agents for a consumer goods giant", "Agentic PO matching deployed across 88 legal entities in 4 months without expanding headcount. PO line matching accuracy reached ~90%, enabling straight-through posting at scale.", "users"),
                    new ContentItem("From multi-step to one-touch processing", "Invoices are now instantly validated against multiple criteria, such as VAT, and autonomously matched to additional information, including ERP order references.", "flow"),
                    new ContentItem("From fragmented to autonomous: a global retailer's AP transformation", "Processing millions of documents across 70+ markets, a global fashion retailer jumped from 30% to 80% straight-through processing of 800k documents and cut manual workload by 40%.", "building"),
                    new ContentItem("90% autonomous data capturing and enrichment", "A global materials company set out to achieve at least 90% automation in data capturing and enrichment and reduce manual data posting in SAP.", "sparkle")
                ]),
            new ContentSection(
                "In their words",
                "From our customers",
                null,
                [
                    new ContentItem("Thomas Possert, Head of Accounting and Finance", "\u201cHypatos advanced our invoice processing with end-to-end automation, seamlessly linking invoices to SAP orders and streamlining workflows towards a one-touch-only process.\u201d", "star"),
                    new ContentItem("Johann Holst, Finance Services Lead", "\u201cHypatos is instrumental to get our global accounts payable processing ready for the future.\u201d", "star"),
                    new ContentItem("Carsten Waschkowitz, Managing Director", "\u201cHypatos enables us to redesign the group's global invoice entry and processing in the most scalable and future-ready way.\u201d", "star")
                ])
        ]
    };

    public static readonly ContentPageModel Whitepapers = new()
    {
        Section = "Resources / Whitepapers",
        Eyebrow = "Resources",
        Title = "Whitepapers",
        Lead = "Learn more before you build. Understand which leaders are shaping the global business " +
               "services landscape today and how they are transforming for the future.",
        MetaDescription = "Whitepapers on the architecture, governance and economics of agentic " +
                          "automation.",
        Sections =
        [
            new ContentSection(
                "Library",
                "A library of practical guidance",
                null,
                [
                    new ContentItem("The architecture wall in AP automation", "AP automation has hit a wall - not a technology wall, but an architecture wall. The answer is not better bots. It is a fundamentally different kind of reasoning.", "layers"),
                    new ContentItem("Agentic AI or agentic-washing?", "How do you differentiate real agentic AI from agentic-washing? This quick checklist reveals all.", "check-circle"),
                    new ContentItem("Secure, compliant and audit-ready at scale", "Ensuring your agentic AI deployment is secure, compliant and audit-ready, even as you scale across mission-critical processes.", "shield-check"),
                    new ContentItem("Unlocking real process autonomy", "Discover how your business should be thinking about AI agent deployment and how best to use this pivotal technology.", "sparkle"),
                    new ContentItem("A practical playbook for AI agents", "A practical playbook for designing, deploying and scaling AI agents across global business services - without disrupting operations or losing control.", "download")
                ])
        ]
    };

    public static readonly ContentPageModel FaqPage = new()
    {
        Section = "Resources / FAQ",
        Eyebrow = "Resources",
        Title = "Frequently Asked Questions",
        Lead = "Your go-to resource for answers to commonly asked questions about Polypus.",
        MetaDescription = "Answers to commonly asked questions about the Polypus platform, its " +
                          "workforce, skills and integrations.",
        Sections =
        [
            new ContentSection(
                "Product & platform basics",
                "How Polypus is different",
                null,
                [
                    new ContentItem("End-to-end, not just capture", "Automation that goes beyond simple capturing - reading, validating, matching, coding and posting through a controlled workflow.", "flow"),
                    new ContentItem("Built-in connectors", "Native integrations with leading platforms such as SAP, Coupa and Workday for seamless workflow integration.", "plug"),
                    new ContentItem("Language understanding", "Specialized in accounts payable processing, with a broad catalogue of models for the hard cases.", "sparkle"),
                    new ContentItem("Human validation when needed", "Autonomous learning from each interaction, with human validation only where it adds control.", "user-check")
                ]),
            new ContentSection(
                "Integrations & connectors",
                "Connectors that fit your core systems",
                null,
                [
                    new ContentItem("SAP", "An SAP-certified add-on installable within your SAP system, with master data, inbound and outbound document integration modules.", "plug"),
                    new ContentItem("Coupa", "A cloud-based connector bringing precision to master data matching, automated line matching and attribute prediction.", "plug"),
                    new ContentItem("Workday", "A two-way connection serving invoice export, master data integration, posting data integration and invoice archiving.", "plug"),
                    new ContentItem("No-code platforms", "A partner connector that integrates the platform with your existing automation stack.", "flow")
                ])
        ],
        Faqs =
        [
            new Faq
            {
                Category = "Product & Platform Basics",
                Question = "Is human intervention required when processing documents?",
                Answer = "Human intervention can be required, but is by no means mandatory. What " +
                         "determines the need is the required set of validations per document and use " +
                         "case. More complex sets of validations increase the probability of a " +
                         "validation rule running into an error, which may require a person to be " +
                         "looped in, either in the review console or in a downstream system."
            },
            new Faq
            {
                Category = "Product & Platform Basics",
                Question = "What document formats are supported?",
                Answer = "PDF (text-based and scanned), DOCX, JPEG and PNG images, TIFF, email " +
                         "attachments and custom formats. Scanned documents and images are handled " +
                         "through OCR."
            },
            new Faq
            {
                Category = "Product & Platform Basics",
                Question = "What are the requirements to use the platform?",
                Answer = "The review console works in the cloud, so there are no special requirements " +
                         "on your end and no complex installations. Integration with your system may " +
                         "have its own prerequisites, and the API is fully documented."
            },
            new Faq
            {
                Category = "Integrations & Connectors",
                Question = "What kind of connectors are offered?",
                Answer = "SAP through an SAP-certified add-on installable within your SAP system, " +
                         "Coupa through a cloud-based connector, Workday through a two-way " +
                         "standardized connector, and no-code platforms such as Boomi that connect " +
                         "your core systems with the platform."
            }
        ]
    };

    public static readonly ContentPageModel ApiDocs = new()
    {
        Section = "Resources / API Docs",
        Eyebrow = "Resources",
        Title = "Build tailored integrations on open APIs",
        Lead = "A broad set of REST endpoints for building integrations that fit exactly how your " +
               "team works, with the same authentication, retry and idempotency guarantees as the " +
               "standard connectors.",
        MetaDescription = "REST endpoints for building tailored integrations on the Polypus platform.",
        Sections =
        [
            new ContentSection(
                "What you get",
                "Everything the connectors use",
                null,
                [
                    new ContentItem("Document intake", "Submit documents by API wherever they originate, alongside email and network drop folders.", "download"),
                    new ContentItem("Status and results", "Poll or receive webhooks for extraction, review and posting state, down to the decision.", "flow"),
                    new ContentItem("Master data", "Read and write the master data lookups the workforce uses for enrichment and matching.", "layers"),
                    new ContentItem("Authentication", "Scoped credentials per tenant, with rotation and an audit log of every call.", "lock")
                ])
        ]
    };

    // ---------------------------------------------------------------------
    // Company
    // ---------------------------------------------------------------------

    public static readonly ContentPageModel Partners = new()
    {
        Section = "Company / Partners",
        Eyebrow = "Company",
        Title = "Partners",
        Lead = "Implementation and technology partners who extend Polypus into the systems and " +
               "regions our customers work in.",
        MetaDescription = "Implementation and technology partners who extend the Polypus platform.",
        Sections =
        [
            new ContentSection(
                "Partner types",
                "How partners work with us",
                null,
                [
                    new ContentItem("Implementation partners", "Regional and process specialists who run rollouts, change management and support.", "users"),
                    new ContentItem("Technology partners", "ERP, workflow and integration platforms whose connectors ship with Polypus.", "plug"),
                    new ContentItem("Certification", "A documented enablement path with joint delivery standards and support escalation agreements.", "shield-check")
                ])
        ]
    };

    public static readonly ContentPageModel Security = new()
    {
        Section = "Company / Security",
        Eyebrow = "Company",
        Title = "Security, compliance and controls",
        Lead = "Polypus maintains ISO 27001 certification and SOC 2 Type II attestation, is HIPAA, " +
               "GDPR and CCPA-compliant, and its cloud services sit on a STAR Level 1 Registry.",
        MetaDescription = "ISO 27001 certification, SOC 2 Type II attestation and data residency " +
                          "options for the Polypus platform.",
        Pills = ["ISO 27001", "SOC 2 Type II", "GDPR", "Data residency"],
        Sections =
        [
            new ContentSection(
                "Certifications",
                "Independently verified",
                null,
                [
                    new ContentItem("ISO 27001", "An information security management system audited annually by an external body.", "shield-check"),
                    new ContentItem("SOC 2 Type II", "Controls tested over a period, covering security, availability and confidentiality.", "check-circle"),
                    new ContentItem("GDPR, HIPAA and CCPA", "Data handling aligned to the regimes our customers operate under.", "lock")
                ]),
            new ContentSection(
                "Controls",
                "Built for auditors",
                null,
                [
                    new ContentItem("Audit trail", "Every decision records what the agent read, what it decided and what the system of record did.", "history"),
                    new ContentItem("Data residency", "Choose the region your tenant, documents and derived data live in.", "globe"),
                    new ContentItem("Access control", "Scoped credentials per tenant with rotation and a full call log.", "lock")
                ])
        ]
    };

    // ---------------------------------------------------------------------
    // Integration connectors
    // ---------------------------------------------------------------------

    public static readonly ContentPageModel SapConnector = new()
    {
        Section = "Platform / Integrations / SAP",
        Eyebrow = "Integrations / SAP",
        Title = "SAP x Polypus",
        Lead = "The Polypus SAP connector is an SAP-certified add-on that integrates with your SAP " +
               "system to deliver autonomous accounts payable processes, master data management and " +
               "advanced document processing.",
        MetaDescription = "The SAP-certified Polypus connector for autonomous accounts payable, " +
                          "master data management and document processing.",
        Sections =
        [
            new ContentSection(
                "How it works",
                "Four modules, used independently or together",
                null,
                [
                    new ContentItem("Master Data Integration", "Sync vendor and company code master data with Polypus for accurate invoice coding, supplier and customer data validation.", "layers"),
                    new ContentItem("Document Workflow", "Fetch the AP documents processed by Polypus and hand them over to the accounts payable workflow to trigger auto-posting or handle via review.", "flow"),
                    new ContentItem("Purchase Order Integration", "Automatically transfer PO data for enhanced line-item matching and reconciliation.", "check-circle"),
                    new ContentItem("Posting Data Integration", "No need to collect posting and archive data or build a complex integration process. The connector takes care of all of it.", "plug"),
                    new ContentItem("Constant Feedback Loop", "A feedback cycle monitors processed documents until posting in SAP. After posting, changes made in the AP workflow flow back to improve accuracy over time.", "history")
                ]),
            new ContentSection(
                "Why Polypus for SAP",
                "Accuracy and governance",
                null,
                [
                    new ContentItem("Better accuracy", "Automatically match data against vendor records, purchase orders and previous invoices to reduce errors and avoid costly discrepancies.", "check-circle"),
                    new ContentItem("Less risk", "Postings follow the procedures your organization already has in place, with the SAP response attached to every failure.", "shield-check"),
                    new ContentItem("Secure and compliant", "ISO 27001 certification, SOC 2 Type II attestation, HIPAA, GDPR and CCPA compliance, and cloud services on a STAR Level 1 Registry.", "lock")
                ])
        ]
    };

    public static readonly ContentPageModel CoupaConnector = new()
    {
        Section = "Platform / Integrations / Coupa",
        Eyebrow = "Integrations / Coupa",
        Title = "Coupa x Polypus",
        Lead = "Polypus agents for invoice processing are Coupa-certified and ready to enhance your " +
               "accounts payable workflows.",
        MetaDescription = "The Coupa-certified Polypus connector for invoice processing, duplicate " +
                          "check and accounting coding.",
        Sections =
        [
            new ContentSection(
                "How it works",
                "From document to Coupa workflow",
                null,
                [
                    new ContentItem("Supplier Document Capture", "Process and categorize invoices, credit notes and payment reminders within Coupa, extracting line items and custom fields in any language.", "scan"),
                    new ContentItem("Duplicate Check", "Identify duplicate invoices based on file content, with flexible criteria to prevent errors before they occur.", "check-circle"),
                    new ContentItem("Fraud Detection", "Detect and flag fraudulent invoices before they enter the Coupa workflow, including supplier validation and PO cross-checking.", "shield-check"),
                    new ContentItem("Accounting Coding", "Predict and populate accounting dimensions such as GL accounts, cost centres and projects for non-PO invoices.", "chart"),
                    new ContentItem("PO Matching & Reconciliation", "Perform advanced 2-way PO line matching, pre-populating the posting lines needed to complete a 3-way match.", "layers"),
                    new ContentItem("Master Data Matching", "Automatically assign company codes, legal entities and supplier master data, even when documents deviate significantly.", "users")
                ]),
            new ContentSection(
                "Why Polypus for Coupa",
                "Faster, more accurate handling",
                null,
                [
                    new ContentItem("Faster processing", "Eliminate manual tasks with AI-driven invoice processing, ensuring rapid approvals and smooth payments.", "flow"),
                    new ContentItem("Improved accuracy", "Leverage synchronized master and transactional data to enhance predictions and reduce coding errors.", "check-circle"),
                    new ContentItem("Seamless automation", "A two-way data exchange that reduces bottlenecks and increases efficiency.", "plug")
                ])
        ]
    };

    public static readonly ContentPageModel WorkdayConnector = new()
    {
        Section = "Platform / Integrations / Workday",
        Eyebrow = "Integrations / Workday",
        Title = "Workday x Polypus",
        Lead = "Integrate Polypus agents into your Workday financial management system. With " +
               "certified, two-way integration, the connector turns document and accounts payable " +
               "workflows into a fully automated, intelligent process.",
        MetaDescription = "The certified two-way Polypus connector for Workday financial management.",
        Sections =
        [
            new ContentSection(
                "How it works",
                "Two-way integration",
                null,
                [
                    new ContentItem("Invoice Processing & Export", "Documents processed by an agent are enriched, validated and exported seamlessly to Workday.", "scan"),
                    new ContentItem("Master Data Enrichment Workflow", "Automatically sync supplier and organizational data from Workday to enrich invoice coding and supplier predictions.", "users"),
                    new ContentItem("Posting Data Integration", "Transfer posting data from Workday to support model self-improvement for cost centres, spend categories and other attributes.", "plug"),
                    new ContentItem("PO Matching & Reconciliation", "Extract PO numbers and invoice lines, match them against PO data and handle deviations like partial fulfilment or price changes.", "layers"),
                    new ContentItem("Document Archiving", "Archive original invoices securely and generate accessible URLs for retrieval and audit compliance.", "lock")
                ]),
            new ContentSection(
                "Why Polypus for Workday",
                "Control and audit readiness",
                null,
                [
                    new ContentItem("Accelerated workflows", "Eliminate manual tasks with automated invoice processing, enrichment and export.", "flow"),
                    new ContentItem("Data-driven accuracy", "Leverage synchronized master and posting data to ensure precise coding and supplier validation.", "check-circle"),
                    new ContentItem("Compliance and audit readiness", "Securely archive documents and streamline audits with instant access to organized, audit-ready data.", "shield-check")
                ])
        ]
    };

    public static readonly ContentPageModel XsuiteConnector = new()
    {
        Section = "Platform / Integrations / xSuite",
        Eyebrow = "Integrations / xSuite",
        Title = "xSuite x Polypus",
        Lead = "Remove bottlenecks and manual effort when processing even the most complex invoices " +
               "with the combined power of xSuite and Polypus. Make best-in-class AI the most " +
               "trusted sidekick of business services teams.",
        MetaDescription = "The Polypus connector for xSuite: intelligent extraction, matching and " +
                          "coding for complex invoices.",
        Sections =
        [
            new ContentSection(
                "How it works",
                "Intelligent handling of complex invoices",
                null,
                [
                    new ContentItem("Intelligent Data Extraction", "Extract header and line-item details from invoices with market-leading accuracy, regardless of format or supplier.", "scan"),
                    new ContentItem("Invoice Classification", "Identify document type, company code and target system while routing non-AP documents to the right teams.", "layers"),
                    new ContentItem("Matching & Validation", "Match PO invoices with purchase orders, validate supplier details and detect duplicates or errors before they enter the workflow.", "check-circle"),
                    new ContentItem("Coding & Approval Routing", "Apply GL account coding, tax categorization and approver assignment using AI-driven predictions.", "chart"),
                    new ContentItem("ERP Integration & Compliance", "Hand validated invoices directly to ERP systems such as SAP and Workday, with audit-ready tracking and real-time analytics.", "plug")
                ]),
            new ContentSection(
                "Why Polypus for xSuite",
                "Beyond rule-based automation",
                null,
                [
                    new ContentItem("Complex transactions made easy", "Handle complex tasks where traditional systems fall short: accounting coding, PO line matching, tax compliance and fraud detection, without re-training.", "sparkle"),
                    new ContentItem("Superb accuracy", "Leverage synchronized master and transactional data to reduce errors in invoice coding and PO matching.", "check-circle"),
                    new ContentItem("Global and scalable", "No model training barriers to achieving high automation rates across multiple languages and regions.", "globe")
                ])
        ]
    };

    public static readonly ContentPageModel Gartner = new()
    {
        Section = "Resources / Gartner",
        Eyebrow = "Recognition",
        Title = "Named a 2026 Gartner® Magic Quadrant™ Visionary for IDP solutions",
        Lead = "Polypus is recognized in the 2026 Gartner® Magic Quadrant™ for Intelligent Document " +
               "Processing (IDP) Solutions as a Visionary - a position we believe reflects our bold " +
               "architectural approach, vertical strategy and strong partner execution across global " +
               "business services organizations.",
        MetaDescription = "Polypus is named a 2026 Gartner Magic Quadrant Visionary for Intelligent " +
                          "Document Processing solutions.",
        Sections =
        [
            new ContentSection(
                "About the report",
                "What the Magic Quadrant measures",
                "Magic Quadrant reports are a culmination of rigorous, fact-based research in specific " +
                "markets, providing a wide-angle view of the relative positions of the providers in " +
                "markets where growth is high and provider differentiation is distinct.",
                [
                    new ContentItem("Report", "Gartner®, Magic Quadrant™ for Intelligent Document Processing Solutions, published 10 September 2026.", "chart"),
                    new ContentItem("Trademark notice", "GARTNER and MAGIC QUADRANT are registered trademarks of Gartner, Inc. and/or its affiliates and are used with permission. All rights reserved.", "shield-check"),
                    new ContentItem("Disclaimer", "Gartner does not endorse any vendor, product or service depicted in its research publications, and does not advise technology users to select only those vendors with the highest ratings.", "alert")
                ])
        ]
    };
}
