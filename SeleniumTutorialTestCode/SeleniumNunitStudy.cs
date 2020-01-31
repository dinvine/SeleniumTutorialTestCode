
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
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
            WDriver.Url = @"http://www.google.com";
        }

        
        [Test]
        public void ChromeHomePageTest()
        {
            GoogleSearch googleSearch = new GoogleSearch(ref WDriver);
            string title = WDriver.Title;

            System.Threading.Thread.Sleep(3000);

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
            System.Threading.Thread.Sleep(2000);
            Assert.That(WDriver.Title.Equals("Google"), "test fail due to title does not equal to Google ");


            //test gmailLink
            googleSearch.gmailLinkTest();
            System.Threading.Thread.Sleep(2000);
            WDriver.Navigate().Back();
            System.Threading.Thread.Sleep(2000);


            //test signInLink
            googleSearch.signInLinkTest();
            System.Threading.Thread.Sleep(2000);

            WDriver.Navigate().Back();
            System.Threading.Thread.Sleep(2000);

            //test picLink
            googleSearch.picLinkTest();
            System.Threading.Thread.Sleep(2000);
            WDriver.Navigate().Back();
            System.Threading.Thread.Sleep(2000);

            //test Navigate().Forward()
            WDriver.Navigate().Forward();
            System.Threading.Thread.Sleep(2000);
            Assert.That(WDriver.Title.Equals("Google Images"), "test fail due to title does not equal to Google Images");

            //test Navigate().Refresh()
            WDriver.Navigate().Refresh();
            System.Threading.Thread.Sleep(2000);
            Assert.That(WDriver.Title.Equals("Google Images"), "test fail due to title does not equal to Google Images");
            


        }

        [TearDown]
        public void closeBrowser()
        {
            System.Threading.Thread.Sleep(3000);
            WDriver.Close();
        }

        static public void Main()
        {

        }
      
    }
}
