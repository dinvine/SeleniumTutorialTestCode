using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace EduSohoClassTest.Pages
{
    public class EduSohoListPage
    {
        IWebDriver webDriver;
        ScenarioContext context;

        public IWebElement productListLink => webDriver.FindElement(By.LinkText("产品介绍"));
        public EduSohoListPage(ScenarioContext scenarioContext)
        {
            webDriver = (IWebDriver)scenarioContext["webdriver"];
            context = scenarioContext;
        }
        /// <summary>
        /// click the “产品介绍” link
        /// </summary>
        public void productListLinkClick()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("产品介绍")));
            productListLink.Click();
        }
    }
}
