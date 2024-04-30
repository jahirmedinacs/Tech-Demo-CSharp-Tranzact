using OpenQA.Selenium;
using TranzactDemo.Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace TranzactDemo.PageObjects
{
    public class InventoryPage : BasePage
    {
        private readonly string _addProductByNameButton = "//div[@class='inventory_item_name '][normalize-space()='{0}']/ancestor::div[@class='inventory_item_description']//button[normalize-space()='Add to cart']";
        private readonly By _cartIcon = By.XPath("//a[@data-test='shopping-cart-link']");
        private readonly By _sortTypeButton = By.XPath("//select[@data-test='product-sort-container']");
        private readonly string _sortTypeByName = "//select/option[normalize-space()='{0}']";
        private readonly By _currentSortType = By.XPath("//span[@class='active_option']");
        private readonly By _itemPrices = By.XPath("//div[@class='inventory_item_price']");
        private readonly string _removeProductByNameButton = "//div[@class='inventory_item_name '][normalize-space()='{0}']/ancestor::div[@class='inventory_item_description']//button[normalize-space()='Remove']";
        private readonly string _itemPriceProductName = "//div[@class='inventory_item_name '][normalize-space()='{0}']/ancestor::div[@class='inventory_item_description']//div[@data-test='inventory-item-price']";
        private List<string> _priceFromProductsOnProductsPage = new List<string>();

        private readonly Utilities _util = new Utilities();

        public InventoryPage(IWebDriver driver) : base(driver)
        {
        }

        private string _destinationURL = "https://www.saucedemo.com/inventory.html";

        public void LandingInventory()
        {
            Assert.AreEqual(_destinationURL, Driver.Url);
        }

        public void AddProductByNameToCart(string productName)
        {
            Click(By.XPath(string.Format(_addProductByNameButton, productName)));
            WaitForPageToBeLoaded();
            _util.AllureCaptureScreenshotRe(Driver);
        }

        public void ClickOnCartIcon()
        {
            Click(_cartIcon);
            WaitForPageToBeLoaded();
            _util.AllureCaptureScreenshotRe(Driver);
        }

        public void ClickOnSortTypeButtonOnProductsPage()
        {
            Click(_sortTypeButton);
            WaitForPageToBeLoaded();
            _util.AllureCaptureScreenshotRe(Driver);
        }

        public void ChangeProductSortByType(string sortType)
        {
            Click(By.XPath(string.Format(_sortTypeByName, sortType)));
            WaitForPageToBeLoaded();
            _util.AllureCaptureScreenshotRe(Driver);
        }

        public void VerifyTheDisplayedNameOnTheSortFilterIs(string sortType)
        {
            IWebElement sortTypeElement = Driver.FindElement(_currentSortType);
            Assert.AreEqual(sortTypeElement.Text.Trim(), sortType);
            _util.AllureCaptureScreenshotRe(Driver);
        }

        public void VerifyPricesFromProductsAreInAscendingOrder()
        {
            List<string> itemPricesString = GetTexts(_itemPrices);
            List<double> itemPricesDouble = itemPricesString.Select(price => double.Parse(price.Replace("$", ""))).ToList();
            bool isSorted = itemPricesDouble.Zip(itemPricesDouble.Skip(1), (x, y) => x <= y).All(b => b);
            Assert.IsTrue(isSorted, "Prices are not in ascending order");
            _util.AllureCaptureScreenshotRe(Driver);
        }

        public void VerifyTheRemoveButtonIsEnabledForProductByName(string productName)
        {
            AssertElementPresent(By.XPath(string.Format(_removeProductByNameButton, productName)));
            _util.AllureCaptureScreenshotRe(Driver);
        }

        public List<string> SaveThePriceOfProductNameFromProductPage(string productName)
        {
            By element = By.XPath(string.Format(_itemPriceProductName, productName));
            AssertElementPresent(element);
            string itemProductPage = GetText(element);
            _priceFromProductsOnProductsPage.Add(itemProductPage);
            System.Console.WriteLine("Price from products on products page: " + _priceFromProductsOnProductsPage);
            _util.AllureCaptureScreenshotRe(Driver);
            return _priceFromProductsOnProductsPage;
        }
    }
}

