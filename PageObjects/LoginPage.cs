// Importing necessary namespaces for Selenium WebDriver and NUnit Framework
using OpenQA.Selenium;
using NUnit.Framework;

// Defining the namespace for the class
namespace TranzactDemo.PageObjects
{
    // LoginPage class which inherits from the BasePage class
    public class LoginPage : BasePage
    {
        // Private variables for By locators for different elements on the page
        private readonly By _userName = By.XPath("//input[@id='user-name']");
        private readonly By _pass = By.XPath("//input[@id='password']");
        private readonly By _loginButton = By.XPath("//input[@id='login-button']");
        private readonly By _errorMessage = By.XPath("//div[@class='error-message-container error']/h3[normalize-space()]");
        
        // Constructor for the class. It takes WebDriver as a parameter and passes it to the base class constructor
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        // Method to navigate to the login page
        public void LoadLoginPage()
        {
            Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        // Method to enter username. It uses the SendText method from the base class.
        public void EnterUsername(string user)
        {
            SendText(_userName, user);
        }

        // Method to enter password. It uses the SendText method from the base class.
        public void EnterPassword(string password)
        {
            SendText(_pass, password);
        }

        // Method to click the login button. It uses the Click method from the base class.
        public void ClickLoginButton()
        {
            Click(_loginButton);
        }
        
        // Method to verify the error message when a user is locked. It uses AssertElementPresent and GetText methods from the base class.
        public void IShouldSeeAnErrorMessageIndicatingTheUserIsLocked(string message)
        {
            AssertElementPresent(_errorMessage);
            Assert.AreEqual(GetText(_errorMessage), message);
        }

        // Method to verify different outcomes. It uses the GetText method from the base class and NUnit's Assert.AreEqual.
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
        } 
    }
}

