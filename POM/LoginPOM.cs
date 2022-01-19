using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SmallBig.POM
{
    class LoginPOM
    {
        IWebDriver driver;
        public LoginPOM(IWebDriver driver)
        {
            this.driver = driver;
        }
        By signInButton = By.XPath("//*[@id='myheader']/div[1]/header/div[2]/div[2]/div[4]/div/div/a[1]");
        By emailbox = By.XPath("//*[@id='CustomerEmail']");
        By passbox = By.XPath("//*[@id='CustomerPassword']");
        By LogInButton = By.XPath("//*[@id='customer_login']/p[1]/input");
        By successLogin = By.XPath("//*[@id='MainContent']/div/header/h2");
        By robotCheck = By.XPath("//*[@id='MainContent']/div[1]/p");
        By unsuccessLogin = By.XPath("/html/body/div[2]/div[2]/div/main/div/div[1]/div/div[2]/form/div[1]/ul/li/text()");


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
            try
            {
                string text = driver.FindElement(robotCheck).Text;
                Console.WriteLine(text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Tried to sign in");
            }
        }

        public void CheckUnSuccessfullLogin()
        {
            string text = driver.FindElement(unsuccessLogin).Text;
            Console.WriteLine(text);
        }


    }
}
