using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using Globals = UnitTests.Globals;

namespace UnitTests;

[TestClass]
public class LoginUnitTest : PageTest
{

    [TestInitialize]
    public async Task TestInitialize()
    {
        await Page.GotoAsync(Globals.BaseUrl+"login");
    }

    /// <summary>
    /// Helper method to fill login credentials
    /// </summary>
    private async Task FillLoginCredentialsAsync(string username, string password)
    {
        await Page.Locator(Globals.UsernameField).FillAsync(username);
        await Page.Locator(Globals.PasswordField).FillAsync(password);
    }

    [TestMethod]
    public async Task HasTitle()
    {
        await Expect(Page.Locator(Globals.LoginPageTitle)).ToBeVisibleAsync();
        await Expect(Page.Locator(Globals.LoginPageTitle)).ToContainTextAsync(new Regex(Globals.LoginPageTitleCopy));
    }

    [TestMethod]
    public async Task HasCopy()
    {
        await Expect(Page.Locator(Globals.PageSubHeader)).ToBeVisibleAsync();
        await Expect(Page.Locator(Globals.PageSubHeader)).ToContainTextAsync(new Regex(Globals.PageCopy));
    }

    [TestMethod]
    public async Task HasFormElements()
    {
        await Expect(Page.Locator(Globals.UsernameField)).ToBeVisibleAsync();
        await Expect(Page.Locator(Globals.PasswordField)).ToBeVisibleAsync();
        await Expect(Page.Locator(Globals.LoginButton)).ToBeVisibleAsync();
    }


    [TestMethod]
    public async Task SubmitLogin()
    {
        await FillLoginCredentialsAsync(Globals.Username, Globals.Password);
        await Page.Locator(Globals.LoginButton).ClickAsync();

        // Verify successful login
        await Expect(Page.Locator(Globals.SecureAreaTitle)).ToContainTextAsync(new Regex(Globals.SecureAreaTitleCopy));
        await Expect(Page.Locator(Globals.SuccessMessage)).ToBeVisibleAsync();
        await Expect(Page.Locator(Globals.SuccessMessage)).ToContainTextAsync(new Regex(Globals.SuccessText));
        await Expect(Page.Locator(Globals.LogoutButton)).ToBeVisibleAsync();
    }

    [TestMethod]
    public async Task SubmitInvalidLogin()
    {
        await FillLoginCredentialsAsync(Globals.InvalidUsername, Globals.InvalidPassword);
        await Page.Locator(Globals.LoginButton).ClickAsync();
        await Expect(Page.Locator(Globals.ValidationError)).ToBeVisibleAsync();
    }
    
    [TestMethod]
    public async Task SubmitEmptyLogin()
    {
        await FillLoginCredentialsAsync("", "");
        await Page.Locator(Globals.LoginButton).ClickAsync();
        await Expect(Page.Locator(Globals.ValidationError)).ToBeVisibleAsync();
    }

    // TODO: Add more test cases for different scenarios as the need arises

    [TestMethod]
    public async Task Logout()
    {
        //LOGIN
        await FillLoginCredentialsAsync(Globals.Username, Globals.Password);
        await Page.Locator(Globals.LoginButton).ClickAsync();
        await Expect(Page.Locator(Globals.SecureAreaTitle)).ToContainTextAsync(new Regex(Globals.SecureAreaTitleCopy));
        
        //LOGOUT
        await Page.Locator(Globals.LogoutButton).ClickAsync();
        await Expect(Page.Locator(Globals.LoginPageTitle)).ToContainTextAsync(new Regex(Globals.LoginPageTitleCopy));
    }
}