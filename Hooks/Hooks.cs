using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SmallBig.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        
        static int count = 0;
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private static ExtentKlovReporter klov;





        [BeforeScenario]
        public void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Thread.Sleep(4000);
            IWebDriver driver = BrowserFactory.GetBrowserInstance();
            Thread.Sleep(2000);
            string dateString = DateTime.Now.ToString("MM-dd-yyyy hh-mm-ss");
            Console.WriteLine(dateString);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(dateString + " test " + (count++) + ".png", ScreenshotImageFormat.Png);

            driver.Quit();
        }
    }
}
