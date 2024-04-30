// Import necessary namespaces
using Allure.NUnit; // Allure is a flexible lightweight multi-language test report tool
using NUnit.Framework; // NUnit is a unit-testing framework for .NET applications
using OpenQA.Selenium; // Selenium WebDriver is a collection of open-source APIs used to automate the testing of a web application
using OpenQA.Selenium.Chrome; // ChromeDriver is a standalone server that implements WebDriver's wire protocol for Chromium
using TechTalk.SpecFlow;
using TranzactDemo.Common; // SpecFlow is a tool for defining and executing human-readable acceptance tests for .NET applications



// Annotate the class with Binding, TestFixture and AllureNUnit attributes
[Binding, TestFixture, AllureNUnit]
public class Hooks
{
    // Declare a private read-only variable of type ScenarioContext (Use to share data between steps)
    private readonly ScenarioContext _scenarioContext;
    private readonly Utilities _util = new Utilities();
    // Define a constructor for the class that takes a ScenarioContext as a parameter
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