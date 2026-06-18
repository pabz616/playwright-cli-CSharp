using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using Globals = UnitTests.Globals;

namespace UnitTests;

[TestClass]
public class CheckboxUnitTest : PageTest
{
    [TestInitialize]
    public async Task TestInitialize()
    {
        await Page.GotoAsync(Globals.BaseUrl+"checkboxes");
    }

    [TestMethod]
    public async Task HasTitle()
    {
        await Expect(Page.Locator(Globals.CheckboxPageTitle)).ToBeVisibleAsync();
        await Expect(Page.Locator(Globals.CheckboxPageTitle)).ToContainTextAsync(new Regex(Globals.CheckboxPageTitleCopy));
    }

    [TestMethod]
    public async Task IsUnchecked()
    {   
        await Expect(Page.Locator($"xpath={Globals.Checkbox1}")).ToBeVisibleAsync();
        await Expect(Page.Locator($"xpath={Globals.Checkbox1}")).Not.ToBeCheckedAsync();
    }

    [TestMethod]
    public async Task IsChecked()
    {
        await Expect(Page.Locator($"xpath={Globals.Checkbox2}")).ToBeVisibleAsync();
        await Expect(Page.Locator($"xpath={Globals.Checkbox2}")).ToBeCheckedAsync();
    }

    [TestMethod]
    public async Task CheckIt()
    {   
        await Page.Locator($"xpath={Globals.Checkbox1}").ClickAsync();
        await Expect(Page.Locator($"xpath={Globals.Checkbox1}")).ToBeCheckedAsync();

        await Page.Locator($"xpath={Globals.Checkbox2}").ClickAsync();
        await Expect(Page.Locator($"xpath={Globals.Checkbox2}")).Not.ToBeCheckedAsync();
    }


}