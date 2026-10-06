# Deck tools

Build-time scripts that produce and check `docs/Polypus-Architecture.pptx`, the
architecture deck for the Polypus website.

Nothing here is part of the website. `Polypus.Web` does not reference these
scripts, they are never deployed, and they add no runtime dependency. They exist
so the deck is *generated from source* and matches the site's own palette,
instead of being a hand-assembled file that drifts out of sync.

---

## Why this folder exists

The architecture deck was a requested deliverable. Generating it
programmatically has two advantages over building it by hand:

1. **It is reproducible.** Slide geometry, colour and type come from named
   constants in `generate-deck.js`, so the deck can be regenerated after a
   change instead of re-edited slide by slide.
2. **It can be checked.** `check-layout.js` and `check-overflow.js` read the
   generated `.pptx` back and catch the two mistakes that are easy to make and
   hard to see: shapes that overlap, and text boxes too small for their content.

---

## Files

| File | What it does |
|------|--------------|
| `generate-deck.js` | Builds all 12 slides and writes `docs/Polypus-Architecture.pptx`. Contains the design tokens (palette, fonts, margins) and one block per slide. |
| `check-layout.js` | Unzips the `.pptx`, reads every shape's declared rectangle, and reports overlapping shapes and anything running off the 10 × 5.625 inch canvas. |
| `check-overflow.js` | Estimates whether each text box is tall enough for its content, using font size and average glyph width. Catches text that spills onto whatever sits below it. |
| `package.json` | Declares the single dependency, `pptxgenjs` 4.0.1. |

---

## Using it

```powershell
cd tools\deck
npm install

node generate-deck.js     # writes ..\..\docs\Polypus-Architecture.pptx
node check-layout.js      # expect: "No layout collisions detected."
node check-overflow.js    # expect: "No text overflow estimated."
```

Always run both checkers after editing the deck. The overflow report is an
*estimate* based on average glyph widths, so treat values under a hundredth of
an inch as noise and larger values as real.

To render the slides as images for a visual check, PowerPoint can export them
directly:

```powershell
$pp = New-Object -ComObject PowerPoint.Application
$pres = $pp.Presentations.Open('<repo>\docs\Polypus-Architecture.pptx', $true, $false, $false)
$pres.Export('<output folder>', 'PNG', 1600, 900)
$pres.Close(); $pp.Quit()
```

---

## Editing the deck

- **Colours and fonts** are the `C` and `F` objects at the top of
  `generate-deck.js`. They deliberately mirror the tokens in
  `Polypus.Web/wwwroot/app.css`.
- **Each slide is its own block**, in order, so `slide7` in the source really is
  slide 7 in the file. Add a slide by adding a block.
- **Slide numbers** are passed to `footer(slide, page)` explicitly. If you add
  or reorder slides, update the page numbers.
- **The canvas is 10 × 5.625 inches** at `LAYOUT_16x9`. The page footer sits at
  `y = 5.625 - 0.52`, so content should stop around `y = 4.9` to stay above it.
