using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using EduSohoClassTest.Common;

namespace EduSohoClassTest.Pages
{
    public class EduSohoPWDRestPage: EduSohuBasePage
    {
        
        public IWebElement txtEmail => webDriver.FindElement(By.Id("form_email"));

        public IWebElement btnPWDRest  => webDriver.FindElement(By.ClassName("btn-primary"));


        public EduSohoPWDRestPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        /// <summary>
        /// input the email
        /// </summary>
        public void EmailEnter(string email)
        {
            Helps.InputClearAndStringOperation(webDriver, By.Id("form_email"), email);
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
