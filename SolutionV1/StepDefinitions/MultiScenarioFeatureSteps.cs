// Importing necessary namespaces for test automation, NUnit framework, and Selenium WebDriver
using Allure.NUnit; // Used for Allure integration with NUnit for better reporting
using NUnit.Framework; // NUnit framework for assertions
using OpenQA.Selenium; // Selenium WebDriver for browser automation
using System.Collections.Generic;
using Allure.NUnit.Attributes; // System.Collections.Generic for List<T> data structure
using TechTalk.SpecFlow; // SpecFlow for Behavior Driven Development (BDD)

using Assert = NUnit.Framework.Assert; // Creating an alias for NUnit.Framework.Assert as Assert

using TranzactDemo.PageObjects; // Importing Page Objects for the application under test
using TranzactDemo.Common;

// Defining the namespace for the class
namespace TranzactDemo.StepDefinitions
{
    // The class is decorated with [Binding], [TestFixture], and [AllureNUnit] attributes
    // [Binding] - SpecFlow attribute to denote that this class contains binding methods (Given, When, Then)
    // [TestFixture] - NUnit attribute to denote that this class contains test cases
    // [AllureNUnit] - Allure attribute to enable Allure reporting for NUnit
    [Binding, TestFixture, AllureNUnit]
    public class MultiScenarioFeatureSteps
    {
        // Private variables to hold instances of WebDriver, Page Objects, and Utilities
        private readonly IWebDriver _driver;
        private readonly Utilities _util = new Utilities();
        
        // Page Object instances for different pages in the application
        private readonly LoginPage _login;
        private readonly GeneralPage _generalPage;
        private readonly InventoryPage _inventory;
        private readonly CartPage _cart;
        private readonly CheckoutPage _checkout;
        private readonly CheckoutOverviewPage _checkoutOverview;
        
        // Lists to hold product and cart prices for comparison in tests
        private List<string> _cartPrices = new List<string>();
        private List<string> _productPrices = new List<string>();

        // Constructor for the class. It takes ScenarioContext as a parameter and initializes WebDriver and Page Objects
        public MultiScenarioFeatureSteps(ScenarioContext scenarioContext)
        {   
            // Getting WebDriver instance from ScenarioContext
            // that has been initialized in the Hooks file
            // this is a way to share the WebDriver instance across different steps 
            // but is feature / functionality related to SpecFlow.
            _driver = scenarioContext["WEBDRIVER"] as IWebDriver;
            
            _login = new LoginPage(_driver);
            _generalPage = new GeneralPage(_driver);
            _inventory = new InventoryPage(_driver);
            _cart = new CartPage(_driver);
            _checkout = new CheckoutPage(_driver);
            _checkoutOverview = new CheckoutOverviewPage(_driver);
        }
        
        // The rest of the methods in the class are SpecFlow step definitions. Each method corresponds to a step in the Gherkin feature file
        // The [Given], [When], and [Then] attributes denote the type of the step (Given, When, Then)
        // The methods use the Page Object instances to perform actions on the application and make assertions
        
        [Given("I am on the SauceDemo login page")]
        public void IAmOnTheSauceDemoLoginPage()
        { 
            _login.LoadLoginPage();
        }
        
        // [When("I enter Username as {string} and Password as {string}")]
        [When(@"^I enter Username as \""(.*)\"" and Password as \""(.*)\""$")]
        public void IEnterUsernameAsAndPasswordAs(string user, string password)
        {
            _login.EnterUsername(user);
            _login.EnterPassword(password);
        }

        [Then("I click on the Login button")]
        [When("I click on the Login button")]
        public void IClickOnTheLoginButton()
        {
            _login.ClickLoginButton();
        }
        
        // [Then("I should be redirected to the home page")]
        // public void IShouldBeRedirectedToTheHomePage()
        // {
        //     _inventory.LandingInventory();
        // }

        [Then(@"^I should get an error message indicating the user is locked$")]
        public void IShouldSeeAnErrorMessageIndicatingTheUserIsLocked()
        {
            string message = "Epic sadface: Sorry, this user has been locked out.";
            _login.IShouldSeeAnErrorMessageIndicatingTheUserIsLocked(message);
        }
        
        
        [Given("I login to the SauceDemo website with valid credentials")]
        public void LoginToTheSauceDemoWebsiteWithValidCredentials()
        {
            string user = "standard_user";
            string password = "secret_sauce";
            _login.LoadLoginPage();
            _login.EnterUsername(user);
            _login.EnterPassword(password);
            _login.ClickLoginButton();
        }
        
        [Then(@"^I should see (.*)$")]
        public void IShouldSee(string expected)
        {
            _login.IShouldSee(expected);
        }
        
        [Then("I click on menu icon on top left of the header")]
        public void IClickOnMenuIconOnTopLeftOfTheHeader()
        {
            _generalPage.ClickOnMenuIconOnTopLeftOfTheHeader();
        }
        
        [Then(@"^I click on \""(.*)\"" button on the displayed menu$")]
        public void ClickOnButtonByNameOnTheDisplayedMenu(string buttonName)
        {
            _generalPage.ClickOnButtonByNameOnTheDisplayedMenu(buttonName);
        }
        
        [Then("Verify prices captured from Products page are the same as Cart page")]
        public void VerifyPricesCapturedFromProductsPageAreTheSameAsCartPage()
        {
            Assert.AreEqual(_productPrices, _cartPrices);
        }
        
        [When(@"I add \""(.*)\"" to the cart from the Products page")]    
        public void IAddProductToTheCartFromTheProductsPage(string productName)
        {
            _inventory.AddProductByNameToCart(productName);
        }
        
        [Then("I click on the cart icon on Products Page")]
        public void ClickOnTheCartIconOnProductsPage()
        {
            _inventory.ClickOnCartIcon();
        }

        [When(@"I change the Product Sort to \""(.*)\"" on the Products page")]
        public void ChangeTheProductSortToParameterOnTheProductsPage(string sortType)
        {
            _inventory.ClickOnSortTypeButtonOnProductsPage();
            _inventory.ChangeProductSortByType(sortType);
        }

        [Then(@"Verify the displayed name on the sort filter is \""(.*)\""")]
        public void VerifyTheDisplayedNameOnTheSortFilterIsAName(string sortType)
        {
            _inventory.VerifyTheDisplayedNameOnTheSortFilterIs(sortType);
        }

        [Then("Verify prices from products are in ascending order")]
        public void VerifyPricesFromProductsAreInAscendingOrder()
        {
            _inventory.VerifyPricesFromProductsAreInAscendingOrder();
        }

        [Then(@"Verify the Remove button is enabled for product \""(.*)\""")]
        public void VerifyTheRemoveButtonIsEnabledForProductByName(string productName)
        {
            _inventory.VerifyTheRemoveButtonIsEnabledForProductByName(productName);
        }

        [Then(@"I save the price of product \""(.*)\"" from Product page")]
        public void SaveThePriceOfProductNameFromProductPage(string productName)
        {
            _productPrices = _inventory.SaveThePriceOfProductNameFromProductPage(productName);
        }

        [Then(@"Verify the value from cart is \""(.*)\""")]
        public void VerifyTheValueFromCartIsANumber(string number)
        {
            _cart.VerifyTheValueFromCartIs(number);
        }

        [When(@"I click on \""(.*)\"" on the Cart page")]
        public void IClickOnButtonNameOnTheCartPage(string buttonName)
        {
            _cart.ClickOnButtonOnCartPage(buttonName);
        }

        [Then(@"I save the price of product \""(.*)\"" from Cart page")]
        public void SaveThePriceOfProductByNameFromCartPage(string productName)
        {
            _cartPrices = _cart.SaveThePriceOfProductByNameFromCartPage(productName);
        }

        [Then(@"I remove the product \""(.*)\"" on the Cart page")]
        public void RemoveTheProductNameOnTheCartPage(string productName)
        {
            _cart.RemoveProductByNameOnCartPage(productName);
        }

        [Then(@"I capture the quantity of items added to cart from \""(.*)\"" on the Cart page")]
        public void CaptureTheQuantityOfItemsAddedToCartFromANameOnTheCartPage(string productName)
        {
            _cart.CaptureTheQuantityOfItemsAddedToCartFromANameOnTheCartPage(productName);
        }

        [Then("I capture the value of cart from the Cart page")]
        public void CaptureTheValueOfCartFromTheCartPage()
        {
            _cart.CaptureTheValueOfCartFromTheCartPage();
        }

        [Then("Verify quantity and value are the same as captured on Cart page")]
        public void VerifyQuantityAndValueAreTheSameAsCapturedOnCartPage()
        {
            _cart.VerifyQuantityAndValueAreTheSameAsCapturedOnCartPage();
        }

        [Then("I fill the checkout information with random data")]
        public void IFillTheCheckoutInformationWithRandomData()
        {
            string randomData = _util.RandomAlphanumeric(6);
            _checkout.FillCheckoutInformation(randomData);
        }

        [Then("I click on continue button on checkout page")]
        public void ClickOnContinueButtonOnCheckoutPage()
        {
            _checkout.ClickOnContinueButtonOnCheckoutPage();
        }

        [Then("I click on Finish on checkout overview page")]
        public void ClickOnFinishOnCheckoutOverviewPage()
        {
            _checkoutOverview.ClickOnFinishOnCheckoutOverviewPage();
        }

        [Then("Verify item total is same first product price captured")]
        public void VerifyItemTotalIsSameFirstProductPriceCaptured()
        {
            _checkoutOverview.VerifyItemTotalIsSameFirstProductPriceCaptured(_productPrices);
        }

        [Then(@"Capture message \""(.*)\"" from checkout complete page")]
        public void CaptureAMessageFromCheckoutCompletePage(string message)
        {
            _checkoutOverview.CaptureAMessageFromCheckoutCompletePage(message);
        }
    }
}



