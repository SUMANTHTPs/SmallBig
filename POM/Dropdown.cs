using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBig.POM
{
    class Dropdown
    {
        IWebDriver driver;
        public Dropdown(IWebDriver driver)
        {
            this.driver = driver;
        }

        By giftDropDown = By.XPath("//*[@id='myheader']/div[1]/div/div/ul/li[7]/a");
        By guysGift = By.XPath("//*[@id='myheader']/div[1]/div/div/ul/li[7]/ul/li[1]/a");
        By guysGiftTitle = By.XPath("//*[@id='shopify-section-collection-header']/div/header/h1");

        

        internal void HoverOnGifts()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(giftDropDown)).Build().Perform();
            driver.FindElement(guysGift).Click();
        }

        internal void SelectGuysGift()
        {
            Console.WriteLine("Guys gift selected");
        }



        internal void AssertGivenTitle(string actualTitle)
        {
            string expectedTitle = driver.FindElement(guysGiftTitle).Text;
            Assert.AreEqual(expectedTitle, actualTitle);
        }
    }
}
