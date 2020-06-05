using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSohoClassTest.Common
{
    public enum BrowserType
    {
        Chrome,
        Firefox,
        IE
    }
    public class Browser
    {
        static IWebDriver driver;

        public Browser( string URL, BrowserType browserType = BrowserType.Firefox)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case BrowserType.Firefox:
                    FirefoxOptions options = new FirefoxOptions();
                    options.AddArguments("--headless");
                    driver = new FirefoxDriver(options);
                    break;
            }
            driver.Navigate().GoToUrl(URL);
        }

        public Browser(BrowserType browserType= BrowserType.Firefox)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case BrowserType.Firefox:
                    FirefoxOptions options = new FirefoxOptions();
                    options.AddArguments("--headless");
                    driver = new FirefoxDriver();
                    break;
            }
        }


        public string GetTitle()
        {
            return driver.Title;
        }
        public void GoToURL(string URL)
        {
            driver.Navigate().GoToUrl(URL);
        }
        public IWebDriver GetDriver()
        {
            return driver;
        }
        /// <summary>
        /// i do not know the usage of IsearchContext ?????
        /// </summary>
        /// <returns></returns>
        public ISearchContext GetDriver2()
        {
            return driver;
        }

        public string GetPageSource()
        {
            return driver.PageSource;

        }
        public void Quit()
        {
            driver.Quit();
        }

        public  void WaitForPageToLoad()
        {
            TimeSpan timeout = new TimeSpan(0, 0, 30);
            WebDriverWait wait = new WebDriverWait(driver, timeout);

            IJavaScriptExecutor javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("driver", "Driver must support javascript execution");

            wait.Until((driver) =>
            {
                try
                {
                    //Web page is fully loaded
                    string readyState = javascript.ExecuteScript(
                    "if (document.readyState) return document.readyState;").ToString();
                    return readyState.ToLower() == "complete";
                }
                catch (InvalidOperationException e)
                {
                    //Window is no longer available
                    return e.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException e)
                {
                    //Browser is no longer available
                    return e.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }
        public  void ScrollTo(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public  bool HasElement(By by)
        {
            try
            {
                driver.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return true;
        }

    }
}
