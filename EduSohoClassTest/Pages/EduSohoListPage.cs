using EduSohoClassTest.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace EduSohoClassTest.Pages
{
    public class EduSohoListPage:EduSohoTopMenuPage
    {

        public EduSohoListPage(ScenarioContext scenarioContext):base(scenarioContext)
        {
        }
        /// <summary>
        /// click the “产品介绍” link
        /// </summary>
        public void productListLinkClick()
        {
            Helps.ClickOperation(webDriver, By.LinkText("产品介绍"));
        }
    }
}
