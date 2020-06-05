using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using EduSohoClassTest.Common;

namespace EduSohoClassTest.Hooks
{
    [Binding]
    public sealed class PreConditions
    {
//        IWebDriver driver;
//        ScenarioContext context;
//        PreConditions(ScenarioContext scenarioContext)
//        {
//            string browsertype= Helps.GetConfigurationValue("BrowserType");
//            switch(browsertype){
//                case "Firefox":
//                    FirefoxOptions options = new FirefoxOptions();
////                    options.AddArguments("--headless");
//                    driver = new FirefoxDriver(options);
//                    break;
//                case "Chrome":
//                    driver = new ChromeDriver();
//                    break;
//            }
//            context = scenarioContext;
//        }

//        [BeforeScenario()]
//        public void ScenarioSetUp()
//        {
//            string baseURL = Helps.GetConfigurationValue("EduSohoHomePageURL");
//            driver.Navigate().GoToUrl(baseURL);
//            context["webdriver"] = driver;
//        }
    }
}
