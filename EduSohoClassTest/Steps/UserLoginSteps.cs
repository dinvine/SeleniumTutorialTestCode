
using EduSohoClassTest.Common;
using EduSohoClassTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace EduSohoClassTest
{
    [Binding]
    public class UserLoginSteps
    {
        public IWebDriver driver;
        readonly ScenarioContext context;
        EduSohoHomePage homePage;
        EduSohoLoginPage loginPage;
        EduSohoListPage listPage;

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
            
            

        }

        [Given(@"I am in homepage")]
        public void GivenIAmInHomepage()
        {
            homePage = new EduSohoHomePage(context);
            homePage.GotoHomePage();
        }
        
        [Given(@"I click login buton and jump to login page")]
        public void GivenIClickLoginButonAndJumpToLoginPage()
        {
            homePage.LoginLinkClick();
            loginPage = new EduSohoLoginPage(context);
        }

        [When(@"I enter ""(.*)"" username and ""(.*)"" password to login")]
        public void WhenIEnterUsernameAndPasswordToLogin(string p0, string p1)
        {
            loginPage.Login(p0, p1);
            homePage = new EduSohoHomePage(context);
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


    }
}
