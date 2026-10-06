using Polypus.Web.Models;

namespace Polypus.Web.Services;

/// <summary>
/// The long-form FAQ page: eight groups of questions, some with connector sub-sections.
/// Generated from the reference FAQ so the table of contents and the groups stay in step.
/// </summary>
public static class FaqPageCatalog
{
    /// <summary>All groups, in page order. The table of contents is derived from these.</summary>
    public static readonly IReadOnlyList<FaqGroup> Groups =
    [
        new FaqGroup
        {
            Title = "Product & Platform Basics",
            Subs =
            [
                new FaqSubGroup
                {
                    SubTitle = null,
                    Items =
                    [
                        new FaqEntry
                        {
                            Question = "How is Polypus different from other automation tools on the market?",
                            Paragraphs = ["Polypus distinguishes itself from other automation tools in several keyways:"],
                            Bullets = ["Exceptional automation rates powered by deep learning algorithms.", "Comprehensive end-to-end automation capabilities that go beyond simple capturing, making it the premier AI capturing solution.", "Built-in integrations with industry-leading platforms such as SAP, Coupa, and Workday for seamless workflow integration.", "Utilization of cutting-edge technology, including Large Language Models (LLMs), to specialize in Accounts Payable processing, surpassing traditional ensemble models.", "Pioneering advancements in complex accounting operations, leveraging generative AI to enhance both speed and accuracy."]
                        },
                        new FaqEntry
                        {
                            Question = "How can Polypus transform my finance function?",
                            Paragraphs = ["Polypus can revolutionize your finance function by providing advanced data for seamless backend processing, eliminating the need for manual setup or training, thereby alleviating concerns about time constraints. It allows for human validation when necessary while autonomously learning from each interaction, accelerating overall success.", "Critical financial documents are effortlessly integrated into existing ERP or CRM workflows, processed with nearly 100% accuracy, and human intervention is only required for decision-making. With the capability to consistently process large volumes of documents, Polypus ensures high data quality and eradicates backlogs, resulting in enhanced consistency, accuracy, and control while reducing operational costs and delivering immediate ROI.", "Ultimately, Polypus mitigates business risks, enhances profitability, and liberates resources for strategic endeavors like data analysis, decision-making, and operational enhancements."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "Is human intervention required when processing documents with Polypus?",
                            Paragraphs = ["Human intervention can be required, but is by no means mandatory. What determines the need of human intervention is the required set of validations per document and use case. More complex (sets of) validations increase the probability of a validation rule running into an error, which may require a human to be looped in for validation, either in Polypus Studio or in a downstream system.", "As an example, when extracting and validating both header and line items level data for a standard Accounts Payable use case, validating all legal requirements, we expect an autocompletion rate (no human intervention required) of around 90% of total document volume."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "What are the requirements to use Polypus?",
                            Paragraphs = ["Using Polypus is hassle-free! Polypus Studio works in the cloud, so there are no special requirements on your end. It's user-friendly and no complex installations needed. However, integration with the system may have its own prerequisites. We love crafting tailored solutions for our significant clients. If you're into using our API, check out our detailed documentation here. It's your go-to guide for understanding how to use our platform programmatically."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "What document formats are supported by Polypus?",
                            Paragraphs = ["As a versatile document processing tool Polypus can save time and resources by automating data extraction from diverse documents, reducing errors and improving overall productivity.", "Polypus supports a wide range of document formats, making it a multi-faceted solution for businesses across various industries. Some of the key document formats supported by Polypus include:"],
                            Bullets = ["PDF: PDF is one of the most commonly used document formats for sharing information. Polypus can extract data from both text-based and scanned PDFs, allowing organizations to work with a vast repository of documents seamlessly.", "DOCX (Microsoft Word Document): DOCX files are frequently used for text-based documents. Polypus can extract information from these files, enabling businesses to analyze data within Word documents efficiently.", "JPEG and PNG Images: Polypus has OCR (Optical Character Recognition) capabilities that enable it to extract text from image files. This is particularly useful for scanned documents, receipts, or invoices in image formats.", "TIFF (Tagged Image File Format): TIFF is a common format for scanned documents and images. Polypus can extract data from TIFF files, enhancing its versatility for processing scanned documents.", "Email Attachments: Polypus can extract information from email attachments in various formats, such as PDFs, Word documents, or spreadsheets.", "Custom Formats: Polypus offers flexibility by allowing organizations to define custom document formats. This capability is especially valuable for businesses with unique document templates or specialized requirements."]
                        },
                    ]
                },
            ]
        },
        new FaqGroup
        {
            Title = "Integrations & Connectors",
            Subs =
            [
                new FaqSubGroup
                {
                    SubTitle = null,
                    Items =
                    [
                        new FaqEntry
                        {
                            Question = "What kind of different connectors does Polypus offer?",
                            Paragraphs = ["Polypus simplifies integration into your existing core systems, allowing you to focus more on automating document processing and less on integration challenges."],
                            Bullets = ["SAP: The Polypus SAP Connector is a SAP® certified add-on installable within your SAP system.", "Coupa: Coupa is a comprehensive Invoicing Management platform enhanced by Polypus' cloud-based connector. The integration brings precision to master data matching, automated line matching, and attribute prediction, contributing to increased efficiency and cost savings.", "Workday: The Polypus Workday Integration is a two-way connection facilitated by a standardized connector. It serves various purposes, including Invoice Export, Master Data Integration, Posting Data Integration, and Invoice Archiving. This integration streamlines document processing, enhances data enrichment, and ensures compliance with audit and regulatory requirements.", "Boomi: The Polypus Boomi Connector is a partner connector designed to seamlessly integrate Polypus platforms with Boomi's Integration platform. It empowers users to connect their core systems, such as ERP, P2P, and BSM, with Polypus' AI and ML-driven document processing capabilities, ensuring highly accurate end-to-end automation."]
                        },
                    ]
                },
                new FaqSubGroup
                {
                    SubTitle = "SAP",
                    Items =
                    [
                        new FaqEntry
                        {
                            Question = "Why should I install and use the Polypus SAP Connector?",
                            Paragraphs = ["Polypus, machine learning company, customizes models for individual customers, requiring substantial data and regular updates. The Polypus SAP Connector streamlines this process by automating the integration between your SAP system and the Polypus Cloud. This eliminates the need for manual data exchange, sparing you from data quality issues associated with manual exports.", "The SAP Connector ensures seamless communication with Polypus APIs, collecting, transforming, and syncing data effortlessly. It keeps pace with Polypus' evolving features, requiring only an update rather than a complete overhaul of custom integrations. Beyond its impact on machine learning services, the SAP Connector simplifies master data integration for enrichment services. Moreover, if you're seeking a hassle-free way to collect processed documents from Polypus into your SAP system, the Inbound Document Integration module has you covered. With minimal configuration, you can avoid building a custom integration.", "In essence, the Polypus SAP Connector is the key to maximizing the potential of Polypus' services without burdening your IT team with extensive integration efforts."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "Can the Polypus SAP Connector be configured to meet specific requirements?",
                            Paragraphs = ["Absolutely. It offers three modules:", "They can be used independently or in combination. Depending on your setup, Polypus will provide the appropriate transport for installation in your SAP system, ensuring flexibility in meeting your specific requirements."],
                            Bullets = ["Master Data Integration: Transfers vendor and company code master data to Polypus Studio for master data prediction services.", "Inbound Document Integration: Collects document data from Polypus Studio, making it available in SAP for further processing.", "Outbound Document Integration: Transfers document data from SAP to Polypus for attribute prediction model training."]
                        },
                        new FaqEntry
                        {
                            Question = "Does the Polypus SAP Connector have any impact on my SAP updates?",
                            Paragraphs = ["No, the Polypus SAP Connector does not impact any SAP updates. We are not modifying or enhancing any SAP standard objects or functionality. The Connector is only used for communication with the Polypus APIs. The only exception is, if you are upgrading from SAP ECC to S4H, the S4H compatible version of the Connector needs to be installed."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "How frequently does Polypus release an updated version of the SAP Connector?",
                            Paragraphs = ["Polypus releases a new version of the Connector approximately every quarter. In between releases you might occasionally see small service pack releases."],
                            Bullets = []
                        },
                    ]
                },
                new FaqSubGroup
                {
                    SubTitle = "Coupa",
                    Items =
                    [
                        new FaqEntry
                        {
                            Question = "How does Polypus complement Coupa Invoicing Management?",
                            Paragraphs = ["Polypus offers a cloud-based connector that enhances Coupa in two key ways."],
                            Bullets = ["It strengthens Coupa as a source of truth for vital supply chain transactions and utilizes it as a source of master data.", "Polypus ingests, extracts, and enriches data from processed invoices, leveraging its trained models, and shares this enhanced data back to Coupa for accelerated downstream automation."]
                        },
                        new FaqEntry
                        {
                            Question = "What is the integration overview for Polypus and Coupa?",
                            Paragraphs = ["Polypus offers a two-way integration with Coupa through a standardised, cloud-based connector comprising specific modules designed for the transfer of:", "Moreover, our connector not only handles processed document data but also efficiently transfers document image scans to Coupa. These modules offer the flexibility to be utilised stand-alone or in combination, providing flexibility in integration."],
                            Bullets = ["Reference Data: Supplier reference data; Remit-to address reference data", "Transactional Data: Purchase order transactional data"]
                        },
                        new FaqEntry
                        {
                            Question = "How does the end-to-end integration flow between Coupa and Polypus work?",
                            Paragraphs = ["Polypus connector for Coupa utilizes JSON REST APIs for communication with Coupa and Polypus respective services. More specifically:"],
                            Bullets = ["The Coupa Core API is used for creating and submitting invoices in Coupa, as well as retrieving reference and transactional data from it.", "Polypus Documents API is used for fetching processed documents data from Polypus Studio.", "Polypus Files API is used for fetching documents image scans from Polypus Studio.", "Polypus Enrichment API is used for maintaining reference and transactional data records in Polypus Enrichment Service."]
                        },
                    ]
                },
                new FaqSubGroup
                {
                    SubTitle = "Workday",
                    Items =
                    [
                        new FaqEntry
                        {
                            Question = "What is the main purpose of the Polypus integration with Workday?",
                            Paragraphs = ["The primary goal of the integration is to streamline and enhance the processing of financial documents. Polypus facilitates the extraction, normalization, enrichment, and validation of documents in its Studio. Completed documents, including Purchase Orders (PO), non-PO related documents, and credit notes, are seamlessly transferred to Workday for further processing through our connector, ensuring efficient and accurate data flow, including the transfer of document images."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "What are the Workday fields the connector is currently considering?",
                            Paragraphs = ["The Workday fields in this document transfer and data population process include Invoice Date, Currency, Supplier's Invoice Number, Payment Type, Accounting Date Override, Remit-To Connection, Company, Supplier, Ship-To Address, and others. These fields are populated based on specific business logic and validation rules, as detailed in the provided information."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "How does the Master Data Integration work within the Polypus and Workday integration?",
                            Paragraphs = ["It's a daily process that fetches supplier details from Workday. This data enhances document processing in Polypus Studio for better Supplier and Company Code prediction."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "How does Document Archiving and Export work in the integration?",
                            Paragraphs = ["This is an asynchronous process that runs in more frequent intervals (every 1 minute) and is responsible for archiving and export of processed documents. Completed documents are fetched from Polypus Studio, archived and then transferred to Workday. The success of these transfers is reflected in the updated document status, while any failures are appropriately flagged with error messages for correction."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "What data does the Polypus Workday connector transfer to Workday?",
                            Paragraphs = ["It transfers a comprehensive set of information, including invoice header details, line items, enriched invoice data, predicted attributes, and the original document image processed in Polypus Studio. The transfer process is customized depending on whether a Purchase Order (PO) number is extracted from the document."],
                            Bullets = []
                        },
                    ]
                },
                new FaqSubGroup
                {
                    SubTitle = "Boomi",
                    Items =
                    [
                        new FaqEntry
                        {
                            Question = "What operations can I perform with the Polypus Boomi Connector?",
                            Paragraphs = ["The Polypus Boomi Connector allows users to perform various operations, including uploading and downloading documents to/from Polypus Studio, retrieving document processing results and images, and synchronizing master data records in Polypus Enrichment Service."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "What components need to be configured to communicate with Polypus using the connector?",
                            Paragraphs = ["To configure the connector, users need to set up two components:", "These components contain connection settings and operation settings, providing a modular and reusable configuration."],
                            Bullets = ["Polypus.ai – Partner connection", "Polypus.ai – Partner operation"]
                        },
                        new FaqEntry
                        {
                            Question = "What versions of Polypus REST API are supported?",
                            Paragraphs = ["The Polypus.ai – Partner connector supports Polypus REST API version 2. Users should ensure compatibility with their specific edition for seamless integration."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "What prerequisites do I need to use the Polypus Boomi Connector?",
                            Paragraphs = ["To use the connector within the Boomi Integration platform, you must first have acquired your Polypus API client ID and secret for OAuth2.0 authorization and defined the respective API access rights and permissions to your Polypus Studio projects."],
                            Bullets = []
                        },
                    ]
                },
            ]
        },
        new FaqGroup
        {
            Title = "Implementation & Support",
            Subs =
            [
                new FaqSubGroup
                {
                    SubTitle = null,
                    Items =
                    [
                        new FaqEntry
                        {
                            Question = "In which language is the Service Support provided?",
                            Paragraphs = ["The Service Support is primarily provided in English, since our company and contract language is English. However, as an international company with professionals around the world, we strive to accommodate requests in other languages whenever possible while maintaining English as our primary language."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "How long does it take to implement Polypus?",
                            Paragraphs = ["The Polypus Solution offers an integrated ecosystem of tools designed to streamline the integration process for you through API connectivity. Our projects follow a structured approach, starting with the Assessment and Design phase where we gather requirements, followed by the implementation of the tailored solution and rigorous SIT/UAT validation. Concurrently, we provide comprehensive user training and support to facilitate your change management process.", "While each project is unique, the time to Go Live typically ranges from 2 to 6 months, contingent upon factors such as the complexity of your use cases, business logic, functional and technical requirements, as well as the availability of your teams."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "Is there any training or onboarding support available for new users of Polypus?",
                            Paragraphs = ["Absolutely! We offer training through Polypus Academy, a dedicated platform designed for users to master Polypus Studio."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "What is Polypus Academy?",
                            Paragraphs = ["Polypus Academy is a user-friendly learning hub crafted to provide the skills and knowledge needed for effective use of Polypus Studio.", "What to expect: Two learning paths cater to specific user roles:", "Key Benefits:", "Learning Path Customization: Choose Admin or Key User path based on your responsibilities.", "Interactive Learning Approach: Quizzes, playground activities, and assignments for hands-on learning.", "Completion Requirements:", "Elevate your expertise with Polypus Academy – practical, efficient, and tailored for you!"],
                            Bullets = ["Polypus Studio - Admin User (285 Minutes)", "Polypus Studio - Key User (175 Minutes)", "Gain confidence in using Polypus Studio for real-world scenarios.", "Learn to navigate the software with ease, minimizing errors and maximizing productivity.", "Successfully finish all courses.", "Achieve at least 80% on quizzes and assessments.", "Complete a minimum of 80% of practical activities."]
                        },
                    ]
                },
            ]
        },
        new FaqGroup
        {
            Title = "Contracts & Legal",
            Subs =
            [
                new FaqSubGroup
                {
                    SubTitle = null,
                    Items =
                    [
                        new FaqEntry
                        {
                            Question = "What does the contract consist of?",
                            Paragraphs = ["Our contracts are concluded by means of an Order Form which contains all necessary Annexes such as Terms & Conditions, Data Processing Agreement, Service Level Agreements and Feature List. Our Terms and Conditions are available under the following link: https://www.Polypus.ai/general-terms-and-conditions. Our Data Processing Agreement is available under the following link: https://www.Polypus.ai/data-processing-agreement."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "Can I try Polypus before I commit to a full deployment?",
                            Paragraphs = ["Absolutely! Our Proof of Value (PoV) contract allows you to try out our product before making a commitment to a full deployment. Think of it as a test phase where you can experience the benefits of our product firsthand. This trial period enables you to assess whether our software meets your needs and delivers the value you’re looking for before making a decision to move forward with a larger implementation."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "Can I negotiate the Terms and Conditions?",
                            Paragraphs = ["While we strive to accommodate your needs to the best of our ability, certain terms and conditions may not be negotiable due to legal or regulatory requirements. However, we are open to discussing specific aspects of the agreement to ensure it aligns with your needs and expectations. Please feel free to reach out to us to discuss any concerns or questions you may have regarding the Terms and Conditions."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "Which law applies to our contracts?",
                            Paragraphs = ["Our contracts will be ruled by German law."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "Who gets access to the Polypus Platform?",
                            Paragraphs = ["Only you as the customer are granted access to the Polypus Platform. Depending on the number of user seats purchased, several users to be determined by you will receive an account."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "How can I terminate my contract with Polypus?",
                            Paragraphs = ["The minimum term of our contracts is generally 36 months. That ensures price stability, allows for efficient resource planning, and ensures consistent customer support. After that, your contract is automatically extended by 12 months if you don’t terminate it 30 days before the end of the current term."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "How can Polypus terminate the contract?",
                            Paragraphs = ["Polypus can terminate (i) If there's a material breach of contract by the Customer, unremedied for 30 days after written warning, (ii) If the Customer defaults on payments for over six weeks, after giving written or text notice two weeks prior, (iii) if Polypus provide notice of termination 30 days before the end of the current term."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "What happens to my data after termination?",
                            Paragraphs = ["Customer data is deleted within 14 days following contract termination or a data deletion request."],
                            Bullets = []
                        },
                    ]
                },
            ]
        },
        new FaqGroup
        {
            Title = "Pricing & Billing",
            Subs =
            [
                new FaqSubGroup
                {
                    SubTitle = null,
                    Items =
                    [
                        new FaqEntry
                        {
                            Question = "How is a standard Polypus solution priced?",
                            Paragraphs = ["Standard Workforce solutions — Invoice Processing, Order Management, Order Confirmations, Delivery Notes — come with pre-packaged GBS Skills, priced according to their complexity. Each time a GBS Skill is applied to complete a job for a document (e.g., validate, match, etc.), the corresponding cost is incurred. A full breakdown of your Solution pricing is available in your Quote or Contract documentation."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "What is the price for the bespoke Polypus solutions?",
                            Paragraphs = ["Polypus offers bespoke solutions for non-standardized use cases, such as Cash Application, Dispute Management, Contract Accounting or a Build Your Own option. These run in production on an annual credit subscription with five tiers to choose from. Unused credits roll over to the following year for the duration of your contract. Talk to your CSM or AM to learn more."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "How can I explore the pricing options?",
                            Paragraphs = ["Reach out to us and we will walk you through the calculations."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "Can Polypus change its prices?",
                            Paragraphs = ["Polypus may adjust its prices:", "During the contract term, only if there's a significant increase in the wage cost index for IT services in Germany compared to the start of the contract. Any price adjustments will be communicated to you at least three months in advance and will take effect at the start of the next contract year.", "At the end of the initial contract term and at the end of each renewal term, provided at least two months notice is given to you before the end of the current term."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "What if I pay my invoice later?",
                            Paragraphs = ["If the payment deadline is missed, we may charge interest at the standard rate. Additionally, if you are consistently late with payments, we may temporarily block your access to the software. If your payments are overdue for more than six weeks and we have tried everything possible to come to an agreement with you, we may also terminate an Order Form as last resort. We hope that will never be necessary."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "Are the processed documents calculated by page or by document?",
                            Paragraphs = ["Processed documents are calculated by the document number."],
                            Bullets = []
                        },
                    ]
                },
            ]
        },
        new FaqGroup
        {
            Title = "Data, Security & Compliance",
            Subs =
            [
                new FaqSubGroup
                {
                    SubTitle = null,
                    Items =
                    [
                        new FaqEntry
                        {
                            Question = "How do I ensure the security of sensitive documents when using Polypus?",
                            Paragraphs = ["We are highly committed to transparency and building trust with our customers offering you comprehensive information and assurance regarding our ability to safeguard your data. Here you can find our compliance documentation and overview of security controls.", "Polypus is ISO 27001 certified and compliant with SOC 2, HIPAA and GDPR. Our enterprise-grade cloud service has been developed for high availability, with SLAs of up to a 99.5% uptime guarantee."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "Where will customer data be processed?",
                            Paragraphs = ["Polypus hosts its cloud services on servers provided by Amazon Web Services (AWS). Customers can select between two AWS Regions for hosting their data based on data residency requirements:"],
                            Bullets = ["eu-west-1 (Europe - Ireland)", "us-east-1 (US - N.Virginia)"]
                        },
                        new FaqEntry
                        {
                            Question = "Do you provide Service Level Agreements (SLAs) for availability your cloud services?",
                            Paragraphs = ["Polypus commits to offer availability Service Level Agreements (SLAs) between 98% and 99.5% depending on the subscription plan selected by the customer."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "What are the Recovery Time Objective (RTO) and Recovery Point Objective (RPO) for your cloud services?",
                            Paragraphs = ["We have established the following RTO and RPO targets for Polypus Cloud:"],
                            Bullets = ["RTO: 24 hours", "RPO: 6 hours"]
                        },
                        new FaqEntry
                        {
                            Question = "Do you maintain a detailed list of implemented security measures?",
                            Paragraphs = ["Yes, please refer to our CAIQ which is available in the Documents section of our Trust Report.", "Find further information here: Polypus Trust Center & Security | Polypus."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "What kind of customer data do Polypus collect?",
                            Paragraphs = ["Polypus collects two main categories of customer data:", "Personal User Data: This includes information about users themselves, such as their name, address, communication details like phone numbers and email addresses, electronic communication data like IP addresses and device information, and log data.", "Personal Document Data: This encompasses personal data of individuals mentioned in documents processed through Polypus’ services. This can include information like person master data (name, address) and any other personal data contained within the documents provided by the customer. Additionally, account master data such as bank details are also collected, but specifically under Personal Document Data."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "How does Polypus respond to data breaches or security incidents?",
                            Paragraphs = ["We have established a Security Breach Policy which outlines processes for security breach notifications. You are notified of security breaches impacting your data within 72 hours of discovery. When appropriate, incidents are reported to relevant authorities."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "What is the duration for which customer data is retained, and what is the process for data deletion?",
                            Paragraphs = ["Customer data is retained for the full duration of the contract for the purpose of AI model retraining."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "How is customer consent obtained for data processing activities?",
                            Paragraphs = ["Customer consent for data processing activities is formalized through a Data Processing Agreement (available here)."],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "What is the European Union's AI Act and what are it's key points and implications?",
                            Paragraphs = ["At Polypus we provide AI agents designed for efficient processing of high volumes of documents and we recognize our responsibility. Protecting our customers is a priority for us and that's why we generally embrace the introduction of new legal regulations.", "The European Union achieved a significant milestone by endorsing the AI Act, marking the first legislative effort to govern the widely debated realm of artificial intelligence (AI), which holds the potential to transform our daily lives.", "The AI Act defines artificial intelligence systems in alignment with internationally recognized criteria, drawing inspiration from OECD guidelines. It broadly categorizes AI systems as machine-based entities that deduce outputs, explicitly or implicitly, to influence physical or virtual environments based on received input for specific objectives. While encompassing various sectors, the AI Act exempts certain applications, such as military and defense, and distinguishes between the professional and personal use of AI.", "Questions can be directed to legal@Polypus.ai."],
                            Bullets = []
                        },
                    ]
                },
            ]
        },
        new FaqGroup
        {
            Title = "Partnerships",
            Subs =
            [
                new FaqSubGroup
                {
                    SubTitle = null,
                    Items =
                    [
                        new FaqEntry
                        {
                            Question = "Which partnerships options does Polypus offer?",
                            Paragraphs = ["Polypus values collaboration with professional partners. The partnership options available include:"],
                            Bullets = ["Referral: Partners can refer potential clients to Polypus and earn revenue for successful referrals.", "Resale: Partners have the opportunity to sell Polypus’ products or services directly to their customers and earn revenue through sales.", "Technology: Partners can integrate their technology solutions with Polypus’ offerings to provide enhanced solutions to mutual customers.", "Managed Services: Partners can collaborate with Polypus to provide comprehensive managed services to clients, leveraging expertise and resources."]
                        },
                    ]
                },
            ]
        },
        new FaqGroup
        {
            Title = "Using Polypus Studio (How-To)",
            Subs =
            [
                new FaqSubGroup
                {
                    SubTitle = null,
                    Items =
                    [
                        new FaqEntry
                        {
                            Question = "How do I reset my password?",
                            Paragraphs = ["If a user uses the wrong email address and password combination or the user doesn't exist in the database the log-in attempt fails.", "The user can request a link to reset their password by following 'Forget password':", "The user can request a password reset link after adding a valid email address:", "Only users that exist in the database actually receive an email:", "The user can set a new password:", "The UI signals the successful change of the password and the user receives a confirmation via email:"],
                            Bullets = []
                        },
                        new FaqEntry
                        {
                            Question = "How do I upload a new document to Studio?",
                            Paragraphs = ["Polypus studio offers upload via UI or API and supports a variety of different file types: PDF, TIFF, JPEG, and PNG.", "Manual Upload:", "You can also use the Upload button in the top right corner when inside a project", "Email Service: You can upload files to each project using our email service. At this point, we are supporting TIFF and PDF files. To use this service, simply send or forward emails with attachments to the correct email address. The email address can be copied from Polypus Studio:", "On-Prem Document Collection: Our on-prem document collection agent is a Java app that integrates on-premise servers with Studio via REST API. It supports our standard file types PDF, TIFF, JPEG & JSON, as well as JSON so that external data can be added to the metadata of a document. In order for this to work, the main file and JSON file have to be named, except for the extension, exactly the same. Files are added to the Input folder, where the agent collects them from. Depending on the status, files are moved to the folder Processing, Success or Error.", "Contact us and our team will get back to you."],
                            Bullets = []
                        },
                    ]
                },
            ]
        },
    ];
}
