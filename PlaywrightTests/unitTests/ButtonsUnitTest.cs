using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using Globals = UnitTests.Globals;

namespace UnitTests;

[TestClass]
public class ButtonsUnitTest : PageTest
{
    [TestInitialize]
    public async Task TestInitialize()
    {
        await Page.GotoAsync(Globals.BaseUrl+"add_remove_elements/");
    }


    [TestMethod]
    public async Task HasTitle()
    {
        await Expect(Page.Locator(Globals.ButtonsPageTitle)).ToBeVisibleAsync();
        await Expect(Page.Locator(Globals.ButtonsPageTitle)).ToContainTextAsync(new Regex(Globals.ButtonsPageTitleCopy));
    }

    [TestMethod]
    public async Task HasAddButton()
    {
        await Expect(Page.Locator($"xpath={Globals.AddButton}")).ToBeVisibleAsync();
        await Expect(Page.Locator($"xpath={Globals.AddButton}")).ToBeEnabledAsync();
        await Expect(Page.Locator($"xpath={Globals.DeleteButton}")).ToBeHiddenAsync();
    }

    [TestMethod]
    public async Task HasDeleteButton()
    {
        await Page.Locator($"xpath={Globals.AddButton}").ClickAsync();
        await Expect(Page.Locator($"xpath={Globals.DeleteButton}")).ToBeVisibleAsync();
    }

    [TestMethod]
    public async Task ClickDeleteButton()
    {
        await Page.Locator($"xpath={Globals.AddButton}").ClickAsync();
        await Expect(Page.Locator($"xpath={Globals.DeleteButton}")).ToBeVisibleAsync();
        await Expect(Page.Locator($"xpath={Globals.DeleteButton}")).ToBeEnabledAsync();

        await Page.Locator($"xpath={Globals.DeleteButton}").ClickAsync();
        await Expect(Page.Locator($"xpath={Globals.DeleteButton}")).ToBeHiddenAsync();
    }
}