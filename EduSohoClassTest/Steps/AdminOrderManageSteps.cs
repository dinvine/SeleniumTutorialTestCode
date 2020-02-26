using EduSohoClassTest.Common;
using EduSohoClassTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;

namespace EduSohoClassTest.Steps
{
    [Binding]
    public class AdminOrderManageSteps
    {
        public IWebDriver driver;
        public ScenarioContext context;
        CommonSteps commonSteps;
        EduSohoAdminPage adminPage;
        EduSohoAdminOrderManagePage orderPage;
        //EduSohoHomePage homePage;
        //EduSohoPersonalSettingsLeftMenu leftMenuPage;
        //EduSohoPersonalSettingsAvatarPage avatarPage;
        //EduSohoPersonalSettingsBasicInfoPage basicInfoPage;
        AdminOrderManageSteps(ScenarioContext scenarioContext)
        {
            context = scenarioContext;
            if (scenarioContext.ContainsKey("webdriver"))
                driver = (IWebDriver)scenarioContext["webdriver"];
            else
            {
                string baseURL = Helps.GetConfigurationValue("EduSohoHomePageURL");
                driver = new FirefoxDriver();
                driver.Navigate().GoToUrl(baseURL);
                context["webdriver"] = driver;
            }
            commonSteps = new CommonSteps(context);
            
        }
        [Given(@"I am in admin  order manage page")]
        public void GivenIAmInAdminOrderManagePage()
        {
            //commonSteps.GivenIAmInHomepage();
            //commonSteps.GivenIClickLoginButonAndJumpToLoginPage();
            //commonSteps.WhenIEnterUsernameAndPasswordToLogin(p0, p1);
            //context["webdriver"] = driver;
            adminPage = new EduSohoAdminPage(context);
            adminPage.订单Click();
            context["webdriver"] = driver;
            orderPage = new EduSohoAdminOrderManagePage(context);
        }


        [When(@"I select ""(.*)""订单类型 in the left menue")]
        public void WhenISelect订单类型InTheLeftMenue(string p0)
        {
            orderPage.SelectOrderType(p0);
        }
        
        [When(@"I enter ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"" into the conditions")]
        public void WhenIEnterIntoTheConditions(string 起始时间, string 结束时间, string 订单状态, string 支付方式, string 关键词类型, string 关键词)
        {
            orderPage.起始时间Enter(起始时间);
            orderPage.结束时间Enter(结束时间);
            orderPage.订单状态Select(订单状态);
            orderPage.支付方式Select(支付方式);
            orderPage.关键词typeSelect(关键词类型);
            orderPage.关键词Enter(关键词);
        }
        
        [When(@"I click search button")]
        public void WhenIClickSearchButton()
        {
            orderPage.搜索click();
            System.Threading.Thread.Sleep(3000);
            
        }
        
        [Then(@"there should be (.*) search results")]
        public void ThenThereShouldBeSearchResults(string p0)
        {
            // string resultCountStr = "";
            //// int resultCount=orderPage.ResultCounts();
            // if (p0.Length>4)
            // {
            //     resultCountStr = orderPage.GetResultCountOfTable();
            //     Assert.AreEqual(p0,)
            // }
            // else
            string resultCountStr = "";
            resultCountStr = orderPage.GetResultCountOfTable();
            Assert.AreEqual(p0, resultCountStr, "test failed due to the count of search results does not match ");
        }
    }
}
