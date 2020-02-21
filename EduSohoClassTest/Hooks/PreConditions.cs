using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using EduSohoClassTest.Common;

namespace EduSohoClassTest.Hooks
{
    class PreConditions
    {
        IWebDriver driver;
        ScenarioContext context;
        PreConditions(ScenarioContext scenarioContext)
        {

            driver = new FirefoxDriver();
            context = scenarioContext;
        }

        [BeforeScenario()]
        public void ScenarioTearDown()
        {
            string baseURL = Helps.GetConfigurationValue("EduSohoHomePageURL");
            driver.Navigate().GoToUrl(baseURL);
            context["webdriver"] = driver;
        }
    }
}
