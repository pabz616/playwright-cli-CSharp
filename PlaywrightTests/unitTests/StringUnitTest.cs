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
        await Expect(Page.Locator(Globals.LoginPageTitle)).ToBeVisibleAsync();
        await Expect(Page.Locator(Globals.LoginPageTitle)).ToContainTextAsync(new Regex(Globals.LoginPageTitleCopy));
    }

    [TestMethod]
    public async Task HasCopyElements()
    {
        await Expect(Page.Locator(Globals.TyposPageCopyElement1)).ToBeVisibleAsync();
        await Expect(Page.Locator(Globals.TyposPageCopyElement2)).ToBeVisibleAsync();
    }

    [TestMethod]
    public async Task HasCopyText()
    {
        await Expect(Page.Locator(Globals.TyposPageCopyElement1)).ToContainTextAsync(new Regex(Globals.TyposPageCopy));
        await Expect(Page.Locator(Globals.TyposPageCopyElement2)).ToContainTextAsync(new Regex(Globals.TyposPageCopy2));
    }

    // [TestMethod]
    // public async Task HasCopyLength()
    // {
    //     var copyLength1 = Page.Locator(Globals.TyposPageCopyElement1);
    //     var copyLength2 = Page.Locator(Globals.TyposPageCopyElement2);

    //     await Expect(copyLength1.length).ToHaveLengthAsync(3);
    //     await Expect(copyLength2.length).ToHaveLengthAsync(3);
    // }
}