using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Configuration;
// using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace TechDemoCSharpTranzactv2.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            // Read the browser type from App.config
            var browserType = ConfigurationManager.AppSettings["Browser"];
            Console.WriteLine("Browser: " + browserType);

            IWebDriver driver;

            switch (browserType)
            {
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

            // Store the driver in ScenarioContext
            _scenarioContext["WEBDRIVER"] = driver;
        }

        // [AfterStep]
        // public void TakeScreenshotAfterStep()
        // {
        //     var driver = _scenarioContext["WEBDRIVER"] as IWebDriver;
        //     _util.TakeScreenshot(driver);
        // }

        // Annotate a method with the AfterScenario attribute. This method will be run after each scenario

        [AfterScenario]
        public void AfterScenario()
        {
            if (_scenarioContext.TryGetValue("WEBDRIVER", out IWebDriver driver))
            {
                driver.Quit();
            }
        }
    }
}