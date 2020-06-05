using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;

namespace SeleniumTutorialTestCode.PageOBJ
{
    public class LyricTesting2LoginPage
    {

        IWebDriver webDriver;

        public IWebElement TxtBoxUSR => webDriver.FindElement(By.Id("login_username"));

        public IWebElement TxtBoxPWD => webDriver.FindElement(By.Id("login_password"));

        public IWebElement BtnLogin  => webDriver.FindElement(By.ClassName("js-btn-login"));

        public IWebElement ChkBoxRememberMe => webDriver.FindElement(By.Name("_remember_me"));

        public IWebElement TxtLoginErrMsg => webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/form/div[1]"));

        // public IWebElement btnLogin => webDriver.FindElement(By.XPath(@"/html/body/div[1]/div[1]/div/div[2]/form/div[4]/button"));


        //    public IWebElement btnLogin => webDriver.FindElement(By.XPath(@"/html/body/div[1]/div[1]/div/div[2]/form/div[4]/button"));
        //*[@id="login-form"]/div[4]/button

        public LyricTesting2LoginPage(IWebDriver driver)
        {
            webDriver = driver;
        }
        /// <summary>
        /// input the username
        /// </summary>
        public void usernameEnter(string username)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("login_username")));
            TxtBoxUSR.SendKeys(username);
        }


        /// <summary>
        /// input the password
        /// </summary>
        public void passwordEnter(string password)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("login_password")));
            TxtBoxPWD.SendKeys(password);
            TxtBoxPWD.Click();
        }


        /// <summary>
        /// click "登陆"
        /// </summary>
        public void btnLoginClick()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("js-btn-login")));
            BtnLogin.Click();
        }

        public void Login(string username,string password)
        {
            usernameEnter(username);
            passwordEnter(password);
            btnLoginClick();

        }

        public void chkBoxRememberMeClick()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("_remember_me")));

            if (ChkBoxRememberMe.Selected == false)
                ChkBoxRememberMe.Click();
        }

        public void LoginErrMsgDisplayed(string expectStr)
        {
            Assert.AreEqual(expectStr, TxtLoginErrMsg.Text, "test faled due to login error msg not displayed.");
        }
    }
}
