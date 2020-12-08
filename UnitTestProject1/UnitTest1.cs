using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProject1.Pages;
using System.Diagnostics;
using UnitTestProject1.Infra;



namespace UnitTestProject1
{
   

    

    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;

        

        [TestMethod]
        public void TestMethod1()
        {
            driver = new ChromeDriver();
            LoginPage login = new LoginPage();
            LoginInfra loginInfra = new LoginInfra();
            //Launch google
            driver.Navigate().GoToUrl("https://dshtigel.netlify.app/");

           



            //find the search bar and enter the text
            //IWebElement emailField = driver.FindElement(By.Id("email"));
            loginInfra.InsertEmail("dshtigel@gmail.com");
            login.GetEmailField(driver).SendKeys(Keys.Enter);
            
            
            login.GetPassField(driver).SendKeys("123456");
            login.GetPassField(driver).SendKeys(Keys.Enter);

            //Find result by LinkText and click
            IWebElement ResultElement = driver.FindElement(By.CssSelector("div > div.Income_balance__3PrIs > p:nth-child(1)"));
            ResultElement.Click();

            string expectedPageTitle = "MMM";
            string actualPageTitle = driver.Title;

            if (expectedPageTitle == actualPageTitle)
            {
                Trace.WriteLine("done");
            } else
            {
                Trace.WriteLine("failed");
            }

        }
    }
}

