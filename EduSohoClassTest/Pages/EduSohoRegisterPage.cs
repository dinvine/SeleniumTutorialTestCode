﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Interactions;
using EduSohoClassTest.Common;

namespace EduSohoClassTest.Pages
{
    public class EduSohoRegisterPage:EduSohuBasePage
    {
        //public IWebElement txtEmail => webDriver.FindElement(By.Id("register_email"));
        //public IWebElement labelEmail => webDriver.FindElement(By.Id("register_email-error"));        

        //public IWebElement txtUsername => webDriver.FindElement(By.Id("register_nickname"));
        //public IWebElement labelUsername => webDriver.FindElement(By.Id("register_nickname-error"));

        //public IWebElement txtPassword => webDriver.FindElement(By.Id("register_password"));
        //public IWebElement labelPassword => webDriver.FindElement(By.Id("register_password-error"));

        //public IWebElement txtCaptchaCode => webDriver.FindElement(By.Id("captcha_code"));
        //public IWebElement labelCaptchaCode => webDriver.FindElement(By.Id("captcha_code-error"));

        //public IWebElement chkbxUserterms => webDriver.FindElement(By.Id("user_terms"));
        //public IWebElement labelUserterms => webDriver.FindElement(By.Id("userterms-error"));

        //public IWebElement btnRegister => webDriver.FindElement(By.Id("register-btn"));



        public EduSohoRegisterPage(ScenarioContext scenarioContext):base(scenarioContext)
        {

        }

        /// <summary>
        /// input the username
        /// </summary>
        public void UsernameEnter(string username)
        {
            Helps.InputClearAndStringOperation(webDriver, By.Id("register_nickname"), username);
            Helps.InputAddingStringOperation(webDriver, By.Id("register_nickname"), Keys.Enter);
        }

        /// <summary>
        /// input the username
        /// </summary>
        public void EmailEnter(string email)
        {

            Helps.InputClearAndStringOperation(webDriver, By.Id("register_email"), email);
            Helps.InputAddingStringOperation(webDriver, By.Id("register_email"), Keys.Enter);

        }

        public void PasswordEnter(string password)
        {

            Helps.InputClearAndStringOperation(webDriver, By.Id("register_password"), password);
            Helps.InputAddingStringOperation(webDriver, By.Id("register_email"), Keys.Enter);


        }

        public void CaptchaCodeEnter(string captureCode)
        {

            Helps.InputClearAndStringOperation(webDriver, By.Id("captcha_code"), captureCode);
            Helps.InputAddingStringOperation(webDriver, By.Id("captcha_code"), Keys.Enter);
        }

        public void UserTermsSelect(string status ="true")
        {
            Helps.SelectFromChkbxOperationByIndex(webDriver, By.Id("user_terms"),0, false);
            
        }
               
        /// <summary>
        /// click "注册"
        /// </summary>
        public void RegisterBtnClick()
        {
            Helps.ClickOperation(webDriver, By.Id("register-btn"));
        }

        public  void clickBlankArea()
        {
            Actions actions = new Actions(webDriver);
            actions.MoveByOffset(0, 0).Click().Build().Perform();
        }
        public void LoginErrMsgDisplayed(string expectMsg, string labelName)
        {
            By by=null;
            
            switch (labelName)
            {
                
                case "email":
                    by = By.Id("register_email-error");
                    break;
                case "username":
                    by = By.Id("register_nickname-error");
                    break;
                case "password":
                    by = By.Id("register_password-error");
                    break;
                case "captchaCode":
                    by = By.Id("captcha_code-error");
                    break;
                case "userterm":
                    by = By.Id("userterms-error");
                    break;
            }
            Helps.LabelShowMsgAsExpected(webDriver,by, expectMsg, labelName);
        }
    }
}
