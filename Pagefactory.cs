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
        By signInButton = By.XPath("//*[@id='myheader']/div[1]/header/div[2]/div[2]/div[4]/div/div/a[1]");
        By emailbox = By.XPath("//*[@id='CustomerEmail']");
        By passbox = By.XPath("//*[@id='CustomerPassword']");
        By LogInButton = By.XPath("//*[@id='customer_login']/p[1]/input");
        By successLogin = By.XPath("//*[@id='MainContent']/div/header/h2");
        By robotCheck = By.XPath("//*[@id='MainContent']/div[1]/p");
        By unsuccessLogin = By.XPath("/html/body/div[2]/div[2]/div/main/div/div[1]/div/div[2]/form/div[1]/ul/li/text()");
        By searchBar = By.XPath("//*[@id='myheader']/div[1]/header/div[2]/div[2]/div[3]/form/input[2]");
        By firstItem = By.XPath("//*[@id='snize-product-6617900843206']/a/div/span/span[1]");
        By firstItemPrice = By.ClassName("money");
        By clickGiftCard = By.LinkText("gift card");
        By pincodeBox = By.XPath("//*[@id='PostalCode']");
        By checkPin = By.XPath("//*[@id='cod-cheker']/button");
        By codavailablity = By.XPath("//*[@id='PostalCodeCheckerAvailability']");
        By giftDropDown = By.XPath("//*[@id='myheader']/div[1]/div/div/ul/li[7]/a");
        By guysGift = By.XPath("//*[@id='myheader']/div[1]/div/div/ul/li[7]/ul/li[1]/a");
        By guysGiftTitle = By.XPath("//*[@id='shopify-section-collection-header']/div/header/h1");
        By rakhilink = By.XPath("//*[@id='shopify-section-footer']/footer[1]/div[1]/div[2]/div[4]/ul/li[1]/a");
        By rakhititle = By.XPath("//*[@id='shopify-section-collection-header']/div/header/h1");
        By top50Link = By.XPath("//*[@id='myheader']/div[1]/div/div/ul/li[6]/a");
        By top50Title = By.XPath("//*[@id='shopify-section-collection-header']/div/header/h1");
        By descriptionPath = By.XPath("//*[@id='ProductSection-6617900843206']/div/div/div[1]/div[2]/div/div[4]/p[1]/span");
        By wishListPath = By.XPath("//*[@id='ProductSection-6617900843206']/div/div/div[1]/div[2]/div/div[1]/div[1]/div/button/span");
        By wishListLink = By.LinkText("wish list");


        //Methods
        public void ClickSignIn()
        {
            //driver.FindElement(By.XPath("//*[@id='myheader']/div[1]/header/div[2]/div[2]/div[3]/form/input[2]")).SendKeys("blaaa");
            Thread.Sleep(2000);
            driver.FindElement(signInButton).Click();
        }

        public void CreateLogin(string email, string password)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(emailbox).Clear();
            driver.FindElement(emailbox).SendKeys(email);
            driver.FindElement(passbox).Clear();
            driver.FindElement(passbox).SendKeys(password);
            Thread.Sleep(2000);
            
        }

        public void ClickSignInbutton()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(LogInButton).Click();
            
        }

        
        public void IsRobotCheckopened()
        {
            string text = driver.FindElement(robotCheck).Text;
            Console.WriteLine(text);
        }

        public void CheckUnSuccessfullLogin()
        {
            string text = driver.FindElement(unsuccessLogin).Text;
            Console.WriteLine(text);
        }

        public void ClickSearchBar()
        {
            driver.FindElement(searchBar).Click();
        }

        internal void searchItem(string text)
        {
            driver.FindElement(searchBar).SendKeys(text+Keys.Enter);
        }

        internal void SelectFirstItem()
        {
            driver.FindElement(firstItem).Click();
        }

        internal void GetPrice()
        {
            string price = driver.FindElement(firstItemPrice).Text;
            Console.WriteLine("The price of first item is:"+price);
            

        }

        public void SelectGiftCard()
        {
            driver.FindElement(clickGiftCard).Click();
        }

        public void EnterPin(string pincode)
        {
            driver.FindElement(pincodeBox).SendKeys(pincode);
        }

        public void checkAvailibity()
        {
            driver.FindElement(checkPin).Click();
            string text = driver.FindElement(codavailablity).Text;
            Console.WriteLine(text);
            
        }

        public void ClickRakhi()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(rakhilink)).Build().Perform();
            driver.FindElement(rakhilink).Click();
            
        }

        public void checkRakhiPageIsDisplayed()
        {
            string expectedTitle = "Unique Rakhi Gifts For Brothers And Sisters";
            string actualTitle = driver.FindElement(rakhititle).Text;
            Assert.AreEqual(expectedTitle, actualTitle);   
        }

        public void HoverOnGifts()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(giftDropDown)).Build().Perform();
            driver.FindElement(guysGift).Click();
        }

        public void SelectGuysGift()
        {
            Console.WriteLine("Guys gift selected");
        }

        

        public void AssertGivenTitle(string actualTitle)
        {
            string expectedTitle = driver.FindElement(guysGiftTitle).Text;
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        public void NavigateToTop50()
        {
            driver.FindElement(top50Link).Click();
        }

        public void AssertDisplayed()
        {
            string actual = "Most Popular";
            string expected = driver.FindElement(top50Title).Text;
            Assert.AreEqual(expected, actual);
        }

        public void GetDescription()
        {
            string description = driver.FindElement(descriptionPath).Text;
            Console.WriteLine("########___DESCRIPTION___#########");
            Console.WriteLine(description);

        }

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
            Console.WriteLine("\n %%%%%"+expectedTitle);
            Assert.AreEqual(expectedTitle, actualTitle);
        }
    }

}
