using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using EduSohoClassTest.Common;
using TechTalk.SpecFlow;

namespace EduSohoClassTest.Pages
{
    public class EduSohoHomePage:EduSohoTopMenuPage
    {
//        public IWebElement logInLink => webDriver.FindElement(By.LinkText("登录"));
////      public IWebElement avatarLink => webDriver.FindElement(By.ClassName("avatar-xs"));
//        public IWebElement moreClassLink => webDriver.FindElement(By.XPath(@"/html/body/div[1]/section[2]/div/div[4]/a"));
//        public IWebElement logOutLink => webDriver.FindElement(By.LinkText("退出登录"));
//        public IWebElement personalSettingsLink => webDriver.FindElement(By.LinkText("个人设置"));

        public EduSohoHomePage(ScenarioContext scenarioContext):base(scenarioContext)
        {
        }

        /// <summary>
        /// click the “登陆” link
        /// </summary>
        public void LoginLinkClick()
        {
            Helps.ClickOperation(webDriver, By.LinkText("登录"));
            context["webdriver"] = webDriver;
        }

        /// <summary>
        /// click the “更多课程” link
        /// </summary>
        public void MoreClassLinkClick()
        {
            Helps.ClickOperation(webDriver, By.XPath(@"/html/body/div[1]/section[2]/div/div[4]/a"));
            context["webdriver"] = webDriver;
        }


    }


}
