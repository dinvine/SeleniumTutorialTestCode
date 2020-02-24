using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Interactions;

namespace EduSohoClassTest.Pages
{
    public class EduSohoRegisterPage
    {

        IWebDriver webDriver;
        ScenarioContext context;
        public IWebElement txtEmail => webDriver.FindElement(By.Id("register_email"));
        public IWebElement labelEmail => webDriver.FindElement(By.Id("register_email-error"));        

        public IWebElement txtUsername => webDriver.FindElement(By.Id("register_nickname"));
        public IWebElement labelUsername => webDriver.FindElement(By.Id("register_nickname-error"));

        public IWebElement txtPassword => webDriver.FindElement(By.Id("register_password"));
        public IWebElement labelPassword => webDriver.FindElement(By.Id("register_password-error"));

        public IWebElement txtCaptchaCode => webDriver.FindElement(By.Id("captcha_code"));
        public IWebElement labelCaptchaCode => webDriver.FindElement(By.Id("captcha_code-error"));

        public IWebElement chkbxUserterms => webDriver.FindElement(By.Id("user_terms"));
        public IWebElement labelUserterms => webDriver.FindElement(By.Id("userterms-error"));

        public IWebElement btnRegister => webDriver.FindElement(By.Id("register-btn"));



        public EduSohoRegisterPage(ScenarioContext scenarioContext)
        {
            webDriver = (IWebDriver)scenarioContext["webdriver"];
            context = scenarioContext;
        }

        /// <summary>
        /// input the username
        /// </summary>
        public void UsernameEnter(string username)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("register_nickname")));
            txtUsername.SendKeys(username);
        }

        /// <summary>
        /// input the username
        /// </summary>
        public void EmailEnter(string email)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("register_email")));
            txtEmail.SendKeys(email);
        }

        public void PasswordEnter(string password)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("register_password")));
            txtPassword.SendKeys(password);
        }

        public void CaptchaCodeEnter(string captureCode)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("captcha_code")));
            txtCaptchaCode.SendKeys(captureCode);
        }

        public void UserTermsSelect(string status ="true")
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("user_terms")));
            if(status=="true")
                if (chkbxUserterms.Selected == false)
                    chkbxUserterms.Click();
            if(status == "false")
                if (chkbxUserterms.Selected == true)
                    chkbxUserterms.Click();
        }
               
        /// <summary>
        /// click "注册"
        /// </summary>
        public void RegisterBtnClick()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("register-btn")));
            btnRegister.Click();
        }

        public  void clickBlankArea()
        {
            Actions actions = new Actions(webDriver);
            actions.MoveByOffset(0, 0).Click().Build().Perform();
        }
        public void LoginErrMsgDisplayed(string expectMsg, string labelName)
        {
            
            string msgShown = "";
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            switch (labelName)
            {
                
                case "email":                    
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("register_email-error")));
                    msgShown = labelEmail.Text;
                    break;
                case "username":

                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("register_nickname-error")));
                    msgShown = labelUsername.Text;
                    break;
                case "password":

                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("register_password-error")));
                    msgShown = labelPassword.Text;
                    break;
                case "captchaCode":

                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("captcha_code-error")));
                    msgShown = labelCaptchaCode.Text;
                    break;
                case "userterm":

                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("userterms-error")));
                    msgShown = labelUserterms.Text;
                    break;
            }
            Assert.AreEqual(expectMsg, msgShown, "test failed due to Error message of " + labelName + " shown in register page");
        }
    }
}
