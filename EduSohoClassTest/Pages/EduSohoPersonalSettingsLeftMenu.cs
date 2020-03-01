using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;   
using TechTalk.SpecFlow;
using AutoItX3Lib;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using EduSohoClassTest.Common;

namespace EduSohoClassTest.Pages
{
    public class EduSohoPersonalSettingsLeftMenu:EduSohoTopMenuPage
    {
        //IWebDriver webDriver;
        //ScenarioContext context;
        public IWebElement avatarSetLink => webDriver.FindElement(By.LinkText("头像设置"));
        public IWebElement basicInfoSetLink => webDriver.FindElement(By.LinkText("基础信息"));

        public EduSohoPersonalSettingsLeftMenu(ScenarioContext scenarioContext):base(scenarioContext)
        {
            //webDriver = (IWebDriver)scenarioContext["webdriver"];
            //context = scenarioContext;
        }
        /// <summary>
        /// click on the 头像设置
        /// </summary>
        public void AvatarAddClick()
        {
            Helps.ClickOperation(webDriver, By.LinkText("头像设置"));
            context["webdriver"] = webDriver;
        }

        /// <summary>
        /// click on the 基础信息
        /// </summary>
        public void BasicInfoClick()
        {

            Helps.ClickOperation(webDriver, By.LinkText("基础信息"));
            context["webdriver"] = webDriver;
        }
    }
}
