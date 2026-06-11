# Publish to github.com/Raajik/Mag-SuitBuilder

Cloud agent token cannot push to this repo. One-time publish from a machine with GitHub access:

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
