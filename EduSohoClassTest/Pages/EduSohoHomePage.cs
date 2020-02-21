using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using EduSohoClassTest.Common;
using TechTalk.SpecFlow;

namespace EduSohoClassTest.Pages
{
    public class EduSohoHomePage
    {
        IWebDriver webDriver;
        ScenarioContext context;
        public IWebElement logInLink => webDriver.FindElement(By.LinkText("登录"));
        public IWebElement avatarLink => webDriver.FindElement(By.ClassName("avatar-xs"));
        // public IWebElement moreClassLink => webDriver.FindElement(By.XPath(@"//*[@id='course - list - section']/div/div[4]/a"));
        public IWebElement moreClassLink => webDriver.FindElement(By.XPath(@"/html/body/div[1]/section[2]/div/div[4]/a"));
        public IWebElement logOutLink => webDriver.FindElement(By.LinkText("退出登录"));
        
        public EduSohoHomePage(ScenarioContext scenarioContext)
        {
            webDriver = (IWebDriver)scenarioContext["webdriver"];
            context = scenarioContext;
        }

        /// <summary>
        /// click the “登陆” link
        /// </summary>
        public void LoginLinkClick()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("登录")));
            logInLink.Click();
            context["webdriver"] = webDriver;
        }

        /// <summary>
        /// click the “更多课程” link
        /// </summary>
        public void MoreClassLinkClick()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(@"/html/body/div[1]/section[2]/div/div[4]/a")));
            moreClassLink.Click();
            context["webdriver"] = webDriver;
        }

        public void SuccessLogin()
        {
            Assert.IsTrue(avatarLink.Displayed, "test failed due to avatar is not displayed after login action.");            
        }

        public void SuccessLogout()
        {
            Assert.IsFalse(avatarLink.Displayed, "test failed due to avatar is not displayed after login action.");
            Assert.AreEqual("http://lyratesting2.co.nz/login", webDriver.Url, "test failed due to url is not directed to login page after logout action");
        }

        public void LogOut()
        {
//            avatarLink.Click();
            Actions builder = new Actions(webDriver);
            Actions hover = builder.MoveToElement(avatarLink);
            hover.Build().Perform();
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("退出登录")));
            logOutLink.Click();
            //  Actions hoverClick = builder.MoveToElement(avatarLink).MoveByOffset(0,100).MoveToElement(webDriver.FindElement(By.LinkText("退出登录"))).Click();
            //   hoverClick.Build().Perform();
            context["webdriver"] = webDriver;

          //  WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
          //  wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("退出登录")));
            //
        }

        public void GotoHomePage()
        {
            string baseURL = Helps.GetConfigurationValue("EduSohoHomePageURL");
            webDriver.Navigate().GoToUrl(baseURL);
            context["webdriver"] = webDriver;
        }
               
    }


}
