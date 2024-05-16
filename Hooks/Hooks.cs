// Import necessary namespaces for Selenium WebDriver and browser-specific drivers
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

// Import utilities and other necessary namespaces from the project
using TechDemoCSharpTranzactv2.Utils;

// Namespace declaration for the project
namespace TechDemoCSharpTranzactv2.Hooks
{
    // The Binding attribute is used by SpecFlow to identify this class as containing bindings for steps, hooks, etc.
    [Binding]
    public sealed class Hooks
    {
        // ScenarioContext provides a way to share data between bindings within the same scenario.
        private readonly ScenarioContext _scenarioContext;

        // Utilities class instance to access common utility functions such as configuration reading.
        private readonly Utilities _util = new Utilities();

        // Constructor for the Hooks class, which initializes the ScenarioContext.
        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        // BeforeScenario is a hook that runs before each scenario is executed.
        [BeforeScenario]
        public void BeforeScenario()
        {  
            // Read the browser type from the configuration file.
            var browserType = _util.ReadConfig("Browser", "ConfigFiles/App.config");

            // Declare a variable to hold the WebDriver instance.
            IWebDriver driver;

            // Switch statement to initialize the WebDriver based on the browser type specified in the config.
            switch (browserType)
            {
                case "Firefox":
                    driver = new FirefoxDriver();  // Creates a new instance of FirefoxDriver
                    break;
                case "Chrome":
                    driver = new ChromeDriver();  // Creates a new instance of ChromeDriver
                    break;
                default:
                    driver = new ChromeDriver();  // Default to ChromeDriver if no valid browser is specified
                    break;
            }

            // Store the WebDriver instance in ScenarioContext under the key "WEBDRIVER" for use in other steps.
            _scenarioContext["WEBDRIVER"] = driver;
        }

        // AfterScenario is a hook that runs after each scenario is executed.
        [AfterScenario]
        public void AfterScenario()
        {
            // Try to retrieve the WebDriver instance from ScenarioContext.
            if (_scenarioContext.TryGetValue("WEBDRIVER", out IWebDriver driver))
            {
                driver.Quit();  // Quit the driver, closing every associated window.
            }
        }
    }
}
