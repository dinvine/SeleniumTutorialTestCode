﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;   
using TechTalk.SpecFlow;
using AutoIt;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using EduSohoClassTest.Common;

namespace EduSohoClassTest.Pages
{
    public class EduSohoPersonalSettingsAvatarPage: EduSohoPersonalSettingsLeftMenu
    {
//        IWebDriver webDriver;
//        ScenarioContext context;
        //public IWebElement uploadNewAvatarBtn => webDriver.FindElement(By.Id("upload-picture-btn"));
        public IWebElement confirmNewAvatarBtn => webDriver.FindElement(By.Id("upload-avatar-btn"));
        
        public EduSohoPersonalSettingsAvatarPage(ScenarioContext scenarioContext):base(scenarioContext)
        {
            //webDriver = (IWebDriver)scenarioContext["webdriver"];
            //context = scenarioContext;
        }
        /// <summary>
        /// click 上传新头像
        /// </summary>
        public void UploadNewAvatarClick()
        {
            Helps.ClickOperation(webDriver, By.Id("upload-picture-btn"));
        }
        /// <summary>
        /// select image file and upload it
        /// </summary>
        public void SelectFileForAvatar()
        {
            AutoItX.WinActivate("File Upload");
            Thread.Sleep(500);
            AutoItX.Send(@"d:\strawberry2.jpg");
            Thread.Sleep(500);
            AutoItX.Send("{ENTER}");
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
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
            Assert.IsTrue(Helps.GetIWebElementBy(webDriver,By.Id("upload-picture-btn")).Displayed, "test failed due to the process of uploading image to avatar is not completed.");
        }

    }
}
