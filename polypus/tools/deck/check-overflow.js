/* Overflow checker: estimates whether a text box's content needs more vertical
 * space than the box was given. pptxgenjs does not auto-shrink text, so an
 * under-sized box spills onto whatever sits below it - which the rectangle
 * collision check cannot see, because the declared rects never overlap. */

const fs = require('fs');
const path = require('path');
const { execSync } = require('child_process');
const os = require('os');

const pptx = path.join(__dirname, '..', '..', 'docs', 'Polypus-Architecture.pptx');
const tmp = fs.mkdtempSync(path.join(os.tmpdir(), 'pptxovf-'));

const ps = `
Add-Type -AssemblyName System.IO.Compression.FileSystem
$z=[System.IO.Compression.ZipFile]::OpenRead('${pptx.replace(/'/g, "''")}')
foreach($e in $z.Entries){
  if($e.FullName -match '^ppt/slides/slide\\d+\\.xml$'){
    $sr=New-Object System.IO.StreamReader($e.Open())
    $txt=$sr.ReadToEnd(); $sr.Close()
    [System.IO.File]::WriteAllText((Join-Path '${tmp.replace(/\\/g, '\\\\')}' $e.Name), $txt)
  }
}
$z.Dispose()
`;
execSync(`powershell -NoProfile -Command "${ps.replace(/"/g, '\\"').replace(/\r?\n/g, '; ')}"`, { stdio: 'pipe' });

const EMU = 914400;
const files = fs.readdirSync(tmp)
    .filter((f) => /^slide\d+\.xml$/.test(f))
    .sort((a, b) => parseInt(a.replace(/\D/g, ''), 10) - parseInt(b.replace(/\D/g, ''), 10));

let flagged = 0;

/** Decode the handful of XML entities the generator can emit. */
function decode(s) {
    return s.replace(/&lt;/g, '<').replace(/&gt;/g, '>')
        .replace(/&quot;/g, '"').replace(/&apos;/g, "'").replace(/&amp;/g, '&');
}

for (const file of files) {
    const xml = fs.readFileSync(path.join(tmp, file), 'utf8');
    const shapeRe = /<p:sp>([\s\S]*?)<\/p:sp>/g;
    let m;

    while ((m = shapeRe.exec(xml)) !== null) {
        const body = m[1];
        const off = body.match(/<a:off x="(-?\d+)" y="(-?\d+)"\s*\/>/);
        const ext = body.match(/<a:ext cx="(\d+)" cy="(\d+)"\s*\/>/);
        if (!off || !ext) continue;

        const w = +ext[1] / EMU, h = +ext[2] / EMU;
        const y = +off[2] / EMU;

        // Per-run font size (hundredths of a point); default 1800 = 18pt.
        const sizes = [...body.matchAll(/<a:rPr[^>]*\bsz="(\d+)"/g)].map((x) => +x[1] / 100);
        const fs_ = sizes.length ? Math.max(...sizes) : 18;

        // Body text only - skip the shape's own paragraph properties.
        const paragraphs = [...body.matchAll(/<a:p>([\s\S]*?)<\/a:p>/g)];
        let lines = 0;
        let chars = 0;

        for (const p of paragraphs) {
            const t = [...p[1].matchAll(/<a:t>([\s\S]*?)<\/a:t>/g)].map((x) => decode(x[1])).join('');
            if (!t.trim()) continue;
            chars += t.length;

            // Average glyph width ~0.5em for sans/serif, ~0.55em for mono.
            const mono = /Consolas/.test(p[1]) || /Consolas/.test(body);
            const avgW = fs_ * (mono ? 0.55 : 0.5) / 72;
            const perLine = Math.max(1, Math.floor(w / avgW));
            lines += Math.max(1, Math.ceil(t.length / perLine));
        }

        if (lines === 0) continue;

        // 1.20 line-height factor plus a little padding for descenders.
        const needed = lines * fs_ * 1.2 / 72 + 0.06;
        const over = needed - h;

        if (over > 0.03) {
            flagged++;
            console.log(`[${file}] y=${y.toFixed(2)} box h=${h.toFixed(2)} needs ~${needed.toFixed(2)} (${lines} lines @ ${fs_}pt, ${chars} chars, w=${w.toFixed(2)})`);
            console.log(`           over by ${over.toFixed(2)}in  ->  "${[...body.matchAll(/<a:t>([\s\S]*?)<\/a:t>/g)].map((x) => decode(x[1])).join(' ').slice(0, 70)}"`);
        }
    }
}

fs.rmSync(tmp, { recursive: true, force: true });
console.log(flagged === 0 ? '\nNo text overflow estimated.' : `\n${flagged} box(es) may overflow.`);
console.log('Note: this is an estimate using average glyph widths; treat near-zero values as fine and large ones as real.');
