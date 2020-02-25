using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;   
using TechTalk.SpecFlow;
using AutoItX3Lib;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace EduSohoClassTest.Pages
{
    public class EduSohoPersonalSettingsAvatarPage
    {
        IWebDriver webDriver;
        ScenarioContext context;
        public IWebElement uploadNewAvatarBtn => webDriver.FindElement(By.Id("upload-picture-btn"));
        public IWebElement confirmNewAvatarBtn => webDriver.FindElement(By.Id("upload-avatar-btn"));
        
        public EduSohoPersonalSettingsAvatarPage(ScenarioContext scenarioContext)
        {
            webDriver = (IWebDriver)scenarioContext["webdriver"];
            context = scenarioContext;
        }
        /// <summary>
        /// click 上传新头像
        /// </summary>
        public void UploadNewAvatarClick()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("upload-picture-btn")));

            uploadNewAvatarBtn.Click();            

        }
        /// <summary>
        /// select image file and upload it
        /// </summary>
        public void SelectFileForAvatar()
        {
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("File Upload");
            autoIt.Send(@"d:\strawberry2.jpg");
            Thread.Sleep(1000);
            autoIt.Send("{ENTER}");
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("upload-avatar-btn")));

            Actions builder = new Actions(webDriver);
            Actions hover = builder.MoveToElement(webDriver.FindElement(By.Id("upload-avatar-btn")));
            hover.Build().Perform();

            Actions click = builder.Click();
            click.Build().Perform();

          //  webDriver.FindElement(By.Id("upload-avatar-btn")).Click();
            Thread.Sleep(5000);
            context["webdriver"] = webDriver;
        }

        public void UploadImageFinished()
        {
            Assert.IsTrue(uploadNewAvatarBtn.Displayed, "test failed due to the process of uploading image to avatar is not completed.");
        }

    }
}
