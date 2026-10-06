<!--
  Axonite - common pull request template
  Shown automatically on every PR opened under this folder.
-->

## What changed

<!-- One or two sentences. What does this PR do, and why? -->

## Which project

- [ ] `backend/` — Calid.Api (meeting scheduler API)
- [ ] `polypus/` — Polypus.Web (Blazor marketing site)
- [ ] Both

## Type

- [ ] Feature
- [ ] Fix
- [ ] Refactor
- [ ] Content or copy only
- [ ] Chore (build, config, dependencies)

## How it was checked

<!-- The commands you actually ran, and what you saw. -->

```
dotnet build backend/Calid.Api.csproj
dotnet build polypus/Polypus.Web.csproj
```

## Screenshots

<!-- Required for any visible change to Polypus.Web. Before and after if it is a fix. -->

## Checklist

- [ ] Builds clean with no new warnings
- [ ] No secrets, keys or connection strings added
- [ ] Content copied from a third party is attributed and permitted
- [ ] Responsive layout checked (desktop, tablet, mobile) for UI changes
- [ ] Related documentation updated
