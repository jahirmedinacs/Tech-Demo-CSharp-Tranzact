using OpenQA.Selenium;
using NUnit.Framework;
using TranzactDemo.Common;

namespace TranzactDemo.PageObjects
{
    public class LoginPage : BasePage
    {
        private readonly By _userName = By.XPath("//input[@id='user-name']");
        private readonly By _pass = By.XPath("//input[@id='password']");
        private readonly By _loginButton = By.XPath("//input[@id='login-button']");
        private readonly By _errorMessage = By.XPath("//div[@class='error-message-container error']/h3[normalize-space()]");

        private readonly Utilities _util = new Utilities();

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void LoadLoginPage()
        {
            Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            _util.AllureCaptureScreenshotRe(Driver);
        }

        public void EnterUsername(string user)
        {
            SendText(_userName, user);
            _util.AllureCaptureScreenshotRe(Driver);
        }

        public void EnterPassword(string password)
        {
            SendText(_pass, password);
            _util.AllureCaptureScreenshotRe(Driver);
        }

        public void ClickLoginButton()
        {
            Click(_loginButton);
            _util.AllureCaptureScreenshotRe(Driver);
        }
        
        public void IShouldSeeAnErrorMessageIndicatingTheUserIsLocked(string message)
        {
            AssertElementPresent(_errorMessage);
            Assert.AreEqual(GetText(_errorMessage), message);
            _util.AllureCaptureScreenshotRe(Driver);
        }

        public void IShouldSee(string expected)
        {
            if (expected == "redirected to the home page")
            {
                Assert.AreEqual(Driver.Url, "https://www.saucedemo.com/inventory.html");
            }
            else if (expected == "error message indicating the user is locked")
            {
                Assert.AreEqual(GetText(_errorMessage), "Epic sadface: Sorry, this user has been locked out.");
            }
            else if (expected == "error message indicating invalid credentials")
            {
                Assert.AreEqual(GetText(_errorMessage), "Epic sadface: Username and password do not match any user in this service");
            }
            _util.AllureCaptureScreenshotRe(Driver);
        }

        
    }
}

