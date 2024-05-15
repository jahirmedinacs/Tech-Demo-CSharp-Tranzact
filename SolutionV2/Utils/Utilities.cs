using System;
using System.Collections.Generic;
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

        //public void TakeScreenshot(IWebDriver _driver)
        //{
        //    string screenshotName = "tempScreenshot";
        //    var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
        //    var path = Path.Combine(Directory.GetCurrentDirectory(), $"{screenshotName}.png");
        //    screenshot.SaveAsFile(path);
        //    AllureApi.AddAttachment($"{screenshotName}.png", "image/png", File.ReadAllBytes(path));
        //}
    }
}
