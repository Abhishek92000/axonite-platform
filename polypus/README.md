# Polypus marketing website

The public marketing site for **Polypus** — intelligent document processing and
controlled SAP automation, a product owned by **Axonite**.

Built with **.NET 10** and **Blazor Web App** (interactive server render mode).
Written by hand: no CSS framework, no icon package, no UI kit, no CDN calls at
runtime. Every page, component, style rule and line of JavaScript lives in this
repository.

---

## Contents

1. [What this site is](#1-what-this-site-is)
2. [Quick start](#2-quick-start)
3. [The one flow that matters most: plan → contact](#3-the-one-flow-that-matters-most-plan--contact)
4. [How the project is organised](#4-how-the-project-is-organised)
5. [Every file, and why it exists](#5-every-file-and-why-it-exists)
6. [Where to change things](#6-where-to-change-things)
7. [The design system](#7-the-design-system)
8. [JavaScript, and why the site works without it](#8-javascript-and-why-the-site-works-without-it)
9. [Render modes](#9-render-modes)
10. [Accessibility](#10-accessibility)
11. [Before you go live](#11-before-you-go-live)
12. [Troubleshooting](#12-troubleshooting)
13. [Glossary](#13-glossary)

---

## 1. What this site is

A single marketing website for one product. There is no database, no
authentication, no CMS and no external service. The contact form validates input
and shows a confirmation; it does not send mail (see
[Before you go live](#11-before-you-go-live)).

The product in one sentence:

> **Polypus reads documents, checks them against your rules, and posts clean
> documents into SAP — with an audit trail for every decision.**

### The home page, top to bottom

The home page is the main deliverable and follows a deliberate order. Each
section is a `<section>` with an `id` so it can be linked to directly.

| # | Section | `id` | Why it is in this position |
|---|---------|------|----------------------------|
| 1 | Header — logo, Home, Product / Platform / Resources / Company menus, email, CTA | — | Navigation first, always reachable |
| 2 | Hero — positioning, the document strip, plus a console mock | — | What it is, in one screen |
| 3 | Customer strip | `customers` | Immediate credibility cue |
| 4 | Metrics — 5L, 90%, 85% +, 4.1x | — | Concrete numbers before any feature talk |
| 5 | Features — six highlights | `features` | What it does |
| 6 | Process — capture → extract → review → post | — | How it actually works, in four steps |
| 7 | Document-type strip | — | "Does it read *my* documents?" |
| 8 | Company — Axonite, the owner | `company` | Who is behind the product |
| 9 | Testimonials — one featured plus four | — | Proof from people like the visitor |
| 10 | FAQ — five questions | — | Objections answered before the ask |
| 11 | Closing CTA | — | The one thing we want them to do |
| 12 | Footer — help, legal, status, offices | — | Everything else, for those who scroll |

The pricing section is not on the home page. `/plans` carries the plan cards,
the billing toggle and the comparison table.

---

## 2. Quick start

Requires the **.NET 10 SDK**. Nothing else — no npm, no bundler, no build step
for the front end.

```powershell
cd Polypus.Web
dotnet run
```

Then open the URL it prints. The launch profile uses:

| Scheme | URL |
|--------|-----|
| http | `http://localhost:5238` |
| https | `https://localhost:7251` |

Other useful commands:

```powershell
cd Polypus.Web
dotnet build                 # compile
dotnet build -c Release      # release build
dotnet watch                 # rebuild and hot-reload on save
dotnet run --urls http://localhost:5238   # pin the port
```

There are no tests. Verification is done by running the site and checking the
routes (see [Troubleshooting](#12-troubleshooting)).

---

## 3. The one flow that matters most: plan → contact

**Requirement:** clicking a plan (Basic, Growth, …) must take the visitor to the
**contact page** with **that plan already selected**.

This is a three-link chain. Understanding it is the key to the whole site.

```
  ┌──────────────────────┐   href="/contact?plan=growth"
  │  PlanCard.razor      │ ─────────────────────────────────┐
  │  (the CTA button)    │                                  │
  └──────────────────────┘                                  ▼
                                              ┌──────────────────────────────┐
  ┌──────────────────────┐                    │  Contact.razor               │
  │ PlanCatalog.cs       │  PlanCatalog.Find("growth")      │                              │
  │ All[] + Find()       │ ─────────────────────────────────▶│  [_plan] renders the         │
  │ Aliases{}            │                    │  .plan-summary panel         │
  └──────────────────────┘                    │  and preselects <select>     │
                                              └──────────────────────────────┘
```

**Step 1 — the link.** `PlanCard.razor` builds the href from the plan's `Id`:

```razor
<a href="/contact?plan=@Plan.Id" aria-label="Choose @Plan.Name - continue to the contact form with the @Plan.Name plan selected">
```

**Step 2 — reading the query string.** `Contact.razor` declares a query-bound
property. Blazor populates it from `?plan=` and calls `OnParametersSet`.

```razor
[SupplyParameterFromQuery(Name = "plan")]
public string? PlanId { get; set; }
```

**Step 3 — resolving it safely.** The value comes from the URL, so it is treated
as untrusted. `PlanCatalog.Find()` returns `null` for anything it does not
recognise, and the form falls back to no preselection instead of throwing:

```csharp
_plan = PlanCatalog.Find(PlanId);   // null when the value is unknown
```

**Aliases.** Old or guessed links still work, because `Find()` checks a lookup of
synonyms first. See `PlanCatalog.Aliases`: `starter → basic`, `pro → growth`,
`scale → business`, `custom`/`enterprise-plus` → `enterprise`.

**Why the plan lives in two places.** Once the visitor is on the contact page,
the plan is held in `_plan` (a `Plan?` field). The sidebar panel renders from it
immediately, and the form's `<select>` is bound to the same value, so changing
the dropdown updates the panel live via `@bind-Value:after="SyncPlanFromForm"`.

### How to test it by hand

```
http://localhost:5238/contact?plan=growth      → Growth preselected
http://localhost:5238/contact?plan=pro         → Growth preselected (alias)
http://localhost:5238/contact?plan=enterprise  → Enterprise preselected
http://localhost:5238/contact?plan=nonsense    → no preselection, no error
```

---

## 4. How the project is organised

The architecture is a strict one-way dependency. Content and rules live at the
bottom; pages render at the top. A page never contains business data, and a
catalog never contains markup.

```
   Components/Pages/*.razor        ← routes; compose sections, own page state
   Components/Shared/*.razor       ← reusable presentation, no page knowledge
   Components/Layout/*.razor       ← header, footer, main layout
              │
              ▼
   Services/*Catalog.cs            ← the content: plans, features, FAQs, links
   Models/*.cs, *Profile.cs        ← the shapes and the brand facts
              │
              ▼
   wwwroot/app.css, home.css       ← the design system (tokens → components)
   wwwroot/js/site.js              ← two cosmetic enhancements
```

**The rule that keeps this maintainable:** *if you are changing words or
numbers, you should be editing a `Models` or `Services` file, not a `.razor`
file.* The Razor files decide **where** content appears; the catalogs decide
**what** it says.

### Folder map

```
polypus/
├─ README.md                      ← this file
├─ docs/
│  ├─ TECH-STACK.md               ← every technology used, and why
│  └─ Polypus-Architecture.pptx   ← architecture deck
├─ tools/deck/                    ← build-time generator for the deck (not deployed)
│  ├─ generate-deck.js            ← writes the .pptx; palette matches app.css
│  ├─ check-layout.js             ← detects overlapping shapes and off-canvas content
│  ├─ check-overflow.js           ← detects text boxes too small for their content
│  └─ README.md                   ← how to regenerate and verify the deck
└─ Polypus.Web/                   ← the application
   ├─ Program.cs                  ← startup and request pipeline
   ├─ Polypus.Web.csproj          ← project definition
   ├─ appsettings*.json           ← configuration
   ├─ Properties/launchSettings.json
   ├─ Models/                     ← data shapes and brand facts
   ├─ Services/                   ← content catalogs
   ├─ Components/
   │  ├─ App.razor                ← the HTML document
   │  ├─ Routes.razor             ← the router
   │  ├─ _Imports.razor           ← shared @using directives
   │  ├─ Layout/                  ← header, footer, main layout, reconnect modal
   │  ├─ Shared/                  ← buttons, cards, icons, headings
   │  └─ Pages/                   ← one file per route
   └─ wwwroot/                    ← static files served as-is
      ├─ app.css                  ← design system
      ├─ home.css                 ← home page sections
      ├─ favicon.svg
      ├─ brand/polypus-mark.svg
      └─ js/site.js
```

`tools/` is not part of the website and is never deployed. See
[tools/deck/README.md](./tools/deck/README.md).

---

## 5. Every file, and why it exists

### 5.1 Root and configuration

#### `Polypus.Web/Polypus.Web.csproj`
The project definition. Targets `net10.0`, enables nullable reference types and
implicit usings, and sets `BlazorDisableThrowNavigationException=true` so
internal navigations behave like normal link clicks.

**There are no `PackageReference` entries.** The site deliberately runs with zero
third-party NuGet packages — everything on screen is either the framework or
hand-written. Adding a package means adding a supply-chain item to review; if you
need one, add it here and note it in `docs/TECH-STACK.md`.

#### `Polypus.Web/Program.cs`
Startup. Registers Blazor, then configures the request pipeline:

| Call | What it does |
|------|--------------|
| `AddRazorComponents().AddInteractiveServerComponents()` | Enables Blazor and the interactive server render mode |
| `AddHttpContextAccessor()` | Lets `Error.razor` read the request identifier |
| `UseExceptionHandler("/Error")` | Non-development unhandled errors go to `Error.razor` |
| `UseHsts()` | Production only — tells browsers to use HTTPS |
| `UseStatusCodePagesWithReExecute("/not-found")` | A 404 status re-renders `NotFound.razor` while **keeping** the 404 status |
| `UseAntiforgery()` | Validates the contact form's anti-forgery token |
| `MapStaticAssets()` | Serves and fingerprints files from `wwwroot` |
| `MapRazorComponents<App>()` | Maps the component tree |

**Why `createScopeFor*: true` matters:** it starts a fresh dependency-injection
scope for the error and 404 handlers, so a failure inside a request cannot be
made worse by reusing that request's scoped services.

#### `Polypus.Web/appsettings.json`, `appsettings.Development.json`
Standard configuration. Currently only logging levels. Add connection strings or
feature flags here rather than hard-coding them.

#### `Polypus.Web/Properties/launchSettings.json`
The development launch profiles — which ports to bind and which environment name
to use. Edit the ports here if `5238` or `7251` are already taken.

### 5.2 The application shell

#### `Components/App.razor`
The outermost HTML document: `<html>`, `<head>` and `<body>`. Everything else
renders inside it.

It loads, in order: `favicon.svg`, `app.css`, `home.css`,
`Polypus.Web.styles.css` (Blazor's generated scoped CSS), the framework import
map, `<HeadOutlet />` (which lets any page write into `<head>`), the routed
components, the reconnect modal, `blazor.web.js`, and finally `js/site.js`.

**Ordering matters:** `home.css` comes after `app.css` so the home-page section
rules can override the generic design-system rules. `js/site.js` comes after
`blazor.web.js` so `window.Blazor` exists when it looks for the
`enhancedload` event.

**When to edit it:** adding a stylesheet, a font, an analytics tag or a meta tag
that applies to every page.

#### `Components/Routes.razor`
The router. Maps the current URL to a page component and applies
`MainLayout`. `NotFoundPage="typeof(Pages.NotFound)"` is what makes an unknown
URL render the 404 page. `<FocusOnNavigate Selector="h1" />` moves keyboard
focus to the page's `h1` after navigation, so screen-reader and keyboard users
start at the top of the new page.

#### `Components/_Imports.razor`
`@using` directives shared by **every** Razor file. This is why a page can write
`<AppIcon …>` or `PlanCatalog.Find(…)` without an `@using` of its own.

Adding a namespace here makes it available everywhere; use this instead of
repeating `@using` at the top of each page.

#### `Components/Layout/MainLayout.razor`
The frame around every page: a "skip to content" link, `<Header />`,
`<main id="main-content">@Body</main>`, `<Footer />`, and Blazor's error bar.

`@Body` is where the current page renders. The `id="main-content"` is the target
of the skip link, which is the first thing a keyboard user reaches.

#### `Components/Layout/Header.razor`
The sticky header. Contains the logo, the Home link, four dropdown menus —
**Product**, **Platform**, **Resources** (a wider panel with a highlight card)
and **Company** — plus a Help Center link, the `info@axonite.net` email and the
"Book a walkthrough" button. On narrow screens the nav collapses behind a
hamburger button that opens an accordion, one group per menu.

Key parts:

| Member | Purpose |
|--------|---------|
| `_openMenu` | Label of the open desktop dropdown, or null |
| `_openMobileGroup` | Label of the expanded mobile accordion group, or null |
| `_mobileOpen` | Is the mobile panel open? |
| `IsActive(href)` | "Is this link the current page?" |
| `IsMenuSection(menu)` | Highlights a trigger while any of its pages is open |
| `ToggleMenu` / `ToggleMobileMenu` / `ToggleMobileGroup` / `CloseAll` | State transitions; each closes the other menus |
| `Nav.LocationChanged` | Closes the menu after navigation, including browser back/forward |

It is `@rendermode InteractiveServer` because a dropdown needs click handling.

**Where the links come from:** the whole structure is looped from
`NavigationCatalog.HeaderMenu`, so adding an item is a catalog edit. Icons are
carried on each `NavMenuItem` as an `AppIcon` key — add a matching `case` in
`Components/Shared/AppIcon.razor` if you introduce a new icon.

#### `Components/Layout/Footer.razor`
The footer: brand block, social links, then the **four columns** and the meta row
(Privacy, Terms, Cookie, Data Processing, status chip), plus registration details
and the "sample content" disclaimer.

The four columns are **not** written in the markup — they are looped from
`NavigationCatalog.FooterColumns`. To add a footer link, add it to the catalog;
this file needs no change.

#### `Components/Layout/ReconnectModal.razor` (+ `.css`, `.js`)
The "reconnecting…" indicator shown when the Blazor circuit drops. Generated by
the `dotnet new blazor` template and kept as-is. You should not need to touch it.

**When you might:** if you rebrand, align its colours with your tokens.

### 5.3 Pages — one file per route

Every file below is in `Components/Pages/`. The `@page` directive at the top is
the route.

| File | Route | Interactivity | What it is for |
|------|-------|---------------|----------------|
| `Home.razor` | `/` | Server | **The main deliverable.** All 11 sections in order |
| `Contact.razor` | `/contact` | Server | Contact form, plan summary, success state |
| `Features.razor` | `/features` | Static | All eight features in detail |
| `Plans.razor` | `/plans` | Server | Plan cards, billing toggle, 32-row comparison table |
| `Integrations.razor` | `/integrations` | Static | SAP surfaces, webhook events, integration FAQ |
| `Product.razor` | `/product` | Static | Product overview in one page |
| `Workforce.razor` | `/workforce` | Server | The reference Workforce page: hero, Skills/Agents/Workforce rows, bundle grid, Build Your Own, scale band, FAQ |
| `InvoiceProcessing.razor` | `/workforce/invoice-processing` | Server | The reference Invoice Processing page: hero, tabbed how-it-works, 22-skill library with complexity tags, success stories, CTA |
| `OrderConfirmations.razor` | `/workforce/order-confirmations` | Server | The reference Order Confirmations page: hero, how-it-works, 12-skill library with complexity tags, CTA, 6-question FAQ |
| `DeliveryNotes.razor` | `/workforce/delivery-notes` | Server | The reference Delivery Notes page: hero, goods-receipt card, 12-skill library with complexity tags, CTA, 5-question FAQ |
| `OrderManagement.razor` | `/workforce/order-management` | Server | The reference Order Management page: hero, how-it-works with media, 14-skill library with complexity tags, CTA, 6-question FAQ |
| `Skills.razor` | `/skills` | Server | The reference Skills page: hero, four complexity cards, filterable 28-skill library, 4-question FAQ |
| `Platform.razor` | `/platform` | Server | The reference Platform page: hero, six capabilities, four-lever tab set, security band, model strip, CTA |
| `Agents.razor` | `/agents` | Server | The reference Agents page: hero, Collaborate/Reason/Use tools, seven workforce bundles, Build Your Own band, 4-question FAQ |
| `Integrations.razor` | `/integrations` | Server | The reference Integrations page: hero, four connector cards, data-flow cards, reliability stats, CTA |
| `Blog.razor` | `/resources/blog` | Server | The reference blog index: hero, seven filter chips, two featured cards and the 100-post grid with cover art, tags, read times and "Show more" |
| `FaqPage.razor` | `/faq` | Server | The reference FAQ page: hero, sticky table of contents, 8 groups / 53 questions with connector sub-sections |
| `SapConnector.razor` / `CoupaConnector.razor` / `IfsConnector.razor` / `OdooConnector.razor` | `/integrations/{partner}` | Static | Reference connector pages, rendered from `ConnectorCatalog` by `Shared/ConnectorPage.razor` (includes the integration diagram, partner lockup and security illustration) |
| `Company.razor` | `/company` | Static | About Axonite: story, facts, offices, contact |
| `Careers.razor` | `/careers` | Static | Six sample vacancies and the hiring process |
| `Changelog.razor` | `/changelog` | Static | Five sample releases, newest first |
| `Help.razor` | `/help` | Server | Searchable FAQ with category filters |
| `Status.razor` | `/status` | Static | Service components and past incidents |
| `PrivacyPolicy.razor` | `/privacy-policy` | Static | Privacy policy, 10 sections |
| `TermsOfService.razor` | `/terms-of-service` | Static | Terms, 10 sections |
| `CookiePolicy.razor` | `/cookie-policy` | Static | Cookie policy |
| `DataProcessing.razor` | `/data-processing` | Static | Data Processing Addendum |
| `NotFound.razor` | `/not-found` | Static | 404 with routes back into the site |
| `Error.razor` | `/Error` | Static | Unhandled-error page with the request identifier |

#### `Home.razor` — the main deliverable
22 KB, the largest file, and the one to read first. Its structure maps one-to-one
onto the table in [What this site is](#1-what-this-site-is).

Notable pieces:

- `_cycle` — the Monthly/Annual field driving the plan price toggle through
  `PlanCard`. Changing it re-renders every card.
- The hero console mock is **pure CSS** (`.console`, `.field-row`) — no image, so
  it stays sharp and adds no bytes to download.
- The four process steps are a local `ProcessStep[]` because they are specific to
  this page's narrative; the features, plans and FAQs come from catalogs because
  they are shared with other pages.
- `@rendermode InteractiveServer` at the top, because the price toggle and the
  FAQ accordion need server round-trips.

**To reorder sections:** move the corresponding `<section>` block. The `id`
attributes are also the anchor targets used by the header and footer links.

#### `Contact.razor` — the conversion page
19 KB. The most logic-heavy page; read it together with
[the plan → contact flow](#3-the-one-flow-that-matters-most-plan--contact).

| Member | Purpose |
|--------|---------|
| `PlanId` | `[SupplyParameterFromQuery(Name = "plan")]` — the plan from the URL |
| `_plan` | The resolved `Plan?`, or `null` |
| `_request` | The bound `ContactRequest` form model |
| `_showSummary` | Reveals the validation summary after a failed submit |
| `_submitted` | Has a valid form been submitted? |
| `Headline`, `_heroPills` | Page copy that changes depending on whether a plan was passed |
| `OnParametersSet` | Resolves `PlanId` via `PlanCatalog.Find` |
| `SyncPlanFromForm` | Keeps `_plan` in step when the visitor changes the dropdown |
| `OnValidSubmit` | Builds the reference number and switches to the success view |
| `HandleInvalidSubmit` | Sets `_showSummary` |
| `Dispose` | Unsubscribes the `LocationChanged` handler |

It implements `IDisposable` so the `NavigationManager.LocationChanged`
subscription is removed. Without that, every visit to the page would leak a
handler.

> **The form does not send email.** It validates and confirms. See
> [Before you go live](#11-before-you-go-live).

### 5.4 Shared components (`Components/Shared/`)

Reusable pieces with no knowledge of any particular page. If two pages need the
same markup, it belongs here.

| File | What it renders | Key parameters |
|------|-----------------|----------------|
| `AppIcon.razor` | Every icon on the site, as inline SVG | `Name` (one of ~34 keys), `Size`, `CssClass`, `StrokeWidth` |
| `BrandMark.razor` | The Polypus glyph, drawn inline | `Size`, `Plate`, `Stroke`, `Node`, `Decorative` |
| `SectionHeading.razor` | The eyebrow / title / description block above a section | `Eyebrow`, `Title`, `Description`, `Level`, `Split`, `Align` |
| `PlanCard.razor` | One pricing card, **and the plan → contact link** | `Plan`, `Cycle`, `CycleChanged` |
| `QuoteCard.razor` | A testimonial, featured (large, dark) or compact | `Testimonial` |
| `PageHero.razor` | The banner at the top of every inner page | `Breadcrumb`, `Eyebrow`, `Title`, `Lead`, `Pills` |
| `FaqList.razor` | A self-contained accordion | `Items`, `ShowCategory`, `CssClass` |
| `ContentPage.razor` | A full page built from a `ContentPageModel` (hero, card sections, FAQ, CTA) | `Page` |
| `LegalDocument.razor` | Long-form legal text with a sticky table of contents | `Sections`, `Intro`, `Updated` |

**`AppIcon.razor`** is worth understanding because it is used everywhere. It is
one `<svg>` element whose contents are chosen by a `@switch` on `Name`. Adding an
icon means adding a `case` with a `<path>`. Because a `switch` is not a valid
root element in Razor, the `<svg>` **must** stay outermost — removing it breaks
the build.

**`PlanCard.razor`** is the most important shared component in the repository,
because it produces the plan → contact link. See
[section 3](#3-the-one-flow-that-matters-most-plan--contact).

**`FaqList.razor`** owns its own open/closed state in a `private int _open`. Each
FAQ list on each page therefore has independent state for free. It is used by the
home page, `/plans`, `/integrations` and `/help`.

### 5.5 Models (`Models/`) — shapes and brand facts

Two kinds of file live here, and the distinction is worth keeping:

- **Plain shapes** — how a piece of data is structured.
- **Profile files** (`CompanyProfile`, `ProductProfile`) — the actual words and
  numbers about the brand.

| File | Contents |
|------|----------|
| `Plan.cs` | `BillingCycle` enum (Monthly/Annual) and the `Plan` record |
| `Feature.cs` | `Feature` — Id, Icon, Title, Summary, Details |
| `Testimonial.cs` | `Testimonial`, plus a computed `Initials` property that derives avatar text from the author's name |
| `Faq.cs` | `Faq`, plus `Matches(term)` — the method behind help search |
| `SiteModels.cs` | The small shared records: `Stat`, `ProcessStep`, `ComparisonRow`, `ComparisonGroup`, `NavLink`, `NavMenu`, `NavMenuItem`, `FooterColumn`, `ContentSection`, `ContentItem`, `ContentPageModel`, `Office`, `CapabilityChip`, `LegalSection` |
| `CompanyProfile.cs` | **Axonite**: legal name, story, founder, facts, three offices, sales/support/info emails, phone, hours |
| `ProductProfile.cs` | **Polypus**: positioning, headline, lead, four metrics, the hero document strip, ten document types, six integration surfaces, six sample customers |
| `ContactRequest.cs` | The contact form model, with all validation rules as attributes |

#### About `NavLink` — a real trap worth knowing
`NavLink` is declared as **`NavLink(Label, Href, Description)`** — label first.

Because both are strings, swapping them still compiles. It produces
`href="Features"` alongside a visible label of `/features` — a menu that looks
entirely plausible and is completely broken. This actually happened during
development. `NavigationCatalog.cs` now names the first two arguments
explicitly, and that file's comment explains why. **Keep the named arguments.**

#### Where the form rules live
`ContactRequest.cs` holds every validation rule as data annotations
(`[Required]`, `[EmailAddress]`, …). The contact page renders them automatically
through `DataAnnotationsValidator`, so **changing the rules means editing only
this file** — no Razor changes.

### 5.6 Services (`Services/`) — the content catalogs

This is where the site's words and numbers actually live. Every one is a
`static` class, so nothing needs registering in `Program.cs`.

| File | Owns | Key members |
|------|------|-------------|
| `PlanCatalog.cs` | Pricing | `All` (4 plans), `Volumes`, `SapLandscapes`, `Aliases`, `Find()`, `IsKnown()`, `Describe()`, `Selectable` |
| `FeatureCatalog.cs` | The eight capabilities | `All`, `HomeHighlights` (first six), `IconKeys` |
| `TestimonialCatalog.cs` | Five quotes | `All`, `Featured`, `Others` |
| `FaqCatalog.cs` | Twelve FAQs | `All`, `HomeHighlights`, `Categories`, `Search(term, category)` |
| `NavigationCatalog.cs` | Every header and footer link | `HeaderMenu`, `ProductMenu`, `FooterColumns`, `AllRoutes` |
| `ContentPageCatalog.cs` | The pages behind the header menus | `Workforce`, `Platform`, `Skills`, `Blog`, `FaqPage`, `ByRoute`, … |

#### `PlanCatalog.cs` — the pricing source of truth
The most important file for anyone changing commercial copy.

- `All` — the four plans, in display order. `SortOrder` is the ordering key.
- `MonthlyPrice` / `AnnualPrice` — `decimal`. Changing a price here changes it on
  `/plans` and the contact page's summary panel, all at once.
- `PriceNote` / `CustomPriceLabel` — for Enterprise, which has no number.
- `IsPopular` — marks Growth with the "Most chosen" badge.
- `Aliases` — tolerated spellings from the URL, e.g. `pro → growth`.
- `Find()` — resolves an untrusted string to a `Plan?`. **Returns `null` for
  unknown input rather than throwing**; that is what makes a hand-typed
  `?plan=whatever` harmless.
- `IsKnown()` — a safe boolean for conditional copy.
- `Describe()` — one-line human description used in the summary panel.

#### `FaqCatalog.cs` — the search behind `/help`
- `Search(term, category)` — case-insensitive substring match across question and
  answer, optionally narrowed by category. `null`/empty matches everything.
- `Categories` — distinct categories for the filter chips.
- `HomeHighlights` — the FAQs flagged `FeaturedOnHome: true`.

### 5.7 `wwwroot/` — static assets

#### `wwwroot/app.css` (~40 KB) — the design system
Organised into numbered sections. It starts with tokens and gets more specific,
so a later section can override an earlier one without `!important`.

| § | Section | What is in it |
|---|---------|---------------|
| 1 | Design tokens | The `:root` custom properties — colours, fonts, spacing, radii, shadows |
| 2 | Reset and base | Box sizing, margins, focus rings, selection, `scroll-behavior` |
| 3 | Layout | `.container`, `.section`, `.grid-*`, `.stack`, `.row` |
| 4 | Typography | `.display`, `.h2`–`.h4`, `.eyebrow`, `.lead`, `.muted`, `.measure` |
| 5 | Buttons and controls | `.btn` variants, pills, `.toggle-group`, `.link-arrow` |
| 6 | Surfaces | `.card`, `.check-list`, `.dl` |
| 7 | Header | Sticky bar, `.dropdown`, `.mobile-nav`, `.nav__scrim` |
| 8 | Footer | Columns, meta row, social, small print |
| 9 | Inner-page blocks | `.page-hero`, `.table-wrap`, `.chip-grid`, `.toolbar`, `.legal`, `.prose`, `.status-chip` |
| 10 | Forms | `.form-grid`, `.field`, `.contact-layout`, `.plan-summary`, `.form-success`, `.validation-summary` |
| 11 | Utilities, motion, responsive | Reveal animation, `prefers-reduced-motion`, `#blazor-error-ui` |

**Change the look here, not in the Razor.** Because the components only carry
class names, changing a token changes every use at once.

#### `wwwroot/home.css` (~26 KB) — the home page sections
Section-specific styling that would bloat `app.css`: hero and console mock, logo
strip, metrics, feature grid, process timeline, plan cards, company block,
testimonials, FAQ accordion, closing CTA, and the responsive rules.

Loaded after `app.css`, so it wins ties.

#### `wwwroot/js/site.js` (~6 KB) — two cosmetic enhancements
Described in full in
[JavaScript, and why the site works without it](#8-javascript-and-why-the-site-works-without-it).

#### `wwwroot/favicon.svg` and `wwwroot/brand/polypus-mark.svg`
The browser-tab icon and the Polypus glyph. Both are SVG, so they stay crisp at
any size. `BrandMark.razor` inlines its own copy so it can inherit `currentColor`
from the surrounding text.

### 5.8 `tools/deck/` — the architecture deck generator

Not part of the website. Never deployed, never built by `dotnet`, and not
referenced by `Polypus.Web`. It exists so `docs/Polypus-Architecture.pptx` is
*generated from source* rather than hand-assembled, which keeps it reproducible
and consistent with the site's palette.

| File | What it does |
|------|--------------|
| `generate-deck.js` | Builds all 12 slides and writes `docs/Polypus-Architecture.pptx`. Holds the palette and font constants (mirroring `app.css`) and one block per slide. |
| `check-layout.js` | Reads the generated `.pptx` back and reports overlapping shapes or content running off the canvas. |
| `check-overflow.js` | Estimates whether each text box is tall enough for its text, catching content that spills onto the slide below it. |
| `package.json` | Declares the single dependency, `pptxgenjs` 4.0.1. |
| `README.md` | How to regenerate and verify the deck. |

**The two checkers exist for a reason.** `pptxgenjs` does not auto-shrink or
auto-grow anything: a text box that is too short does not error, it silently
overlaps the next element. Neither problem is visible in code, and both are easy
to introduce when editing slide geometry. Run them after any change to
`generate-deck.js`:

```powershell
cd tools\deck
npm install
node generate-deck.js ; node check-layout.js ; node check-overflow.js
```

---

## 6. Where to change things

| I want to… | Edit this | Notes |
|-----------|-----------|-------|
| Change a price | `Services/PlanCatalog.cs` | Updates `/plans` and the contact summary at once |
| Add or rename a plan | `Services/PlanCatalog.cs` + `Components/Pages/Plans.razor` | The comparison table has one value per plan per row — add a column entry to every `ComparisonRow` |
| Accept another URL spelling for a plan | `Services/PlanCatalog.Aliases` | e.g. add `["starter"] = "basic"` |
| Reword a feature | `Services/FeatureCatalog.cs` | Appears on `/` and `/features` |
| Add a feature | `Services/FeatureCatalog.cs` | Add to `All`; the home page shows the first six automatically |
| Change the company facts | `Models/CompanyProfile.cs` | Name, story, offices, emails, phone |
| Change the product positioning | `Models/ProductProfile.cs` | Headline, lead, metrics, document types |
| Edit a testimonial | `Services/TestimonialCatalog.cs` | Keep exactly one `IsFeatured` |
| Add or edit an FAQ | `Services/FaqCatalog.cs` | Set `FeaturedOnHome: true` to show it on `/` |
| Add a footer link | `Services/NavigationCatalog.cs` | Footer loops the catalog; no markup change |
| Add a header menu or item | `Services/NavigationCatalog.cs` (+ a page) | `HeaderMenu` drives both the desktop dropdown and the mobile accordion |
| Edit the content of a header page | `Services/ContentPageCatalog.cs` | Rendered by `Components/Shared/ContentPage.razor` |
| Change the brand colour | `wwwroot/app.css` §1 | `--accent`, `--accent-bright`, `--ink`, `--paper` |
| Change the fonts | `wwwroot/app.css` §1 | `--font-serif`, `--font-sans`, `--font-mono` |
| Change spacing everywhere | `wwwroot/app.css` §1 | `--s-1` … `--s-9` |
| Restyle one section | `wwwroot/home.css` | Loaded after `app.css` |
| Add a whole new page | `Components/Pages/MyPage.razor` | Start with `@page "/my-page"` |
| Change form validation | `Models/ContactRequest.cs` | Rules are attributes on the model |
| Change the header or footer layout | `Components/Layout/Header.razor` / `Footer.razor` | — |

### Adding a new page — the short version

1. Create `Components/Pages/MyPage.razor`.
2. Put `@page "/my-page"` at the top and a unique `<PageTitle>`.
3. Compose it from `<PageHero>`, `<SectionHeading>` and the other shared components.
4. Add links to it in `Components/Layout/Footer.razor` or
   `Services/NavigationCatalog.cs`.
5. Check it renders at `/my-page`.

You do **not** need to register the route anywhere — the router discovers pages
in the assembly automatically.

---

## 7. The design system

### Colour

A warm, paper-like palette with one deep teal accent. The intent is "considered
enterprise document product", not "generic SaaS gradient".

| Token | Value | Used for |
|-------|-------|----------|
| `--paper` | `#faf9f7` | Page background — warm off-white, not pure white |
| `--ink` | `#12151c` | Primary text |
| `--accent` | `#0f766e` | Buttons, links, active states |
| `--accent-bright` | `#14b8a6` | Highlights on dark backgrounds |
| `--gold`, `--coral` | — | Small accents only — badges and pills |

**All colour lives in `:root` at the top of `app.css`.** Nothing below it writes
a raw hex value for a themeable colour, so the palette can be changed in one
place.

### Type

Three families, each with a job. Every stack ends in a generic family, so no font
download is required and nothing breaks if a font is unavailable.

| Token | Stack | Used for |
|-------|-------|----------|
| `--font-serif` | Newsreader, Iowan Old Style, Palatino Linotype, Georgia, serif | Headings — the editorial feel |
| `--font-sans` | Inter, system-ui, …, sans-serif | Body copy and UI |
| `--font-mono` | — | Numbers, reference codes, the console mock |

**No web fonts are downloaded.** The site uses fonts the visitor may already
have. That removes a render-blocking request and any third-party tracking — a
genuine advantage for a site about data governance.

### Spacing and radius

`--s-1` … `--s-9` is one spacing scale used for all padding, margin and gaps;
`--r-xs` … `--r-full` does the same for corners. Because components reference
these tokens rather than raw pixels, adjusting the scale re-proportions the whole
site consistently.

### Responsive approach
Desktop-first rules, then `@media` blocks at the end of each stylesheet that
reflow the grids. The header nav collapses behind a hamburger below 1200 px, where
`.mobile-nav` takes over. There is no horizontal overflow at 390 px wide.

---

## 8. JavaScript, and why the site works without it

The entire JavaScript budget is **`wwwroot/js/site.js`, about 6 KB, with two
jobs**:

1. A border and shadow on the sticky header once the page is scrolled (`.is-stuck`).
2. A fade-and-rise animation for `[data-reveal]` elements as they scroll into view.

**Everything else is CSS or Blazor.** There is no jQuery, no animation library,
no carousel plugin, no framework, and no CDN request.

### The reveal animation is built to fail safe
This is a deliberate design decision worth preserving.

`app.css` **never hides** a `[data-reveal]` element. Its resting state is fully
visible. JavaScript only *adds* `.is-visible`, which plays a one-shot keyframe
animation. So:

| Situation | Result |
|-----------|--------|
| JavaScript disabled or blocked | Sections visible, no animation. **Nothing is lost.** |
| `prefers-reduced-motion: reduce` | Sections visible, no animation |
| `site.js` throws an error | Sections visible, no animation |
| Normal | Sections animate in as you scroll |

The alternative — hiding in CSS and revealing in JS — looks identical when
everything works, but turns a script failure into **blank sections on a
marketing page**. That is the wrong failure mode, so the site avoids it.

### Why `site.js` is defensive about the DOM
Blazor's interactive circuit re-renders the home, plans, contact and help pages
after the server HTML arrives, **replacing those DOM nodes**. Anything attached
to the original elements — listeners, observer registrations — is then pointing
at detached elements and silently does nothing.

So the file follows one rule: **never hold on to an element.** It re-queries the
current node each time, re-scans on Blazor's `enhancedload` event, and watches
for DOM changes with a `MutationObserver`. The scroll listener is attached once
to `window` and looks the header up when it fires.

> This was found by testing, not by reading. During development the reveal
> animation appeared to work while six sections stayed permanently invisible,
> because the observer was watching nodes Blazor had already discarded.

### Adding JavaScript
If you must add a script:

- Prefer a plain `<script src>` in `App.razor`.
- Keep it in the same "look elements up, never capture them" style.
- Treat it as optional. The page should still be usable if it never runs.

---

## 9. Render modes

Blazor can render a component on the server, in the browser, or both. This site
uses two modes, chosen per page. The default is **static server rendering**,
which sends finished HTML with no WebSocket and no JavaScript needed for the
content.

| Mode | Pages | Why |
|------|-------|-----|
| **InteractiveServer** | `/`, `/plans`, `/contact`, `/help`, `/workforce`, and the header | These have real interaction: an accordion, a price toggle, a validated form, a search box, a dropdown |
| **Static (default)** | Everything else | Pure content. Full HTML arrives immediately, with no circuit to wait for |

**Why this matters:**
- Interactive pages need a live connection. If it drops, Blazor shows the
  reconnect modal — expected behaviour, not a bug.
- Static pages are faster, more robust and more cacheable. Adding
  `@rendermode InteractiveServer` to a page that only displays text is a
  downgrade.
- The header is interactive because it has a dropdown and a mobile menu.

**To make a page interactive**, add this as the first line:

```razor
@rendermode InteractiveServer
```

**To make it fast again**, remove that line.

---

## 10. Accessibility

Built in from the start rather than retrofitted:

- **Landmarks** — `<header>`, `<nav aria-label="Main">`, `<main id="main-content">`,
  `<footer>`. A screen reader can jump straight to any of them.
- **Skip link** — the first focusable element bypasses the header.
- **Focus management** — `<FocusOnNavigate Selector="h1" />` moves focus to the
  heading of each new page, so keyboard users are not stranded at the top.
- **ARIA on real widgets** — each header dropdown is a `button` with
  `aria-expanded`/`aria-controls` around a `role="menu"`; the accordion buttons
  carry `aria-expanded`; the validation summary is `role="alert"`.
- **Visible focus** — a clear `:focus-visible` ring on every interactive element,
  never removed.
- **Labels** — every form field is a real `<label for=…>`, with `aria-describedby`
  connecting the hint and error text.
- **Decorative icons** — inline SVGs carry `aria-hidden="true"` and
  `focusable="false"`, so they are not announced.
- **Meaningful link text** — plan buttons carry `aria-label`s like
  "Choose Growth - continue to the contact form with the Growth plan selected"
  instead of a bare "Choose".
- **Reduced motion** — `prefers-reduced-motion: reduce` disables the reveal
  animation and smooth scrolling.
- **Contrast** — text against background targets WCAG AA.
- **No horizontal scroll** at 390 px.

**If you add a component**, keep these habits: use a real `<button>` for actions
and a real `<a href>` for navigation; label every input; add `aria-expanded` to
anything that opens.

---

## 11. Before you go live

The site is complete and runs, but several things are deliberately placeholders.
Work through this list.

### Must do

1. **The contact form does not send anything.** `Contact.razor`'s `OnValidSubmit`
   builds a reference number and shows the success panel — it does not call an
   API and no email is sent. Wire it to your real endpoint (a
   `POST` to your CRM, or SMTP) and remove the "sample" behaviour. Until then, a
   visitor's enquiry is **silently discarded** — this is the single most
   important item on this list.
2. **Replace the sample content.** The testimonials
   (`TestimonialCatalog.cs`) and customer names (`ProductProfile.Customers`) are
   **invented**. They are labelled as illustrative in the UI and in code
   comments, but publishing them as real endorsements would be misleading.
   Careers, changelog and status pages are likewise sample data.
3. **Replace the brand mark.** `BrandMark.razor`, `favicon.svg` and
   `brand/polypus-mark.svg` are a hand-drawn placeholder glyph, not a real logo.
4. **Have a lawyer review the legal pages.** Privacy, Terms, Cookie Policy and
   the Data Processing Addendum are realistic, well-structured starting points —
   **not legal advice**. The DPA in particular is a contract.
5. **Set your real domains and contact details** in `CompanyProfile.cs`
   (`axonite.io` is a placeholder) and verify the phone number and support hours.
6. **Add analytics, if you want it** — in `App.razor`, and note that this site
   currently makes **zero third-party requests**, which is worth keeping.

### Should do

7. Check the metrics and claims in `ProductProfile.cs` — 5L documents, 90%,
   85% +, 4.1x — are ones you can substantiate.
8. Add a `robots.txt` and a sitemap.
9. Add social preview tags (`og:title`, `og:image`) in `App.razor` — social links
   are in the footer but there are no preview tags yet.
10. Decide on cookie consent. There is currently no tracking, so none is needed —
    keep it that way if you can.
11. Configure error logging so `/Error` has something to report, and confirm
    `UseExceptionHandler` is active in your production environment.
12. Set a real `ASPNETCORE_ENVIRONMENT` and review `appsettings.json` for the
    deployed environment.

### Deployment notes

The output is a normal ASP.NET Core app:

```powershell
cd Polypus.Web
dotnet publish -c Release
```

Deploy `bin/Release/net10.0/publish/` to IIS, Azure App Service, a container, or
any host that runs .NET 10. Behind a load balancer, **enable sticky sessions /
WebSocket affinity** — Blazor's interactive pages hold a WebSocket connection,
and without affinity those pages degrade to the reconnect modal.

---

## 12. Troubleshooting

### The build fails after I edited a `.razor` file
Common causes, in order of likelihood:

1. **Two root elements.** A Razor component must have exactly one outermost
   element. A `@switch` or `@if` as the only top-level node is invalid — wrap it
   in an element (this is why `AppIcon.razor` keeps its `<svg>` outermost).
2. **`@using` missing.** Add it to `Components/_Imports.razor` rather than to one page.
3. **A typo in a component parameter.** Parameter names are case-sensitive:
   `Plan=` not `plan=`.
4. **An unmatched tag or brace.**

### `The name 'X' does not exist in the current context`
Add the namespace to `Components/_Imports.razor`. The three project namespaces —
`Components.Shared`, `Models`, `Services` — are already there.

### A page 404s
Check the `@page` directive is the route you expect, with a leading `/`. The
router discovers routes automatically; nothing needs registering.

### The page hangs on "Reconnecting…"
The Blazor circuit dropped. In development this is usually a rebuild. In
production it means the WebSocket was interrupted — check for a proxy or load
balancer without WebSocket support and sticky sessions.

### Interactive features do nothing
The page is probably missing `@rendermode InteractiveServer` as its first line.
Content will render but clicks will not respond.

### A dropdown or footer link goes somewhere odd
Check `Services/NavigationCatalog.cs`. If the arguments to `NavLink` are swapped,
the links will be silently wrong — this is exactly the `NavLink` trap described
in [Models](#about-navlink--a-real-trap-worth-knowing).
**Use named arguments** (`Label:`, `Href:`) to prevent it.

### Sections look empty on the home page
Only possible if you have re-added CSS that hides `[data-reveal]` elements. The
design intentionally never hides them — see
[the reveal animation](#the-reveal-animation-is-built-to-fail-safe). Check that
`app.css` still has no `opacity: 0` on a bare `[data-reveal]` selector.

### Verifying all routes
Start the site, then check each of these returns `200`:

```
/            /features     /plans            /integrations   /product
/company     /careers      /changelog        /help           /status
/contact     /contact?plan=growth
/privacy-policy  /terms-of-service  /cookie-policy  /data-processing
/not-found
```

An unknown URL such as `/nope` should return **404** (rendering the 404 page)
while showing the styled "page not found" content.

---

## 13. Glossary

| Term | Meaning |
|------|---------|
| **Polypus** | The product this site markets |
| **Axonite** | The company that owns and builds Polypus |
| **STP** | Straight-through processing — a document that posts with no human touch |
| **Three-way match** | Checking a purchase order, goods receipt and invoice agree |
| **IDoc / BAPI / OData** | SAP interfaces for moving data in and out of SAP |
| **Parked document** | A draft in SAP that needs a human before it posts |
| **Render mode** | Where a Blazor component runs — on the server, in the browser, or both |
| **Static SSR** | Server rendering that sends finished HTML with no live connection |
| **InteractiveServer** | Server rendering with a live WebSocket for click handling |
| **Circuit** | The stateful connection between the browser and the server in interactive mode |
| **Catalog** | A static class in `Services/` holding content — the site's editable copy |
| **Design token** | A named CSS variable such as `--accent` holding one design decision |
| **`[data-reveal]`** | Marks a section for the optional scroll-in animation |

---

*Polypus — intelligent document processing and controlled SAP automation, owned
by Axonite.*
