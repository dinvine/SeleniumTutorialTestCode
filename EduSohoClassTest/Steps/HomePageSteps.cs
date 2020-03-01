
using EduSohoClassTest.Common;
using EduSohoClassTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace EduSohoClassTest.Steps
{
    [Binding]
    public class HomePageSteps : BasePageSteps
    {
        HomePageSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }
    }
}
