using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Serilog;

namespace SmallBig.Steps
{
    [Binding]
    public sealed class BigsmallStepDefinition
    {
        
        private readonly ScenarioContext _scenarioContext;
        IWebDriver driver;
        
        public BigsmallStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            BrowserFactory browser = new BrowserFactory("chrome");
            Log.Debug("Navigated to the Browser");
        }

        [Given(@"I Intialize the browser")]
        public void GivenIIntializeTheBrowser()
        {
            BrowserFactory.GetBrowserInstance();
        }

        [Given(@"navigate to the URL")]
        public void GivenNavigateToTheURL()
        {
            driver = BrowserFactory.GetBrowserInstance();
            driver.Navigate().GoToUrl("https://www.bigsmall.in/");
            driver.Manage().Window.Maximize();

        }
        [Given(@"I am in homepage")]
        public void GivenIAmInHomepage()
        {
            Console.WriteLine("In homepage");
        }

        [Then(@"get the title of that page")]
        public void ThenGetTheTitleOfThatPage()
        {
            string title=driver.Title;
            Console.WriteLine(title);
            Log.Debug("Captured the Title of the Page");
        }

        [Given(@"I click on signup")]
        public void GivenIClickOnSignup()
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.ClickSignIn();
        }
        [Given(@"enter (.*) and (.*)")]
        public void GivenEnterSumanthsumuGmail_ComAnd(string email,string password)
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.CreateLogin(email, password);
        }

        [When(@"click on sign in button")]
        public void WhenClickOnSignInButton()
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.ClickSignInbutton();
        }

        [Then(@"It should check for robot or man")]
        public void ThenItShouldCheckForRobotOrMan()
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.IsRobotCheckopened();
            Log.Debug("Entered to Sign in page");
        }

        [Then(@"It should display Incorrect email or password.")]
        public void ThenItShouldDisplayIncorrectEmailOrPassword_()
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.CheckUnSuccessfullLogin();
            Log.Debug("Entered to Sign in page with invalid credentials");

        }

        [Given(@"I click on search bar")]
        public void GivenIClickOnSearchBar()
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.ClickSearchBar();
        }

        [Given(@"search (.*) in the search bar")]
        public void GivenSearchHarryPotterInTheSearchBar(string text)
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.searchItem(text);
        }
        
        [When(@"I click the first product")]
        public void WhenIClickTheFirstProduct()
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.SelectFirstItem();
        }

        [Then(@"I should get the price of that product")]
        public void ThenIShouldGetThePriceOfThatProduct()
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.GetPrice();
            Log.Debug("Captured the Price tag for the Website");
        }

        [Given(@"I click on the gift card")]
        public void GivenIClickOnTheGiftCard()
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.SelectGiftCard();
        }

        [When(@"I enter pincode (.*)")]
        public void WhenIEnterPincode(string pincode)
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.EnterPin(pincode);
        }

        [Then(@"check the COD availibility")]
        public void ThenCheckTheAvailibility()
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.checkAvailibity();
            Log.Debug("Checked COD availability");
        }

        [Given(@"I click on rakhi")]
        public void GivenIClickOnRakhi()
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.ClickRakhi();
        }

        [Then(@"It should navigate to the rakhi page")]
        public void ThenItShouldNavigateToTheRakhiPage()
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.checkRakhiPageIsDisplayed();
            Log.Debug("Naviagated to the Rakhi Page");
        }

        [Given(@"I hover on gifts dropdowns")]
        public void GivenIHoverOnGiftsDropdowns()
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.HoverOnGifts();
        }

        [Given(@"select gift for guys")]
        public void GivenSelectGiftForGuys()
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.SelectGuysGift();
        }

        [Then(@"It should display (.*)")]
        public void ThenItShouldDisplayBestGiftsForGuysMenInIndia(string title)
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.AssertGivenTitle(title);
            Log.Debug("Asserted with Guys Gift Page");
        }

        [Given(@"I click on top 50")]
        public void GivenIClickOnTop()
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.NavigateToTop50();
        }

        [Then(@"it should display top 50 items")]
        public void ThenItShouldDisplayTopItems()
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.AssertDisplayed();
            Log.Debug("Naviagated to Rakhi page from the footer");
        }

        [Then(@"I get description")]
        public void ThenIGetDescription()
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.GetDescription();
            Log.Debug("Captured the description of the searched product");
        }

        [When(@"I click on wishlist")]
        public void WhenIClickOnWishlist()
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.AddToWishlist();
            
        }

        [Then(@"I navigate to wishlist and get the title of the product in wishlist")]
        public void ThenINavigateToWishlistAndGetTheTitleOfTheProductInWishlist()
        {
            Pagefactory POM = new Pagefactory(driver);
            POM.CheckWishList();
            Log.Debug("Item added to the Wishlist");
        }
    }
}
