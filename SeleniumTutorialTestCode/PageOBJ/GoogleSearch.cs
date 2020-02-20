
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
/// <summary>
/// google search page test 
/// click and check title
/// </summary>
namespace SeleniumTutorialTestCode.PageOBJ
{
    public class GoogleSearch
    {
        public Browser browser;
        IWebDriver webDriver;

        public IWebElement textBoxSearch => webDriver.FindElement(By.Name("q"));
        
        public IWebElement btnSearch2 => webDriver.FindElement(By.Name("btnK"));
        public IWebElement btnGoodLuck => webDriver.FindElement(By.Name("btnI"));

        public IWebElement gmailLink => webDriver.FindElement(By.LinkText("Gmail"));

        public IWebElement picLink => webDriver.FindElement(By.LinkText("Images"));

        public IWebElement signInLink => webDriver.FindElement(By.LinkText("Sign in"));

        public GoogleSearch(BrowserType browserType = BrowserType.Firefox, string URL = "http://www.google.com")
        {
            browser = new Browser(browserType, URL);
            webDriver = browser.GetDriver();
        }

        public void TestTilePageSourcePageSourceLen()
        {
            string title = browser.GetTitle();
            Console.WriteLine("Page title is {0}", title);

            string pageSource = browser.GetPageSource();
            Console.WriteLine("PageSource is {0}", pageSource);

            int pageSourceLen = 0;
            pageSourceLen = pageSource.Length;
            Console.WriteLine("pageSourceLen is {0}", pageSourceLen);
        }

        public void searchTextTest(string searchTxt)
        {
            textBoxSearch.Clear();
            textBoxSearch.SendKeys(searchTxt);
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("btnK")));
            btnSearch2.Click();
            Assert.That(webDriver.Title.Contains(searchTxt), "test fail due to title does not contain search items");
            browser.GetDriver().Navigate().Back();
        }

        public void gmailLinkTest()
        {
            gmailLink.Click();
            Assert.That(webDriver.Title.Contains("Gmail"), "test fail due to title does not contain Gmail");
            browser.GetDriver().Navigate().Back();
        }

        public void picLinkTest()
        {
            picLink.Click();
            Assert.That(webDriver.Title.Equals("Google Images"), "test fail due to title does not equal to Google Images");
            browser.GetDriver().Navigate().Back();
        }

        public void signInLinkTest()
        {
            signInLink.Click();
            Assert.That(webDriver.Title.Contains("Sign in"), "test fail due to title does not contain Sign in");
            browser.GetDriver().Navigate().Back();
        }
    }
}
