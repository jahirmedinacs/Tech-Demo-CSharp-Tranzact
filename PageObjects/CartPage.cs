namespace TechDemoCSharpTranzactv2.PageObjects
{
    internal class CartPage : BasePage
    {
        // Private variables for By locators and strings that will be used in XPaths for different elements on the page.
        private readonly string _btnByNameOnCartPage = "//button[normalize-space()='{0}']";
        private readonly string _removeItemByNameFromCart = "//div[@class='inventory_item_name'][normalize-space()='{0}']/../..//button[normalize-space()='Remove']";
        private readonly string _quantityOfItemByName = "//div[@class='inventory_item_name'][normalize-space()='{0}']/../../../div[@class='cart_quantity'][normalize-space()]";
        private readonly By _numberOfItemsOnCart = By.XPath("//span[@class='shopping_cart_badge'][normalize-space()]");
        private readonly string _itemPriceProductCartPage = "//div[@class='cart_item_label']//div[@class='inventory_item_name'][normalize-space()='{0}']/../..//div[@class='inventory_item_price']";

        // List to store the prices of products on the cart page
        private List<string> _priceFromProductsOnCartPage = new List<string>();

        // Strings to store the quantity of items and the cart value
        private string _itemQuantity = "";
        private string _cartValue = "";

        // Constructor for the class. It takes WebDriver as a parameter and passes it to the base class constructor
        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        // Method to click a button on the cart page. The button name is passed as a parameter.
        public void ClickOnButtonOnCartPage(string buttonName)
        {
            Click(By.XPath(string.Format(_btnByNameOnCartPage, buttonName)));
            WaitForPageToBeLoaded();
        }

        // Method to remove a product from the cart page. The product name is passed as a parameter.
        public void RemoveProductByNameOnCartPage(string productName)
        {
            Click(By.XPath(string.Format(_removeItemByNameFromCart, productName)));
            WaitForPageToBeLoaded();
        }

        // Method to capture the quantity of items added to the cart from a name on the cart page. The product name is passed as a parameter.
        public void CaptureTheQuantityOfItemsAddedToCartFromANameOnTheCartPage(string productName)
        {
            _itemQuantity = GetText(By.XPath(string.Format(_quantityOfItemByName, productName)));
        }

        // Method to capture the value of the cart from the cart page.
        public void CaptureTheValueOfCartFromTheCartPage()
        {
            _cartValue = GetText(_numberOfItemsOnCart);
        }

        // Method to verify that the quantity and value are the same as captured on the cart page.
        public void VerifyQuantityAndValueAreTheSameAsCapturedOnCartPage()
        {
            Assert.That(_itemQuantity, Is.EqualTo(_cartValue));
        }

        // Method to save the price of a product by name from the cart page. The product name is passed as a parameter.
        public List<string> SaveThePriceOfProductByNameFromCartPage(string productName)
        {
            By element = By.XPath(string.Format(_itemPriceProductCartPage, productName));
            AssertElementPresent(element);
            string itemCartPage = GetText(element);
            _priceFromProductsOnCartPage.Add(itemCartPage);
            System.Console.WriteLine("Price from products on cart page: " + _priceFromProductsOnCartPage);
            return _priceFromProductsOnCartPage;
        }

        // Method to verify the value from the cart is as expected. The expected number is passed as a parameter.
        public void VerifyTheValueFromCartIs(string number)
        {
            IWebElement numberOfItemsOnCartElement = Driver.FindElement(_numberOfItemsOnCart);
            Assert.That(numberOfItemsOnCartElement.Text, Is.EqualTo(number));
        }
    }
}
