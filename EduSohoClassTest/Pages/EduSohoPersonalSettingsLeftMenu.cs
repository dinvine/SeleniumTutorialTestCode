using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;   
using TechTalk.SpecFlow;
using AutoItX3Lib;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace EduSohoClassTest.Pages
{
    public class EduSohoPersonalSettingsLeftMenu
    {
        IWebDriver webDriver;
        ScenarioContext context;
        public IWebElement avatarSetLink => webDriver.FindElement(By.LinkText("头像设置"));
        public IWebElement basicInfoSetLink => webDriver.FindElement(By.LinkText("基础信息"));

        public EduSohoPersonalSettingsLeftMenu(ScenarioContext scenarioContext)
        {
            webDriver = (IWebDriver)scenarioContext["webdriver"];
            context = scenarioContext;
        }
        /// <summary>
        /// click on the 头像设置
        /// </summary>
        public void AvatarAddClick()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("头像设置")));
            avatarSetLink.Click();
            context["webdriver"] = webDriver;
        }

        /// <summary>
        /// click on the 基础信息
        /// </summary>
        public void BasicInfoClick()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("基础信息")));
            basicInfoSetLink.Click();
            context["webdriver"] = webDriver;
        }
    }
}
