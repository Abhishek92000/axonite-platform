# Tech stack

Every technology used by the Polypus website, what it does, and why it was
chosen. Read this before adding a dependency: the stack is deliberately small,
and each entry below lists what it would cost to replace.

---

## 1. At a glance

| Layer | Technology | Version | Where it is declared |
|-------|-----------|---------|----------------------|
| Language (server) | C# | 14 (with .NET 10) | implied by the target framework |
| Language (client) | JavaScript (ES5-style, no build) | — | `wwwroot/js/site.js` |
| Runtime | .NET | 10.0 | `Polypus.Web.csproj` |
| Web framework | ASP.NET Core | 10.0 | `Polypus.Web.csproj` |
| UI framework | Blazor Web App | 10.0 | `Program.cs` |
| Render mode | Interactive Server | — | per page |
| Markup | Razor components (`.razor`) | — | `Components/` |
| Styling | Hand-written CSS | — | `wwwroot/app.css`, `home.css` |
| Icons | Inline SVG | — | `Components/Shared/AppIcon.razor` |
| Fonts | System font stacks | — | `wwwroot/app.css` §1 |
| Forms and validation | Blazor `EditForm` + DataAnnotations | — | `Components/Pages/Contact.razor` |
| Testing | Manual route verification | — | see README §12 |
| NuGet packages | **none** | — | `Polypus.Web.csproj` |
| npm packages | **none at runtime** | — | — |
| CDN / third-party runtime calls | **none** | — | — |

**Two numbers to notice: zero NuGet packages, zero runtime npm packages.** The
only third-party code that ever runs is the .NET SDK and framework themselves.
The single npm dependency in this repository (`pptxgenjs`) is a build-time tool
used once to generate the architecture deck and is not part of the deployed
application.

---

## 2. Platform

### .NET 10 (`net10.0`)
The application platform. Provides the runtime, garbage collector, HTTP server,
configuration system, dependency injection container and logging.

- **Declared in:** `Polypus.Web/Polypus.Web.csproj` → `<TargetFramework>net10.0</TargetFramework>`
- **Why:** it is the current LTS-track release, and the Blazor tooling for
  static server rendering plus per-page interactivity is mature here.
- **Cost to replace:** none — this is the foundation. Changing it means a rewrite.
- **Requirement:** the .NET 10 SDK to build, the .NET 10 runtime to run.

### ASP.NET Core 10
The web host. Routing, middleware, static file serving, HTTPS, antiforgery,
error handling and configuration.

- **Configured in:** `Polypus.Web/Program.cs`
- **Key middleware:** `UseExceptionHandler`, `UseStatusCodePagesWithReExecute`,
  `UseAntiforgery`, `UseHsts`, `UseHttpsRedirection`, `MapStaticAssets`.
- **Why:** comes with .NET; a separate web server framework would add a moving
  part for no benefit.
- **Cost to replace:** very high.

### C# 14
The server-side language. The model layer leans on language features that keep
the code short and hard to get wrong:

| Feature | Example in this repository |
|---------|---------------------------|
| `record` | `Plan`, `Feature`, `Testimonial` — value equality and concise declarations |
| `required` members | `Testimonial.Author`, `Plan.Name` — the compiler rejects an object built without them |
| Collection expressions | `All = [ new Plan { … }, … ]` |
| Primary constructors | `Stat(string Value, string Label, string? Footnote = null)` |
| Nullable reference types | `Plan? Find(string? id)` — the signature states it can return nothing |
| `nameof` and expression-bodied members | `AllRoutes => …` |
| Computed properties | `Testimonial.Initials` derives the avatar text from the name |

- **Cost to replace:** n/a.

### Blazor Web App — interactive server render mode
The UI framework. Components are written in Razor and executed on the server;
DOM updates travel over a WebSocket.

- **Registered in:** `Program.cs` — `.AddRazorComponents().AddInteractiveServerComponents()`
- **Mapped in:** `Program.cs` — `.MapRazorComponents<App>().AddInteractiveServerRenderMode()`
- **Applies to:** `/`, `/plans`, `/contact`, `/help`, and the site header.

**Why Interactive Server rather than WebAssembly or Auto:**

| Option | Why not chosen |
|--------|----------------|
| Blazor WebAssembly | Ships the .NET runtime to the browser — several MB before the first pixel, for a marketing site whose interactivity is a price toggle |
| Blazor Auto | Best of both, but the extra configuration earns nothing here |
| **Interactive Server** | Server holds the state; the browser gets a small WebSocket. Fast first paint and simple code |
| Static SSR only | Would lose the price toggle, accordion, search and validated form |

The trade-off is a persistent connection on interactive pages, which requires
**sticky sessions / WebSocket affinity** behind a load balancer. That is
documented in the README's deployment notes.

- **Cost to replace:** high. Replacing Blazor means rewriting every page.

---

## 3. Front end

### Razor components (`.razor`)
The markup and component model. One file per page or reusable component, with
HTML, C# and directives together.

- **Location:** `Components/Pages/` (routes), `Components/Shared/` (reusable),
  `Components/Layout/` (chrome).
- **Why:** ships with ASP.NET Core, gives compile-time checking of markup
  (`<PlanCard Plan="@plan" />` fails the build if the parameter is wrong), and
  needs no separate SPA toolchain.
- **Cost to replace:** high.

### Hand-written CSS — no framework
The entire visual design. About 66 KB of unminified CSS across two files.

- **Location:** `wwwroot/app.css` (~40 KB, the design system),
  `wwwroot/home.css` (~26 KB, home-page sections).
- **Approach:** a `:root` block defines 53 design tokens; everything below
  references them. Components carry class names only, never inline styles.

**Why not Bootstrap / Tailwind / Bulma:**

| Concern | Consequence of a framework here |
|---------|--------------------------------|
| Payload | Bootstrap's CSS is larger than all the CSS on this site combined, and most of it would be unused |
| Distinctiveness | Framework defaults are instantly recognisable — the opposite of the brief, which asked for a site that does not look machine-generated |
| Overriding | Fighting framework specificity with `!important` ages badly |
| Upgrades | A major-version bump means re-checking every screen |
| Control | This design needs an editorial serif/sans pairing and a custom console mock; both are simpler to write directly than to coax out of a framework |

**The trade-off, stated honestly:** no utility classes means writing more CSS by
hand, and there is no design-system documentation generator. Mitigations are the
token system (change one value, update every use) and the numbered section
comments in each stylesheet that make it navigable.

- **Cost to replace:** medium, and mostly mechanical. It is only CSS.

### CSS custom properties (design tokens)
53 variables in `:root`, covering colour, typography, spacing, radii and shadows.

- **Example:** `--accent: #0f766e`, `--s-5`, `--r-lg`.
- **Why:** one place to change the palette or spacing rhythm. Verified during
  development: every `var(--x)` reference resolves to a defined token, so no
  rule silently falls back to nothing.
- **Cost to replace:** low, but there is no reason to.

### CSS features used
Standard, widely supported, no preprocessor and no build step:

- Custom properties, `flexbox`, `grid`, `clamp()` for fluid type
- `position: sticky` (header, legal TOC)
- `cubic-bezier()` transitions and one `@keyframes` reveal animation
- `:focus-visible` for keyboard-only focus rings
- `@media` queries for responsive behaviour and `prefers-reduced-motion`

**No Sass, no PostCSS, no Autoprefixer, no CSS modules, no CSS-in-JS.** Native
CSS now covers what these were needed for, so the build stays a single command.

### Inline SVG icons
Every icon is an SVG path written directly into a Razor component.

- **Location:** `Components/Shared/AppIcon.razor` — one `<svg>` whose contents are
  selected by a `@switch` on `Name` (~34 icons).
- **Why not an icon font or an icon package:** an icon font downloads a whole
  font file and renders as text; a package adds a dependency for shapes that are
  a few hundred bytes each. Inline SVG inherits `currentColor`, scales cleanly,
  and can be marked `aria-hidden` so screen readers skip it.
- **Adding an icon:** add a `case` with a `<path>`. Keep the `<svg>` outermost —
  Razor requires exactly one root element.
- **Cost to replace:** low.

### System font stacks — no web fonts
Three stacks, each ending in a generic family.

| Token | Purpose |
|-------|---------|
| `--font-serif` | Headings — Newsreader → Iowan Old Style → Palatino → Georgia → serif |
| `--font-sans` | Body and UI — Inter → system UI fonts → sans-serif |
| `--font-mono` | Numbers and reference codes |

**Why:** no web font means no render-blocking request and no font-loading flash.
For an enterprise site about data governance, making **zero third-party
requests** is also a credibility point — no font CDN sees your visitors.

The trade-off is that headlines render in whatever the visitor's machine already
has, so the exact serif varies by platform. If brand consistency across
platforms matters more than the extra request, self-host one font here.

- **Cost to replace:** low.

### JavaScript — one small file, no build step
~6 KB at `wwwroot/js/site.js`, plain ES5-compatible, no bundler, no transpiler,
no npm dependency at runtime.

It does exactly two things: a sticky-header shadow, and an opt-in scroll reveal
for `[data-reveal]` elements.

It is written to run **after** `blazor.web.js` (so `window.Blazor` exists) and to
re-scan on Blazor's `enhancedload` and on DOM mutation, because the interactive
circuit replaces DOM nodes. See the README's
[JavaScript section](#8-javascript-and-why-the-site-works-without-it) for why
that matters.

**Guiding principle: JavaScript is optional.** The reveal animation plays only
when the script runs; it never hides content in CSS. With scripts blocked the
site is fully usable, just without two cosmetic effects.

- **Cost to replace:** low.

---

## 4. Forms and validation

**Blazor `EditForm` + `DataAnnotationsValidator` + .NET DataAnnotations.**

- **Implementation:** `Components/Pages/Contact.razor`,
  `Models/ContactRequest.cs`
- **How it works:** validation rules are attributes on the model
  (`[Required]`, `[EmailAddress]`, `[StringLength]`, `[Range]`). `EditForm` runs
  them, shows a `role="alert"` summary and per-field messages, and only calls
  `OnValidSubmit` when everything passes.

**Why this over a form library:**

| Concern | Benefit here |
|---------|--------------|
| Single source of truth | All rules live in one C# file; the Razor never repeats them |
| Server-side authority | Validation runs on the server, so it cannot be bypassed from the browser |
| Accessibility | Blazor wires `aria-invalid` and the summary's alert role |
| Antiforgery | `UseAntiforgery()` plus the token Blazor injects protect the POST |
| No dependency | Zero packages |

**Not implemented:** rate limiting, CAPTCHA and spam protection. Add those when
the form is wired to a real endpoint — see README §11.

- **Cost to replace:** medium.

---

## 5. Configuration and hosting

| Concern | Mechanism | File |
|---------|-----------|------|
| Settings | `appsettings.json` + environment overrides | `Polypus.Web/appsettings*.json` |
| Dev ports and env | Launch profiles | `Properties/launchSettings.json` |
| Static files | `MapStaticAssets()` with fingerprinting | `Program.cs` |
| Errors | `UseExceptionHandler("/Error")` | `Program.cs`, `Pages/Error.razor` |
| Missing routes | `UseStatusCodePagesWithReExecute("/not-found")` | `Program.cs`, `Routes.razor`, `Pages/NotFound.razor` |

`MapStaticAssets()` fingerprints filenames and emits precompressed variants, so
static assets can be cached aggressively and served compressed without extra
configuration. **No CDN, no external asset host.**

### Deployment targets
Any host running .NET 10: IIS, Azure App Service, a container, or a Linux host
with the runtime.

**Requirement:** because interactive pages hold a WebSocket, enable **sticky
sessions / WebSocket affinity** if you run more than one instance. Without it
those pages fall back to the reconnect modal.

---

## 6. Build and tooling

### .NET CLI
```powershell
dotnet run                 # run locally
dotnet build               # compile
dotnet build -c Release    # release compile
dotnet watch               # rebuild + hot reload
dotnet publish -c Release  # produce deployable output
```

**No MSBuild customisation, no build scripts, no task runner, no Dockerfile.**
One command compiles and runs the whole application, front end included.

### `pptxgenjs` 4.0.1 — build-time only, not shipped
Used to generate `docs/Polypus-Architecture.pptx`.

- **Installed in:** `tools/deck/` — a separate, self-contained generator project.
- **Runtime impact:** none. Nothing in `Polypus.Web/` references it, and it is not
  part of the published output.
- **Why it exists at all:** the architecture deck was a requested deliverable, and
  generating it programmatically keeps it reproducible and consistent with the
  site's own palette rather than being a hand-assembled file. The folder also
  carries two verification scripts that read the generated `.pptx` back to check
  for overlapping shapes and under-sized text boxes.
- **How to regenerate:** `cd tools/deck ; npm install ; node generate-deck.js`.
  See [tools/deck/README.md](../tools/deck/README.md).

### Verified during development, not automated

| Check | Method | Result |
|-------|--------|--------|
| Compilation | `dotnet build -c Release` | 0 warnings, 0 errors |
| Every route | HTTP request to each of the 19 routes | all `200`; an unknown URL returns `404` |
| Every link | Extracted all `href`s from every page | 0 broken links |
| Every CSS class | Compared 226 classes used in Razor against the stylesheets | all resolve |
| Every CSS token | Compared 46 `var(--x)` uses against 53 definitions | 0 undefined |
| Plan → contact | Clicked each plan CTA | `/contact?plan=<id>` with the plan preselected |
| Form validation | Submitted empty, then valid | Summary and per-field errors; success panel with a reference number |
| Interactive widgets | Price toggle, FAQ accordion, help search, mobile nav | all behave |
| Responsive | 1440 px and 390 px viewports | no horizontal overflow |

**There is no automated test suite.** For a static marketing site this was a
judgement call: the meaningful risks are visual and content-related, and the
checks above catch them directly. If the contact form is wired to a real backend,
add integration tests around that endpoint — it becomes the only part with
genuine logic worth locking down.

---

## 7. Deliberate omissions

Each of these was considered and left out. If you add one, add it here with its
reason and cost.

| Not used | Why not | What it would cost |
|----------|---------|--------------------|
| Bootstrap / Tailwind | Payload, generic look, specificity fights | A rewrite of the stylesheets |
| jQuery | Not needed — no DOM library requirement remains | None; it would only add weight |
| Icon package / icon font | Inline SVG is smaller and inherits colour | Low |
| Web fonts / Google Fonts | Render-blocking, third-party request, privacy | One self-hosted font file |
| CSS preprocessor | Native custom properties and nesting cover it | A build step for little gain |
| JS bundler / npm | One 6 KB file, no modules to resolve | A whole toolchain |
| SPA framework (React/Vue/Angular) | Blazor already owns the component model | Redundant and heavy |
| Client-side Blazor (WASM) | Multi-MB download for a price toggle | Slower first paint |
| Database | Nothing on this site needs persistence | Infrastructure and migrations to maintain |
| CMS | Five catalogs are easier to review in Git than a CMS UI | Admin UI, hosting, integration |
| Authentication | No user-specific content | Identity, sessions, security review |
| Analytics / tag manager | Keeps the site free of third-party requests | One script tag; review the privacy policy if added |
| CDN | `MapStaticAssets` with fingerprinting is sufficient | DNS and cache-invalidation complexity |
| Docker | Deployment target is not yet decided | One Dockerfile when needed |
| Automated tests | Judged low value for static content; see §6 | Test project and CI wiring |
| Rate limiting / CAPTCHA | Form has no backend yet | Add with the real endpoint |

---

## 8. Dependency policy

The repository currently has **zero runtime dependencies** beyond the .NET
framework itself. That is a feature, not an accident: it removes supply-chain
risk, version drift, licence review and upgrade work.

Before adding a NuGet or npm package, check whether it is needed:

1. **Does the framework already do it?** ASP.NET Core and Blazor cover routing,
   configuration, validation, DI, logging and static assets.
2. **Can it be written in a reasonable amount of code?** The icon set is a
   `switch`; the animations are one file of CSS; the accordion is a state field.
   All were written rather than installed.
3. **Is it build-time only?** `pptxgenjs` is acceptable precisely because it never
   reaches production.
4. **What is the maintenance cost?** Every package needs updating, reviewing and
   tracking for advisories.
5. **What is the licence?** Confirm it is compatible before adding it.

If a package is genuinely warranted, add it to
`Polypus.Web/Polypus.Web.csproj`, record it in the table in §1, and explain the
reasoning in this file.

---

## 9. Requirements summary

| To… | You need |
|-----|----------|
| Build and run | .NET 10 SDK |
| Edit the design | A text editor — CSS needs no compiler |
| Edit content | A text editor — content is C# in `Models/` and `Services/` |
| Regenerate the architecture deck | Node.js 18+ (optional; the `.pptx` is committed) — see `tools/deck/README.md` |
| Deploy | Any host running .NET 10, with WebSocket support |

---

*Polypus — intelligent document processing and controlled SAP automation, owned
by Axonite.*
