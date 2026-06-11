# Publish to github.com/Raajik/Mag-SuitBuilder

The Cursor cloud-agent GitHub App token can **read** this repo but returns **403 on push** (repo not in the app's write grant). Use one of these:

## Option A — GitHub Actions sync (recommended)

1. Create a fine-grained PAT with **Contents: Read and write** on `Raajik/Mag-SuitBuilder`.
2. Add it to **ace-raaj-mods** repo secrets as `MAG_SUITBUILDER_SYNC_TOKEN`.
3. Run workflow **Sync Mag-SuitBuilder** (or merge to `main` with changes under `tools/Mag-SuitBuilder/`).

## Option B — manual push

One-time publish from a machine with GitHub access:

```bash
cd tools/Mag-SuitBuilder   # from ace-raaj-mods root
git init
git checkout -b main
git add .
git commit -m "Initial Raajik fork v2.2.0: dark theme and raised filter caps"
git remote add origin https://github.com/Raajik/Mag-SuitBuilder.git
git push -u origin main
git tag v2.2.0
git push origin v2.2.0
```

Tag `v2.2.0` triggers `.github/workflows/build-release.yml` and uploads `Mag-SuitBuilder.exe` to GitHub Releases.
