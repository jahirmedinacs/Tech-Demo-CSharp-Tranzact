using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V122.Schema;


namespace TranzactDemo.Common
{
    public class Utilities
    {
        public static readonly string REGEX = "[^a-zA-Z0-9]+";

        public string Format(string str, params object[] args)
        {
            return string.Format(str, args);
        }

        public string RandomAlphanumeric(int length)
        {
            return Path.GetRandomFileName().Replace(".", "").Substring(0, length);
        }

        public int RandomInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max + 1);
        }

        public int RandomIndex(int size)
        {
            Random random = new Random();
            return random.Next(0, size - 1);
        }

        public void CaptureScreenshot(IWebDriver driver)
        {
            try
            {
                var date = DateTime.Now.ToString("yyyy_MMM_dd_HH_mm_ss");
                var title = driver.Title.Replace("|", "-");
                var nameFile = Format("Screenshot_{0}_{1}", title, date);
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile($"./screenshots/{nameFile}.png");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to capture screenshot: {e.Message}");
            }
        }

        public void AllureCaptureScreenshotRe(IWebDriver driver)
        {
            try
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                TestContext.AddTestAttachment(screenshot.AsByteArray.ToString(), "screenshot.png");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public DateTime GetParsedAndFormattedDateWithYear(string date)
        {
            try
            {
                return DateTime.ParseExact(date, "dd MMM yyyy", null);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public DateTime GetParsedAndFormattedDateWithCommaAndYear(string date)
        {
            try
            {
                return DateTime.ParseExact(date, "dd MMM, yyyy", null);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public DateTime GetParsedAndFormattedDate(string date)
        {
            try
            {
                return DateTime.ParseExact(date, "dd MMM", null);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public bool IsInAlphabeticalOrder(List<string> list)
        {
            var previous = string.Empty;
            var tmpList = list.Select(e => e.Trim().Substring(0, 1).ToLower()).ToList();

            foreach (var current in tmpList)
            {
                if (string.Compare(current, previous, StringComparison.Ordinal) < 0)
                    return false;
                previous = current;
            }
            return true;
        }

        public int GetElementLocation(IWebElement element)
        {
            var elementRect = element.Location;
            return elementRect.Y;
        }
    }
}

