
using EduSohoClassTest.Common;
using EduSohoClassTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace EduSohoClassTest.Steps
{
    [Binding]
    public class UserLoginSteps
    {
        public IWebDriver driver;
        readonly ScenarioContext context;
        CommonSteps commonSteps;
        EduSohoHomePage homePage;
        EduSohoLoginPage loginPage;
        EduSohoListPage listPage;
        EduSohoPWDRestPage pwdResetPage;

        public UserLoginSteps(ScenarioContext scenarioContext)
        {
            context = scenarioContext;
            if(scenarioContext.ContainsKey("webdriver"))
                driver = (IWebDriver)scenarioContext["webdriver"];
            else
            {
                string baseURL = Helps.GetConfigurationValue("EduSohoHomePageURL");
                driver = new FirefoxDriver();
                driver.Navigate().GoToUrl(baseURL);
                context["webdriver"] = driver;
            }
            commonSteps = new CommonSteps(scenarioContext);

        }

        [Then(@"I can click the 更多课程 and jump to course page")]
        public void ThenICanClickThe更多课程AndJumpToCoursePage()
        {
            homePage.MoreClassLinkClick();
            listPage = new EduSohoListPage(context);
        }
        
        [Then(@"I can click the 产品介绍 and view the productlist")]
        public void ThenICanClickThe产品介绍AndViewTheProductlist()
        {
            listPage.productListLinkClick();
        }

        [Then(@"I can see avatar image on the right top of the home page")]
        public void ThenICanSeeAvatarImageOnTheRightTopOfTheHomePage()
        {
            homePage.SuccessLogin();
        }

        [When(@"I click remember me checkbox")]
        public void WhenIClickRememberMeCheckbox()
        {
            loginPage.chkBoxRememberMeClick();
        }
        
        [Then(@"I can see ""(.*)"" on the login page")]
        public void ThenICanSeeOnTheLoginPage(string p0)
        {
            loginPage.LoginErrMsgDisplayed(p0);
        }

        [Given(@"click 找回密码 link")]
        public void GivenClickPWDResetLinkOnLoginPage()
        {
            if (loginPage == null)
                loginPage = new EduSohoLoginPage(context);
            loginPage.PWDResetClick();
            pwdResetPage = new EduSohoPWDRestPage(context);
        }

        [When(@"enter ""(.*)""emailForPWDReset")]
        public void WhenEnterEmailForPWDReset(string p0)
        {
            pwdResetPage.EmailEnter(p0);
        }

        [When(@"click 重设密码")]
        public void WhenClickPWDResetOnPWDResetPage()
        {
            pwdResetPage.PWDRestClick();
        }

        [Then(@"there should be ""(.*)""msg shown on  ""(.*)"" fieldName in password reset page")]
        public void ThenThereShouldBeMsgShownOnFieldNameInPasswordResetPage(string expectedStr, string fieldName)
        {
            pwdResetPage.LoginErrMsgDisplayed(expectedStr, fieldName);
        }



    }
}
