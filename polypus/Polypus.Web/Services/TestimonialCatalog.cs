using Polypus.Web.Models;

namespace Polypus.Web.Services;

/// <summary>
/// The five customer quotes shown on the home page. One is marked
/// <see cref="Testimonial.IsFeatured"/> and gets the larger dark treatment.
/// </summary>
/// <remarks>
/// These are illustrative sample quotes written for the template. Replace them with
/// approved customer references (name, role and company cleared for publication)
/// before going live.
/// </remarks>
public static class TestimonialCatalog
{
    public static readonly IReadOnlyList<Testimonial> All =
    [
        new Testimonial
        {
            Quote = "We had already failed one automation project, so the first thing Axonite offered was " +
                    "a shadow run against twelve months of our own invoices. When the numbers held up " +
                    "across every entity, the decision to go live took a single meeting.",
            Author = "Priya Raghavan",
            Role = "Group Financial Controller",
            Company = "Meridian Industrial",
            Sector = "Manufacturing",
            Metric = "18,400",
            MetricLabel = "invoices posted per quarter, 71% untouched",
            IsFeatured = true
        },
        new Testimonial
        {
            Quote = "Duplicate invoices were our biggest leakage. Polypus caught cases our team had " +
                    "missed for months, and the evidence is attached to each one - nobody argues " +
                    "with the findings.",
            Author = "Marcus Feldt",
            Role = "Head of Shared Services",
            Company = "Northwind Logistics",
            Sector = "Logistics",
            Metric = "$1.6M",
            MetricLabel = "duplicate payments prevented in year one"
        },
        new Testimonial
        {
            Quote = "The part that surprised me was the BASIS conversation. Polypus used the standard " +
                    "IDoc and BAPI interfaces, so our team signed off in a week instead of a quarter.",
            Author = "Sven Albrecht",
            Role = "SAP Platform Lead",
            Company = "Trident Chemicals",
            Sector = "Chemicals",
            Metric = "6 days",
            MetricLabel = "from sandbox to production posting"
        },
        new Testimonial
        {
            Quote = "Month-end used to mean two weeks of overtime for my team. They now spend their time " +
                    "on the exceptions and the supplier conversations, which is what they were hired to do.",
            Author = "Anita Deshmukh",
            Role = "Accounts Payable Manager",
            Company = "Halcyon Foods",
            Sector = "Food processing",
            Metric = "82%",
            MetricLabel = "reduction in overtime hours"
        },
        new Testimonial
        {
            Quote = "Auditors asked for the decision trail behind 200 postings. We produced it in " +
                    "minutes, with the source document and model version attached to each line.",
            Author = "Daniel Okonkwo",
            Role = "Director of Internal Audit",
            Company = "Vertex Components",
            Sector = "Automotive",
            Metric = "200",
            MetricLabel = "audit samples served in under 15 minutes"
        }
    ];

    /// <summary>The featured quote, or the first one if none is marked.</summary>
    public static Testimonial Featured =>
        All.FirstOrDefault(t => t.IsFeatured) ?? All[0];

    /// <summary>Everything except the featured card, in display order.</summary>
    public static IReadOnlyList<Testimonial> Others =>
        All.Where(t => !ReferenceEquals(t, Featured)).ToList();
}
