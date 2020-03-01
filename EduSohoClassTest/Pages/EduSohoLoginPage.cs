using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using EduSohoClassTest.Common;

namespace EduSohoClassTest.Pages
{
    public class EduSohoLoginPage: EduSohuBasePage
    {

        public IWebElement txtBoxUSR => webDriver.FindElement(By.Id("login_username"));

        public IWebElement txtBoxPWD => webDriver.FindElement(By.Id("login_password"));

        public IWebElement btnLogin  => webDriver.FindElement(By.ClassName("js-btn-login"));

        public IWebElement ChkBoxRememberMe => webDriver.FindElement(By.Name("_remember_me"));

        public IWebElement txtLoginErrMsg => webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/form/div[1]"));

        public IWebElement linkPWDRest => webDriver.FindElement(By.LinkText("找回密码"));

        // public IWebElement btnLogin => webDriver.FindElement(By.XPath(@"/html/body/div[1]/div[1]/div/div[2]/form/div[4]/button"));


        //    public IWebElement btnLogin => webDriver.FindElement(By.XPath(@"/html/body/div[1]/div[1]/div/div[2]/form/div[4]/button"));
        //*[@id="login-form"]/div[4]/button

        public EduSohoLoginPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }
        /// <summary>
        /// input the username
        /// </summary>
        public void usernameEnter(string username)
        {

            Helps.InputClearAndStringOperation(webDriver, By.Id("login_username"), username);
        }


        /// <summary>
        /// input the password
        /// </summary>
        public void passwordEnter(string password)
        {
            Helps.InputClearAndStringOperation(webDriver, By.Id("login_password"), password);
            txtBoxPWD.Click();
        }


        /// <summary>
        /// click "登陆"
        /// </summary>
        public void btnLoginClick()
        {
            Helps.ClickOperation(webDriver, By.ClassName("js-btn-login"));
        }

        public void Login(string username,string password)
        {
            usernameEnter(username);
            passwordEnter(password);
            btnLoginClick();
            context["webdriver"] = webDriver;
        }

        public void chkBoxRememberMeClick()
        {
            string[] strlist = { "" };
            Helps.SelectFromChkbxOperation(webDriver, By.Name("_remember_me"), strlist);
        }

        public void LoginErrMsgDisplayed(string expectStr)
        {
            Assert.AreEqual(expectStr, txtLoginErrMsg.Text, "test faled due to login error msg not displayed.");
        }

        public void PWDResetClick()
        {
            linkPWDRest.Click();
            context["webdriver"] = webDriver;
        }
    }
}
