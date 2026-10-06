namespace Polypus.Web.Models;

/// <summary>
/// Static company facts for Axonite, the company that owns Polypus.
/// Everything the site says about the company lives here so it can be edited in one place.
/// </summary>
public static class CompanyProfile
{
    public const string Name = "Axonite";

    public const string LegalName = "Axonite Technologies Pvt. Ltd.";

    public const string Tagline = "Enterprise automation, delivered with controls your finance team signs off on.";

    public const string ShortAbout =
        "Axonite is an enterprise automation company. Since 2026 we have built document, " +
        "workflow and SAP integration systems for finance and supply-chain teams in manufacturing, " +
        "logistics and food processing.";

    public static readonly IReadOnlyList<string> Story =
    [
        "Axonite started as four engineers fixing a single problem: shared service centres were " +
        "re-keying millions of documents into SAP by hand, and every attempt to automate it broke " +
        "the moment a supplier changed their invoice layout.",

        "Polypus is the product that came out of that work. It pairs a layout-aware document " +
        "pipeline with governed SAP posting, so the automation is measured in postings that passed " +
        "your controls - not in demo accuracy percentages.",

        "We ship deliberately slowly. Pilots run in shadow mode against your real documents before " +
        "anything is written to production, and every release can be replayed against historical runs."
    ];

    public const string FounderQuote =
        "The technology was never the hard part. Getting a controller to trust an automated posting " +
        "on a Tuesday afternoon is the hard part - so we built the audit trail first and the " +
        "automation second.";

    public const string FounderName = "Subodh Mahante";

    public const string FounderRole = "Co-founder & Chief Executive Officer";

    public static readonly IReadOnlyList<Stat> Facts =
    [
        new("2026", "Founded"),
        new("Pune, Gurgaon, Nashik", ""),
        new("11", "Engineers and specialists"),
        new("3", "Enterprise deployments")
    ];

    public static readonly IReadOnlyList<Office> Offices =
    [
        new("Pune", "India", "3rd Floor, Lunawat Reality, Paud Road, Opp. Vanaz Factory, Kothrud, Pune, Maharashtra 411038", "Headquarters "),
        new("Gurgaon", "India", "", "Delivery & customer operations"),
        new("Nashik", "India", "", "Delivery & customer operations")
    ];

    public const string SalesEmail = "sales@axonite.io";

    public const string SupportEmail = "support@axonite.io";

    /// <summary>General enquiries address shown in the site header.</summary>
    public const string InfoEmail = "info@axonite.net";

    public const string Phone = "+91 20 4850 1200";

    public const string SupportHours = "Mon - Fri, 09:00 - 18:00 IST";

    public const string Website = "https://axonite.io";

    public const string RegistrationNote = "CIN U72900PN2019PTC184221 · GSTIN 27AATCA1234K1Z8";
}
