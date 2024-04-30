using OpenQA.Selenium;
using TranzactDemo.Common;

namespace TranzactDemo.PageObjects
{
    public class CheckoutPage : BasePage
    {
        private readonly By _firstNameInput = By.XPath("//input[@id='first-name']");
        private readonly By _lastNameInput = By.XPath("//input[@id='last-name']");
        private readonly By _postalCodeInput = By.XPath("//input[@id='postal-code']");
        private readonly By _continueButton = By.XPath("//input[@data-test='continue']");

        private readonly Utilities _util = new Utilities();

        public CheckoutPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillCheckoutInformation(string randomData)
        {
            ClearText(_firstNameInput);
            SendText(_firstNameInput, randomData);
            ClearText(_lastNameInput);
            SendText(_lastNameInput, randomData);
            ClearText(_postalCodeInput);
            SendText(_postalCodeInput, randomData);
            _util.AllureCaptureScreenshotRe(Driver);
        }

        public void ClickOnContinueButtonOnCheckoutPage()
        {
            Click(_continueButton);
            WaitForPageToBeLoaded();
            _util.AllureCaptureScreenshotRe(Driver);
        }
    }
}