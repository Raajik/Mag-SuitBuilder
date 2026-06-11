# Mag-SuitBuilder (Raajik fork)

Windows desktop tool for building optimal armor suits from Decal/Mag-Tools inventory exports. Forked from [Mag-nus/Mag-Plugins](https://github.com/Mag-nus/Mag-Plugins) **Mag-SuitBuilder v2.1.4**.

Original work © Mag-nus (LGPL 2.1 — see `license.md`). Fork changes © Raajik.

**Releases:** [github.com/Raajik/Mag-SuitBuilder/releases](https://github.com/Raajik/Mag-SuitBuilder/releases)

A convenience copy also lives in [ace-raaj-mods `tools/Mag-SuitBuilder/`](https://github.com/Raajik/ace-raaj-mods/tree/main/tools/Mag-SuitBuilder).

## Changes in this fork (v2.2.0)

- **Dark theme** — charcoal UI across main form, filters, grids, trees, tabs, and context menus.
- **Raised filter caps** — upstream hard-limited filter text boxes (`MaxLength = 3` → 999 armor, single-digit cantrips/ratings). This fork allows:
  - Armor / wield level & skill: up to **6 digits** (default max **5000**)
  - Legendary / epic counts: up to **3 digits** (default max **99**)
  - Offensive / defensive / other / total ratings: up to **4 digits** (default max **999**)

Edit defaults in `Mag-SuitBuilder/FilterFieldLimits.cs` if your shard goes higher.

## Requirements

- Windows
- [.NET 8 SDK](https://dotnet.microsoft.com/download) (project targets `net8.0-windows`)
- Mag-Tools inventory XML at `%UserProfile%\Decal Plugins\Mag-Tools\` (same as upstream)

## Build

From this repository root:

```powershell
dotnet build Mag-SuitBuilder\Mag-SuitBuilder.csproj -c Release
```

Output: `Mag-SuitBuilder\bin\Release\net8.0-windows\Mag-SuitBuilder.exe`

## Upstream

- Release: https://github.com/Mag-nus/Mag-Plugins/releases/tag/Mag-SuitBuilder-v2.1.4
- Report upstream bugs to Mag-nus; report fork-specific issues in this repo.
