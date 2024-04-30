using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace TranzactDemo.PageObjects
{
    public class BasePage
    {
        protected IWebDriver Driver;

        protected readonly WebDriverWait Wait;

        private string _currentPage;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
        }

        public void ClearText(By element)
        {
            WaitWebElementVisibleBy(element);
            Driver.FindElement(element).Clear();
        }

        public void SendText(By element, string text)
        {
            WaitWebElementVisibleBy(element);
            Driver.FindElement(element).SendKeys(text);
        }

        public void PressEnter(By element)
        {
            WaitWebElementVisibleBy(element);
            Driver.FindElement(element).SendKeys(Keys.Enter);
        }

        public IWebElement FindElement(By locator)
        {
            WaitWebElementVisibleBy(locator);
            return Driver.FindElement(locator);
        }

        public string GetText(IWebElement element)
        {
            return element.Text;
        }

        public string GetText(By locator)
        {
            WaitWebElementVisibleBy(locator);
            return Driver.FindElement(locator).Text;
        }

        public List<string> GetTexts(By locator)
        {
            return FindElements(locator).Select(e => e.Text).ToList();
        }

        public bool IsVisible(By locator)
        {
            try
            {
                WaitWebElementVisibleBy(locator);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }

        public void Click(By element)
        {
            WaitWebElementVisibleBy(element);
            WaitWebElementClickableBy(element);
            Driver.FindElement(element).Click();
        }

        public void ClickJS(By element)
        {
            IWebElement webElement = Driver.FindElement(element);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].click();", webElement);
        }

        public void AssertEquals(string elementActual, string txtError)
        {
            Assert.AreEqual(elementActual, txtError);
        }

        public bool ElementExists(By locator)
        {
            return Driver.FindElements(locator).Count > 0;
        }

        public void MoveToElement(By locator)
        {
            IWebElement element = Driver.FindElement(locator);
            Actions actions = new Actions(Driver);
            actions.MoveToElement(element).Perform();
        }

        public void ScrollToElement(By locator)
        {
            IWebElement element = Driver.FindElement(locator);
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(500);
        }

        public void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(500);
        }

        public bool IsNotDisplayed(By locator)
        {
            return Driver.FindElements(locator).Count == 0;
        }

        public bool IsDisplayed(By locator)
        {
            return !IsNotDisplayed(locator);
        }

        public void Click(string xpath)
        {
            By locator = By.XPath(xpath);
            WaitWebElementVisibleBy(locator);
            WaitWebElementClickableBy(locator);
            Driver.FindElement(locator).Click();
        }

        public void MouseOver(By element)
        {
            WaitWebElementVisibleBy(element);
            Actions builder = new Actions(Driver);
            builder.MoveToElement(Driver.FindElement(element)).Perform();
        }

        public List<IWebElement> FindElements(By elements)
        {
            WaitWebElementsVisibleBy(elements);
            return Driver.FindElements(elements).ToList();
        }

        public List<IWebElement> FindElementsIfExists(By elements)
        {
            try
            {
                WaitWebElementsVisibleBy(elements);
            }
            catch (WebDriverTimeoutException)
            {
                return new List<IWebElement>();
            }
            return Driver.FindElements(elements).ToList();
        }

        public void WaitWebElementClickableBy(By element)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public void WaitWebElementVisibleBy(By element)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(element));
        }

        public void WaitWebElementsVisibleBy(By elements)
        {
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(elements));
        }

        public void WaitWebElementPresentBy(By element)
        {
            Wait.Until(ExpectedConditions.ElementExists(element));
        }

        public void AssertElementPresent(By element)
        {
            WaitWebElementVisibleBy(element);
            Assert.IsTrue(Driver.FindElement(element).Displayed);
        }

        public void AssertTextPresentJS(By element, string text)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", Driver.FindElement(element));
            Assert.IsTrue(Driver.FindElement(element).Text.Contains(text));
        }

        public void WaitForPageToBeLoaded()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(driver =>
                ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState;").ToString() == "complete");
            Thread.Sleep(4000);
        }

        public void Sleep(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        public void Sleep(long millis)
        {
            Thread.Sleep((int)millis);
        }

        public bool IsWebElementClickableBy(By element)
        {
            try
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }

        public void SwitchToNewTab()
        {
            _currentPage = Driver.CurrentWindowHandle;
            foreach (string windowHandle in Driver.WindowHandles)
            {
                if (_currentPage != windowHandle)
                {
                    Driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }
        }

        public void SwitchToBaseTab()
        {
            Driver.SwitchTo().Window(_currentPage);
        }

        public void CloseCurrentTab()
        {
            Driver.Close();
        }

        public void DragAndDrop(IWebElement from, IWebElement to)
        {
            Actions act = new Actions(Driver);
            act.DragAndDrop(from, to).Build().Perform();
        }

        public bool IsWebElementDisplayed(By element)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(element));
            return Driver.FindElement(element).Displayed;
        }

        public void WaitWebElementInvisible(By element)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            try
            {
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(element));
            }
            catch (ElementNotInteractableException)
            {
                WaitForPageToBeLoaded();
            }
        }
    }
}

