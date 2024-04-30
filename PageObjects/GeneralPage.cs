using OpenQA.Selenium;
using TranzactDemo.Common;

namespace TranzactDemo.PageObjects
{
    public class GeneralPage : BasePage
    {
        private readonly By _menuIcon = By.XPath("//button[@id='react-burger-menu-btn']");
        private readonly string _buttonOptionByNameOnMenu = "//div[@class='bm-menu']//a[normalize-space()='{0}']";

        private readonly Utilities _util = new Utilities();

        public GeneralPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickOnMenuIconOnTopLeftOfTheHeader()
        {
            Click(_menuIcon);
            WaitForPageToBeLoaded();
            _util.AllureCaptureScreenshotRe(Driver);
        }

        public void ClickOnButtonByNameOnTheDisplayedMenu(string buttonName)
        {
            Click(By.XPath(string.Format(_buttonOptionByNameOnMenu, buttonName)));
            WaitForPageToBeLoaded();
            _util.AllureCaptureScreenshotRe(Driver);
        }
    }
}