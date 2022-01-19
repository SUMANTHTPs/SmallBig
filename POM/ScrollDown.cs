using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBig.POM
{
    class ScrollDown
    {
        IWebDriver driver;
        public ScrollDown(IWebDriver driver)
        {
            this.driver = driver;
        }

        By rakhilink = By.XPath("//*[@id='shopify-section-footer']/footer[1]/div[1]/div[2]/div[4]/ul/li[1]/a");
        By rakhititle = By.XPath("//*[@id='shopify-section-collection-header']/div/header/h1");


        internal void ClickRakhi()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(rakhilink)).Build().Perform();
            driver.FindElement(rakhilink).Click();

        }

        internal void checkRakhiPageIsDisplayed()
        {
            string expectedTitle = "Unique Rakhi Gifts For Brothers And Sisters";
            string actualTitle = driver.FindElement(rakhititle).Text;
            Assert.AreEqual(expectedTitle, actualTitle);
        }
    }
}
