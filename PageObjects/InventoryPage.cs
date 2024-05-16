// Importing necessary namespaces for Selenium WebDriver, NUnit Framework, and System.Collections.Generic
using OpenQA.Selenium;
using NUnit.Framework;

namespace TechDemoCSharpTranzactv2.PageObjects
{
    internal class InventoryPage : BasePage
    {
        // XPath with placeholder to locate "Add to cart" button for a specific product. Placeholder will be replaced with actual product name at runtime.
        private readonly string _addProductByNameButton = "//div[@class='inventory_item_name '][normalize-space()='{0}']/ancestor::div[@class='inventory_item_description']//button[normalize-space()='Add to cart']";

        // XPath to locate the cart icon.
        private readonly By _cartIcon = By.XPath("//a[@data-test='shopping-cart-link']");

        // XPath to locate the sort type button.
        private readonly By _sortTypeButton = By.XPath("//select[@data-test='product-sort-container']");

        // XPath with placeholder to locate sort type option. Placeholder will be replaced with actual sort type at runtime.
        private readonly string _sortTypeByName = "//select/option[normalize-space()='{0}']";

        // XPath to locate the current sort type.
        private readonly By _currentSortType = By.XPath("//span[@class='active_option']");

        // XPath to locate item prices.
        private readonly By _itemPrices = By.XPath("//div[@class='inventory_item_price']");

        // XPath with placeholder to locate "Remove" button for a specific product. Placeholder will be replaced with actual product name at runtime.
        private readonly string _removeProductByNameButton = "//div[@class='inventory_item_name '][normalize-space()='{0}']/ancestor::div[@class='inventory_item_description']//button[normalize-space()='Remove']";

        // XPath with placeholder to locate the price of a specific product. Placeholder will be replaced with actual product name at runtime.
        private readonly string _itemPriceProductName = "//div[@class='inventory_item_name '][normalize-space()='{0}']/ancestor::div[@class='inventory_item_description']//div[@data-test='inventory-item-price']";

        // List to store the prices of products on the products page.
        private List<string> _priceFromProductsOnProductsPage = new List<string>();

        public InventoryPage(IWebDriver driver) : base(driver)
        {
        }

        private string _destinationURL = "https://www.saucedemo.com/inventory.html";

        // Method to add a product to the cart by name. The product name is passed as a parameter. String.Format is used to replace the placeholder in the XPath with the actual product name.
        public void AddProductByNameToCart(string productName)
        {
            Click(By.XPath(string.Format(_addProductByNameButton, productName)));
            WaitForPageToBeLoaded();
        }

        // Method to click the cart icon.
        public void ClickOnCartIcon()
        {
            Click(_cartIcon);
            WaitForPageToBeLoaded();
        }

        // Method to click the sort type button on the products page.
        public void ClickOnSortTypeButtonOnProductsPage()
        {
            Click(_sortTypeButton);
            WaitForPageToBeLoaded();
        }

        // Method to change the product sort type. The sort type is passed as a parameter. String.Format is used to replace the placeholder in the XPath with the actual sort type.
        public void ChangeProductSortByType(string sortType)
        {
            Click(By.XPath(string.Format(_sortTypeByName, sortType)));
            WaitForPageToBeLoaded();
        }

        // Method to verify the displayed name on the sort filter. The sort type is passed as a parameter.
        public void VerifyTheDisplayedNameOnTheSortFilterIs(string sortType)
        {
            IWebElement sortTypeElement = Driver.FindElement(_currentSortType);
            Assert.That(sortTypeElement.Text.Trim(), Is.EqualTo(sortType));
        }

        // Method to verify that the prices from products are in ascending order.
        public void VerifyPricesFromProductsAreInAscendingOrder()
        {
            List<string> itemPricesString = GetTexts(_itemPrices);
            List<double> itemPricesDouble = itemPricesString.Select(price => double.Parse(price.Replace("$", ""))).ToList();
            bool isSorted = itemPricesDouble.Zip(itemPricesDouble.Skip(1), (x, y) => x <= y).All(b => b);
            Assert.That(isSorted, "Prices are not in ascending order");
        }

        // Method to verify the remove button is enabled for a product by name. The product name is passed as a parameter. String.Format is used to replace the placeholder in the XPath with the actual product name.
        public void VerifyTheRemoveButtonIsEnabledForProductByName(string productName)
        {
            AssertElementPresent(By.XPath(string.Format(_removeProductByNameButton, productName)));
        }

        // Method to save the price of a product by name from the product page. The product name is passed as a parameter. String.Format is used to replace the placeholder in the XPath with the actual product name.
        public List<string> SaveThePriceOfProductNameFromProductPage(string productName)
        {
            By element = By.XPath(string.Format(_itemPriceProductName, productName));
            AssertElementPresent(element);
            string itemProductPage = GetText(element);
            _priceFromProductsOnProductsPage.Add(itemProductPage);
            Console.WriteLine("Price from products on products page: " + _priceFromProductsOnProductsPage);
            return _priceFromProductsOnProductsPage;
        }
    }
}
