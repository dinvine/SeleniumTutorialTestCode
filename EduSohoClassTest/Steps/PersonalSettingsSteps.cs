using EduSohoClassTest.Common;
using EduSohoClassTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;

namespace EduSohoClassTest.Steps
{
    [Binding]
    public class PersonalSettingsSteps
    {
        public IWebDriver driver;
        readonly ScenarioContext context;
        EduSohoHomePage homePage;
        EduSohoPersonalSettingsPage personalSettingsPage;
        PersonalSettingsSteps(ScenarioContext scenarioContext)
        {
            context = scenarioContext;
            if (scenarioContext.ContainsKey("webdriver"))
                driver = (IWebDriver)scenarioContext["webdriver"];
            else
            {
                string baseURL = Helps.GetConfigurationValue("EduSohoHomePageURL");
                driver = new FirefoxDriver();
                driver.Navigate().GoToUrl(baseURL);
                context["webdriver"] = driver;
            }

        }

        [Given(@"hover on the avatar and click 个人设置")]
        public void GivenHoverOnTheAvatarAndClick个人设置()
        {
            homePage = new EduSohoHomePage(context);
            homePage.GotoPersonalSettings();
            personalSettingsPage = new EduSohoPersonalSettingsPage(context);
        }
        
        [Given(@"click on the 头像设置")]
        public void GivenClickOnThe头像设置()
        {
            personalSettingsPage.AvatarAddClick();
        }
        
        [When(@"click 上传新头像")]
        public void WhenClick上传新头像()
        {
            personalSettingsPage.UploadNewAvatarClick();
        }
        
        [When(@"select image file and upload it")]
        public void WhenSelectImageFileAndClickOpen()
        {
            personalSettingsPage.SelectFileForAvatar();
        }
        
        [Then(@"the avatar is updated to the new image")]
        public void ThenTheAvatarIsUpdatedToTheNewImage()
        {
            personalSettingsPage.UploadImageFinished();
        }
    }
}
