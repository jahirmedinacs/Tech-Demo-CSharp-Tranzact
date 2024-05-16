using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SysConf = System.Configuration;
using TechTalk.SpecFlow;
using System.Reflection;
using TechDemoCSharpTranzactv2.Utils;

namespace TechDemoCSharpTranzactv2.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Utilities _util = new Utilities();

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {  
            var browserType = _util.ReadConfig("Browser", "ConfigFiles/App.config");

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