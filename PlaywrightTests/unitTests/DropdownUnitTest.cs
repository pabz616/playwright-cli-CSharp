using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using Globals = UnitTests.Globals;

namespace UnitTests;

[TestClass]
public class DropdownUnitTest : PageTest
{
    [TestInitialize]
    public async Task TestInitialize()
    {
        await Page.GotoAsync(Globals.BaseUrl+"dropdown");
    }

    [TestMethod]
    public async Task HasTitle()
    {
        await Expect(Page.Locator(Globals.DropdownListPageTitle)).ToBeVisibleAsync();
        await Expect(Page.Locator(Globals.DropdownListPageTitle)).ToContainTextAsync(new Regex(Globals.DropdownListPageTitleCopy));
    }

    [TestMethod]
    public async Task HasDropdownList()
    {
        await Expect(Page.Locator($"xpath={Globals.DropdownList}")).ToBeVisibleAsync();
    }

    [TestMethod]
    public async Task SelectOption()
    {
        await Page.Locator($"xpath={Globals.DropdownList}").SelectOptionAsync("2");
        await Expect(Page.Locator($"xpath={Globals.DropdownList}")).ToHaveValueAsync("2");
        await Expect(Page.Locator($"xpath={Globals.DropdownList}")).ToContainTextAsync("Option 2");
    }

}