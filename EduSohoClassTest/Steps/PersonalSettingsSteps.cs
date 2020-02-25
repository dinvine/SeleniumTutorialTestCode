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
        EduSohoPersonalSettingsLeftMenu leftMenuPage;
        EduSohoPersonalSettingsAvatarPage avatarPage;
        EduSohoPersonalSettingsBasicInfoPage basicInfoPage;
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
            leftMenuPage = new EduSohoPersonalSettingsLeftMenu(context);
        }            
        
        [Given(@"click on the 头像设置")]
        public void GivenClickOnThe头像设置()
        {
            leftMenuPage.AvatarAddClick();
            avatarPage = new EduSohoPersonalSettingsAvatarPage(context);
        }
    
        
        [When(@"click 上传新头像")]
        public void WhenClick上传新头像()
        {
            avatarPage.UploadNewAvatarClick();
        }
        
        [When(@"select image file and upload it")]
        public void WhenSelectImageFileAndClickOpen()
        {
            avatarPage.SelectFileForAvatar();
        }
        
        [Then(@"the avatar is updated to the new image")]
        public void ThenTheAvatarIsUpdatedToTheNewImage()
        {
            avatarPage.UploadImageFinished();
        }

        [Given(@"click on the 基础信息")]
        public void GivenClickOnThe基础信息()
        {
            leftMenuPage.BasicInfoClick();
            basicInfoPage = new EduSohoPersonalSettingsBasicInfoPage(context);
        }


        [Then(@"msg should be there when inputValue is entered to fieldName as table below in personal basic info page")]
        public void ThenMsgShouldBeThereWhenInputValueIsEnteredToFieldNameAsTableBelowInPersonalBasicInfoPage(Table table)
        {
            foreach (var row in table.Rows)
            {

                basicInfoPage.EnterOneTableRecordToPersonalBasicInfoPage(row[0].Trim(), row[1].Trim());
                basicInfoPage.ShouldDisplayMsgAt(row[0].Trim(), row[2].Trim());
            }
        }

        [When(@"msg should be there when inputValue is entered to fieldName as table below in personal basic info page")]
        public void WhenMsgShouldBeThereWhenInputValueIsEnteredToFieldNameAsTableBelowInPersonalBasicInfoPage(Table table)
        {
            foreach (var row in table.Rows)
            {
                basicInfoPage.EnterOneTableRecordToPersonalBasicInfoPage(row[0].Trim(), row[1].Trim());
                basicInfoPage.ShouldDisplayMsgAt(row[0].Trim(), row[2].Trim());
            }
        }

        [When(@"click 保存 in personal basic info page")]
        public void WhenClickSaveInPersonalBasicInfoPage()
        {
            basicInfoPage.SubmitClick();
        }
        
        [Then(@"success message should show ""(.*)""")]
        public void ThenSuccessMessageShouldShow(string p0)
        {
            basicInfoPage.SuccessSaveShown(p0);
        }


    }
}
