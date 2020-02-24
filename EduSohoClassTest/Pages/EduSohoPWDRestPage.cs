using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using EduSohoClassTest.Common;

namespace EduSohoClassTest.Pages
{
    public class EduSohoPWDRestPage
    {

        IWebDriver webDriver;
        ScenarioContext context;
        public IWebElement txtEmail => webDriver.FindElement(By.Id("form_email"));

        public IWebElement btnPWDRest  => webDriver.FindElement(By.ClassName("btn-primary"));


        public EduSohoPWDRestPage(ScenarioContext scenarioContext)
        {
            webDriver = (IWebDriver)scenarioContext["webdriver"];
            context = scenarioContext;
        }

        /// <summary>
        /// input the email
        /// </summary>
        public void EmailEnter(string email)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("form_email")));
            txtEmail.SendKeys(email);
        }

        public void PWDRestClick()
        {
            btnPWDRest.Click();
        }


        public void LoginErrMsgDisplayed(string expectStr, string fieldName)
        {
            By by = null;
            switch (fieldName)
            {
                case "unexisting":
                    by = By.Id("alertxx");
                    break;
                case "invalid":
                    by = By.Id("form_email-error");
                    break;             
            }
            Helps.LabelShowMsgAsExpected(webDriver, by, expectStr, fieldName);
        }
    }
}
