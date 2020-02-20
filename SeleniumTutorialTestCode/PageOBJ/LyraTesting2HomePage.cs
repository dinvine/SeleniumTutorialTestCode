using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace SeleniumTutorialTestCode.PageOBJ
{
    public class LyraTesting2HomePage
    {
        IWebDriver webDriver;

        public IWebElement logInLink => webDriver.FindElement(By.LinkText("登录"));
        public IWebElement avatarLink => webDriver.FindElement(By.ClassName("avatar-xs"));
        // public IWebElement moreClassLink => webDriver.FindElement(By.XPath(@"//*[@id='course - list - section']/div/div[4]/a"));
        public IWebElement moreClassLink => webDriver.FindElement(By.XPath(@"/html/body/div[1]/section[2]/div/div[4]/a"));
        public IWebElement logOutLink => webDriver.FindElement(By.LinkText("退出登录"));
        
        public LyraTesting2HomePage(IWebDriver driver)
        {
            webDriver = driver;
        }

        /// <summary>
        /// click the “登陆” link
        /// </summary>
        public void LoginLinkClick()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("登录")));
            logInLink.Click();
        }

        /// <summary>
        /// click the “更多课程” link
        /// </summary>
        public void MoreClassLinkClick()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(@"/html/body/div[1]/section[2]/div/div[4]/a")));
            moreClassLink.Click();
        }

        public void SuccessLogin()
        {
            Assert.IsTrue(avatarLink.Displayed, "test failed due to avatar is not displayed after login action.");            
        }

        public void SuccessLogout()
        {
            Assert.IsFalse(avatarLink.Displayed, "test failed due to avatar is not displayed after login action.");
        }

        public void LogOut()
        {
//            avatarLink.Click();
            Actions builder = new Actions(webDriver);
            Actions hoverClick = builder.MoveToElement(avatarLink).MoveByOffset(0,100).MoveToElement(webDriver.FindElement(By.LinkText("退出登录"))).Click();
            hoverClick.Build().Perform();

            //WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("退出登录")));
            //logOutLink.Click();
        }


    }


}
