using Allure.Net.Commons;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDemoCSharpTranzactv2.Utils
{
    internal class Utilities
    {
        // This is a public method that returns a string. It can be accessed from any class
        public string RandomAlphanumeric(int length)
        {
            // Path.GetRandomFileName() generates a random 11-character string that can be used as a file name
            // The Replace(".", "") removes any periods from the string
            // The Substring(0, length) returns the first 'length' characters of the string
            // So, this method returns a random alphanumeric string of the specified length
            return Path.GetRandomFileName().Replace(".", "").Substring(0, length);
        }

        public string ReadConfig(string key, string filePath)
        {
            string configFilePath = @filePath;

            // Map the path of the config file
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = configFilePath;

            // Get the mapped configuration file
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            // Read a specific setting from the configuration file
            KeyValueConfigurationCollection settings = config.AppSettings.Settings;
            string mySetting = settings[key]?.Value ?? "Default Value if Not Found";

            Console.WriteLine("Setting " + key + ": " + mySetting);

            // If you have custom sections, you can access them like this:
            // var myCustomSection = (MyCustomSection)config.GetSection("myCustomSection");
            return mySetting;
        }

        public string GenerateTimeStamp()
        {
            DateTime now = DateTime.Now;

            // Format the DateTime to include milliseconds
            string timestampWithMilliseconds = now.ToString("yyyy-MM-dd_HH-mm-ss_fff");
            return timestampWithMilliseconds;
        }

        public void TakeScreenshot(IWebDriver _driver)
        {   
            string screenshotName = GenerateTimeStamp();
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"{screenshotName}.png");
            screenshot.SaveAsFile(path);
            AllureApi.AddAttachment($"{screenshotName}.png", "image/png", File.ReadAllBytes(path));
        }
    }
}
