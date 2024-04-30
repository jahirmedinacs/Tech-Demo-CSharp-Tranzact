using OpenQA.Selenium;
using TranzactDemo.Common;
using NUnit.Framework;
using System.Collections.Generic;

namespace TranzactDemo.PageObjects
{
    public class CartPage : BasePage
    {
        private readonly string _btnByNameOnCartPage = "//button[normalize-space()='{0}']";
        private readonly string _removeItemByNameFromCart = "//div[@class='inventory_item_name'][normalize-space()='{0}']/../..//button[normalize-space()='Remove']";
        private readonly string _quantityOfItemByName = "//div[@class='inventory_item_name'][normalize-space()='{0}']/../../../div[@class='cart_quantity'][normalize-space()]";
        private string _itemQuantity = "";
        private string _cartValue = "";
        private readonly By _numberOfItemsOnCart = By.XPath("//span[@class='shopping_cart_badge'][normalize-space()]");
        private readonly string _itemPriceProductCartPage = "//div[@class='cart_item_label']//div[@class='inventory_item_name'][normalize-space()='{0}']/../..//div[@class='inventory_item_price']";
        private List<string> _priceFromProductsOnCartPage = new List<string>();

        private readonly Utilities _util = new Utilities();

        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickOnButtonOnCartPage(string buttonName)
        {
            Click(By.XPath(string.Format(_btnByNameOnCartPage, buttonName)));
            WaitForPageToBeLoaded();
            _util.AllureCaptureScreenshotRe(Driver);
        }

        public void RemoveProductByNameOnCartPage(string productName)
        {
            Click(By.XPath(string.Format(_removeItemByNameFromCart, productName)));
            WaitForPageToBeLoaded();
            _util.AllureCaptureScreenshotRe(Driver);
        }

        public void CaptureTheQuantityOfItemsAddedToCartFromANameOnTheCartPage(string productName)
        {
            _itemQuantity = GetText(By.XPath(string.Format(_quantityOfItemByName, productName)));
            _util.AllureCaptureScreenshotRe(Driver);
        }

        public void CaptureTheValueOfCartFromTheCartPage()
        {
            _cartValue = GetText(_numberOfItemsOnCart);
            _util.AllureCaptureScreenshotRe(Driver);
        }

        public void VerifyQuantityAndValueAreTheSameAsCapturedOnCartPage()
        {
            Assert.AreEqual(_itemQuantity, _cartValue);
            _util.AllureCaptureScreenshotRe(Driver);
        }

        public List<string> SaveThePriceOfProductByNameFromCartPage(string productName)
        {
            By element = By.XPath(string.Format(_itemPriceProductCartPage, productName));
            AssertElementPresent(element);
            string itemCartPage = GetText(element);
            _priceFromProductsOnCartPage.Add(itemCartPage);
            System.Console.WriteLine("Price from products on cart page: " + _priceFromProductsOnCartPage);
            _util.AllureCaptureScreenshotRe(Driver);
            return _priceFromProductsOnCartPage;
        }

        public void VerifyTheValueFromCartIs(string number)
        {
            IWebElement numberOfItemsOnCartElement = Driver.FindElement(_numberOfItemsOnCart);
            Assert.AreEqual(numberOfItemsOnCartElement.Text, number);
            _util.AllureCaptureScreenshotRe(Driver);
        }
    }
}

