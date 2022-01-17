using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBig
{
    class BrowserFactory
    {
        static IWebDriver? driver;

        public BrowserFactory(string browserName)
        {
            switch (browserName)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    driver = new InternetExplorerDriver();
                    break;
            }
        }

        internal static IWebDriver GetBrowserInstance()
        {
            if (driver != null)
                return driver;
            else
            {
                return null;
                Console.WriteLine("Please initialise browser");
            }
        }
    }
}
