namespace TechDemoCSharpTranzactv2.PageObjects
{
    internal class GeneralPage : BasePage
    {
        // XPath to locate the menu icon on the page. This will be used to interact with the menu.
        private readonly By _menuIcon = By.XPath("//button[@id='react-burger-menu-btn']");

        // XPath with placeholder to locate a specific button option by name on the menu. 
        // This will be used to interact with different buttons on the menu by passing the button name at runtime.
        private readonly string _buttonOptionByNameOnMenu = "//div[@class='bm-menu']//a[normalize-space()='{0}']";

        // Constructor to initialize the driver from the BasePage.
        public GeneralPage(IWebDriver driver) : base(driver)
        {
        }

        // Method to click the menu icon located on the top left of the header.
        // This method will be used whenever we need to open the menu in our tests.
        public void ClickOnMenuIconOnTopLeftOfTheHeader()
        {
            Click(_menuIcon);
            WaitForPageToBeLoaded();
        }

        // Method to click a specific button by its name on the displayed menu.
        // This method will be used whenever we need to interact with a specific button on the menu in our tests.
        public void ClickOnButtonByNameOnTheDisplayedMenu(string buttonName)
        {
            Click(By.XPath(string.Format(_buttonOptionByNameOnMenu, buttonName)));
            WaitForPageToBeLoaded();
        }
    }
}
