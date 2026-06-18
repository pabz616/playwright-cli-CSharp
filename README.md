# playwright-cli_C-Sharp

Playwright-CLI w. C#

## Documentation

Playwright .Net Installation Guide
`https://playwright.dev/dotnet/docs/intro`

Powershell 7 Installation for MacOS (ARM)
`https://learn.microsoft.com/en-us/powershell/scripting/install/install-powershell-on-macos?view=powershell-7.6`

After the package is installed, run `pwsh` from a terminal. If you have installed a Preview package, run pwsh-preview.

Locator Strategies
`https://playwright.dev/dotnet/docs/locators`
`https://deepwiki.com/microsoft/playwright-dotnet/3.3-locators`

Run a test
`dotnet test`

:warning: When a `Large File Error` is encountered:

*The Problem* 
The node file [filename] (114.39 MB) was being tracked in git history and exceeded GitHub's 100 MB limit. This is a build artifact that should never be committed.

*The Solution*
Updated .gitignore — Added C# build directories (bin/, obj/, .vs/, etc.) to prevent future commits of build artifacts
Cleaned git history — Used git filter-branch to remove bin/ and obj/ directories from all commits
Force pushed — Pushed the cleaned history to GitHub
The upload is now complete at only 6.19 KiB instead of 41.70 MiB! 🎉

*Future Prevention*
Make sure your .gitignore includes standard build directories for your language/framework before committing. For C# projects, always ignore:

bin/ - compiled binaries
obj/ - object files
.vs/ - Visual Studio metadata