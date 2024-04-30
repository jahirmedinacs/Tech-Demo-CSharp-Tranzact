using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TranzactDemo.Common;
using TranzactDemo.Drivers;
using NUnit.Framework;
using System;

namespace TranzactDemo.StepDefinitions
{
    [Binding]
    public class BaseSteps
    {
        public static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static IWebDriver _driver;

        private readonly Utilities _util = new Utilities();
        private DriverFactory _driverFactory;

        [BeforeScenario]
        public void Setup()
        {
            _driverFactory = new DriverFactory();
            _driverFactory.GetDriver();
            _driver = _driverFactory.Driver();
            Log.Info("@BeforeTest - Setup");
        }

        [AfterScenario(Order = 0)]
        public void TearDown()
        {
            if (ScenarioContext.Current.TestError != null || TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Skipped)
            {
                _util.AllureCaptureScreenshotRe(_driver);
            }
            _driverFactory.TearDown();
            Log.Info("@AfterTest - Tear Down");
        }
    }
}