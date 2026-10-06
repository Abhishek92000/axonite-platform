namespace Polypus.Web.Services;

using Polypus.Web.Models;

/// <summary>
/// Structure of the site: the header dropdowns and the four footer columns.
///
/// Every link in the header and the footer is declared here and nowhere else, so
/// a link audit only has to look in one place. <see cref="AllRoutes"/> lists every
/// destination, and each one must resolve to a real page under Components/Pages or
/// we ship a dead link.
///
/// The HeaderMenu follows the reference navigation: Workforce and Platform each open a
/// dropdown of grouped items, Resources opens a wider panel with a highlight card, and
/// Company opens a plain dropdown. Home, Help Center and Book a walkthrough are kept as
/// they were.
///
/// NOTE ON ARGUMENT ORDER
/// <see cref="NavLink"/> is declared as NavLink(Label, Href, Description). The
/// label is the human-readable text; the href is the URL. Passing those two the
/// wrong way round produces href="Features" with a visible label of "/features",
/// which still renders a plausible-looking menu while every link is broken.
/// </summary>
public static class NavigationCatalog
{
    /// <summary>Links inside the legacy "Product" dropdown (still used by the footer and pages).</summary>
    public static readonly IReadOnlyList<NavLink> ProductMenu =
    [
        new NavLink(
            Label: "Features",
            Href: "/features",
            Description: "Extraction, validation, review and governed SAP posting"),
        new NavLink(
            Label: "Integrations",
            Href: "/integrations",
            Description: "IDoc, BAPI, OData, Ariba and everything in between")
    ];

    /// <summary>The top-level header navigation, in order.</summary>
    public static readonly IReadOnlyList<NavMenu> HeaderMenu =
    [
        new NavMenu
        {
            Label = "Product",
            Href = "/workforce",
            Items =
            [
                new NavMenuItem
                {
                    Label = "Product Overview",
                    Href = "/workforce",
                    Icon = "users",
                    Description = "The GBS skills and agents that run a process end to end",
                    Children =
                    [
                        new NavLink("Invoice Processing", "/workforce/invoice-processing"),
                        new NavLink("Order Confirmations", "/workforce/order-confirmations"),
                        new NavLink("Delivery Notes", "/workforce/delivery-notes"),
                        new NavLink("Order Management", "/workforce/order-management"),
                        new NavLink("Build Your Own", "/workforce/build-your-own")
                    ]
                },
                new NavMenuItem
                {
                    Label = "Skills",
                    Href = "/skills",
                    Icon = "sparkle",
                    Description = "Pre-packaged GBS capabilities you can select per process"
                }
            ]
        },
        new NavMenu
        {
            Label = "Platform",
            Href = "/platform",
            Items =
            [
                new NavMenuItem
                {
                    Label = "Platform",
                    Href = "/platform",
                    Icon = "layers",
                    Description = "Mission control for your agent pipeline"
                },
                new NavMenuItem
                {
                    Label = "Agents",
                    Href = "/agents",
                    Icon = "user-check",
                    Description = "Digital coworkers that reason, use tools and collaborate"
                },
                new NavMenuItem
                {
                    Label = "Integrations",
                    Href = "/integrations",
                    Icon = "plug",
                    Description = "Connect agents to the systems your business already runs on",
                    Children =
                    [
                        new NavLink("SAP Connector", "/integrations/sap"),
                        new NavLink("Coupa Connector", "/integrations/coupa"),
                        new NavLink("IFS Connector", "/integrations/ifs"),
                        new NavLink("Odoo Connector", "/integrations/odoo")
                    ]
                }
            ]
        },
        new NavMenu
        {
            Label = "Resources",
            Href = "/resources/blog",
            Wide = true,
            Highlight = new NavLink(
                "Named a Visionary in the 2026 Gartner® Magic Quadrant™ for Intelligent Document Processing Solutions",
                "/gartner"),
            Items =
            [
                new NavMenuItem { Label = "Blog", Href = "/resources/blog", Icon = "history", Description = "Insights on agentic AI, GBS and more" },
                new NavMenuItem { Label = "FAQ", Href = "/faq", Icon = "search", Description = "Answers to commonly asked questions" },
                // new NavMenuItem { Label = "API Docs", Href = "/resources/api-docs", Icon = "plug", Description = "REST endpoints for tailored integrations" }
            ]
        },
        new NavMenu
        {
            Label = "Company",
            Href = "/company",
            Items =
            [
                new NavMenuItem { Label = "About Us", Href = "/company", Icon = "building", Description = "The team behind Polypus" },
                new NavMenuItem { Label = "Partners", Href = "/partners", Icon = "users", Description = "Implementation and technology partners" },
                new NavMenuItem { Label = "Security", Href = "/security", Icon = "shield-check", Description = "Certifications, controls and data residency" },
                new NavMenuItem { Label = "Careers", Href = "/careers", Icon = "user-check", Description = "Open roles across engineering and delivery" }
            ]
        }
    ];

    /// <summary>The four titled columns in the site footer.</summary>
    public static readonly IReadOnlyList<FooterColumn> FooterColumns =
    [
        new FooterColumn("Product",
        [
            new NavLink("Overview", "/product"),
            new NavLink("Features", "/features"),
            new NavLink("Integrations", "/integrations")
        ]),
        new FooterColumn("Company",
        [
            new NavLink("About Axonite", "/company"),
            new NavLink("Careers", "/careers"),
            new NavLink("Release notes", "/changelog"),
            new NavLink("Contact us", "/contact")
        ]),
        new FooterColumn("Resources",
        [
            new NavLink("Help Center", "/help"),
            new NavLink("Implementation guide", "/help"),
            new NavLink("System status", "/status")
        ]),
        new FooterColumn("Legal",
        [
            new NavLink("Privacy Policy", "/privacy-policy"),
            new NavLink("Terms of Service", "/terms-of-service"),
            new NavLink("Cookie Policy", "/cookie-policy"),
            new NavLink("Data Processing Addendum", "/data-processing")
        ])
    ];

    /// <summary>Every route the header and footer link to, deduplicated and sorted.</summary>
    public static IReadOnlyList<string> AllRoutes =>
        FooterColumns
            .SelectMany(c => c.Links)
            .Concat(ProductMenu)
            .Concat(HeaderMenu.SelectMany(m => m.Items).SelectMany(i => i.Children.Prepend(new NavLink(i.Label, i.Href))))
            .Concat(HeaderMenu.Select(m => new NavLink(m.Label, m.Href)))
            .Select(l => l.Href)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(h => h, StringComparer.OrdinalIgnoreCase)
            .ToList();
}
