using NUnit.Framework;
using SeleniumTutorialTestCode.PageOBJ;
using SeleniumTutorialTestCode;
using System;
using OpenQA.Selenium;

namespace LyricTestCase
{
    [TestFixture]
    public class UnitTest1
    {
        [SetUp]
        public void startBrowser()
        {


        }

        /// <summary>
        /// 第三课作业
        /// test http://lyratesting2.co.nz/
        /// login, productlist, moreclass
        /// </summary>
        [Test, Order(1)]
        public void lyratesting2Test()
        {
            LyraTesting2Pages lyraTesting2Pages = new LyraTesting2Pages();
            lyraTesting2Pages.homepage.LoginLinkClick();
            lyraTesting2Pages.loginPage.Login("test001", "Test1234");
            lyraTesting2Pages.homepage.MoreClassLinkClick();
            lyraTesting2Pages.listPage.productListLinkClick();
            lyraTesting2Pages.browser.GetDriver().Quit();
        }

        /// <summary>
        /// 第二课作业
        /// test http://106.15.238.71/testpage1.html
        /// test the click of linktext, ratiobutton, checkbox, fileupload, filedownload, dropdownlist, listbox
        /// </summary>
        [Test, Order(3)]
        public void PersonalInfomationTest()
        {
            PersonalInfomation testPage = new PersonalInfomation();
            testPage.LinkClick();
            testPage.NameInput();
            testPage.SexSet();
            testPage.ExperienceSet();
            testPage.ProfessionSet(new string[2] { "Manual Tester", "Automation Tester" });
            testPage.AMToolSet(new string[2] { "QTP", "Selenium Webdriver" });
            testPage.TextBoxInputDate();
            testPage.fileUploadBtnClick();
            testPage.DropDownListSelect();
            testPage.fileDownloadLinkClick();
            testPage.fileUploadBtnClick();
            testPage.ListBoxSelect(new string[2] { "Browser Commands", "WebElement Commands" });
            testPage.SubmitClick();
            testPage.browser.GetDriver().Quit();
        }

        /// <summary>
        /// 第一课作业
        /// test google search page
        /// </summary>
        [Test, Order(2)]
        public void ChromeHomePageTest()
        {
            GoogleSearch googleSearch = new GoogleSearch();
            googleSearch.TestTilePageSourcePageSourceLen();
            googleSearch.searchTextTest("Selenium");
            googleSearch.gmailLinkTest();
            googleSearch.picLinkTest();
            googleSearch.signInLinkTest();
            googleSearch.browser.GetDriver().Quit();
        }





        [TearDown]
        public void closeBrowser()
        {
          //  System.Threading.Thread.Sleep(1000);
           // browser.Quit();
           
        }
    }
}
