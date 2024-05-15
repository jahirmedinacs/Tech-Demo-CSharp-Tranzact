using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace TechDemoCSharpTranzactv2.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            // Initialize the _scenarioContext variable with the passed-in scenarioContext
            _scenarioContext = scenarioContext;
        }

        // Annotate a method with the BeforeScenario attribute. This method will be run before each scenario
        [BeforeScenario]
        public void BeforeScenario()
        {
            // Create a new ChromeDriver object and add it to the ScenarioContext with key "WEBDRIVER"
            _scenarioContext["WEBDRIVER"] = new ChromeDriver();
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
            // Retrieve the IWebDriver object from the ScenarioContext and cast it to IWebDriver
            var driver = _scenarioContext["WEBDRIVER"] as IWebDriver;

            // If the driver object is not null, call the Quit method to close all browser windows and end the WebDriver session
            driver?.Quit();
        }
    }
}