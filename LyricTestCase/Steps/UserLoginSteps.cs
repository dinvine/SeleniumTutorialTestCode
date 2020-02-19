using NUnit.Framework;
using SeleniumTutorialTestCode;
using SeleniumTutorialTestCode.PageOBJ;
using TechTalk.SpecFlow;

namespace LyricTestCase.Steps
{
    [Binding]
    public class UserLoginSteps
    {
        //public Browser browser;
        public LyraTesting2Pages lyraTesting2Pages;

        //public UserLoginSteps(Browser br)
        //{
        //    lyraTesting2Pages = new LyraTesting2Pages(br);
        //}
        //public UserLoginSteps()
        //{
        //    lyraTesting2Pages = new LyraTesting2Pages();
        //}        
        [Given(@"I am in homepage")]
        public void GivenIAmInHomepage()
        {
            lyraTesting2Pages = new LyraTesting2Pages();
            lyraTesting2Pages.GotoHomePage();
        }
        
        [Given(@"I click login buton and jump to login page")]
        public void GivenIClickLoginButonAndJumpToLoginPage()
        {
            lyraTesting2Pages.homepage.LoginLinkClick();
        }

        [When(@"I enter ""(.*)"" username and ""(.*)"" password to login and jump to home page")]
        public void WhenIEnterUsernameAndPasswordToLoginAndJumpToHomePage(string p0, string p1)
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
    }
}
