using OpenQA.Selenium;
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
            
        }
    }
}
