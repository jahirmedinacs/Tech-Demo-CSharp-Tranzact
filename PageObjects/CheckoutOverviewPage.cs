using OpenQA.Selenium;
using TranzactDemo.Common;
using NUnit.Framework;
using System.Collections.Generic;

namespace TranzactDemo.PageObjects
{
    public class CheckoutOverviewPage : BasePage
    {
        private readonly By _finishButton = By.XPath("//button[@id='finish']");
        private readonly By _thankYouMessage = By.XPath("//h2[@class='complete-header'][normalize-space()]");
        private readonly By _itemTotalValue = By.XPath("//div[@class='summary_subtotal_label'][normalize-space()]");

        private readonly Utilities _util = new Utilities();

        public CheckoutOverviewPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickOnFinishOnCheckoutOverviewPage()
        {
            Click(_finishButton);
            WaitForPageToBeLoaded();
            _util.AllureCaptureScreenshotRe(Driver);
        }

        public void CaptureAMessageFromCheckoutCompletePage(string message)
        {
            string actualMessage = GetText(_thankYouMessage);
            AssertElementPresent(_thankYouMessage);
            Assert.AreEqual(actualMessage, message);
            _util.AllureCaptureScreenshotRe(Driver);
        }

        public void VerifyItemTotalIsSameFirstProductPriceCaptured(List<string> productPrices)
        {
            string totalValue = GetText(_itemTotalValue);
            string[] totalValueSplit = totalValue.Split("total: ");
            string itemTotal = totalValueSplit[1];
            Assert.AreEqual(productPrices[0], itemTotal);
            _util.AllureCaptureScreenshotRe(Driver);
        }
    }
}