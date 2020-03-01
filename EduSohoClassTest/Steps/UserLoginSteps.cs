
using EduSohoClassTest.Common;
using EduSohoClassTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace EduSohoClassTest.Steps
{
    [Binding]
    public class UserLoginSteps : BasePageSteps
    {
        EduSohoHomePage homePage;
        EduSohoLoginPage loginPage;
        EduSohoListPage listPage;
        EduSohoPWDRestPage pwdResetPage;

        public UserLoginSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            homePage = new EduSohoHomePage(context);
        }
        [Given(@"I click login buton and jump to login page")]
        public void GivenIClickLoginButonAndJumpToLoginPage()
        {
            homePage.LoginLinkClick();
            loginPage = new EduSohoLoginPage(context);
            context["webdriver"] = driver;
        }
        [Given(@"I success to  enter ""(.*)"" username and ""(.*)"" password to log in")]
        public void GivenISuccessToEnterUsernameAndPasswordToLogIn(string p0, string p1)
        {
            GivenIClickLoginButonAndJumpToLoginPage();
            WhenIEnterUsernameAndPasswordToLogin(p0, p1);            
        }

        [When(@"hover on the avatar and click 退出登陆")]
        public void WhenIClick退出登陆()
        {
            homePage.LogOut();
        }

        [Then(@"I should success to logout of the web")]
        public void ThenIShouldSuccessToLogoutOfTheWeb()
        {
            homePage.SuccessLogout();
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
