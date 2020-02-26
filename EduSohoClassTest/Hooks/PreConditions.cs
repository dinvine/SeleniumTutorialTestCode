using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
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
            string browsertype= Helps.GetConfigurationValue("BrowserType");
            switch(browsertype){
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    driver = new FirefoxDriver();
                    break;
            }
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
