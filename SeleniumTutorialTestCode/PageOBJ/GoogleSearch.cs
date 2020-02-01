
using OpenQA.Selenium;
using NUnit.Framework;
namespace SeleniumTutorialTestCode.PageOBJ
{
    class GoogleSearch
    {
        IWebDriver webDriver;

        public IWebElement textBoxSearch => webDriver.FindElement(By.Name("q"));

         public IWebElement btnSearch => webDriver.FindElement(By.XPath(@"//*[@id='tsf']/div[2]/div[1]/div[2]/div[2]/div[2]/center/input[1]"));

        public IWebElement btnSearch2 => webDriver.FindElement(By.Name("btnK"));
        public IWebElement btnGoodLuck => webDriver.FindElement(By.Name("btnI"));

        public IWebElement gmailLink => webDriver.FindElement(By.LinkText("Gmail"));

        public IWebElement picLink => webDriver.FindElement(By.LinkText("Images"));

        public IWebElement signInLink => webDriver.FindElement(By.LinkText("Sign in"));
        public GoogleSearch(ref IWebDriver driver)
        {
            webDriver = driver;
            driver.Url = @"http://www.google.com";
        }


        public void searchTextTest(string searchTxt)
        {
            textBoxSearch.Clear();
            textBoxSearch.SendKeys(searchTxt);
            System.Threading.Thread.Sleep(1000);
            btnSearch2.Click();                  
          //  System.Threading.Thread.Sleep(1000);
            Assert.That(webDriver.Title.Contains("Selenium"), "test fail due to title does not contain Selenium");

        }

        public void gmailLinkTest()
        {
            gmailLink.Click();

            Assert.That(webDriver.Title.Contains("Gmail"), "test fail due to title does not contain Gmail");

        }

        public void picLinkTest()
        {
            picLink.Click();
            Assert.That(webDriver.Title.Equals("Google Images"), "test fail due to title does not equal to Google Images");
        }

        public void signInLinkTest()
        {
            signInLink.Click();

            Assert.That(webDriver.Title.Contains("Sign in"), "test fail due to title does not contain Sign in");
        }


    }
}
