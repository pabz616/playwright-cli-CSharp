using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using Globals = UnitTests.Globals;

namespace UnitTests;

[TestClass]
public class StringUnitTest : PageTest
{
    [TestInitialize]
    public async Task TestInitialize()
    {
        await Page.GotoAsync(Globals.BaseUrl+"typos");
    }

    [TestMethod]
    public async Task HasTitle()
    {
        await Expect(Page.Locator(Globals.TyposPageTitle)).ToBeVisibleAsync();
        await Expect(Page.Locator(Globals.TyposPageTitle)).ToContainTextAsync(new Regex(Globals.TyposPageTitleCopy));
    }

    [TestMethod]
    public async Task HasCopyElements()
    {
        await Expect(Page.Locator($"xpath={Globals.TyposPageCopyElement1}")).ToBeVisibleAsync();
        await Expect(Page.Locator($"xpath={Globals.TyposPageCopyElement2}")).ToBeVisibleAsync();
    }

    [TestMethod]
    public async Task HasCopyText()
    {
        await Expect(Page.Locator($"xpath={Globals.TyposPageCopyElement1}")).ToContainTextAsync(new Regex(Globals.TyposPageCopy));
        await Expect(Page.Locator($"xpath={Globals.TyposPageCopyElement2}")).ToContainTextAsync(new Regex(Globals.TyposPageCopy2));
    }

    [TestMethod]
    public async Task HasCopyLength()
    {
        Assert.AreEqual(Globals.TyposPageCopy.Length, 89);
        Assert.AreEqual(Globals.TyposPageCopy2.Length, 51);
    }
}