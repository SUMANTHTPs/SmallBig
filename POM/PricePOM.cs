using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBig.POM
{
    class PricePOM
    {
        IWebDriver driver;
        public PricePOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        By searchBar = By.XPath("//*[@id='myheader']/div[1]/header/div[2]/div[2]/div[3]/form/input[2]");
        By firstItem = By.XPath("//*[@id='snize-product-6617900843206']/a/div/span/span[1]");
        By firstItemPrice = By.ClassName("money");

        public void ClickSearchBar()
        {
            driver.FindElement(searchBar).Click();
        }

        internal void searchItem(string text)
        {
            driver.FindElement(searchBar).SendKeys(text + Keys.Enter);
        }

        internal void SelectFirstItem()
        {
            driver.FindElement(firstItem).Click();
        }

        internal void GetPrice()
        {
            string price = driver.FindElement(firstItemPrice).Text;
            Console.WriteLine("The price of first item is:" + price);
        }

    }
}
