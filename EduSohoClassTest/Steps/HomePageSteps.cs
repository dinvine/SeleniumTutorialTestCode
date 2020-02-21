
using EduSohoClassTest.Common;
using EduSohoClassTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace EduSohoClassTest.Steps
{
    [Binding]
    public class HomePageSteps
    {
        public IWebDriver driver;
        readonly ScenarioContext context;
        EduSohoHomePage homePage;
//        EduSohoLoginPage loginPage;
 //       EduSohoListPage listPage;
        HomePageSteps(ScenarioContext scenarioContext)
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

        [Given(@"I success to  enter ""(.*)"" username and ""(.*)"" password to log in")]
        public void GivenISuccessToEnterUsernameAndPasswordToLogIn(string p0 , string p1)
        {
            UserLoginSteps login = new UserLoginSteps(context);
            login.GivenIAmInHomepage();
            login.GivenIClickLoginButonAndJumpToLoginPage();
            login.WhenIEnterUsernameAndPasswordToLogin(p0, p1);
            homePage = new EduSohoHomePage(context);

        }


        [When(@"I click 退出登陆")]
        public void WhenIClick退出登陆()
        {
            homePage.LogOut();
        }
        
        [Then(@"I should success to logout of the web")]
        public void ThenIShouldSuccessToLogoutOfTheWeb()
        {
            homePage.SuccessLogout();
        }
    }
}
