using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SmallBig
{
    class Pagefactory
    {
        IWebDriver driver;


        public Pagefactory(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Elements
       
        //By searchBar = By.XPath("//*[@id='myheader']/div[1]/header/div[2]/div[2]/div[3]/form/input[2]");
        //By firstItem = By.XPath("//*[@id='snize-product-6617900843206']/a/div/span/span[1]");
        //By firstItemPrice = By.ClassName("money");
        //By clickGiftCard = By.LinkText("gift card");
        //By pincodeBox = By.XPath("//*[@id='PostalCode']");
        //By checkPin = By.XPath("//*[@id='cod-cheker']/button");
        //By codavailablity = By.XPath("//*[@id='PostalCodeCheckerAvailability']");
        //By giftDropDown = By.XPath("//*[@id='myheader']/div[1]/div/div/ul/li[7]/a");
        //By guysGift = By.XPath("//*[@id='myheader']/div[1]/div/div/ul/li[7]/ul/li[1]/a");
        //By guysGiftTitle = By.XPath("//*[@id='shopify-section-collection-header']/div/header/h1");
        //By rakhilink = By.XPath("//*[@id='shopify-section-footer']/footer[1]/div[1]/div[2]/div[4]/ul/li[1]/a");
        //By rakhititle = By.XPath("//*[@id='shopify-section-collection-header']/div/header/h1");
        //By top50Link = By.XPath("//*[@id='myheader']/div[1]/div/div/ul/li[6]/a");
        //By top50Title = By.XPath("//*[@id='shopify-section-collection-header']/div/header/h1");
        By descriptionPath = By.XPath("//*[@id='ProductSection-6617900843206']/div/div/div[1]/div[2]/div/div[4]/p[1]/span");
        


        //Methods


        

        
    }

}
