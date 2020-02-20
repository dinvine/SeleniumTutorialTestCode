
using SeleniumTutorialTestCode.PageOBJ;
using TechTalk.SpecFlow;

namespace LyricTestCase.Steps
{
    [Binding]
    public class UserLoginSteps
    {
        public LyraTesting2Pages lyraTesting2Pages;
        readonly ScenarioContext context;

        public UserLoginSteps(ScenarioContext scenarioContext)
        {
            context = scenarioContext;
        }


        [Given(@"I am in homepage")]
        public void GivenIAmInHomepage()
        {
            lyraTesting2Pages = new LyraTesting2Pages();
            lyraTesting2Pages.GotoHomePage();
            context["webdriver"] = lyraTesting2Pages.browser.GetDriver();
        }
        
        [Given(@"I click login buton and jump to login page")]
        public void GivenIClickLoginButonAndJumpToLoginPage()
        {
            lyraTesting2Pages.homepage.LoginLinkClick();            
        }

        [When(@"I enter ""(.*)"" username and ""(.*)"" password to login")]
        public void WhenIEnterUsernameAndPasswordToLogin(string p0, string p1)
        {
            lyraTesting2Pages.loginPage.Login(p0, p1);
        }


        [Then(@"I can click the 更多课程 and jump to course page")]
        public void ThenICanClickThe更多课程AndJumpToCoursePage()
        {
            lyraTesting2Pages.homepage.MoreClassLinkClick();
        }
        
        [Then(@"I can click the 产品介绍 and view the productlist")]
        public void ThenICanClickThe产品介绍AndViewTheProductlist()
        {
            lyraTesting2Pages.listPage.productListLinkClick();
        }

        [Then(@"I can see avatar image on the right top of the home page")]
        public void ThenICanSeeAvatarImageOnTheRightTopOfTheHomePage()
        {
            lyraTesting2Pages.homepage.SuccessLogin();
        }

        [When(@"I click remember me checkbox")]
        public void WhenIClickRememberMeCheckbox()
        {
            lyraTesting2Pages.loginPage.chkBoxRememberMeClick();
        }

        [Then(@"I can see ""(.*)"" on the login page")]
        public void ThenICanSeeOnTheLoginPage(string p0)
        {
            lyraTesting2Pages.loginPage.LoginErrMsgDisplayed(p0);
        }


    }
}
