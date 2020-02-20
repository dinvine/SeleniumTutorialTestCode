using TechTalk.SpecFlow;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace EStoreShoppingSys.Steps
{
    [Binding]
    public sealed class PostConditionSteps
    {
        IWebDriver driver;

        PostConditionSteps(ScenarioContext scenarioContext)
        {

            driver=(IWebDriver)scenarioContext["webdriver"];

        }

        [AfterScenario()]
        public void ScenarioTearDown()
        {
            driver.Quit();
        }
    }
}
