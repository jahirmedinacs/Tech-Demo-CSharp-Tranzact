using OpenQA.Selenium;
using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDemoCSharpTranzactv2.PageObjects
{
    internal class CheckoutOverviewPage : BasePage
    {
        // XPath to locate the finish button on the page. This will be used to complete the checkout process.
        private readonly By _finishButton = By.XPath("//button[@id='finish']");

        // XPath to locate the thank you message on the page. This will be used to assert the successful completion of the checkout process.
        private readonly By _thankYouMessage = By.XPath("//h2[@class='complete-header'][normalize-space()]");

        // XPath to locate the item total value on the page. This will be used to verify the total price of the items in the cart.
        private readonly By _itemTotalValue = By.XPath("//div[@class='summary_subtotal_label'][normalize-space()]");

        // Constructor to initialize the driver from the BasePage.
        public CheckoutOverviewPage(IWebDriver driver) : base(driver)
        {
        }

        // Method to click the finish button on the checkout overview page.
        // This method will be used whenever we need to complete the checkout process in our tests.
        public void ClickOnFinishOnCheckoutOverviewPage()
        {
            Click(_finishButton);
            WaitForPageToBeLoaded();
        }

        // Method to capture a message from the checkout complete page and assert it against the expected message.
        // This method will be used to verify the successful completion of the checkout process in our tests.
        public void CaptureAMessageFromCheckoutCompletePage(string message)
        {
            string actualMessage = GetText(_thankYouMessage);
            AssertElementPresent(_thankYouMessage);
            Assert.That(actualMessage, Is.EqualTo(message));
        }

        // Method to verify the item total is the same as the first product price captured.
        // This method will be used to verify the total price of the items in the cart in our tests.
        public void VerifyItemTotalIsSameFirstProductPriceCaptured(List<string> productPrices)
        {
            string totalValue = GetText(_itemTotalValue);
            string[] totalValueSplit = totalValue.Split("total: ");
            string itemTotal = totalValueSplit[1];
            Assert.That(productPrices[0], Is.EqualTo(itemTotal));
        }
    }
}
