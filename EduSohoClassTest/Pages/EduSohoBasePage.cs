using EduSohoClassTest.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace EduSohoClassTest.Pages
{
    /// <summary>
    /// Top Menu Page
    /// </summary>
    public class EduSohuBasePage
    {
        public IWebDriver webDriver;
        public ScenarioContext context;
        public EduSohuBasePage(ScenarioContext scenarioContext)
        {
            webDriver = (IWebDriver)scenarioContext["webdriver"];
            context = scenarioContext;
        }
    }
}
