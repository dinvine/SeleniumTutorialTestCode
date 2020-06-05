using EduSohoClassTest.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace EduSohoClassTest.Pages
{
    /// <summary>
    /// Top Menu Page
    /// </summary>
    public class EduSohoTopMenuPage: EduSohuBasePage
    {

        public IWebElement avatar => webDriver.FindElement(By.ClassName("avatar-xs"));
        //public IWebElement 个人设置 => webDriver.FindElement(By.LinkText("个人设置"));
        //public IWebElement 个人主页 => webDriver.FindElement(By.LinkText("个人主页"));
        //public IWebElement 退出登录 => webDriver.FindElement(By.LinkText("退出登录"));
        //public IWebElement 账户中心 => webDriver.FindElement(By.LinkText("账户中心"));


        public EduSohoTopMenuPage(ScenarioContext scenarioContext):base(scenarioContext)
        {
           // webDriver.Url = Helps.GetConfigurationValue("TopMenu");
        }

        public void LogOut()
        {
            HoverOnAvatar();
            Helps.ClickOperation(webDriver, By.LinkText("退出登录"));
            context["webdriver"] = webDriver;
        }

        public void HoverOnAvatar()
        {
            Actions builder = new Actions(webDriver);
            Actions hover = builder.MoveToElement(Helps.GetIWebElementBy(webDriver, By.ClassName("avatar-xs")));
            hover.Build().Perform();
            Thread.Sleep(500);
        }

        /// <summary>
        /// click pop up menue items
        /// </summary>
        public IWebDriver GotoPersonalManage(string menuName)
        {
            HoverOnAvatar();
            Thread.Sleep(500);
            Helps.ClickOperation(webDriver, By.LinkText(menuName));
            context["webdriver"] = webDriver;
            return webDriver;
        }

        public void SuccessLogin()
        {
            Assert.IsTrue(avatar.Displayed, "test failed due to avatar is not displayed after login action.");
        }

        public void SuccessLogout()
        {
            Assert.IsFalse(avatar.Displayed, "test failed due to avatar is not displayed after login action.");
            Assert.AreEqual("http://lyratesting2.co.nz/login", webDriver.Url, "test failed due to url is not directed to login page after logout action");
        }
    }
}
