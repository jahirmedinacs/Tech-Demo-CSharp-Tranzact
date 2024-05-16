using TechDemoCSharpTranzactv2.PageObjects;

namespace TechDemoCSharpTranzactv2.StepDefinitions
{
    [Binding]
    public sealed class SolutionStepDefinition
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
        public SolutionStepDefinition(ScenarioContext scenarioContext)
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


        [Given(@"I am on the SauceDemo login page")]
        public void IAmOnTheSauceDemoLoginPage()
        {
            _login.LoadLoginPage();

            _util.TakeScreenshot(_driver);
        }

        [When(@"I enter Username as ""([^""]*)"" and Password as ""([^""]*)""")]
        public void IEnterUsernameAsAndPasswordAs(string user, string password)
        {
            _login.EnterUsername(user);
            _login.EnterPassword(password);

            _util.TakeScreenshot(_driver);
        }

        [Then(@"I click on the Login button")]
        [When(@"I click on the Login button")]
        public void IClickOnTheLoginButton()
        {
            _login.ClickLoginButton();

            _util.TakeScreenshot(_driver);
        }

        [Then(@"^I should see (.*)$")]
        public void IShouldSee(string expected)
        {
            _login.IShouldSee(expected);

            _util.TakeScreenshot(_driver);
        }

        [Then(@"I should get an error message indicating the user is locked")]
        public void IShouldGetAnErrorMessageIndicatingTheUserIsLocked()
        {
            string message = "Epic sadface: Sorry, this user has been locked out.";
            _login.IShouldSeeAnErrorMessageIndicatingTheUserIsLocked(message);

            _util.TakeScreenshot(_driver);
        }

        [When(@"I add ""([^""]*)"" to the cart from the Products page")]
        public void IAddToTheCartFromTheProductsPage(string productName)
        {
            _inventory.AddProductByNameToCart(productName);

            _util.TakeScreenshot(_driver);
        }

        [Then(@"I click on the cart icon on Products Page")]
        public void IClickOnTheCartIconOnProductsPage()
        {
            _inventory.ClickOnCartIcon();

            _util.TakeScreenshot(_driver);
        }

        [When(@"I click on ""([^""]*)"" on the Cart page")]
        public void IClickOnOnTheCartPage(string buttonName)
        {
            _cart.ClickOnButtonOnCartPage(buttonName);

            _util.TakeScreenshot(_driver);
        }

        [Then(@"I fill the checkout information with random data")]
        public void IFillTheCheckoutInformationWithRandomData()
        {
            string randomData = _util.RandomAlphanumeric(6);
            _checkout.FillCheckoutInformation(randomData);

            _util.TakeScreenshot(_driver);
        }

        [Then(@"I click on continue button on checkout page")]
        public void IClickOnContinueButtonOnCheckoutPage()
        {
            _checkout.ClickOnContinueButtonOnCheckoutPage();

            _util.TakeScreenshot(_driver);
        }

        [Then(@"I click on Finish on checkout overview page")]
        public void IClickOnFinishOnCheckoutOverviewPage()
        {
            _checkoutOverview.ClickOnFinishOnCheckoutOverviewPage();

            _util.TakeScreenshot(_driver);
        }

        [Then(@"I click on menu icon on top left of the header")]
        public void IClickOnMenuIconOnTopLeftOfTheHeader()
        {
            _generalPage.ClickOnMenuIconOnTopLeftOfTheHeader();

            _util.TakeScreenshot(_driver);
        }

        [Then(@"I click on ""([^""]*)"" button on the displayed menu")]
        public void IClickOnButtonOnTheDisplayedMenu(string buttonName)
        {
            _generalPage.ClickOnButtonByNameOnTheDisplayedMenu(buttonName);

            _util.TakeScreenshot(_driver);
        }

        [When(@"I change the Product Sort to ""([^""]*)"" on the Products page")]
        public void IChangeTheProductSortToOnTheProductsPage(string sortType)
        {
            _inventory.ClickOnSortTypeButtonOnProductsPage();
            _inventory.ChangeProductSortByType(sortType);

            _util.TakeScreenshot(_driver);
        }

        [Then(@"Verify the displayed name on the sort filter is ""([^""]*)""")]
        public void VerifyTheDisplayedNameOnTheSortFilterIs(string sortType)
        {
            _inventory.VerifyTheDisplayedNameOnTheSortFilterIs(sortType);

            _util.TakeScreenshot(_driver);
        }

        [Then(@"Verify prices from products are in ascending order")]
        public void VerifyPricesFromProductsAreInAscendingOrder()
        {
            _inventory.VerifyPricesFromProductsAreInAscendingOrder();

            _util.TakeScreenshot(_driver);
        }

        [Then(@"Verify the Remove button is enabled for product ""([^""]*)""")]
        public void VerifyTheRemoveButtonIsEnabledForProduct(string productName)
        {
            _inventory.VerifyTheRemoveButtonIsEnabledForProductByName(productName);

            _util.TakeScreenshot(_driver);
        }

        [Then(@"I save the price of product ""([^""]*)"" from Product page")]
        public void ISaveThePriceOfProductFromProductPage(string productName)
        {
            _productPrices = _inventory.SaveThePriceOfProductNameFromProductPage(productName);

            _util.TakeScreenshot(_driver);
        }

        [Then(@"Verify the value from cart is ""([^""]*)""")]
        public void VerifyTheValueFromCartIs(string number)
        {
            _cart.VerifyTheValueFromCartIs(number);

            _util.TakeScreenshot(_driver);
        }

        [Then(@"I save the price of product ""([^""]*)"" from Cart page")]
        public void ISaveThePriceOfProductFromCartPage(string productName)
        {
            _cartPrices = _cart.SaveThePriceOfProductByNameFromCartPage(productName);

            _util.TakeScreenshot(_driver);
        }

        [Then(@"Verify prices captured from Products page are the same as Cart page")]
        public void VerifyPricesCapturedFromProductsPageAreTheSameAsCartPage()
        {
            Assert.That(_productPrices, Is.EqualTo(_cartPrices));

            _util.TakeScreenshot(_driver);
        }

        [Then(@"I remove the product ""([^""]*)"" on the Cart page")]
        public void IRemoveTheProductOnTheCartPage(string productName)
        {
            _cart.RemoveProductByNameOnCartPage(productName);

            _util.TakeScreenshot(_driver);
        }

        [Then(@"I capture the quantity of items added to cart from ""([^""]*)"" on the Cart page")]
        public void ICaptureTheQuantityOfItemsAddedToCartFromOnTheCartPage(string productName)
        {
            _cart.CaptureTheQuantityOfItemsAddedToCartFromANameOnTheCartPage(productName);

            _util.TakeScreenshot(_driver);
        }

        [Then(@"I capture the value of cart from the Cart page")]
        public void ICaptureTheValueOfCartFromTheCartPage()
        {
            _cart.CaptureTheValueOfCartFromTheCartPage();

            _util.TakeScreenshot(_driver);
        }

        [Then(@"Verify quantity and value are the same as captured on Cart page")]
        public void VerifyQuantityAndValueAreTheSameAsCapturedOnCartPage()
        {
            _cart.VerifyQuantityAndValueAreTheSameAsCapturedOnCartPage();

            _util.TakeScreenshot(_driver);
        }

        [Then(@"Verify item total is same first product price captured")]
        public void VerifyItemTotalIsSameFirstProductPriceCaptured()
        {
            _checkoutOverview.VerifyItemTotalIsSameFirstProductPriceCaptured(_productPrices);

            _util.TakeScreenshot(_driver);
        }

        [Then(@"Capture message ""([^""]*)"" from checkout complete page")]
        public void CaptureMessageFromCheckoutCompletePage(string message)
        {
            _checkoutOverview.CaptureAMessageFromCheckoutCompletePage(message);

            _util.TakeScreenshot(_driver);
        }
    }
}
