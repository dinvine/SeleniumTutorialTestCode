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

        public IWebElement LogInLink => webDriver.FindElement(By.LinkText("登录"));
        public IWebElement AvatarLink => webDriver.FindElement(By.ClassName("avatar-xs"));
        // public IWebElement moreClassLink => webDriver.FindElement(By.XPath(@"//*[@id='course - list - section']/div/div[4]/a"));
        public IWebElement MoreClassLink => webDriver.FindElement(By.XPath(@"/html/body/div[1]/section[2]/div/div[4]/a"));
        public IWebElement LogOutLink => webDriver.FindElement(By.LinkText("退出登录"));
        
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
            LogInLink.Click();
        }

        /// <summary>
        /// click the “更多课程” link
        /// </summary>
        public void MoreClassLinkClick()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(@"/html/body/div[1]/section[2]/div/div[4]/a")));
            MoreClassLink.Click();
        }

        public void SuccessLogin()
        {
            Assert.IsTrue(AvatarLink.Displayed, "test failed due to avatar is not displayed after login action.");            
        }

        public void SuccessLogout()
        {
            Assert.IsFalse(AvatarLink.Displayed, "test failed due to avatar is not displayed after login action.");
        }

        public void LogOut()
        {
//            avatarLink.Click();
            Actions builder = new Actions(webDriver);
            Actions hoverClick = builder.MoveToElement(AvatarLink).MoveByOffset(0,100).MoveToElement(webDriver.FindElement(By.LinkText("退出登录"))).Click();
            hoverClick.Build().Perform();

            //WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("退出登录")));
            //logOutLink.Click();
        }


    }


}
