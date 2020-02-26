using EduSohoClassTest.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace EduSohoClassTest.Steps
{
    public class BasePageSteps
    {
        public IWebDriver driver;
        public ScenarioContext context;
        public BasePageSteps(ScenarioContext scenarioContext)
        {
            context = scenarioContext;
            if (scenarioContext.ContainsKey("webdriver"))
                driver = (IWebDriver)scenarioContext["webdriver"];
            else
            {
                string baseURL = Helps.GetConfigurationValue("EduSohoHomePageURL");
                driver = new FirefoxDriver();
                driver.Navigate().GoToUrl(baseURL);
                context["webdriver"] = driver;
            }
        }
    }
}
