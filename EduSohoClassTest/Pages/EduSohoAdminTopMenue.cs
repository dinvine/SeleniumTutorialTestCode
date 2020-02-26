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
    public class EduSohoAdminTopMenue
    {
        IWebDriver webDriver;
        ScenarioContext context;
        public IWebElement EduSoho管理后台 => webDriver.FindElement(By.LinkText("EduSoho管理后台"));
        public IWebElement 用户 => webDriver.FindElement(By.LinkText("用户"));
        public IWebElement 课程 => webDriver.FindElement(By.LinkText("课程"));
        public IWebElement 运营 => webDriver.FindElement(By.LinkText("运营"));
        public IWebElement 订单 => webDriver.FindElement(By.LinkText("订单"));
        public IWebElement 账务 => webDriver.FindElement(By.LinkText("账务"));
        public IWebElement 教育云 => webDriver.FindElement(By.LinkText("教育云"));
        public IWebElement 系统 => webDriver.FindElement(By.LinkText("系统"));
        public IWebElement 常用 => webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/ul[2]/li[1]/a"));
        public IWebElement 回首页 => webDriver.FindElement(By.ClassName("glyphicon-home"));
        public IWebElement Admin => webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/ul[2]/li[3]/a"));      
        
        public EduSohoAdminTopMenue(ScenarioContext scenarioContext)
        {
            webDriver = (IWebDriver)scenarioContext["webdriver"];
            context = scenarioContext;
        }
        /// <summary>
        /// click on the 用户
        /// </summary>
        public void 用户Click()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("用户")));
            用户.Click();
            context["webdriver"] = webDriver;
        }

        /// <summary>
        /// click on the 课程
        /// </summary>
        public void 课程Click()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("课程")));
            课程.Click();
            context["webdriver"] = webDriver;
        }

        /// <summary>
        /// click on the 运营
        /// </summary>
        public void 运营Click()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("运营")));
            运营.Click();
            context["webdriver"] = webDriver;
        }

        /// <summary>
        /// click on the 订单
        /// </summary>
        public void 订单Click()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("订单")));
            订单.Click();
            context["webdriver"] = webDriver;
        }

        /// <summary>
        /// click on the 账务
        /// </summary>
        public void 账务Click()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("账务")));
            账务.Click();
            context["webdriver"] = webDriver;
        }

        /// <summary>
        /// click on the 教育云
        /// </summary>
        public void 教育云Click()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("教育云")));
            教育云.Click();
            context["webdriver"] = webDriver;
        }

        /// <summary>
        /// click on the 系统
        /// </summary>
        public void 系统Click()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("系统")));
            系统.Click();
            context["webdriver"] = webDriver;
        }

        /// <summary>
        /// click on the 常用
        /// </summary>
        public void 常用Click()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/div[2]/ul[2]/li[1]/a")));
            常用.Click();
            context["webdriver"] = webDriver;
        }

        /// <summary>
        /// click on the 回首页
        /// </summary>
        public void 回首页Click()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("glyphicon-home")));
            回首页.Click();
            context["webdriver"] = webDriver;
        }

        /// <summary>
        /// click on the Admin
        /// </summary>
        public void AdminClick()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/div[2]/ul[2]/li[3]/a")));
            Admin.Click();
            context["webdriver"] = webDriver;
        }

    }
}
