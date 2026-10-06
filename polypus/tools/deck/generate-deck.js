/* ============================================================================
 * generate-deck.js
 * ----------------------------------------------------------------------------
 * Generates docs/Polypus-Architecture.pptx - the architecture deck for the
 * Polypus website.
 *
 * This is a BUILD-TIME tool. It is not part of Polypus.Web, nothing in the
 * application references pptxgenjs, and it is never deployed. Run it only when
 * the deck needs to be regenerated:
 *
 *     cd tools/deck
 *     npm install
 *     node generate-deck.js                      # writes ..\..\docs\Polypus-Architecture.pptx
 *     node check-layout.js ; node check-overflow.js   # verify the result
 *
 * The palette and type choices below deliberately mirror the tokens in
 * Polypus.Web/wwwroot/app.css so the deck matches the site it describes.
 * ============================================================================ */

const path = require('path');
const PptxGenJS = require('pptxgenjs');

const pptx = new PptxGenJS();
pptx.layout = 'LAYOUT_16x9'; // 10 x 5.625 inches
pptx.author = 'Axonite';
pptx.company = 'Axonite';
pptx.title = 'Polypus website - architecture';

// ---------------------------------------------------------------------------
// Design tokens, mirroring wwwroot/app.css :root
// ---------------------------------------------------------------------------
const C = {
    paper: 'FAF9F7',
    white: 'FFFFFF',
    ink: '12151C',
    ink2: '3B4250',
    muted: '5B6472',
    accent: '0F766E',
    accentBright: '14B8A6',
    accentSoft: 'E7F3F1',
    line: 'E4E1DB',
    dark: '0B1220',
    dark2: '16202E',
    gold: 'B4894A',
    coral: 'C2593F'
};

const F = {
    serif: 'Georgia',
    sans: 'Segoe UI',
    mono: 'Consolas'
};

const W = 10.0;
const H = 5.625;
const M = 0.62; // left/right margin
const CW = W - M * 2; // content width

// ---------------------------------------------------------------------------
// Small helpers
// ---------------------------------------------------------------------------

/** Adds the standard slide footer: product name on the left, page number right. */
function footer(slide, page) {
    slide.addShape(pptx.ShapeType.rect, {
        x: M, y: H - 0.52, w: CW, h: 0.012, fill: { color: C.line }
    });
    slide.addText('Polypus  |  Architecture of the marketing website  |  owned by Axonite', {
        x: M, y: H - 0.46, w: CW * 0.8, h: 0.3,
        fontFace: F.sans, fontSize: 8, color: C.muted, valign: 'middle'
    });
    slide.addText(String(page), {
        x: W - M - 0.6, y: H - 0.46, w: 0.6, h: 0.3,
        fontFace: F.mono, fontSize: 8, color: C.muted, align: 'right', valign: 'middle'
    });
}

/** Adds a content slide header: accent rule, eyebrow, title, optional lead. */
function header(slide, eyebrow, title, lead) {
    slide.addShape(pptx.ShapeType.rect, {
        x: M, y: 0.42, w: 0.46, h: 0.055, fill: { color: C.accent }
    });
    slide.addText(eyebrow.toUpperCase(), {
        x: M, y: 0.6, w: CW, h: 0.22,
        fontFace: F.sans, fontSize: 9, bold: true, color: C.accent, charSpacing: 1.4
    });
    slide.addText(title, {
        x: M, y: 0.86, w: CW, h: 0.46,
        fontFace: F.serif, fontSize: 24, bold: false, color: C.ink, valign: 'middle'
    });
    if (lead) {
        slide.addText(lead, {
            x: M, y: 1.36, w: CW, h: 0.34,
            fontFace: F.sans, fontSize: 10.5, color: C.ink2, valign: 'top'
        });
    }
}

/** A blank paper-coloured slide with the footer applied. */
function paperSlide(page) {
    const s = pptx.addSlide();
    s.background = { color: C.paper };
    footer(s, page);
    return s;
}

/** Bulleted body text, one bullet item per array entry. */
function bullets(slide, items, opts) {
    slide.addText(
        items.map((t) => ({ text: t, options: { bullet: { characterCode: '25AA' }, breakLine: true } })),
        Object.assign({
            fontFace: F.sans, fontSize: 11, color: C.ink2, lineSpacingMultiple: 1.22
        }, opts)
    );
}

// ===========================================================================
// Slide 1 - title
// ===========================================================================
{
    const s = pptx.addSlide();
    s.background = { color: C.dark };

    // Decorative teal block, echoing the site's accent.
    s.addShape(pptx.ShapeType.rect, {
        x: 0, y: 0, w: 0.14, h: H, fill: { color: C.accent }
    });

    s.addText('ARCHITECTURE', {
        x: 1.0, y: 1.05, w: 8, h: 0.3,
        fontFace: F.sans, fontSize: 11, bold: true, color: C.accentBright, charSpacing: 2.4
    });

    s.addText('Polypus', {
        x: 1.0, y: 1.4, w: 8, h: 1.0,
        fontFace: F.serif, fontSize: 54, color: C.white, valign: 'middle'
    });

    s.addText('Intelligent document processing and controlled SAP automation', {
        x: 1.0, y: 2.42, w: 8.2, h: 0.42,
        fontFace: F.sans, fontSize: 15, color: C.accentBright
    });

    s.addText('How the marketing website is built, how a request is served, and how a plan becomes an enquiry.', {
        x: 1.0, y: 2.92, w: 7.6, h: 0.6,
        fontFace: F.sans, fontSize: 11.5, color: 'AEB6C2', lineSpacingMultiple: 1.2
    });

    s.addShape(pptx.ShapeType.rect, {
        x: 1.0, y: 3.7, w: 3.4, h: 0.012, fill: { color: '2C3846' }
    });

    s.addText([
        { text: '.NET 10', options: { bold: true, color: C.white } },
        { text: '   +   ', options: { color: '5A6572' } },
        { text: 'Blazor Web App', options: { bold: true, color: C.white } },
        { text: '   +   ', options: { color: '5A6572' } },
        { text: 'C#', options: { bold: true, color: C.white } },
        { text: '   +   ', options: { color: '5A6572' } },
        { text: 'hand-written CSS', options: { bold: true, color: C.white } }
    ], {
        x: 1.0, y: 3.9, w: 8, h: 0.32,
        fontFace: F.sans, fontSize: 11.5, valign: 'middle'
    });

    s.addText('Zero NuGet packages  ·  Zero runtime npm packages  ·  Zero third-party requests', {
        x: 1.0, y: 4.32, w: 8, h: 0.3,
        fontFace: F.sans, fontSize: 10, color: '8A93A1'
    });

    s.addText('Axonite', {
        x: 1.0, y: 4.85, w: 4, h: 0.3,
        fontFace: F.sans, fontSize: 9, color: '6C7684'
    });
}

// ===========================================================================
// Slide 2 - what the site is
// ===========================================================================
{
    const s = paperSlide(2);
    header(s, 'The brief', 'One product, one page, one clear action',
        'A single marketing website for Polypus - no database, no authentication, no CMS.');

    const cols = [
        {
            t: 'What it is',
            b: [
                'Public marketing site for one product',
                'Static content, served as HTML',
                'One interactive conversion path',
                'Every word lives in version control'
            ]
        },
        {
            t: 'What it is not',
            b: [
                'Not a customer portal or app',
                'No database, no user accounts',
                'No CMS, no admin screens',
                'No third-party runtime requests'
            ]
        },
        {
            t: 'The one job',
            b: [
                'Explain Polypus in one screen',
                'Show features, plans and proof',
                'Name the company behind it',
                'Turn a plan click into an enquiry'
            ]
        }
    ];

    cols.forEach((c, i) => {
        const x = M + i * (CW / 3);
        const w = CW / 3 - 0.18;
        s.addShape(pptx.ShapeType.roundRect, {
            x, y: 1.85, w, h: 2.92, fill: { color: C.white },
            line: { color: C.line, width: 1 }, rectRadius: 0.05
        });
        s.addShape(pptx.ShapeType.rect, {
            x: x + 0.26, y: 2.12, w: 0.3, h: 0.045, fill: { color: C.accent }
        });
        s.addText(c.t, {
            x: x + 0.26, y: 2.24, w: w - 0.5, h: 0.3,
            fontFace: F.serif, fontSize: 13.5, color: C.ink
        });
        bullets(s, c.b, { x: x + 0.26, y: 2.66, w: w - 0.5, h: 1.9, fontSize: 9.5 });
    });
}

// ===========================================================================
// Slide 3 - requirements to implementation
// ===========================================================================
{
    const s = paperSlide(3);
    header(s, 'Coverage', 'Every requirement, and where it lives',
        'Nothing in the brief was left implied - each line maps to a named file.');

    const rows = [
        [
            { text: 'Requirement', options: { bold: true } },
            { text: 'Implementation', options: { bold: true } },
            { text: 'File', options: { bold: true } }
        ],
        ['Home page with product info', 'Hero, metrics, document strip', 'Pages/Home.razor'],
        ['Features section', 'Six highlights from the catalog', 'Services/FeatureCatalog.cs'],
        ['Basic plan and others', 'Four plans, monthly / annual toggle', 'Services/PlanCatalog.cs'],
        ['Company behind the product', 'Axonite story, facts, three offices', 'Models/CompanyProfile.cs'],
        ['4-5 testimonials', 'One featured card plus four compact', 'Services/TestimonialCatalog.cs'],
        ['Header logo and nav', 'Mark plus Product dropdown', 'Layout/Header.razor'],
        ['Footer: help, privacy, terms', 'Four columns from one catalog', 'Services/NavigationCatalog.cs'],
        ['Plan click opens contact', 'Plan preselected via URL query', 'Shared/PlanCard.razor']
    ];

    s.addTable(rows, {
        x: M, y: 1.85, w: CW, colW: [3.1, 3.6, 2.06],
        fontFace: F.sans, fontSize: 9.5, color: C.ink2,
        border: { type: 'solid', color: C.line, pt: 1 },
        align: 'left', valign: 'middle', rowH: 0.335,
        fill: { color: C.white },
        autoPage: false
    });

    // Highlight the row that carries the key requirement (header is row 0,
    // so "Basic plan and others" sits at index 3).
    const hlY = 1.85 + 0.335 * 3;
    s.addShape(pptx.ShapeType.rect, {
        x: M, y: hlY, w: CW, h: 0.335,
        fill: { color: C.accentSoft }, line: { color: C.line, width: 1 }
    });
    s.addText('Basic plan and others', {
        x: M + 0.08, y: hlY, w: 3.0, h: 0.335,
        fontFace: F.sans, fontSize: 9.5, bold: true, color: C.ink, valign: 'middle'
    });
    s.addText('Four plans, monthly / annual toggle', {
        x: M + 3.18, y: hlY, w: 3.5, h: 0.335,
        fontFace: F.sans, fontSize: 9.5, color: C.ink2, valign: 'middle'
    });
    s.addText('Services/PlanCatalog.cs', {
        x: M + 6.78, y: hlY, w: 2.0, h: 0.335,
        fontFace: F.mono, fontSize: 8.5, color: C.accent, valign: 'middle'
    });
}

// ===========================================================================
// Slide 4 - tech stack
// ===========================================================================
{
    const s = paperSlide(4);
    header(s, 'Technology', 'A deliberately small stack',
        'Five real dependencies. Everything else is the framework, or written by hand.');

    const cards = [
        { k: '.NET 10', v: 'Runtime and web host', d: 'ASP.NET Core, routing, DI, config, antiforgery' },
        { k: 'Blazor Web App', v: 'UI framework', d: 'Interactive Server on 4 pages, static elsewhere' },
        { k: 'C# 14', v: 'Language', d: 'Records, required members, nullable reference types' },
        { k: 'Hand-written CSS', v: 'Design system', d: '53 tokens, 2 files, no framework' },
        { k: 'Inline SVG', v: 'Icons and logo', d: '34 icons, one component, no icon package' },
        { k: '~6 KB JavaScript', v: 'Two enhancements', d: 'Sticky header, opt-in scroll reveal' }
    ];

    cards.forEach((c, i) => {
        const col = i % 3;
        const row = Math.floor(i / 3);
        const x = M + col * (CW / 3);
        const y = 1.9 + row * 1.42;
        const w = CW / 3 - 0.18;

        s.addShape(pptx.ShapeType.roundRect, {
            x, y, w, h: 1.24, fill: { color: C.white },
            line: { color: C.line, width: 1 }, rectRadius: 0.05
        });
        s.addShape(pptx.ShapeType.rect, {
            x, y, w: 0.055, h: 1.24, fill: { color: C.accent }
        });
        s.addText(c.k, {
            x: x + 0.24, y: y + 0.14, w: w - 0.4, h: 0.28,
            fontFace: F.sans, fontSize: 12.5, bold: true, color: C.ink
        });
        s.addText(c.v, {
            x: x + 0.24, y: y + 0.44, w: w - 0.4, h: 0.22,
            fontFace: F.sans, fontSize: 9, color: C.accent
        });
        s.addText(c.d, {
            x: x + 0.24, y: y + 0.68, w: w - 0.42, h: 0.48,
            fontFace: F.sans, fontSize: 8.5, color: C.muted, lineSpacingMultiple: 1.1
        });
    });

    s.addText('Not used, on purpose:  Bootstrap / Tailwind  ·  jQuery  ·  icon fonts  ·  web fonts  ·  CSS preprocessor  ·  JS bundler  ·  SPA framework  ·  CMS  ·  database  ·  CDN', {
        x: M, y: 4.78, w: CW, h: 0.32,
        fontFace: F.sans, fontSize: 8.5, color: C.muted, italic: true
    });
}

// ===========================================================================
// Slide 5 - architecture layers
// ===========================================================================
{
    const s = paperSlide(5);
    header(s, 'Architecture', 'One-way dependency between four layers',
        'Content and rules sit at the bottom; pages render at the top. A page never holds business data.');

    const bands = [
        {
            n: '1',
            t: 'Components / Pages',
            d: 'Pages/Home.razor  ·  Pages/Contact.razor  ·  Pages/Plans.razor',
            r: 'Routes and composition',
            c: C.accent
        },
        {
            n: '2',
            t: 'Components / Shared + Layout',
            d: 'PlanCard  ·  AppIcon  ·  FaqList  ·  Header  ·  Footer',
            r: 'Reusable presentation',
            c: C.accentBright
        },
        {
            n: '3',
            t: 'Models + Services',
            d: 'PlanCatalog  ·  FeatureCatalog  ·  NavigationCatalog  ·  CompanyProfile',
            r: 'All content and rules',
            c: C.gold
        },
        {
            n: '4',
            t: 'wwwroot - CSS + JS',
            d: 'app.css (design system)  ·  home.css (sections)  ·  js/site.js',
            r: 'All visual design',
            c: C.coral
        }
    ];

    const bx = M + 0.62;
    const bw = CW - 0.62;

    bands.forEach((b, i) => {
        const y = 1.92 + i * 0.72;
        s.addShape(pptx.ShapeType.roundRect, {
            x: bx, y, w: bw, h: 0.62, fill: { color: C.white },
            line: { color: C.line, width: 1 }, rectRadius: 0.04
        });
        s.addShape(pptx.ShapeType.rect, {
            x: bx, y, w: 0.06, h: 0.62, fill: { color: b.c }
        });
        s.addText(b.t, {
            x: bx + 0.22, y: y + 0.07, w: 3.1, h: 0.26,
            fontFace: F.sans, fontSize: 11, bold: true, color: C.ink
        });
        s.addText(b.d, {
            x: bx + 0.22, y: y + 0.32, w: 5.5, h: 0.24,
            fontFace: F.mono, fontSize: 7.4, color: C.muted
        });
        s.addText(b.r, {
            x: bx + bw - 2.1, y, w: 1.98, h: 0.62,
            fontFace: F.sans, fontSize: 8.5, color: b.c, align: 'right', valign: 'middle'
        });
    });

    // Dependency direction marker on the left.
    s.addText('render  \u2191', {
        x: M - 0.04, y: 2.0, w: 0.62, h: 0.3,
        fontFace: F.sans, fontSize: 8, bold: true, color: C.muted, align: 'center'
    });
    s.addShape(pptx.ShapeType.line, {
        x: M + 0.3, y: 2.1, w: 0, h: 2.5,
        line: { color: C.muted, width: 1, dashType: 'dash' }
    });
    s.addText('depend  \u2193', {
        x: M - 0.04, y: 4.35, w: 0.62, h: 0.3,
        fontFace: F.sans, fontSize: 8, bold: true, color: C.muted, align: 'center'
    });

    s.addText('Rule of thumb:  changing words or numbers means editing a Models or Services file, never a .razor file.', {
        x: M, y: 4.86, w: CW, h: 0.3,
        fontFace: F.sans, fontSize: 9, bold: true, color: C.ink
    });
}

// ===========================================================================
// Slide 6 - request lifecycle and render modes
// ===========================================================================
{
    const s = paperSlide(6);
    header(s, 'Runtime', 'Two render modes, chosen per page',
        'Static server rendering is the default. Interactivity is opt-in, page by page.');

    // Left: the two modes
    s.addShape(pptx.ShapeType.roundRect, {
        x: M, y: 1.85, w: CW / 2 - 0.14, h: 2.6, fill: { color: C.white },
        line: { color: C.line, width: 1 }, rectRadius: 0.05
    });
    s.addText('Static server rendering', {
        x: M + 0.22, y: 2.0, w: 4, h: 0.3,
        fontFace: F.serif, fontSize: 13, color: C.ink
    });
    s.addText('The default', {
        x: M + 0.22, y: 2.3, w: 4, h: 0.22,
        fontFace: F.sans, fontSize: 8.5, bold: true, color: C.accent
    });
    bullets(s, [
        'Finished HTML, no WebSocket',
        'Works with JavaScript disabled',
        'Faster first paint, cacheable',
        '13 of 17 routes'
    ], { x: M + 0.22, y: 2.58, w: 4.1, h: 1.7, fontSize: 10 });

    // Right: the interactive mode
    s.addShape(pptx.ShapeType.roundRect, {
        x: M + CW / 2 + 0.14, y: 1.85, w: CW / 2 - 0.14, h: 2.6, fill: { color: C.white },
        line: { color: C.accent, width: 1.4 }, rectRadius: 0.05
    });
    s.addText('Interactive Server', {
        x: M + CW / 2 + 0.36, y: 2.0, w: 4, h: 0.3,
        fontFace: F.serif, fontSize: 13, color: C.ink
    });
    s.addText('@rendermode InteractiveServer', {
        x: M + CW / 2 + 0.36, y: 2.3, w: 4.3, h: 0.22,
        fontFace: F.mono, fontSize: 7.6, bold: true, color: C.accent
    });
    bullets(s, [
        'Live WebSocket circuit',
        'State held on the server',
        'Only 4 pages plus the header',
        'Price toggle, accordion, search, form'
    ], { x: M + CW / 2 + 0.36, y: 2.58, w: 4.1, h: 1.7, fontSize: 10 });

    // Request path strip
    const steps = ['Browser request', 'ASP.NET Core routing', 'Razor component', 'HTML response', 'Circuit (if interactive)'];
    const sw = (CW - 0.4 * 4) / 5;
    steps.forEach((t, i) => {
        const x = M + i * (sw + 0.4);
        s.addShape(pptx.ShapeType.roundRect, {
            x, y: 4.52, w: sw, h: 0.46, fill: i === 4 ? { color: C.accentSoft } : { color: C.white },
            line: { color: i === 4 ? C.accent : C.line, width: 1 }, rectRadius: 0.04
        });
        s.addText(t, {
            x: x + 0.05, y: 4.52, w: sw - 0.1, h: 0.46,
            fontFace: F.sans, fontSize: 7.6, color: C.ink2, align: 'center', valign: 'middle'
        });
        if (i < 4) {
            s.addText('\u203A', {
                x: x + sw, y: 4.52, w: 0.4, h: 0.46,
                fontFace: F.sans, fontSize: 14, color: C.muted, align: 'center', valign: 'middle'
            });
        }
    });
}

// ===========================================================================
// Slide 7 - the plan to contact flow
// ===========================================================================
{
    const s = paperSlide(7);
    header(s, 'Key requirement', 'A plan click becomes a pre-filled enquiry',
        'The selected plan travels in the URL, is validated on arrival, and lands in the form - and nowhere else.');

    const boxes = [
        { t: 'PlanCard.razor', d: 'The CTA anchor', n: 'href="/contact?plan=growth"' },
        { t: 'Contact.razor', d: 'Reads the query string', n: '[SupplyParameterFromQuery(Name = "plan")]' },
        { t: 'PlanCatalog.Find()', d: 'Resolves it safely', n: 'returns Plan?  -  null when unknown' },
        { t: 'The form', d: 'Preselected and summarised', n: '<select#plan> + .plan-summary panel' }
    ];

    const bw = 2.02;
    const gap = 0.42;
    boxes.forEach((b, i) => {
        const x = M + i * (bw + gap);
        s.addShape(pptx.ShapeType.roundRect, {
            x, y: 2.0, w: bw, h: 1.5, fill: { color: C.white },
            line: { color: C.accent, width: 1.2 }, rectRadius: 0.05
        });
        s.addText(b.t, {
            x: x + 0.12, y: 2.12, w: bw - 0.24, h: 0.46,
            fontFace: F.sans, fontSize: 10, bold: true, color: C.ink, valign: 'top'
        });
        s.addText(b.d, {
            x: x + 0.12, y: 2.58, w: bw - 0.24, h: 0.24,
            fontFace: F.sans, fontSize: 8.2, color: C.muted
        });
        s.addText(b.n, {
            x: x + 0.12, y: 2.84, w: bw - 0.24, h: 0.56,
            fontFace: F.mono, fontSize: 6.8, color: C.accent, lineSpacingMultiple: 1.1
        });
        if (i < 3) {
            s.addText('\u2192', {
                x: x + bw, y: 2.0, w: gap, h: 1.5,
                fontFace: F.sans, fontSize: 15, color: C.accent, align: 'center', valign: 'middle'
            });
        }
    });

    // Alias note
    s.addShape(pptx.ShapeType.roundRect, {
        x: M, y: 3.72, w: CW, h: 0.66, fill: { color: C.accentSoft },
        line: { color: C.accent, width: 0.8 }, rectRadius: 0.04
    });
    s.addText([
        { text: 'Alias tolerance:  ', options: { bold: true, color: C.ink } },
        { text: 'starter \u2192 basic     pro \u2192 growth     scale \u2192 business     custom \u2192 enterprise.     ', options: { color: C.ink2 } },
        { text: 'An unrecognised value such as ?plan=nonsense is harmless: Find() returns null and the form simply loads with no plan selected.', options: { color: C.muted } }
    ], {
        x: M + 0.22, y: 3.72, w: CW - 0.44, h: 0.66,
        fontFace: F.sans, fontSize: 8.8, valign: 'middle', lineSpacingMultiple: 1.15
    });

    s.addText('Verified by clicking each plan on every page:  /contact?plan=basic, growth, business, enterprise  -  all resolve with the plan selected.', {
        x: M, y: 4.56, w: CW, h: 0.3,
        fontFace: F.sans, fontSize: 8.5, italic: true, color: C.muted
    });
}

// ===========================================================================
// Slide 8 - content layer
// ===========================================================================
{
    const s = paperSlide(8);
    header(s, 'Content', 'The site\u2019s words live in code, not markup',
        'Five catalogs hold every price, feature and link. Change one value and it updates everywhere it appears.');

    const rows = [
        [
            { text: 'Catalog', options: { bold: true } },
            { text: 'Owns', options: { bold: true } },
            { text: 'Drives', options: { bold: true } }
        ],
        ['PlanCatalog.cs', 'Four plans, prices, billing cycles, aliases', 'Home, /plans, contact summary'],
        ['FeatureCatalog.cs', 'Eight capabilities with detail bullets', 'Home grid, /features, /product'],
        ['TestimonialCatalog.cs', 'Five quotes, one flagged as featured', 'Home testimonial section'],
        ['FaqCatalog.cs', 'Twelve FAQs with categories and search', 'Home, /plans, /help, /integrations'],
        ['NavigationCatalog.cs', 'Header dropdown and four footer columns', 'Every page\u2019s header and footer']
    ];

    s.addTable(rows, {
        x: M, y: 1.9, w: CW, colW: [2.35, 4.05, 2.36],
        fontFace: F.sans, fontSize: 9.5, color: C.ink2,
        border: { type: 'solid', color: C.line, pt: 1 },
        align: 'left', valign: 'middle', rowH: 0.335,
        fill: { color: C.white }, autoPage: false
    });

    // Worked example
    s.addShape(pptx.ShapeType.roundRect, {
        x: M, y: 4.0, w: CW, h: 0.94, fill: { color: C.dark },
        line: { color: C.dark, width: 1 }, rectRadius: 0.05
    });
    s.addText('CHANGING THE GROWTH PLAN PRICE', {
        x: M + 0.26, y: 4.09, w: 8, h: 0.22,
        fontFace: F.sans, fontSize: 7.6, bold: true, color: C.accentBright, charSpacing: 1.4
    });
    s.addText([
        { text: 'MonthlyPrice = 1_450m', options: { color: 'E6E9EE' } },
        { text: '   \u2192   ', options: { color: C.accentBright } },
        { text: 'edited once in Services/PlanCatalog.cs', options: { color: C.accentBright, bold: true } },
        { text: '   \u2192   ', options: { color: C.accentBright } },
        { text: 'updates the home page card, the /plans table, and the contact page summary panel', options: { color: 'E6E9EE' } }
    ], {
        x: M + 0.26, y: 4.32, w: CW - 0.52, h: 0.5,
        fontFace: F.mono, fontSize: 8.4, valign: 'middle', lineSpacingMultiple: 1.2
    });
}

// ===========================================================================
// Slide 9 - design system
// ===========================================================================
{
    const s = paperSlide(9);
    header(s, 'Design', 'A hand-built system, not a template',
        'The brief asked for a site that looks considered rather than generated.');

    // Swatches
    const swatches = [
        { n: '--paper', v: '#FAF9F7', c: 'FAF9F7', b: true },
        { n: '--ink', v: '#12151C', c: '12151C' },
        { n: '--accent', v: '#0F766E', c: '0F766E' },
        { n: '--accent-bright', v: '#14B8A6', c: '14B8A6' },
        { n: '--gold', v: '#B4894A', c: 'B4894A' },
        { n: '--coral', v: '#C2593F', c: 'C2593F' }
    ];
    swatches.forEach((sw, i) => {
        const x = M + i * 0.9;
        s.addShape(pptx.ShapeType.roundRect, {
            x, y: 1.9, w: 0.78, h: 0.62, fill: { color: sw.c },
            line: { color: C.line, width: sw.b ? 1 : 0 }, rectRadius: 0.05
        });
        s.addText(sw.v, {
            x: x - 0.06, y: 2.56, w: 0.9, h: 0.2,
            fontFace: F.mono, fontSize: 6.6, color: C.muted, align: 'center'
        });
    });

    // Type pairing
    s.addShape(pptx.ShapeType.roundRect, {
        x: M + 5.6, y: 1.9, w: CW - 5.6, h: 1.0, fill: { color: C.white },
        line: { color: C.line, width: 1 }, rectRadius: 0.05
    });
    s.addText('Documents in. SAP postings out.', {
        x: M + 5.78, y: 1.98, w: CW - 5.98, h: 0.4,
        fontFace: F.serif, fontSize: 11, color: C.ink, valign: 'middle'
    });
    s.addText('Serif headings  ·  sans body  ·  mono for numbers', {
        x: M + 5.78, y: 2.4, w: CW - 5.98, h: 0.2,
        fontFace: F.sans, fontSize: 7.4, color: C.muted
    });
    s.addText('System stacks - no web font, no third-party request', {
        x: M + 5.78, y: 2.6, w: CW - 5.98, h: 0.2,
        fontFace: F.sans, fontSize: 7.4, color: C.accent
    });

    // Principles
    const pr = [
        { t: '53 design tokens', d: 'Colour, type, spacing and radii all named once in app.css :root. Change a token, update every use.' },
        { t: 'Two stylesheets', d: 'app.css holds the system; home.css adds the marketing sections and loads second so it can override.' },
        { t: '~34 inline SVG icons', d: 'One component, one switch. They inherit currentColor and carry aria-hidden.' },
        { t: 'Responsive and accessible', d: 'No horizontal overflow at 390 px. Landmarks, skip link, focus rings, reduced-motion support.' }
    ];
    pr.forEach((p, i) => {
        const col = i % 2;
        const row = Math.floor(i / 2);
        const x = M + col * (CW / 2);
        const y = 3.02 + row * 0.86;
        const w = CW / 2 - 0.18;
        s.addShape(pptx.ShapeType.roundRect, {
            x, y, w, h: 0.74, fill: { color: C.white },
            line: { color: C.line, width: 1 }, rectRadius: 0.04
        });
        s.addText(p.t, {
            x: x + 0.2, y: y + 0.08, w: w - 0.36, h: 0.24,
            fontFace: F.sans, fontSize: 10, bold: true, color: C.ink
        });
        s.addText(p.d, {
            x: x + 0.2, y: y + 0.31, w: w - 0.36, h: 0.38,
            fontFace: F.sans, fontSize: 7.8, color: C.muted, lineSpacingMultiple: 1.1
        });
    });

    s.addText('Verified: all 226 CSS classes used in Razor resolve, and all 46 var(--token) references are defined.', {
        x: M, y: 4.82, w: CW, h: 0.3,
        fontFace: F.sans, fontSize: 8.2, italic: true, color: C.muted
    });
}

// ===========================================================================
// Slide 10 - JavaScript and robustness
// ===========================================================================
{
    const s = paperSlide(10);
    header(s, 'Robustness', 'JavaScript is optional, by design',
        'One 6 KB file with two cosmetic jobs. If it never runs, the site still works completely.');

    // Left: the two jobs
    s.addShape(pptx.ShapeType.roundRect, {
        x: M, y: 1.88, w: CW / 2 - 0.14, h: 1.42, fill: { color: C.white },
        line: { color: C.line, width: 1 }, rectRadius: 0.05
    });
    s.addText('What site.js does', {
        x: M + 0.22, y: 1.98, w: 4, h: 0.26,
        fontFace: F.serif, fontSize: 12, color: C.ink
    });
    bullets(s, [
        'Adds .is-stuck to the header when scrolled',
        'Plays a reveal animation for [data-reveal] sections'
    ], { x: M + 0.22, y: 2.26, w: 4.1, h: 0.9, fontSize: 9.5 });

    // Right: the failure story
    s.addShape(pptx.ShapeType.roundRect, {
        x: M + CW / 2 + 0.14, y: 1.88, w: CW / 2 - 0.14, h: 1.42, fill: { color: C.dark },
        line: { color: C.dark, width: 1 }, rectRadius: 0.05
    });
    s.addText('The bug this design prevents', {
        x: M + CW / 2 + 0.36, y: 1.98, w: 4, h: 0.26,
        fontFace: F.serif, fontSize: 12, color: C.white
    });
    s.addText([
        { text: 'Hiding sections in CSS and revealing them with JavaScript turns any script failure into blank sections. During development the observer was watching DOM nodes Blazor had already replaced, so six sections stayed permanently invisible - the animation looked fine while content was missing.', options: { color: 'B9C1CC' } }
    ], {
        x: M + CW / 2 + 0.36, y: 2.26, w: 4.35, h: 0.96,
        fontFace: F.sans, fontSize: 8.2, lineSpacingMultiple: 1.18
    });

    // Failure matrix
    const rows = [
        [
            { text: 'Situation', options: { bold: true, color: C.white } },
            { text: 'Result', options: { bold: true, color: C.white } }
        ],
        ['JavaScript disabled or blocked', 'Sections visible, no animation'],
        ['prefers-reduced-motion: reduce', 'Sections visible, no animation'],
        ['site.js throws an error', 'Sections visible, no animation'],
        ['Normal', 'Sections animate in on scroll']
    ];
    s.addTable(rows, {
        x: M, y: 3.4, w: CW, colW: [3.6, 5.16],
        fontFace: F.sans, fontSize: 9, color: C.ink2,
        border: { type: 'solid', color: C.line, pt: 1 },
        align: 'left', valign: 'middle', rowH: 0.255,
        fill: { color: C.white }, autoPage: false
    });

    s.addText('In every failure mode the content is still there. A broken animation must never cost a visitor a section.', {
        x: M, y: 4.72, w: CW, h: 0.3,
        fontFace: F.sans, fontSize: 8.6, bold: true, color: C.ink
    });
}

// ===========================================================================
// Slide 11 - verification
// ===========================================================================
{
    const s = paperSlide(11);
    header(s, 'Quality', 'What was tested, and what it found',
        'Two real defects were found by testing rather than by reading the code.');

    const rows = [
        [
            { text: 'Check', options: { bold: true } },
            { text: 'Method', options: { bold: true } },
            { text: 'Result', options: { bold: true } }
        ],
        ['Compilation', 'dotnet build -c Release', '0 warnings, 0 errors'],
        ['Every route', 'HTTP request to 19 routes', 'All 200; unknown URL returns 404'],
        ['Every link', 'All hrefs extracted from every page', '0 broken links'],
        ['CSS classes', '226 classes in Razor vs stylesheets', 'All resolve'],
        ['CSS tokens', '46 var(--x) uses vs 53 definitions', '0 undefined'],
        ['Plan to contact', 'Clicked every plan CTA', 'Plan preselected on arrival'],
        ['Form behaviour', 'Empty submit, then valid submit', 'Errors shown; reference issued'],
        ['Widgets', 'Price toggle, accordion, search, nav', 'All respond'],
        ['Responsive', '1440 px and 390 px viewports', 'No horizontal overflow']
    ];

    s.addTable(rows, {
        x: M, y: 1.88, w: CW, colW: [2.4, 4.2, 2.16],
        fontFace: F.sans, fontSize: 9, color: C.ink2,
        border: { type: 'solid', color: C.line, pt: 1 },
        align: 'left', valign: 'middle', rowH: 0.238,
        fill: { color: C.white }, autoPage: false
    });

    s.addText('Defects found and fixed', {
        x: M, y: 4.38, w: 4, h: 0.24,
        fontFace: F.serif, fontSize: 11, color: C.ink
    });
    s.addText([
        { text: '1.  NavigationCatalog passed Href where Label was expected. Both are strings, so it compiled - but every header dropdown and footer link was broken. Fixed with named arguments.   ', options: { color: C.coral } },
        { text: '2.  The scroll-reveal observer watched nodes that Blazor subsequently replaced, leaving six home-page sections invisible. Fixed by making the animation fail-safe.', options: { color: C.coral } }
    ], {
        x: M, y: 4.63, w: CW, h: 0.44,
        fontFace: F.sans, fontSize: 7.4, lineSpacingMultiple: 1.14
    });
}

// ===========================================================================
// Slide 12 - going live
// ===========================================================================
{
    const s = paperSlide(12);
    header(s, 'Next steps', 'What to change before this goes public',
        'The site is complete and running. These are the deliberate placeholders.');

    const items = [
        { n: '01', t: 'Wire up the contact form', d: 'It validates and confirms but sends nothing. A visitor\u2019s enquiry is currently discarded.', c: C.coral },
        { n: '02', t: 'Replace sample content', d: 'Testimonials, customer names, vacancies, releases and the status page are all invented.', c: C.gold },
        { n: '03', t: 'Swap in the real brand mark', d: 'The logo, favicon and glyph are hand-drawn placeholders.', c: C.gold },
        { n: '04', t: 'Have the legal pages reviewed', d: 'Privacy, Terms, Cookie Policy and the DPA are realistic drafts, not legal advice.', c: C.gold },
        { n: '05', t: 'Set the real domain and details', d: 'axonite.io, the phone number and support hours are placeholders.', c: C.accentBright },
        { n: '06', t: 'Add robots.txt and social tags', d: 'No sitemap and no og: preview tags yet. Analytics is optional - there is no tracking today.', c: C.accentBright }
    ];

    items.forEach((it, i) => {
        const col = i % 2;
        const row = Math.floor(i / 2);
        const x = M + col * (CW / 2);
        const y = 1.88 + row * 0.93;
        const w = CW / 2 - 0.18;

        s.addShape(pptx.ShapeType.roundRect, {
            x, y, w, h: 0.84, fill: { color: C.white },
            line: { color: C.line, width: 1 }, rectRadius: 0.04
        });
        s.addShape(pptx.ShapeType.rect, { x, y, w: 0.055, h: 0.84, fill: { color: it.c } });
        s.addText(it.n, {
            x: x + 0.2, y: y + 0.12, w: 0.42, h: 0.28,
            fontFace: F.mono, fontSize: 10, bold: true, color: it.c
        });
        s.addText(it.t, {
            x: x + 0.62, y: y + 0.11, w: w - 0.8, h: 0.26,
            fontFace: F.sans, fontSize: 10.5, bold: true, color: C.ink
        });
        s.addText(it.d, {
            x: x + 0.62, y: y + 0.37, w: w - 0.8, h: 0.42,
            fontFace: F.sans, fontSize: 8, color: C.muted, lineSpacingMultiple: 1.1
        });
    });

    s.addShape(pptx.ShapeType.roundRect, {
        x: M, y: 4.66, w: CW, h: 0.38, fill: { color: C.accentSoft },
        line: { color: C.accent, width: 0.8 }, rectRadius: 0.04
    });
    s.addText([
        { text: 'Deployment:  ', options: { bold: true, color: C.ink } },
        { text: 'dotnet publish -c Release, then host the output anywhere running .NET 10. Behind a load balancer, enable sticky sessions - interactive pages hold a WebSocket.', options: { color: C.ink2 } }
    ], {
        x: M + 0.22, y: 4.66, w: CW - 0.44, h: 0.38,
        fontFace: F.sans, fontSize: 8.4, valign: 'middle'
    });
}

// ---------------------------------------------------------------------------
const out = path.join(__dirname, '..', '..', 'docs', 'Polypus-Architecture.pptx');
pptx.writeFile({ fileName: out })
    .then((f) => console.log('written:', f))
    .catch((e) => { console.error('FAILED:', e.message); process.exit(1); });
