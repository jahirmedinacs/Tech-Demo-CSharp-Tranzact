using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDemoCSharpTranzactv2.PageObjects
{
    internal class CheckoutPage : BasePage
    {
        // XPath to locate the first name input field on the page. This will be used to enter the first name during checkout.
        private readonly By _firstNameInput = By.XPath("//input[@id='first-name']");

        // XPath to locate the last name input field on the page. This will be used to enter the last name during checkout.
        private readonly By _lastNameInput = By.XPath("//input[@id='last-name']");

        // XPath to locate the postal code input field on the page. This will be used to enter the postal code during checkout.
        private readonly By _postalCodeInput = By.XPath("//input[@id='postal-code']");

        // XPath to locate the continue button on the page. This will be used to progress from the checkout page.
        private readonly By _continueButton = By.XPath("//input[@data-test='continue']");

        // Constructor to initialize the driver from the BasePage.
        public CheckoutPage(IWebDriver driver) : base(driver)
        {
        }

        // Method to fill out the checkout information. 
        // This method will be used whenever we need to fill out the checkout form in our tests.
        public void FillCheckoutInformation(string randomData)
        {
            ClearText(_firstNameInput);
            SendText(_firstNameInput, randomData);
            ClearText(_lastNameInput);
            SendText(_lastNameInput, randomData);
            ClearText(_postalCodeInput);
            SendText(_postalCodeInput, randomData);
        }

        // Method to click the continue button on the checkout page.
        // This method will be used whenever we need to proceed from the checkout page in our tests.
        public void ClickOnContinueButtonOnCheckoutPage()
        {
            Click(_continueButton);
            WaitForPageToBeLoaded();
        }
    }
}
