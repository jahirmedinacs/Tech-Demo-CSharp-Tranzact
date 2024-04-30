using OpenQA.Selenium;

namespace TranzactDemo.PageObjects
{
    public class GooglePage
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "https://www.google.com";

        public GooglePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoTo()
        {
            _driver.Navigate().GoToUrl(_url);
        }
    }
}

