
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using SeleniumTutorialTestCode.PageOBJ;
using System;

namespace SeleniumTutorialTestCode
{
    [TestFixture]
    class SeleniumNunitStudy
    {
        public IWebDriver WDriver;
        [SetUp]
        public void startBrowser()
        {
            WDriver = new FirefoxDriver();
            WDriver.Navigate().GoToUrl( @"http://www.google.com");
            WDriver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(10); 


        }

        
        [Test]
        public void ChromeHomePageTest()
        {
            GoogleSearch googleSearch = new GoogleSearch(WDriver);
            string title = WDriver.Title;
            
            Console.WriteLine("Page title is {0}", title);

            string pageSource = WDriver.PageSource;
            Console.WriteLine("PageSource is {0}", pageSource);

            int pageSourceLen = 0;
            pageSourceLen = pageSource.Length;
            Console.WriteLine("pageSourceLen is {0}", pageSourceLen);

            //test search
            googleSearch.searchTextTest("Selenium");


            //test Navigate().Back();
            WDriver.Navigate().Back();
            Assert.That(WDriver.Title.Equals("Google"), "test fail due to title does not equal to Google ");


            //test gmailLink
            googleSearch.gmailLinkTest();
            WDriver.Navigate().Back();


            //test signInLink
            googleSearch.signInLinkTest();

            WDriver.Navigate().Back();

            //test picLink
            googleSearch.picLinkTest();
            WDriver.Navigate().Back();

            //test Navigate().Forward()
            WDriver.Navigate().Forward();
            Assert.That(WDriver.Title.Equals("Google Images"), "test fail due to title does not equal to Google Images");

            //test Navigate().Refresh()
            WDriver.Navigate().Refresh();
            Assert.That(WDriver.Title.Equals("Google Images"), "test fail due to title does not equal to Google Images");
            


        }

        [TearDown]
        public void closeBrowser()
        {
            System.Threading.Thread.Sleep(1000);
            WDriver.Close();
        }

        static public void Main()
        {

        }
      
    }
}
