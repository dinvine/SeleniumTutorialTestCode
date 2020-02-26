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
    public class CommonSteps
    {

        public IWebDriver driver;
        public ScenarioContext context;
        EduSohoHeaderAvatarPopMenue AvatarPopMenue;
        EduSohoHomePage homePage;
        EduSohoLoginPage loginPage;
        //EduSohoPersonalSettingsLeftMenu leftMenuPage;
        //EduSohoPersonalSettingsAvatarPage avatarPage;
        //EduSohoPersonalSettingsBasicInfoPage basicInfoPage;

        public CommonSteps(ScenarioContext scenarioContext)//:base(scenarioContext)
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
        }

        [Given(@"I am in homepage")]
        public void GivenIAmInHomepage()
        {
            homePage = new EduSohoHomePage(context);
            homePage.GotoHomePage();
            context["webdriver"] = driver;
        }

        [Given(@"I click login buton and jump to login page")]
        public void GivenIClickLoginButonAndJumpToLoginPage()
        {
            homePage.LoginLinkClick();
            loginPage = new EduSohoLoginPage(context);
            context["webdriver"] = driver;
        }

        [When(@"I enter ""(.*)"" username and ""(.*)"" password to login")]
        public void WhenIEnterUsernameAndPasswordToLogin(string p0, string p1)
        {
            loginPage.Login(p0, p1);
            homePage = new EduSohoHomePage(context);
        }

        [Given(@"hover on the avatar and click ""(.*)""")]
        public void GivenHoverOnTheAvatarAndClick(string p0)
        {
            AvatarPopMenue = new EduSohoHeaderAvatarPopMenue(context);
            AvatarPopMenue.GotoPersonalManage(p0);
            context["webdriver"] = driver;
            //switch (p0)
            //{
            //    case "个人设置":
            //        leftMenuPage = new EduSohoPersonalSettingsLeftMenu(context);
            //        break;
            //}
        }
        [Given(@"I click linktext ""(.*)""")]
        public void GivenIClickLinktext(string p0)
        {
            Helps.LinkTextClick(driver, p0);
            context["webdriver"] = driver;
        }

    }
}
