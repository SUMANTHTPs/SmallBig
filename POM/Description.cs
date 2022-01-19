using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBig.POM
{
    class Description
    {
        IWebDriver driver;
        public Description(IWebDriver driver)
        {
            this.driver = driver;
        }

        By descriptionPath = By.XPath("//*[@id='ProductSection-6617900843206']/div/div/div[1]/div[2]/div/div[4]/p[1]/span");

        internal void GetDescription()
        {
            string description = driver.FindElement(descriptionPath).Text;
            Console.WriteLine("########___DESCRIPTION___#########");
            Console.WriteLine(description);

        }
    }
}
