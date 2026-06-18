using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace PlaywrightTests;

public static class Globals
{
    public static string BaseUrl = "https://the-internet.herokuapp.com/";

    //LOGIN PAGE
    public static string PageTitle = "h2";    
    public static string PageTitleCopy = "Login Page";
    public static string PageSubHeader = "h4[class='subheader']";
    public static string PageCopy = "This is where you can log into the secure area. Enter tomsmith for the username and SuperSecretPassword! for the password. If the information is wrong you should see error messages.";
    public static string Username = "tomsmith";
    public static string Password = "SuperSecretPassword!";
    public static string UsernameField = "input[name='username']";
    public static string PasswordField = "input[name='password']";
    public static string LoginButton = "button[type='submit']";
    
    //SECURE AREA PAGE
    public static string ErrorMessages = "Error messages";
    public static string SuccessMessage = "div[class='flash success']";
    public static string SecureAreaTitle = "h2";
    public static string SecureAreaTitleCopy = "Secure Area";
    public static string SuccessText = "You logged into a secure area!";
    public static string LogoutButton = "a.button.secondary.radius";
}


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
        await Expect(Page.Locator(Globals.PageTitle)).ToBeVisibleAsync();
        await Expect(Page.Locator(Globals.PageTitle)).ToContainTextAsync(new Regex(Globals.PageTitleCopy));
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
    public async Task Logout()
    {
        //LOGIN
        await FillLoginCredentialsAsync(Globals.Username, Globals.Password);
        await Page.Locator(Globals.LoginButton).ClickAsync();
        await Expect(Page.Locator(Globals.SecureAreaTitle)).ToContainTextAsync(new Regex(Globals.SecureAreaTitleCopy));
        
        //LOGOUT
        await Page.Locator(Globals.LogoutButton).ClickAsync();
        await Expect(Page.Locator(Globals.PageTitle)).ToContainTextAsync(new Regex(Globals.PageTitleCopy));
    }
}