using EduSohoClassTest.Common;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace EduSohoClassTest.Steps
{
    [Binding]
    public class CommonSteps: BasePageSteps
    {
        public CommonSteps(ScenarioContext scenarioContext):base(scenarioContext)
        {
        }
        [Given(@"I am in ""(.*)"" page")]
        public void GivenIAmInPage(string pageName)
        {
            string baseURL = Helps.GetConfigurationValue(pageName);
            driver.Navigate().GoToUrl(baseURL);
            context["webdriver"] = driver;            
        }
        [Given(@"I click linktext ""(.*)""")]
        public void GivenIClickLinktext(string p0)
        {
            driver = (IWebDriver)context["webdriver"];
            By by = By.LinkText(p0);
            Helps.ClickOperation(driver,by);
            context["webdriver"] = driver;
        }
    }
}
