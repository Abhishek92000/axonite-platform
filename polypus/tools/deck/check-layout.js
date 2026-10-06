/* Layout checker: reads the generated PPTX, extracts every shape's declared
 * rectangle, and reports pairs that overlap. Catches the "table runs into the
 * paragraph below it" class of mistake without needing to look at images. */

const fs = require('fs');
const path = require('path');
const { execSync } = require('child_process');
const os = require('os');

const pptx = path.join(__dirname, '..', '..', 'docs', 'Polypus-Architecture.pptx');
const tmp = fs.mkdtempSync(path.join(os.tmpdir(), 'pptxchk-'));

// Extract the slide XML parts using PowerShell (no extra npm deps).
const ps = `
Add-Type -AssemblyName System.IO.Compression.FileSystem
$z=[System.IO.Compression.ZipFile]::OpenRead('${pptx.replace(/'/g, "''")}')
foreach($e in $z.Entries){
  if($e.FullName -match '^ppt/slides/slide\\d+\\.xml$'){
    $sr=New-Object System.IO.StreamReader($e.Open())
    $txt=$sr.ReadToEnd(); $sr.Close()
    $name=$e.Name
    [System.IO.File]::WriteAllText((Join-Path '${tmp.replace(/\\/g, '\\\\')}' $name), $txt)
  }
}
$z.Dispose()
`;
execSync(`powershell -NoProfile -Command "${ps.replace(/"/g, '\\"').replace(/\r?\n/g, '; ')}"`, { stdio: 'pipe' });

const EMU = 914400;
const files = fs.readdirSync(tmp)
    .filter((f) => /^slide\d+\.xml$/.test(f))
    .sort((a, b) => parseInt(a.replace(/\D/g, ''), 10) - parseInt(b.replace(/\D/g, ''), 10));

let problems = 0;

for (const file of files) {
    const xml = fs.readFileSync(path.join(tmp, file), 'utf8');
    const shapes = [];

    // Non-greedy split keeps each shape's own offsets with its own text.
    const shapeRe = /<p:(sp|graphicFrame)>([\s\S]*?)<\/p:\1>/g;
    let m;
    while ((m = shapeRe.exec(xml)) !== null) {
        const body = m[2];
        const off = body.match(/<a:off x="(-?\d+)" y="(-?\d+)"\s*\/>/);
        const ext = body.match(/<a:ext cx="(\d+)" cy="(\d+)"\s*\/>/);
        if (!off || !ext) continue;

        // Pull visible text so the report is human-readable.
        const texts = [...body.matchAll(/<a:t>([\s\S]*?)<\/a:t>/g)].map((t) => t[1]);
        const label = texts.join(' ').replace(/\s+/g, ' ').trim().slice(0, 58);

        const x = +off[1] / EMU, y = +off[2] / EMU;
        const w = +ext[1] / EMU, h = +ext[2] / EMU;
        if (w < 0.3 || h < 0.06) continue; // hairlines / accents
        if (!label) continue;

        shapes.push({ kind: m[1], label, x, y, w, h });
    }

    // Sanity: prove the extractor actually found shapes.
    if (shapes.length === 0) {
        problems++;
        console.log(`\n[${file}] NO SHAPES EXTRACTED - the parser is broken, not the deck.`);
    } else {
        console.log(`[${file}] ${shapes.length} shapes`);
    }

    for (let i = 0; i < shapes.length; i++) {
        for (let j = i + 1; j < shapes.length; j++) {
            const a = shapes[i], b = shapes[j];
            const ox = Math.min(a.x + a.w, b.x + b.w) - Math.max(a.x, b.x);
            const oy = Math.min(a.y + a.h, b.y + b.h) - Math.max(a.y, b.y);
            if (ox <= 0.02 || oy <= 0.02) continue;

            const overlap = ox * oy;
            const smaller = Math.min(a.w * a.h, b.w * b.h);
            const ratio = overlap / smaller;

            // Ignore deliberate layering: backgrounds inside accent cards etc.
            const isCard = a.w * a.h > 1.2 || b.w * b.h > 1.2;
            if (ratio < 0.34) continue;
            if (isCard && ratio < 0.9) continue;

            // Both must have real content to count as a collision.
            problems++;
            console.log(`\n[${file}] overlap ${(ratio * 100).toFixed(0)}%  (${ox.toFixed(2)} x ${oy.toFixed(2)} in)`);
            console.log(`   A ${a.kind} @ y=${a.y.toFixed(2)} h=${a.h.toFixed(2)}  "${a.label}"`);
            console.log(`   B ${b.kind} @ y=${b.y.toFixed(2)} h=${b.h.toFixed(2)}  "${b.label}"`);
        }
    }

    // Also flag anything running off the 10 x 5.625 in canvas.
    for (const s of shapes) {
        if (s.x + s.w > 10.02 || s.y + s.h > 5.63 || s.x < -0.02 || s.y < -0.02) {
            problems++;
            console.log(`\n[${file}] OFF-CANVAS  x=${s.x.toFixed(2)} y=${s.y.toFixed(2)} w=${s.w.toFixed(2)} h=${s.h.toFixed(2)}  "${s.label}"`);
        }
    }
}

fs.rmSync(tmp, { recursive: true, force: true });
console.log(problems === 0 ? '\nNo layout collisions detected.' : `\n${problems} problem(s) found.`);
