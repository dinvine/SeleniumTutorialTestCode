using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTutorialTestCode
{
    public enum BrowserType
    {
        Chrome,
        Firefox,
        IE
    }
    public class Browser
    {
        IWebDriver driver;

        public Browser(BrowserType browserType,string URL)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
            }
            driver.Navigate().GoToUrl(URL);
        }

        public Browser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case BrowserType.Firefox:
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
    }
}
