using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBig.POM
{
    class GiftCod
    {
        IWebDriver driver;
        public GiftCod(IWebDriver driver)
        {
            this.driver = driver;
        }

        By clickGiftCard = By.LinkText("gift card");
        By pincodeBox = By.XPath("//*[@id='PostalCode']");
        By checkPin = By.XPath("//*[@id='cod-cheker']/button");
        By codavailablity = By.XPath("//*[@id='PostalCodeCheckerAvailability']");

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
    }
}
