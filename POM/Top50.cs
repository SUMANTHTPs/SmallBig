using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBig.POM
{
    class Top50
    {
        IWebDriver driver;
        public Top50(IWebDriver driver)
        {
            this.driver = driver;
        }
            By top50Link = By.XPath("//*[@id='myheader']/div[1]/div/div/ul/li[6]/a");
            By top50Title = By.XPath("//*[@id='shopify-section-collection-header']/div/header/h1");


            internal void NavigateToTop50()
            {
                driver.FindElement(top50Link).Click();
            }

            internal void AssertDisplayed()
            {
                string actual = "Most Popular";
                string expected = driver.FindElement(top50Title).Text;
                Assert.AreEqual(expected, actual);
            }
        }
    }
