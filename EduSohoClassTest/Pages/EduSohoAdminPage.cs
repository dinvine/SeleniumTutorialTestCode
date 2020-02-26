using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace EduSohoClassTest.Pages
{
    class EduSohoAdminPage: EduSohoAdminTopMenue
    {
        IWebDriver webDriver;
        ScenarioContext context;
        public EduSohoAdminPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            webDriver = (IWebDriver)scenarioContext["webdriver"];
            context = scenarioContext;
        }
    }
}
