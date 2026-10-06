using Polypus.Web.Models;

namespace Polypus.Web.Services;

/// <summary>
/// The blog index: every article on /resources/blog, newest first.
/// Extracted from the reference post list so the cards, tags and filter chips
/// all stay in step. Cover art is referenced by URL; if it cannot load, the card
/// falls back to a category gradient plate.
/// </summary>
public static class BlogCatalog
{
    /// <summary>Filter chips shown above the list, in order.</summary>
    public static readonly IReadOnlyList<BlogCategory> Categories =
    [
        new("all", "Blog Home"),
        new("gbs", "GBS"),
        new("finance", "Finance"),
        new("product", "Product"),
        new("events", "Events"),
        new("media", "Media"),
        new("employee-journey", "Employee Journey")
    ];

    /// <summary>Every article, newest first.</summary>
    public static readonly IReadOnlyList<BlogPost> All =
    [
        new BlogPost
        {
            Title = "The Governance Gap: 5 Considerations For Building A Controls Framework for Agentic AI",
            Excerpt = "How do you fit Agentic AI into your internal controls framework? Which controls are built in and which do you need to configure yourself? This blog explains.",
            Author = "Sally Fletcher",
            Date = "October 6, 2026",
            ReadTime = "4 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/6ac4b959b4db5c65869c4a57_The%20Governance%20Gap_%205%20Takeaways%20on%20Controlling%20Agentic%20AI%20in%20Finance%20-%20Blog%20Cover.png",
            Tags = ["Global Business Services", "Finance"],
            Category = "gbs",
            CategoryKeys = ["gbs", "finance"],
            CategoryLabels = ["GBS", "Finance"]
        },
        new BlogPost
        {
            Title = "Back-Office Automation in Practice: Exploring the Reality Behind the GBS AI Hype",
            Excerpt = "Setting the record straight. How far has the GBS industry come with Agentic AI and how can we bridge the gap from ambition to reality.",
            Author = "Sally Fletcher",
            Date = "August 10, 2026",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/6a79b8a998816039be73b43b_Back-Office%20Automation%20in%20Practice%20-%20Blog%20Cover%20(1).png",
            Tags = ["Agentic AI", "Global Business Services"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "Token costs are the new budget risk in agentic AI. Here's how to plan for them",
            Excerpt = "Token pricing can vary 20x between models. Polypus CEO Uli Erxleben explains why outcome-based pricing and not token tracking is the safer bet for GBS leaders.",
            Author = "Sally Fletcher",
            Date = "July 21, 2026",
            ReadTime = "4 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/6a5f27e25015defef7c806ff_Token%20Cost%20-%20Blog%20Cover.png",
            Tags = ["Agentic AI", "Token Costs", "Global Business Services"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "How Agentic AI Affects Your Workforce",
            Excerpt = "Understand how Agentic AI affects your workforce when 90% of work is automated and what it's actually like to work in a blended Agent/Human team.",
            Author = "Sally Fletcher",
            Date = "July 9, 2026",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/6a4f53eddb77872b6da81fa2_How%20Agentic%20AI%20Affects%20Your%20Workforce%20-%20Blog%20Cover.png",
            Tags = ["Agentic AI", "Global Business Services", "Workforce Transformation"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "Stop Automating the Old Process: Why Agentic AI Demands a New Way of Thinking",
            Excerpt = "Don't make the same mistakes twice! How processes should change to fully embrace Agentic AI.",
            Author = "Sally Fletcher",
            Date = "July 6, 2026",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/6a4b5f00064b4ef5614d800d_Stop%20Automating%20the%20Old%20Process_%20Why%20Agentic%20AI%20Demands%20a%20New%20Way%20of%20Thinking%20%20-%20Blog%20Cover.png",
            Tags = ["Agentic AI", "Global Process Ownership", "Global Business Services", "Process Improvement"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "How to Scale Agentic AI Without Things Breaking",
            Excerpt = "Struggling to scale Agentic AI? CK Taneja, SVP Transformation, Northern Trust gives his expert advice on orchestration, technology and change management.",
            Author = "Sally Fletcher",
            Date = "May 12, 2026",
            ReadTime = "7 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/6a0347577db47f008f41ac38_How%20to%20Scale%20Agentic%20AI%20Without%20Things%20Breaking_%20Lessons%20from%20Northern%20Trust%20-%20Blog%20Cover%20(1).png",
            Tags = ["Agentic AI", "Global Business Services", "Autonomous Finance"],
            Category = "gbs",
            CategoryKeys = ["gbs", "finance"],
            CategoryLabels = ["GBS", "Finance"]
        },
        new BlogPost
        {
            Title = "The GPO Is Now the Most Important Role in Your Agentic AI Transformation",
            Excerpt = "Most organisations hand Agentic AI to IT and wonder why it fails. Discover why the Global Process Owner is the most critical role in any successful Agentic AI transformation.",
            Author = "Sally Fletcher",
            Date = "April 28, 2026",
            ReadTime = "3 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/69f0c6097c371d64486a865d_The%20GPO%20Is%20Now%20the%20Most%20Important%20Role%20in%20Your%20Agentic%20AI%20Transformation%20-%20Blog%20Cover.png",
            Tags = ["Agentic AI", "Global Business Services", "Global Process Ownership"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "Why User Experience Is the Secret Weapon of High-Performing GBS Teams",
            Excerpt = "Discover why user experience is critical to GBS success and how empowering every team member to shape daily interactions can drive better operations and strategic impact.",
            Author = "Sally Fletcher",
            Date = "April 20, 2026",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/69f0c628092c772f67d7380d_Why%20User%20Experience%20Is%20the%20Secret%20Weapon%20of%20High-Performing%20GBS%20Teams%20-%20Blog%20Cover.png",
            Tags = ["Agentic AI", "Global Business Services"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "Redesigning the Operating Model for Agentic GBS",
            Excerpt = "Agentic AI transforms Global Business Services by requiring a redesigned operating model centered on end-to-end process ownership, structured and strategic work instructions, and strong knowledge governance to enable effective, consistent automation.",
            Author = "Sally Fletcher",
            Date = "March 31, 2026",
            ReadTime = "4 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/69f0c64097e62a189a81a061_Redesigning%20the%20Operating%20Model%20for%20Agentic%20GBS%20-%20Blog%20Cover.png",
            Tags = ["Agentic AI", "Global Business Services"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "From Automation to Autonomy: Why GBS Is Hitting Its Next S-Curve of Innovation",
            Excerpt = "AI pilots are stalling not because of technology limits, but because enterprises have yet to redesign GBS operating models for true agentic execution.",
            Author = "Nicole Gajda, Head of Marketing @Polypus",
            Date = "December 18, 2025",
            ReadTime = "4 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/69442fc237149087f0f1b811_From%20Automation%20to%20Autonomy_%20Why%20GBS%20Is%20Hitting%20Its%20Next%20S-Curve%20of%20Innovation%20-%20Blog%20Cover.jpg",
            Tags = ["Agentic AI", "AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "When AI Agents Become Your Co-Workers, Not Your Tool",
            Excerpt = "Learn how to prepare your organization for AI co-workers through upskilling, governance, and trust-building strategies.",
            Author = "Uli Erxleben, Founder & CEO @Polypus",
            Date = "November 10, 2025",
            ReadTime = "7 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/69123303a235df642d7cc4d4_When%20AI%20Agents%20Become%20Your%20Co-Workers%2C%20Not%20Your%20Tool%20web.jpg",
            Tags = ["Forbes"],
            Category = "media",
            CategoryKeys = ["media"],
            CategoryLabels = ["Media"]
        },
        new BlogPost
        {
            Title = "How AI Agents Are Transforming Global Business Services",
            Excerpt = "Exclusive insights from Polypus CEO Dr. Uli Erxleben in Handelsblatt's AI Special Edition.",
            Author = "Nicole Gajda, Head of Marketing @Polypus",
            Date = "October 29, 2025",
            ReadTime = "4 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/6902219b199b3d60ad24ffdf_Handelsblatt%20web.jpg",
            Tags = ["Agentic AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "AI Agents vs AI Assistants: When to Use What",
            Excerpt = "Discover why AI agents and AI assistants might sound similar, but they're as different as day and night.",
            Author = "Ana Aguilar, Content Marketing Manager @Polypus",
            Date = "October 22, 2025",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/68fa3ddff941d0525ed6ad37_Group%20597.jpg",
            Tags = ["Agentic AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "Agentic Process Automation: Beyond the 'Happy Path' Problem",
            Excerpt = "Find out how APA adapts and drives results when routine automation hits a roadblock.",
            Author = "Uli Erxleben, Founder & CEO @Polypus",
            Date = "September 29, 2025",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/68da42c9c6ab18576f241264_Agentic%20Process%20Automation_%20Beyond%20the%20%27Happy%20Path%27%20Problem.webp",
            Tags = ["Forbes"],
            Category = "media",
            CategoryKeys = ["media"],
            CategoryLabels = ["Media"]
        },
        new BlogPost
        {
            Title = "Accounting 2025 Summit Made Us Rethink Finance",
            Excerpt = "Discover the key takeaways from the Accounting Summit 2025 with a focus on change management, innovation, and the human side of AI.",
            Author = "Ana Aguilar, Content Marketing Manager @Polypus",
            Date = "September 22, 2025",
            ReadTime = "4 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/68d152955dd97c06b77163b6_Accounting%20Summit%202025%20Made%20Us%20Rethink%20Finance.webp",
            Tags = ["Agentic AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "2025 Explainer: The IDP Landscape in the Agentic AI Era",
            Excerpt = "Discover how agentic AI transforms IDP from reading paperwork into driving smarter business operations.",
            Author = "Denitza Velcheva, Sr. Product Marketing Manager @Polypus",
            Date = "September 18, 2025",
            ReadTime = "4 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/68ca79a99e1b60b5d0810213_2025%20Explainer_%20The%20IDP%20Landscape%20in%20the%20Agentic%20AI%20Era.webp",
            Tags = ["Agentic AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "Your Sneak Peek: Polypus at Gartner CFO & Finance 2025",
            Excerpt = "See what’s in store for CFOs and finance leaders this year.",
            Author = "Ana Aguilar, Content Marketing Manager @Polypus",
            Date = "September 8, 2025",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/68beb7f23a5c2b5f95523457_Your%20Sneak%20Peek_%20Polypus%20at%20Gartner%20CFO%20%26%20Finance%202025.webp",
            Tags = ["Agentic AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "The Beat of Finance Transformation at Accounting Summit 2025",
            Excerpt = "Get a glimpse of the future of accounting at this year’s summit.",
            Author = "Ana Aguilar, Content Marketing Manager @Polypus",
            Date = "August 21, 2025",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/68a5cb8a13ac5f86c49df0f6_The%20Beat%20of%20Finance%20Transformation%20at%20Accounting%20Summit%202025.webp",
            Tags = ["Agentic AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "How to buy Agentic AI in finance without vendor lock-in",
            Excerpt = "Learn the signs of vendor lock-in, how Agentic AI offers flexibility and transparency, and what to ask before committing to a new AI solution.",
            Author = "Denitza Velcheva, Sr. Product Marketing Manager @Polypus",
            Date = "July 2, 2025",
            ReadTime = "6 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/6864eac71d3728f274c00dc6_How%20to%20buy%20AI%20in%20finance%20without%20vendor%20lock-in.webp",
            Tags = ["Agentic AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "Agentic AI vs Generative AI: 5 Key Differences",
            Excerpt = "From prompt-based output to purpose-driven action, see how Agentic AI redefines what AI can do.",
            Author = "Ana Aguilar, Content Marketing Manager @Polypus",
            Date = "June 26, 2025",
            ReadTime = "6 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/685e5a23a37c4346fb84a551_Agentic%20AI%20vs%20Generative%20AI_%205%20Key%20Differences.webp",
            Tags = ["Agentic AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "What Enterprises Really Asked About AI Agents at EY Lisbon",
            Excerpt = "Enterprises want AI, but not at the cost of control. Discover what they really asked and why architecture matters more than ever.",
            Author = "Denitza Velcheva, Sr. Product Marketing Manager @Polypus",
            Date = "June 5, 2025",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/684193cea384ad1e322feadf_What%20Enterprise%20Buyers%20Really%20Asked%20About%20Our%20AI%20Agents%20%40%20EY%20Lisbon.webp",
            Tags = ["Agentic AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "2025 Gartner CFO & Finance Executive Conference: Our Recap",
            Excerpt = "Leading through change means leading with AI. Discover the top insights driving finance transformation.",
            Author = "Ana Aguilar, Content Marketing Manager @Polypus",
            Date = "June 3, 2025",
            ReadTime = "7 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/683ebb0dde916d537ac02171_2025%20Gartner%20CFO%20%26%20Finance%20Executive%20Conference_%20Our%20Recap.webp",
            Tags = ["Agentic AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "AI Agents: Build or Buy? A Roadmap for Enterprise Leaders",
            Excerpt = "Discover why building AI agents is tougher than it seems and when buying or hybridizing makes smarter sense.",
            Author = "Luca van Skyhawk, Chief Revenue Officer @Polypus",
            Date = "May 16, 2025",
            ReadTime = "6 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/6826c320a3639275f3993a40_AI%20Agents_%20Build%20or%20Buy_%20A%20Roadmap%20for%20Enterprise%20Leaders.webp",
            Tags = ["Agentic AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "The Strategic Shift From RPA To Autonomous AI Systems",
            Excerpt = "Discover why leading organizations are moving beyond RPA and embracing AI agents for smarter, more flexible automation.",
            Author = "Uli Erxleben, Founder & CEO @Polypus",
            Date = "May 13, 2025",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/6823148c33afce919e2a1d09_The%20Strategic%20Shift%20From%20RPA%20to%20Autonomous%20AI%20Systems%20LI%20Announcement.webp",
            Tags = ["Agentic AI", "Forbes"],
            Category = "gbs",
            CategoryKeys = ["gbs", "media"],
            CategoryLabels = ["GBS", "Media"]
        },
        new BlogPost
        {
            Title = "Agentic AI and the Future of Finance Automation at Rethink! 2025",
            Excerpt = "Learn how Agentic AI is bridging the gap between automation hype and real operational impact.",
            Author = "Nicole Gajda, Head of Marketing @Polypus",
            Date = "May 6, 2025",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/6819e9af6b9d22d2c2e37960_Rethink%20Accounting%20-%20Christiane%20Tetzner%20(1).webp",
            Tags = ["Agentic AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "How Autonomous AI Agents Are Redefining Financial Processes",
            Excerpt = "Discover how AI agents offer a smarter, more adaptive approach to meet growing data and compliance demands.",
            Author = "Uli Erxleben, Founder & CEO @Polypus",
            Date = "May 5, 2025",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/68189728e8e10f92221e7184_Finance%20of%20the%20Future_%20How%20CFOs%20are%20Leveraging%20AI.jpg",
            Tags = ["Agentic AI", "Harvard Business Manager"],
            Category = "gbs",
            CategoryKeys = ["gbs", "media"],
            CategoryLabels = ["GBS", "Media"]
        },
        new BlogPost
        {
            Title = "Finance of the Future: How CFOs are Leveraging AI",
            Excerpt = "Explore how AI is reshaping finance; streamlining operations, enabling smarter decisions, and giving early adopters a competitive edge",
            Author = "Polypus Team",
            Date = "April 30, 2025",
            ReadTime = "4 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/6811f9a625a85d0fe4df9a21_Finance%20of%20the%20Future_%20How%20CFOs%20are%20Leveraging%20AI%20(1).jpg",
            Tags = ["Agentic AI", "Harvard Business Manager"],
            Category = "gbs",
            CategoryKeys = ["gbs", "media"],
            CategoryLabels = ["GBS", "Media"]
        },
        new BlogPost
        {
            Title = "Could Agentic AI Be The Superhero Of Sales Order Processing?",
            Excerpt = "Learn how AI is reshaping sales order workflows—faster, smarter, and error-free.",
            Author = "Uli Erxleben, Founder & CEO @Polypus",
            Date = "April 7, 2025",
            ReadTime = "4 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/67f3d99ac9c1a8e6b076dab7_Could%20Agentic%20AI%20Be%20the%20Superhero%20of%20Sales%20Order%20Processing_.webp",
            Tags = ["Forbes"],
            Category = "media",
            CategoryKeys = ["media"],
            CategoryLabels = ["Media"]
        },
        new BlogPost
        {
            Title = "Polypus AI Coworkers: Smarter Back Office Automation",
            Excerpt = "Discover, how unlike AI copilots that assist, Polypus AI agents take full ownership of back-office workflows, delivering accuracy, efficiency, and true end-to-end automation.",
            Author = "Luca van Skyhawk, Chief Revenue Officer @Polypus",
            Date = "March 31, 2025",
            ReadTime = "6 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/67ea707ffcfa0799cfcdd249_Polypus%20vs.%20the%20Competition_%20Understanding%20AI%20Coworkers%20in%20Back-Office%20Automation.webp",
            Tags = ["Agentic AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "AI Agents and the 2025 Shift in Business Automation",
            Excerpt = "AI Conference 2025 Level Up! revealed how intelligent agents are transforming businesses, automating workflows, and creating a competitive edge.",
            Author = "Nicole Gajda, Head of Marketing @Polypus",
            Date = "March 28, 2025",
            ReadTime = "3 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/67e528c9ba8f3c3ef9477cea_AI%20Revolution%202025_%20How%20Intelligent%20Agents%20Are%20Transforming%20Business%20Processes.webp",
            Tags = ["Agentic AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "Meet Katerina Waiz our Learning & Development Specialist",
            Excerpt = "Meet Kate, who followed her instincts into Learning & Development and built a thriving career, proving that a gut feeling can lead to meaningful impact.",
            Author = "Polypus Team",
            Date = "March 27, 2025",
            ReadTime = "4 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/67e521a135d4b383ea5e7da5_Employee%20journey-%20Kate.webp",
            Tags = ["Employee Journey"],
            Category = "employee-journey",
            CategoryKeys = ["employee-journey"],
            CategoryLabels = ["Employee Journey"]
        },
        new BlogPost
        {
            Title = "Agentic AI for Accounts Payable: From Cost to Value Creation",
            Excerpt = "Learn how agentic AI transforms Accounts Payable into a profit center by cutting costs, optimizing payments, and driving revenue.",
            Author = "Luca van Skyhawk, Chief Revenue Officer @Polypus",
            Date = "March 17, 2025",
            ReadTime = "6 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/67d7f42c325da5034cf02b55_Transforming%20AP%20from%20Cost%20Center%20to%20Profit%20Center_%20How%20Agentic%20AI%20Redefines%20Finance%20Operations.webp",
            Tags = ["Agentic AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "What to Know Before Licensing an Agentic AI Solution",
            Excerpt = "Learn how to critically assess agentic AI solutions by verifying autonomy, architecture, security, learning, and proof of value for your business.",
            Author = "Luca van Skyhawk, Chief Revenue Officer @Polypus",
            Date = "March 11, 2025",
            ReadTime = "6 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/67d0110a1d1a42b8643c2fcd_How%20to%20Evaluate%20Agentic%20AI%20Solutions%20Before%20Committing%20to%20a%20Software%20License.webp",
            Tags = ["Agentic AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "Meet Rita Péter our Finance Manager",
            Excerpt = "Meet Rita, who discovered her gift for finances and built a successful career, proving that passion and talent can lead to incredible achievements",
            Author = "Polypus Team",
            Date = "February 25, 2025",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/67bc82eb4f57fdbfcb4b10e8_Employee%20journey-%20Rita.webp",
            Tags = ["Employee Journey"],
            Category = "employee-journey",
            CategoryKeys = ["employee-journey"],
            CategoryLabels = ["Employee Journey"]
        },
        new BlogPost
        {
            Title = "Why Agentic AI in Order Management Isn't Just Another Trend",
            Excerpt = "Find out how agentic AI eliminates inefficiencies in order management and transforms financial operations.",
            Author = "Ana Aguilar, Content Marketing Manager @Polypus",
            Date = "February 20, 2025",
            ReadTime = "6 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/67b72d38673354260013e267_Why%20Agentic%20AI%20in%20Order%20Management%20Isn%27t%20Just%20Another%20Trend.webp",
            Tags = ["Agentic AI", "Autonomous Finance"],
            Category = "gbs",
            CategoryKeys = ["gbs", "finance"],
            CategoryLabels = ["GBS", "Finance"]
        },
        new BlogPost
        {
            Title = "Agentic AI Makes 2025 the Year of the Chief Value Officer",
            Excerpt = "In this article, you’ll discover why 33% of enterprise software will soon integrate agentic AI and what that means for CFOs stepping into a more strategic, value driven role.",
            Author = "Polypus Team",
            Date = "February 11, 2025",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/67ab0740806f2dce8a66bb98_2025%20is%20The%20Year%20of%20the%20Chief%20Value%20Officer%20%E2%80%93%20Thanks%20to%20Agentic%20AI.webp",
            Tags = ["Agentic AI", "Autonomous Finance"],
            Category = "gbs",
            CategoryKeys = ["gbs", "finance"],
            CategoryLabels = ["GBS", "Finance"]
        },
        new BlogPost
        {
            Title = "Accelerating AI Adoption: Key Insights from PwC's GenAI Day",
            Excerpt = "Catch the key insights from PwC’s GenAI Day where industry leaders discussed how companies can effectively adopt and scale generative AI.",
            Author = "Polypus Team",
            Date = "February 7, 2025",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/67ab11412e432843e33c7634_Accelerating%20AI%20Adoption_Key%20Insights%20from%20PwC%27s%20GenAI%20Day%20(1).webp",
            Tags = ["Agentic AI", "Autonomous Finance"],
            Category = "gbs",
            CategoryKeys = ["gbs", "finance"],
            CategoryLabels = ["GBS", "Finance"]
        },
        new BlogPost
        {
            Title = "Common Security Concerns About AI Document Processing—And How Polypus Resolves Them",
            Excerpt = "Discover how Polypus enhances AI security, protecting data privacy and model integrity while ensuring trustworthy and compliant document processing.",
            Author = "Vasil Sultanov",
            Date = "February 2, 2025",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/679cd536af0da39e4c2cb0c3_Common%20Security%20Concerns%20About%20AI%20Document%20Processing.webp",
            Tags = ["Product Updates"],
            Category = "product",
            CategoryKeys = ["product"],
            CategoryLabels = ["Product"]
        },
        new BlogPost
        {
            Title = "Meet Jieying Yan our Team Lead Cognitive AI",
            Excerpt = "Explore how Jieying transitioned into a leadership role, overcoming challenges, driving innovation, and embracing the collaborative culture at Polypus.",
            Author = "Polypus Team",
            Date = "January 30, 2025",
            ReadTime = "4 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/6798a75b512a8796fc60d09d_Employee%20journey-%20Jieying.jpg",
            Tags = ["Employee Journey"],
            Category = "employee-journey",
            CategoryKeys = ["employee-journey"],
            CategoryLabels = ["Employee Journey"]
        },
        new BlogPost
        {
            Title = "Accounts Payable Reinvented: From Back Office to Strategy",
            Excerpt = "Discover the future of Accounts Payable with Polypus AI. Automate tasks, optimize operations, and unlock data-driven growth.",
            Author = "Polypus Team",
            Date = "January 29, 2025",
            ReadTime = "4 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/67990895625949352398c65d_From%20Back%20Office%20to%20Strategic%20Driver_%20Transforming%20the%20Formidable%20World%20of%20Accounts%20Payable.webp",
            Tags = ["Accounts Payable", "Agentic AI"],
            Category = "finance",
            CategoryKeys = ["finance", "gbs"],
            CategoryLabels = ["Finance", "GBS"]
        },
        new BlogPost
        {
            Title = "OCR, Agentic AI or Both?",
            Excerpt = "Discover the key differences between OCR and Agentic AI and how they impact automation, accuracy, and efficiency in finance.",
            Author = "Ana Aguilar, Content Marketing Manager @Polypus",
            Date = "January 23, 2025",
            ReadTime = "6 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/6792727348b74c142f7d5caf_OCR_AgenticAI_or_Both.webp",
            Tags = ["Agentic AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "Agentic AI Order Management: Accurate, Scalable, Smart",
            Excerpt = "Dive into how Agentic AI improves order management, outpacing OCR in automation and increasing efficiency for businesses and finance teams.",
            Author = "Polypus Team",
            Date = "December 20, 2024",
            ReadTime = "6 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/675c48949353bf26f5a68bf8_Agentic%20AI-Powered%20Order%20Management_%20Elevating%20Accuracy%20and%20Scaling%20Automation.webp",
            Tags = ["Agentic AI", "AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "End-of-Month Reconciliation? Call Your AI Assistant",
            Excerpt = "Discover how AI simplifies intercompany reconciliation, solving inefficiencies and empowering smarter finance operations.",
            Author = "Uli Erxleben, Founder & CEO @Polypus",
            Date = "December 19, 2024",
            ReadTime = "6 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/675c6741d91901a5f8a5562e_Revolutionizing%20Intercompany%20Reconciliation%20with%20AI%20Agents%20(1).webp",
            Tags = ["Agentic AI", "AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "Fall Product Updates",
            Excerpt = "Our autumn updates are here: smarter e-invoicing, improved collaboration features, and seamless integrations.",
            Author = "Denitza Velcheva, Sr. Product Marketing Manager @Polypus",
            Date = "December 12, 2024",
            ReadTime = "3 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/67599df4c98974adaf62923b_Product%20update%20-autumn.webp",
            Tags = ["Product Updates"],
            Category = "product",
            CategoryKeys = ["product"],
            CategoryLabels = ["Product"]
        },
        new BlogPost
        {
            Title = "How Agentic AI Is Changing Order Management: Webinar Recap",
            Excerpt = "In this review, uncover how Agentic AI revolutionizes order management with unmatched accuracy and efficiency.",
            Author = "Polypus Team",
            Date = "December 3, 2024",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/6752edeb10d59cb235962812_Revolutionizing%20Order%20Management%20with%20Agentic%20AI_%20Key%20Insights%20from%20Our%20Webinar.webp",
            Tags = ["Agentic AI", "AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "From automation to autonomy: Agentic AI in accounting",
            Excerpt = "This article explores how agentic AI is transforming accounting by enabling autonomous, intelligent solutions for complex tasks like tax assessments and e-invoicing.",
            Author = "Uli Erxleben, Founder & CEO @Polypus",
            Date = "December 3, 2024",
            ReadTime = "7 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/675873c72e9ae664ff526682_From%20Automation%20To%20Autonomy_%20How%20Agentic%20AI%20Is%20Transforming%20Accounting.webp",
            Tags = ["AI", "Agentic AI", "Autonomous Finance"],
            Category = "gbs",
            CategoryKeys = ["gbs", "finance"],
            CategoryLabels = ["GBS", "Finance"]
        },
        new BlogPost
        {
            Title = "Intercompany Reconciliation? AI Agents Got This",
            Excerpt = "Explore how AI agents are revolutionizing intercompany reconciliation, turning reactive fixes into proactive solutions and transforming financial operations worldwide.",
            Author = "Luca van Skyhawk (CRO @Polypus) & Andreas Muzzu (FAAS Innovation/Digital Lead @EY)",
            Date = "November 29, 2024",
            ReadTime = "8 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/674867673e2429971ccb9855_AI%20AGENT.webp",
            Tags = ["Agentic AI", "AI", "Autonomous Finance"],
            Category = "gbs",
            CategoryKeys = ["gbs", "finance"],
            CategoryLabels = ["GBS", "Finance"]
        },
        new BlogPost
        {
            Title = "Meet Wai Cheung our Product Manager",
            Excerpt = "Meet Wai, our Product Manager. His six-year journey at Polypus reflects growth, adaptability, and curiosity. Let’s dive into his story!",
            Author = "Polypus Team",
            Date = "November 28, 2024",
            ReadTime = "6 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/67449e9006e61a618a48453d_Employee%20journey-%20Wai.webp",
            Tags = ["Employee Journey"],
            Category = "employee-journey",
            CategoryKeys = ["employee-journey"],
            CategoryLabels = ["Employee Journey"]
        },
        new BlogPost
        {
            Title = "Avoiding AI Pitfalls in Finance: The Key Role of High-Quality Data",
            Excerpt = "Discover why quality matters more than quantity in AI-driven projects and how bad data can cost your business millions.",
            Author = "Polypus Team",
            Date = "November 26, 2024",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/6744855d01fe35b38ebc5702_Avoiding%20AI%20Pitfalls%20in%20Finance_%20The%20Key%20Role%20of%20High-Quality%20Data.webp",
            Tags = ["Agentic AI", "AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "Learn about AI Agents’ role in intercompany reconciliation with EY",
            Excerpt = "Uncover insights from EY advisors on the role of Agentic AI in intercompany reconciliation.",
            Author = "Ana Aguilar, Content Marketing Manager @Polypus",
            Date = "November 18, 2024",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/673b47c5a10e44c260f295e7_Revolutionizing%20Intercompany%20Reconciliation%20with%20AI%20Agents_%20An%20Interview%20with%20EY%20Advisors.webp",
            Tags = ["Agentic AI", "Autonomous Finance", "AI"],
            Category = "gbs",
            CategoryKeys = ["gbs", "finance"],
            CategoryLabels = ["GBS", "Finance"]
        },
        new BlogPost
        {
            Title = "Exploring Agentic AI and Process Mining with EY Mexico",
            Excerpt = "Discover how process mining and AI automate finance tasks, ensuring accuracy and compliance while freeing teams for strategic work.",
            Author = "Luca van Skyhawk, Chief Revenue Officer @Polypus",
            Date = "November 14, 2024",
            ReadTime = "7 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/6735c9edeab72f2a6467a5f9_Process%20Mining%20Meets%20Agentic%20AI_%20Insights%20from%20Our%20Recent%20EY%20Mexico%20Visit.webp",
            Tags = ["Agentic AI", "AI", "Autonomous Finance"],
            Category = "gbs",
            CategoryKeys = ["gbs", "finance"],
            CategoryLabels = ["GBS", "Finance"]
        },
        new BlogPost
        {
            Title = "Learn everything about the Agentic Approach to eInvoicing",
            Excerpt = "In this piece we uncover the full scope of Agentic AI in eInvoicing—from language translation and data enrichment to regulatory compliance and error reduction.",
            Author = "Ana Aguilar, Content Marketing Manager @Polypus",
            Date = "November 12, 2024",
            ReadTime = "10 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/673b7ac327808c4abe179535_Everything%20you%20wanted%20to%20know%20about%20the%20Agentic%20Approach%20to%20eInvoicing.webp",
            Tags = ["Agentic AI", "AI", "Autonomous Finance"],
            Category = "gbs",
            CategoryKeys = ["gbs", "finance"],
            CategoryLabels = ["GBS", "Finance"]
        },
        new BlogPost
        {
            Title = "The EU AI Act",
            Excerpt = "Explore the EU AI Act and how Polypus is committed to aligning its solutions with it.",
            Author = "Polypus Team",
            Date = "November 8, 2024",
            ReadTime = "",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/672c848cd1c6644e9c3a016b_The%20EU%20AI%20Act.webp",
            Tags = ["AI", "Agentic AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "Managing The Human/Machine Transition To A Hybrid Workforce",
            Excerpt = "Curious why a human-machine hybrid workforce is the key to success? Discover how blending human expertise with AI can transform efficiency and drive results.",
            Author = "Uli Erxleben, Founder & CEO @Polypus",
            Date = "November 8, 2024",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/6728cac723dd6f9bb11cbae1_Machine%20Transition%20To%20A%20Hybrid%20Workforce.webp",
            Tags = ["Agentic AI", "AI", "Forbes"],
            Category = "gbs",
            CategoryKeys = ["gbs", "media"],
            CategoryLabels = ["GBS", "Media"]
        },
        new BlogPost
        {
            Title = "Revolutionizing Intercompany Reconciliation with AI Agents: A CPA's Journey",
            Excerpt = "Discover why the future of intercompany reconciliation hinges on blending AI agents with human expertise for smarter, faster solutions.",
            Author = "Luca van Skyhawk, Chief Revenue Officer @Polypus",
            Date = "November 5, 2024",
            ReadTime = "4 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/672a0197d4a115e411c00f37_Revolutionizing%20Intercompany%20Reconciliation%20with%20AI%20Agents_%20A%20CPA%27s%20Journey.webp",
            Tags = ["Autonomous Finance", "Agentic AI"],
            Category = "finance",
            CategoryKeys = ["finance", "gbs"],
            CategoryLabels = ["Finance", "GBS"]
        },
        new BlogPost
        {
            Title = "Agentic AI for Smarter Intercompany Reconciliation",
            Excerpt = "Discover how Agentic AI automates intercompany reconciliation, streamlining finances and enabling real-time insights for faster decisions.",
            Author = "Polypus Team",
            Date = "October 31, 2024",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/6720e10f788d0478eacb6dd9_How%20to%20Use%20Agentic%20AI%20to%20Automate%20Your%20Intercompany%20Reconciliation.webp",
            Tags = ["AI", "Agentic AI", "Autonomous Finance"],
            Category = "gbs",
            CategoryKeys = ["gbs", "finance"],
            CategoryLabels = ["GBS", "Finance"]
        },
        new BlogPost
        {
            Title = "Debunking Common Myths About eInvoicing: What Is It Really, And Why Do You Need It?",
            Excerpt = "There are many myths about eInvoicing: it’s too complex, expensive, and no different from sending a PDF by email. So, what’s the truth?",
            Author = "Polypus Team",
            Date = "October 25, 2024",
            ReadTime = "4 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/671a426b6fd02c9ec68d4e81_Debunking%20Common%20Myths%20About%20eInvoicing_%20What%20Is%20It%20Really%2C%20And%20Why%20Do%20You%20Need%20It_.webp",
            Tags = ["Agentic AI", "Autonomous Finance", "AI"],
            Category = "gbs",
            CategoryKeys = ["gbs", "finance"],
            CategoryLabels = ["GBS", "Finance"]
        },
        new BlogPost
        {
            Title = "Key takeaways from the Digital Finance Forum 2024",
            Excerpt = "In this piece, we explore how the Digital Finance Forum 2024 revealed that AI and digital transformation thrive when people are empowered and processes are reimagined.",
            Author = "Nicole Gajda, Head of Marketing @Polypus",
            Date = "October 23, 2024",
            ReadTime = "4 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/671911c27d2f406aa5622d9b_Digital%20Finance%20Transformation%20Recap%20of%20the%20Digital%20Finance%20Forum%202024.jpg.webp",
            Tags = ["AI", "Autonomous Finance", "Events"],
            Category = "gbs",
            CategoryKeys = ["gbs", "finance", "events"],
            CategoryLabels = ["GBS", "Finance", "Events"]
        },
        new BlogPost
        {
            Title = "From Routine to Strategy: How AI is Transforming the Future of Finance",
            Excerpt = "By embracing AI-driven automation, finance teams are transforming from task executors to strategic decision-makers. This shift is revolutionizing the finance industry.",
            Author = "Nicole Gajda, Head of Marketing @Polypus",
            Date = "October 23, 2024",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/671761ce88e16f93bc1abac1_From%20Routine%20to%20Strategy_%20How%20AI%20is%20Transforming%20the%20Future%20of%20Finance.webp",
            Tags = ["Agentic AI", "Autonomous Finance"],
            Category = "gbs",
            CategoryKeys = ["gbs", "finance"],
            CategoryLabels = ["GBS", "Finance"]
        },
        new BlogPost
        {
            Title = "Meet Christiane Tetzner our Account Director",
            Excerpt = "Discover Christiane's journey, our Account Director who is motivated by challenges and sees uncertainty as opportunity.",
            Author = "Polypus Team",
            Date = "October 22, 2024",
            ReadTime = "8 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/671787c07088d095e709b8a4_Employee%20journey-%20Christiane.webp",
            Tags = ["Employee Journey"],
            Category = "employee-journey",
            CategoryKeys = ["employee-journey"],
            CategoryLabels = ["Employee Journey"]
        },
        new BlogPost
        {
            Title = "Why Global Business Trusts Agentic AI for eInvoicing",
            Excerpt = "Explore how Agentic AI is revolutionizing eInvoicing for global businesses, from improving efficiency to tackling international standardization challenges.",
            Author = "Polypus Team",
            Date = "October 21, 2024",
            ReadTime = "7 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/67161c95e449c9f6c36dc7d9_How%20Agentic%20AI%20Is%20Revolutionizing%20eInvoicing%20for%20Global%20Businesses.webp",
            Tags = ["Agentic AI", "Autonomous Finance"],
            Category = "gbs",
            CategoryKeys = ["gbs", "finance"],
            CategoryLabels = ["GBS", "Finance"]
        },
        new BlogPost
        {
            Title = "Smarter eInvoicing Starts with Agentic AI",
            Excerpt = "If your business is dealing with complex invoicing workflows or struggling to keep up with compliance, have a look at this piece.",
            Author = "Nicole Gajda, Head of Marketing @Polypus",
            Date = "October 14, 2024",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/670908525b0a07a0036dd656_The%20Agentic%20AI%20Approach%20to%20eInvoicing.webp",
            Tags = ["Agentic AI", "Autonomous Finance"],
            Category = "gbs",
            CategoryKeys = ["gbs", "finance"],
            CategoryLabels = ["GBS", "Finance"]
        },
        new BlogPost
        {
            Title = "Meet Agniva Banerjee our Senior Data Scientist",
            Excerpt = "Join us as we chat with Agniva, Senior Data Scientist at Polypus, who is at the forefront of developing next-generation AI models.",
            Author = "Polypus Team",
            Date = "September 25, 2024",
            ReadTime = "7 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66f50e875c9cfb1624fdd172_Employee%20journey-%20Agniva.webp",
            Tags = ["Employee Journey"],
            Category = "employee-journey",
            CategoryKeys = ["employee-journey"],
            CategoryLabels = ["Employee Journey"]
        },
        new BlogPost
        {
            Title = "Polypus Leads the AI Finance Wave at Accounting Summit 2024",
            Excerpt = "Catch all our highlights from the Accounting Summit 2024 and discover how Polypus is leading finance AI-driven automation.",
            Author = "Nicole Gajda, Head of Marketing @Polypus",
            Date = "September 18, 2024",
            ReadTime = "4 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66f5413adca4b75b63e5008f_Inside%20the%20Accounting%20Summit%202024_%20Polypus%20Leads%20the%20Charge%20in%20AI-Driven%20Finance%20(1).webp",
            Tags = ["Autonomous Finance", "Agentic AI"],
            Category = "finance",
            CategoryKeys = ["finance", "gbs"],
            CategoryLabels = ["Finance", "GBS"]
        },
        new BlogPost
        {
            Title = "Summer Product Updates",
            Excerpt = "Check out our summer product updates, featuring everything from enterprise-grade capabilities to out-of-the-box solutions.",
            Author = "Denitza Velcheva, Sr. Product Marketing Manager @Polypus",
            Date = "September 11, 2024",
            ReadTime = "4 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66e8244ca2e2fba66666e9ad_Product%20update%20-Summer.jpg",
            Tags = ["Product Updates"],
            Category = "product",
            CategoryKeys = ["product"],
            CategoryLabels = ["Product"]
        },
        new BlogPost
        {
            Title = "Agentic AI in action: Meet Polypus at Accounting Summit 2024",
            Excerpt = "Join Polypus at the Accounting Summit 2024 in Düsseldorf to discover how Agentic AI is revolutionizing finance operations.",
            Author = "Nicole Gajda, Head of Marketing @Polypus",
            Date = "September 2, 2024",
            ReadTime = "4 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66eabdb21fcdef5a3d5d7a2f_Meet%20Polypus%20at%20Accounting%20Summit%202024.webp",
            Tags = ["Agentic AI", "Autonomous Finance", "Events"],
            Category = "gbs",
            CategoryKeys = ["gbs", "finance", "events"],
            CategoryLabels = ["GBS", "Finance", "Events"]
        },
        new BlogPost
        {
            Title = "AI At Work: Here’s What It Means For Employers And Employees",
            Excerpt = "AI tools help humans deliver higher quality work. Companies should be exploring ways to successfully integrate AI tools in their current workforce.",
            Author = "Judith Magyar, SAP BRANDVOICE",
            Date = "August 30, 2024",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea8197d14acb7669c906bc_AI%20At%20Work_%20Here%E2%80%99s%20What%20It%20Means%20For%20Employers%20And%20Employees.webp",
            Tags = ["Agentic AI", "Autonomous Finance"],
            Category = "gbs",
            CategoryKeys = ["gbs", "finance"],
            CategoryLabels = ["GBS", "Finance"]
        },
        new BlogPost
        {
            Title = "Meet Adam Pogorzelski our Team Lead QA",
            Excerpt = "Meet Adam, our new QA Team Lead. He combines technical skill with empathy to ensure top-notch, user-friendly software. Let’s get to know him!",
            Author = "Polypus Team",
            Date = "August 21, 2024",
            ReadTime = "10 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea8e3169a20f6a37e92452_Employee%20journey-%20Adam.webp",
            Tags = ["Employee Journey"],
            Category = "employee-journey",
            CategoryKeys = ["employee-journey"],
            CategoryLabels = ["Employee Journey"]
        },
        new BlogPost
        {
            Title = "Polypus AI Agent for Sales Orders: Precision Meets Power",
            Excerpt = "In time for a well-deserved summer breather, we closed July with the launch of our new product – the AI Agent for Sales Order Processing.",
            Author = "Denitza Velcheva, Sr. Product Marketing Manager @Polypus",
            Date = "August 6, 2024",
            ReadTime = "7 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea91b4819f3a0698d11f76_The%20Polypus%20AI%20Agent%20for%20Sales%20Order%20Processing.webp",
            Tags = ["Agentic AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "What Is Agentic AI & Is It The Next Big Thing?",
            Excerpt = "What is Agentic AI? How does Agentic AI differ from Generative AI, and what is its potential for transforming shared services and finance?",
            Author = "Hendrik Leitner, Sally Fletcher",
            Date = "July 24, 2024",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea86c5c940d6e5b8e278d4_What%20Is%20Agentic%20AI%20%26%20Is%20It%20The%20Next%20Big%20Thing_.webp",
            Tags = ["Autonomous Finance", "Agentic AI"],
            Category = "finance",
            CategoryKeys = ["finance", "gbs"],
            CategoryLabels = ["Finance", "GBS"]
        },
        new BlogPost
        {
            Title = "Meet Lucía Ferreiro Martínez our Senior Customer Success Manager",
            Excerpt = "Today, we’re sitting down with Lucía, our stellar Senior Customer Success Manager who makes sure our clients are nothing short of thrilled with our tech.",
            Author = "Polypus Team",
            Date = "July 18, 2024",
            ReadTime = "10 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea9159be52e41d76fd5199_Employee%20journey-%20Lucia.webp",
            Tags = ["Employee Journey"],
            Category = "employee-journey",
            CategoryKeys = ["employee-journey"],
            CategoryLabels = ["Employee Journey"]
        },
        new BlogPost
        {
            Title = "Sales Order Automation: Enhancing O2C Performance",
            Excerpt = "In this article, we’ll dive into the key aspects of sales order automation and its crucial role in the success of the order-to-cash (O2C) process for large organizations.",
            Author = "Denitza Velcheva, Sr. Product Marketing Manager @Polypus",
            Date = "July 17, 2024",
            ReadTime = "10 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea90ffbe52e41d76fcdfb9_Sales%20Order%20Automation_%20Enhancing%20O2C%20Performance.webp",
            Tags = ["AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "LLMs and RAG Redefine Intelligent Document Processing",
            Excerpt = "If you’ve heard about RAG before but aren’t sure of its business application or relationship with language models – keep reading!",
            Author = "Dr. He Zhang, CTO, Polypus",
            Date = "July 16, 2024",
            ReadTime = "4 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea83df5fbb11b67d7b389a_LLMs%20and%20RAG%20Ushering%20the%20Next%20Era%20of%20Intelligent%20Document%20Processing.webp",
            Tags = ["Autonomous Finance"],
            Category = "finance",
            CategoryKeys = ["finance"],
            CategoryLabels = ["Finance"]
        },
        new BlogPost
        {
            Title = "Meet Max Geigis our VP Product Management",
            Excerpt = "Today, we’re grabbing a virtual coffee with our very own Max, who’s just earned a well-deserved promotion to VP of Product Management at Polypus.",
            Author = "Polypus Team",
            Date = "June 5, 2024",
            ReadTime = "10 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea863d28321e1fd314e6e1_Employee%20journey-%20Max.webp",
            Tags = ["Employee Journey"],
            Category = "employee-journey",
            CategoryKeys = ["employee-journey"],
            CategoryLabels = ["Employee Journey"]
        },
        new BlogPost
        {
            Title = "From O2C & H2R to ESG our SSOW Europe 2024 Recap",
            Excerpt = "Our key takaways from SSOW Europe 2024: reshaping shared services and GBS with automation within O2C, H2R, ESG.",
            Author = "Denitza Velcheva, Sr. Product Marketing Manager @Polypus",
            Date = "May 27, 2024",
            ReadTime = "2 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea92fc819f3a0698d2beb6_SSOW%20Lisbon_%203%20days%20of%20Innovation%2C%20Collaboration%20and%20Transformation.webp",
            Tags = ["Autonomous Finance"],
            Category = "finance",
            CategoryKeys = ["finance"],
            CategoryLabels = ["Finance"]
        },
        new BlogPost
        {
            Title = "Decoding ESG Reporting: Navigating The Puzzle With AI Assistance",
            Excerpt = "Effective ESG reporting hinges on robust data collection. This post highlights the difficulties companies face and explores how AI assistants can revolutionize the process.",
            Author = "Uli Erxleben, Founder & CEO @Polypus",
            Date = "April 25, 2024",
            ReadTime = "6 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea9275e89804fdd041c688_Decoding%20ESG%20Reporting_%20Navigating%20The%20Puzzle%20With%20AI%20Assistance.webp",
            Tags = ["AI", "Forbes"],
            Category = "gbs",
            CategoryKeys = ["gbs", "media"],
            CategoryLabels = ["GBS", "Media"]
        },
        new BlogPost
        {
            Title = "The new European Data Act: Overview",
            Excerpt = "The European Commission's recent initiative, the European Strategy for Data, represents a significant step towards creating a unified market for data within the EU.",
            Author = "Polypus Team",
            Date = "April 23, 2024",
            ReadTime = "10 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea85841aff543aa66612a0_The%20new%20European%20Data%20Act_%20Overview.webp",
            Tags = ["AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "Shared Services & GBS Transformation for Everyone at SSOW Europe 2024",
            Excerpt = "SSOW Europe 2024 is the event for you and your team to enjoy exceptional learning and networking opportunities, regardless of how far along you are in your shared services journey or how mature your GBS organization is already. With events like SSOWomen Leadership Day, the GBS Certification Course, and Focus Days on HR Shared Services, Global Process Ownership (GPO), and AI & Generative AI, among others, SSOW provides you with the knowledge and resources you need to succeed in your company's operations.",
            Author = "Polypus Team",
            Date = "April 22, 2024",
            ReadTime = "",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea9218550ea1fbeac93dc1_SSOW%20Europe%202024.webp",
            Tags = ["AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "Unlock Accounts Payable auto-posting in SAP with AI Assistants",
            Excerpt = "As a financial professional you are already aware of the benefits of autonomous finance, especially when it comes to accounts payable (AP). You know autonomous finance can lead to increased efficiency, reduced operational costs by minimizing manual intervention, and improved accuracy in financial decision-making driven by advanced algorithms and artificial intelligence.",
            Author = "Polypus Team",
            Date = "April 15, 2024",
            ReadTime = "",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea80d75b09e6f59906e8fb_Unlocking%20Accounts%20Payable%20Posting%20in%20SAP%20with%20AI%20Assistants.webp",
            Tags = ["Accounts Payable"],
            Category = "finance",
            CategoryKeys = ["finance"],
            CategoryLabels = ["Finance"]
        },
        new BlogPost
        {
            Title = "Shared Services Giants: Industry Icons & F1 Legend Take Center Stage at SSOW Lisbon 2024",
            Excerpt = "The Shared Services and Outsourcing Week (SSOW) ignites this year with a lineup that's more than just informative – it's electrifying.",
            Author = "Polypus Team",
            Date = "April 9, 2024",
            ReadTime = "2 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea828df65490c001c6c5e8_Shared%20Services%20Giants_%20Industry%20Icons%20%26%20F1%20Legend%20Take%20Center%20Stage%20at%20SSOW%20Lisbon%202024.webp",
            Tags = ["AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "Demystifying Prompt Engineering For Finance Teams (Hint, Anyone Can Do It)",
            Excerpt = "This article explores the art of instructing AI assistants effectively, demonstrating its application in finance. While AI automates repetitive tasks, human input remains crucial.",
            Author = "Uli Erxleben, Founder & CEO @Polypus",
            Date = "March 30, 2024",
            ReadTime = "10 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea8452df8827e1431a5691_Demystifying%20Prompt%20Engineering%20For%20Finance%20Teams%20(Hint%2C%20Anyone%20Can%20Do%20It).webp",
            Tags = ["AI", "Forbes"],
            Category = "gbs",
            CategoryKeys = ["gbs", "media"],
            CategoryLabels = ["GBS", "Media"]
        },
        new BlogPost
        {
            Title = "Four Key Reasons Why You Shouldn't Miss SSOW Lisbon 2024",
            Excerpt = "The Shared Services and Outsourcing Week (SSOW) is undoubtedly one of the most anticipated weeks of the year for industry professionals. This is where the magic happens for those who strive to stay ahead in the dynamic landscape of shared services and outsourcing.",
            Author = "Polypus Team",
            Date = "March 29, 2024",
            ReadTime = "2 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea82e55b09e6f59909b67e_Four%20Key%20Reasons%20Why%20You%20Shouldn%27t%20Miss%20SSOW%20Lisbon%202024.webp",
            Tags = ["AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "How Much Can You Trust Your AI Assistant? As Much As The Rest Of Your Team",
            Excerpt = "Whether you're managing finances or tackling complex workflows, this article equips you to unlock the true potential of AI assistants within your team.",
            Author = "Uli Erxleben, Founder & CEO @Polypus",
            Date = "February 29, 2024",
            ReadTime = "7 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea85ef8dd731b1f543945e_How%20Much%20Can%20You%20Trust%20Your%20AI%20Assistant_%20As%20Much%20As%20The%20Rest%20Of%20Your%20Team.webp",
            Tags = ["Forbes", "AI"],
            Category = "media",
            CategoryKeys = ["media", "gbs"],
            CategoryLabels = ["Media", "GBS"]
        },
        new BlogPost
        {
            Title = "Navigating the Future of Shared Services and Outsourcing - Embracing generative AI for Autonomous Operations and Workforce Transformation",
            Excerpt = "SSOW 2024 is where innovation meets expertise, and the future of shared services and outsourcing unfolds before your eyes. As participants gear up for an enriching experience, let's explore what awaits attendees at this year's event and how they can maximize their journey through the world of SSOW.",
            Author = "Polypus Team",
            Date = "February 27, 2024",
            ReadTime = "2 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea8369162c56d53308b700_Navigating%20the%20Future%20of%20Shared%20Services%20and%20Outsourcing.webp",
            Tags = ["AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "Uli Erxleben Joins Forbes Finance Council",
            Excerpt = "Forbes Finance Council is an invitation-only community for executives in accounting, financial planning, wealth and asset management, and investment firms.",
            Author = "Polypus Team",
            Date = "February 15, 2024",
            ReadTime = "2 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea78188a24a17f9c17a95b_Uli%20joining%20the%20forbes%20finance%20council.webp",
            Tags = ["Forbes"],
            Category = "media",
            CategoryKeys = ["media"],
            CategoryLabels = ["Media"]
        },
        new BlogPost
        {
            Title = "Top 5 SSON Orlando 2024 Keynote Speakers You Can’t Miss",
            Excerpt = "Are you ready to unlock the secrets to operational excellence, streamline processes, and revolutionize your business strategies? Look no further than the Shared Services and Outsourcing Week (SSOW), where industry leaders converge to share insights, innovations, and best practices. While there are countless reasons to attend SSOW, today, we're shining the spotlight on the crown jewel of the event: the SSOW 2024 Trailblazers and Leading Practitioners.",
            Author = "Polypus Team",
            Date = "February 13, 2024",
            ReadTime = "2 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea8f11be52e41d76fad45f_Top%205%20SSON%20Orlando%202024%20Keynote%20Speakers.webp",
            Tags = ["AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "Unlocking Growth and Insights: Why Visiting SSOW in Orlando (March 25 – 28, 2024) Is Essential for Industry Professionals",
            Excerpt = "Shared Services and Outsourcing Week (SSOW) stands as a pivotal event in the calendar of industry professionals seeking to stay ahead in the dynamic landscape of shared services and outsourcing.",
            Author = "Polypus Team",
            Date = "February 5, 2024",
            ReadTime = "2 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea853961a54be9954f8f45_Why%20Visiting%20SSOW%20in%20Orlando.webp",
            Tags = ["AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "The Ultimate Assistant: Your AI Agent for Accounts Payable",
            Excerpt = "In today’s rapidly evolving business environment, the finance function is undergoing a profound digital transformation, and the accounts payable process (AP) is no exception.",
            Author = "Polypus Team",
            Date = "February 2, 2024",
            ReadTime = "7 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea7aca1904d9ea62f39f85_Your%20AI%20Agent%20for%20Accounts%20Payable.webp",
            Tags = ["Accounts Payable"],
            Category = "finance",
            CategoryKeys = ["finance"],
            CategoryLabels = ["Finance"]
        },
        new BlogPost
        {
            Title = "Empowering Your Workflow with Innovative Enhancements",
            Excerpt = "We are thrilled to announce a series of feature releases that are set to elevate your experience with our platform. These enhancements are designed to streamline your processes, boost efficiency, and provide you with even more control over your data. Let's dive into the latest updates:",
            Author = "Polypus Team",
            Date = "January 24, 2024",
            ReadTime = "4 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/65b0cc40406e2c6f1e3e18d1_IMG.png",
            Tags = ["Product Updates"],
            Category = "product",
            CategoryKeys = ["product"],
            CategoryLabels = ["Product"]
        },
        new BlogPost
        {
            Title = "Why CFOs Should Have AI On Their Minds",
            Excerpt = "In the contemporary landscape, the role of a CFO demands a heightened level of strategic acumen and forward-thinking, almost transforming them into the Chief Future Officer.",
            Author = "Hendrik Leitner",
            Date = "January 9, 2024",
            ReadTime = "7 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea81328140f3e605d131cc_Why%20CFOs%20Should%20Have%20AI%20On%20Their%20Minds.webp",
            Tags = ["AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "Unlocking the Future of Business with Autonomous Finance",
            Excerpt = "This article outlines the advantages of autonomous finance, as well as the difficulties CFOs encounter while implementing this novel strategy.",
            Author = "Polypus Team",
            Date = "December 20, 2023",
            ReadTime = "7 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea8452df8827e1431a5691_Demystifying%20Prompt%20Engineering%20For%20Finance%20Teams%20(Hint%2C%20Anyone%20Can%20Do%20It).webp",
            Tags = ["Autonomous Finance"],
            Category = "finance",
            CategoryKeys = ["finance"],
            CategoryLabels = ["Finance"]
        },
        new BlogPost
        {
            Title = "EU AI Act Greenlit: Comprehensive Guide to the Artificial Intelligence Regulations in Europe",
            Excerpt = "At Polypus, we offer enterprise-ready AI agents for high document throughput and are aware of our responsibility. Protecting our customers is important to us, which is why we generally welcome the new regulations.",
            Author = "Hendrik Leitner",
            Date = "December 14, 2023",
            ReadTime = "8 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea9044bf9ecfa129787766_EU%20AI%20Act%20Greenlit.webp",
            Tags = ["AI"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
        new BlogPost
        {
            Title = "Partner spotlight: ScaleHub and their Collective Intelligence solutions",
            Excerpt = "At Polypus, we’re proud of the tech we’ve created. The AI that powers our solutions does much more than get us past the 85% accuracy ceiling of OCR; it’s made it possible for us to provide the highest data accuracy and fastest processing speed for our customers. But the smallest amount of errors are still errors, which is why we’ve entered into a strategic partnership with ScaleHub. With their Collective Intelligence solutions and crowdsourcing as a managed service, our fellow disruptors’s offering in the intelligent document processing (IDP) world perfectly complements ours—and together we offer unparalleled accuracy, speed and scalability. We asked Susanne Richter-Wills, ScaleHub’s VP of Partnerships EMEA, to explain more:",
            Author = "Susanne Richter-Wills, ScaleHub’s VP of Partnerships EMEA",
            Date = "November 14, 2023",
            ReadTime = "10 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea873f8f0922f099e623a8_Introducing%20our%20Partner%20ScaleHub%20and%20their%20Collective%20Intelligence%20Solutions.webp",
            Tags = ["Partnerships"],
            Category = "media",
            CategoryKeys = ["media"],
            CategoryLabels = ["Media"]
        },
        new BlogPost
        {
            Title = "Stop duplicate invoices early with Celonis in Polypus",
            Excerpt = "Celonis and Polypus have joined forces to tackle the longstanding issue of duplicate invoice payments through the integration of AI technologies. The Celonis Duplicate Checker, now incorporated within Polypus, serves as a powerful tool to prevent duplicate invoices from reaching the ERP system.",
            Author = "Hendrik Leitner",
            Date = "October 31, 2023",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea880c888edbbda6bf1285_Celonis%20and%20Polypus.webp",
            Tags = ["Partnerships"],
            Category = "media",
            CategoryKeys = ["media"],
            CategoryLabels = ["Media"]
        },
        new BlogPost
        {
            Title = "Extended Partnership: Polypus embedded in Cloudworx REEDR",
            Excerpt = "We are thrilled to share the exciting news about the extended partnership between Polypus and cloudworx, integrating Polypus' Document AI into the core of REEDR.",
            Author = "Hendrik Leitner",
            Date = "October 26, 2023",
            ReadTime = "2 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea799ce7faae6b38dc1505_Polypus%20embedded%20in%20Cloudworx%20REEDR%E2%80%AF.webp",
            Tags = ["Partnerships"],
            Category = "media",
            CategoryKeys = ["media"],
            CategoryLabels = ["Media"]
        },
        new BlogPost
        {
            Title = "Polypus has earned recognition as a 'Representative Vendor' in the 2023 Gartner \"Market Guide for Accounts Payable Invoice Automation Solutions.\" (APIA)",
            Excerpt = "Polypus has earned recognition as a 'Representative Vendor' in the 2023 Gartner \"Market Guide for Accounts Payable Invoice Automation Solutions.\" This acknowledgment highlights Polypus' expertise in the global financial automation and B2B Finance SaaS sectors, demonstrating its commitment to enhancing secure payment capabilities for large multinational enterprises.",
            Author = "Hendrik Leitner",
            Date = "October 9, 2023",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea8ea5d9a92ea1804c9ac4_Polypus%20has%20earned%20recognition.webp",
            Tags = ["Accounts Payable"],
            Category = "finance",
            CategoryKeys = ["finance"],
            CategoryLabels = ["Finance"]
        },
        new BlogPost
        {
            Title = "6 key tips to get the most from generative AI in finance and accounting",
            Excerpt = "Don’t worry if you missed our AccountingGPT webinar in June because we took the time to break it down to its key insights and included some of questions viewers posted live. If you are a financial-, accounting- or a shared service center leader and are anxious to find the most seamless way to leverage the latest in AI and turn your operations into a truly no-touch workflow - keep reading! Here are the 6 things to consider for a successful APAI work frame.",
            Author = "Denitza Velcheva, Sr. Product Marketing Manager @Polypus",
            Date = "July 20, 2023",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea7a118d08efbd1fd07935_6%20things%20to%20know%20to%20make%20the%20best%20out%20of%20generative%20AI%20for%20Finance%20and%20Accounting.webp",
            Tags = ["Autonomous Finance"],
            Category = "finance",
            CategoryKeys = ["finance"],
            CategoryLabels = ["Finance"]
        },
        new BlogPost
        {
            Title = "AccountingGPT revolutionizing AP automation with next-gen AI",
            Excerpt = "Processing financial documents is a crucial aspect of an organization's back office operations. This typically entails sorting through documents, manually inputting data, and conducting accounting tasks, as well as managing payment approvals. However, this manual process can be time-consuming, error-prone, and inefficient. As a result, many companies have turned to rule-based automation solutions like OCR and workflow automation, but the results have been mixed.",
            Author = "Polypus Team",
            Date = "May 12, 2023",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea9356be52e41d76ffb789_AccountingGPT.webp",
            Tags = ["Autonomous Finance"],
            Category = "finance",
            CategoryKeys = ["finance"],
            CategoryLabels = ["Finance"]
        },
        new BlogPost
        {
            Title = "Press Release: Polypus Unveils AccountingGPT to Revolutionize Finance Operations",
            Excerpt = "Berlin, Germany - Polypus, a leading provider of next-generation AI for finance, has announced the launch of AccountingGPT which automates accounts payable processing from data capturing to posting with transformative results.",
            Author = "Polypus Team",
            Date = "May 11, 2023",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66ea90a03ae6bbbf8b30f82d_Press%20Release_%20Polypus%20Unveils%20AccountingGPT.webp",
            Tags = ["Autonomous Finance"],
            Category = "finance",
            CategoryKeys = ["finance"],
            CategoryLabels = ["Finance"]
        },
        new BlogPost
        {
            Title = "Best OCR in 2019: In-depth data extraction benchmark",
            Excerpt = "What is the difference between data extraction and OCR? How can we determine the best data extraction solution? What is the most accurate data extraction solution? Are there other criteria that could affect a companies’ procurement decision? What are the areas where data extraction solutions fail?",
            Author = "Polypus Team",
            Date = "October 15, 2019",
            ReadTime = "5 min. read",
            Image = "https://cdn.prod.website-files.com/651d1e208ce412729bde901d/66f6fdb17076d8eb0c6c6cc1_BestOCR.webp",
            Tags = ["OCR"],
            Category = "gbs",
            CategoryKeys = ["gbs"],
            CategoryLabels = ["GBS"]
        },
    ];
}
