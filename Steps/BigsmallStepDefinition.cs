using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Serilog;
using SmallBig.POM;

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
            LoginPOM login = new LoginPOM(driver);
            login.ClickSignIn();
        }
        [Given(@"enter (.*) and (.*)")]
        public void GivenEnterSumanthsumuGmail_ComAnd(string email,string password)
        {
            LoginPOM login = new LoginPOM(driver);
            login.CreateLogin(email, password);
        }

        [When(@"click on sign in button")]
        public void WhenClickOnSignInButton()
        {
            LoginPOM login = new LoginPOM(driver);
            login.ClickSignInbutton();
        }

        [Then(@"It should check for robot or man")]
        public void ThenItShouldCheckForRobotOrMan()
        {
            LoginPOM login = new LoginPOM(driver);
            login.IsRobotCheckopened();
            Log.Debug("Entered to Sign in page");
        }

        [Then(@"It should display Incorrect email or password.")]
        public void ThenItShouldDisplayIncorrectEmailOrPassword_()
        {
            LoginPOM login = new LoginPOM(driver);
            login.CheckUnSuccessfullLogin();
            Log.Debug("Entered to Sign in page with invalid credentials");

        }

        [Given(@"I click on search bar")]
        public void GivenIClickOnSearchBar()
        {
            PricePOM price = new PricePOM(driver);
            price.ClickSearchBar();
        }

        [Given(@"search (.*) in the search bar")]
        public void GivenSearchHarryPotterInTheSearchBar(string text)
        {
            PricePOM price = new PricePOM(driver);
            price.searchItem(text);
        }
        
        [When(@"I click the first product")]
        public void WhenIClickTheFirstProduct()
        {
            PricePOM price = new PricePOM(driver);
            price.SelectFirstItem();
        }

        [Then(@"I should get the price of that product")]
        public void ThenIShouldGetThePriceOfThatProduct()
        {
            PricePOM price = new PricePOM(driver);
            price.GetPrice();
            Log.Debug("Captured the Price tag for the Website");
        }

        [Given(@"I click on the gift card")]
        public void GivenIClickOnTheGiftCard()
        {
            GiftCod giftCod = new GiftCod(driver);
            giftCod.SelectGiftCard();
        }

        [When(@"I enter pincode (.*)")]
        public void WhenIEnterPincode(string pincode)
        {
            GiftCod giftCod = new GiftCod(driver);
            giftCod.EnterPin(pincode);
        }

        [Then(@"check the COD availibility")]
        public void ThenCheckTheAvailibility()
        {
            GiftCod giftCod = new GiftCod(driver);
            giftCod.checkAvailibity();
            Log.Debug("Checked COD availability");
        }

        [Given(@"I click on rakhi")]
        public void GivenIClickOnRakhi()
        {
            ScrollDown scrollDown = new ScrollDown(driver);
            scrollDown.ClickRakhi();
        }

        [Then(@"It should navigate to the rakhi page")]
        public void ThenItShouldNavigateToTheRakhiPage()
        {
            ScrollDown scrollDown = new ScrollDown(driver);
            scrollDown.checkRakhiPageIsDisplayed();
            Log.Debug("Naviagated to the Rakhi Page");
        }

        [Given(@"I hover on gifts dropdowns")]
        public void GivenIHoverOnGiftsDropdowns()
        {
            Dropdown dropdown = new Dropdown(driver);
            dropdown.HoverOnGifts();
        }

        [Given(@"select gift for guys")]
        public void GivenSelectGiftForGuys()
        {
            Dropdown dropdown = new Dropdown(driver);
            dropdown.SelectGuysGift();
        }

        [Then(@"It should display (.*)")]
        public void ThenItShouldDisplayBestGiftsForGuysMenInIndia(string title)
        {
            Dropdown dropdown = new Dropdown(driver);
            dropdown.AssertGivenTitle(title);
            Log.Debug("Asserted with Guys Gift Page");
        }

        [Given(@"I click on top 50")]
        public void GivenIClickOnTop()
        {
            Top50 top50 = new Top50(driver);
            top50.NavigateToTop50();
        }

        [Then(@"it should display top 50 items")]
        public void ThenItShouldDisplayTopItems()
        {
            Top50 top50 = new Top50(driver);
            top50.AssertDisplayed();
            Log.Debug("Naviagated to Rakhi page from the footer");
        }

        [Then(@"I get description")]
        public void ThenIGetDescription()
        {
            Description description = new Description(driver);
            description.GetDescription();
            Log.Debug("Captured the description of the searched product");
        }

        [When(@"I click on wishlist")]
        public void WhenIClickOnWishlist()
        {
            WishList wishList = new WishList(driver);
            wishList.AddToWishlist(); 
        }

        [Then(@"I navigate to wishlist and get the title of the product in wishlist")]
        public void ThenINavigateToWishlistAndGetTheTitleOfTheProductInWishlist()
        {
            WishList wishList = new WishList(driver);
            wishList.CheckWishList();
            Log.Debug("Item added to the Wishlist");
        }
    }
}
