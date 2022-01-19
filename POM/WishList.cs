using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBig.POM
{
    class WishList
    {
        IWebDriver driver;
        public WishList(IWebDriver driver)
        {
            this.driver = driver;
        }

        By wishListPath = By.XPath("//*[@id='ProductSection-6617900843206']/div/div/div[1]/div[2]/div/div[1]/div[1]/div/button/span");
        By wishListLink = By.LinkText("wish list");

        public void AddToWishlist()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(wishListPath).Click();

        }

        public void CheckWishList()
        {
            driver.FindElement(wishListLink).Click();
            string expectedTitle = driver.Title;
            string actualTitle = driver.Title;
            Console.WriteLine(expectedTitle);
            Assert.AreEqual(expectedTitle, actualTitle);
        }
    }
}
