using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace UnitTests;

public static class Globals
{
    public static string BaseUrl = "https://the-internet.herokuapp.com/";

    //BUTTONS PAGE  
    public static string ButtonsPageTitle = "h3";    
    public static string ButtonsPageTitleCopy = "Add/Remove Elements";
    public static string AddButton = "//div[@class='example']/button";
    public static string DeleteButton = "//button[@class='added-manually']";

    //CHECKBOX PAGE
    public static string CheckboxPageTitle = "h3";    
    public static string CheckboxPageTitleCopy = "Checkboxes";
    public static string Checkbox1 = "(//input[@type='checkbox'])[1]";
    public static string Checkbox2 = "(//input[@type='checkbox'])[2]";

    //DROPDOWN PAGE
    public static string DropdownListPageTitle = "h3";    
    public static string DropdownListPageTitleCopy = "Dropdown List";
    public static string DropdownList = "//select[@id='dropdown']";


    //LOGIN PAGE
    public static string LoginPageTitle = "h2";    
    public static string LoginPageTitleCopy = "Login Page";
    public static string PageSubHeader = "h4[class='subheader']";
    public static string PageCopy = "This is where you can log into the secure area. Enter tomsmith for the username and SuperSecretPassword! for the password. If the information is wrong you should see error messages.";
    public static string Username = "tomsmith";
    public static string Password = "SuperSecretPassword!";
    public static string UsernameField = "input[name='username']";
    public static string PasswordField = "input[name='password']";
    public static string LoginButton = "button[type='submit']";
    
    //VALIDATION
    public static string InvalidUsername = "invaliduser";
    public static string InvalidPassword = "invalidpassword";
    public static string ValidationError = "div[class='flash error']";
    
    //SECURE AREA PAGE
    public static string ErrorMessages = "Error messages";
    public static string SuccessMessage = "div[class='flash success']";
    public static string SecureAreaTitle = "h2";
    public static string SecureAreaTitleCopy = "Secure Area";
    public static string SuccessText = "You logged into a secure area!";
    public static string LogoutButton = "a.button.secondary.radius";

    //TYPOS PAGE
    public static string TyposPageTitle = "h3";
    public static string TyposPageTitleCopy = "Typos";
    public static string TyposPageCopyElement1= "(//p)[1]";
    public static string TyposPageCopyElement2= "(//p)[2]";
    public static string TyposPageCopy = "This example demonstrates a typo being introduced. It does it randomly on each page load.";
    public static string TyposPageCopy2 = "Sometimes you'll see a typo, other times you won't.";
}
