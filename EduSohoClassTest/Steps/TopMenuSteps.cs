using EduSohoClassTest.Common;
using EduSohoClassTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace EduSohoClassTest.Steps
{
    [Binding]
    public class TopMenuSteps : BasePageSteps
    {
        EduSohoTopMenuPage topMenue;
        public TopMenuSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }
        [Given(@"hover on the avatar and click ""(.*)""")]
        public void GivenHoverOnTheAvatarAndClick(string p0)
        {
            topMenue = new EduSohoTopMenuPage(context);
            topMenue.GotoPersonalManage(p0);
            context["webdriver"] = driver;
        }
    }
}
