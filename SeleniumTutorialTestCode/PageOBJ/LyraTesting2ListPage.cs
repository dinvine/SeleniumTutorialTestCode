using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTutorialTestCode.PageOBJ
{
    public class LyraTesting2ListPage
    {
        IWebDriver webDriver;

        public IWebElement productListLink => webDriver.FindElement(By.LinkText("产品介绍"));
        public LyraTesting2ListPage(IWebDriver driver)
        {
            webDriver = driver;
        }
        /// <summary>
        /// click the “产品介绍” link
        /// </summary>
        public void productListLinkClick()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("产品介绍")));
            productListLink.Click();
        }
    }
}
