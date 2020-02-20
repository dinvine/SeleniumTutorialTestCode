using SeleniumTutorialTestCode.PageOBJ;
using TechTalk.SpecFlow;

namespace LyricTestCase.Steps
{
    [Binding]
    public class HomePageSteps
    {
        public LyraTesting2Pages lyraTesting2Pages;
        readonly ScenarioContext context;
        HomePageSteps(ScenarioContext scenarioContext)
        {
            context = scenarioContext;
        }

        [Given(@"I success to  enter ""(.*)"" username and ""(.*)"" password to log in")]
        public void GivenISuccessToEnterUsernameAndPasswordToLogIn(string p0 , string p1)
        {
            UserLoginSteps login = new UserLoginSteps(context);
            login.GivenIAmInHomepage();
            login.GivenIClickLoginButonAndJumpToLoginPage();
            login.WhenIEnterUsernameAndPasswordToLogin(p0, p1);
            lyraTesting2Pages = login.lyraTesting2Pages;
        }


        [When(@"I click 退出登陆")]
        public void WhenIClick退出登陆()
        {
            lyraTesting2Pages.homepage.LogOut();
        }
        
        [Then(@"I should success to logout of the web")]
        public void ThenIShouldSuccessToLogoutOfTheWeb()
        {
            lyraTesting2Pages.homepage.SuccessLogout();
        }
    }
}
