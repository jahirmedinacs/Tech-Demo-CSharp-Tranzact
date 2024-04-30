using Allure.NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

[Binding, TestFixture, AllureNUnit]
public class Hooks
{
    private readonly ScenarioContext _scenarioContext;

    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        _scenarioContext["WEBDRIVER"] = new ChromeDriver();
    }

    [AfterScenario]
    public void AfterScenario()
    {
        var driver = _scenarioContext["WEBDRIVER"] as IWebDriver;
        driver?.Quit();
    }
}