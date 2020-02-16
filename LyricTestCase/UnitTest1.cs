using NUnit.Framework;
using SeleniumTutorialTestCode.PageOBJ;
using SeleniumTutorialTestCode;
using System;

namespace LyricTestCase
{
    [TestFixture]
    public class UnitTest1
    {
        public Browser browser;

        [SetUp]
        public void startBrowser()
        {

        }

        /// <summary>
        /// test http://lyratesting2.co.nz/
        /// login, productlist, moreclass
        /// </summary>
        [Test, Order(1)]
        public void lyratesting2Test()
        {
            browser = new Browser(BrowserType.Firefox, @"http://lyratesting2.co.nz/");
            LyraTesting2HomePage homepage = new LyraTesting2HomePage(browser.GetDriver());
            homepage.LoginLinkClick();
            LyricTesting2LoginPage loginPage = new LyricTesting2LoginPage(browser.GetDriver());
            loginPage.Login("test001", "Test1234");
            LyraTesting2ListPage listPage = new LyraTesting2ListPage(browser.GetDriver());
            listPage.productListLinkClick();
            homepage.MoreClassLinkClick();
            listPage.productListLinkClick();
        }


        /// <summary>
        /// test google search page
        /// </summary>
        [Test, Order(2)]
        public void ChromeHomePageTest()
        {
            browser = new Browser(BrowserType.Chrome, @"http://www.google.com");

            //            WDriver.Navigate().GoToUrl();
            GoogleSearch googleSearch = new GoogleSearch(browser.GetDriver());
            string title = browser.GetTitle();
            Console.WriteLine("Page title is {0}", title);

            string pageSource = browser.GetPageSource();
            Console.WriteLine("PageSource is {0}", pageSource);

            int pageSourceLen = 0;
            pageSourceLen = pageSource.Length;
            Console.WriteLine("pageSourceLen is {0}", pageSourceLen);

            //test search
            googleSearch.searchTextTest("Selenium");


            //test Navigate().Back();
            browser.GetDriver().Navigate().Back();
            Assert.That(browser.GetTitle().Equals("Google"), "test fail due to title does not equal to Google ");


            //test gmailLink
            googleSearch.gmailLinkTest();
            browser.GetDriver().Navigate().Back();


            //test signInLink
            googleSearch.signInLinkTest();

            browser.GetDriver().Navigate().Back();

            //test picLink
            googleSearch.picLinkTest();
            browser.GetDriver().Navigate().Back();

            //test Navigate().Forward()
            browser.GetDriver().Navigate().Forward();
            Assert.That(browser.GetTitle().Equals("Google Images"), "test fail due to title does not equal to Google Images");

            //test Navigate().Refresh()
            browser.GetDriver().Navigate().Refresh();
            Assert.That(browser.GetTitle().Equals("Google Images"), "test fail due to title does not equal to Google Images");



        }


        /// <summary>
        /// test http://106.15.238.71/testpage1.html
        /// test the click of linktext, ratiobutton, checkbox, fileupload, filedownload, dropdownlist, listbox
        /// </summary>
        [Test, Order(3)]
        public void PersonalInfomationTest()
        {
            browser = new Browser(BrowserType.Firefox, @"http://106.15.238.71/testpage1.html");
            //      WDriver.Navigate().GoToUrl(@"http://106.15.238.71/testpage1.html");
            PersonalInfomation testPage = new PersonalInfomation(browser.GetDriver());
            testPage.PageLinkClick();
            testPage.TextBoxInput();
            testPage.radioButtonsClick();
            testPage.TextBoxInputDate();
            testPage.CheckBoxClick();
            testPage.fileUploadBtnClick();
            testPage.fileDownloadLinkClick();
            testPage.DropDownListSelect();
            testPage.ListBoxSelect();
            testPage.SubmitClick();
        }


        [TearDown]
        public void closeBrowser()
        {
            System.Threading.Thread.Sleep(1000);
            browser.Quit();
        }
    }
}
