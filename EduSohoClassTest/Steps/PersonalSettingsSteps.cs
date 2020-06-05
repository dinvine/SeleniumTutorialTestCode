using EduSohoClassTest.Common;
using EduSohoClassTest.Models;
using EduSohoClassTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace EduSohoClassTest.Steps
{
    [Binding]
    public class PersonalSettingsSteps : BasePageSteps
    {
        EduSohoPersonalSettingsAvatarPage avatarPage;
        EduSohoPersonalSettingsBasicInfoPage basicInfoPage;
        PersonalSettingsSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            avatarPage = new EduSohoPersonalSettingsAvatarPage(scenarioContext);
            //basicInfoPage = new EduSohoPersonalSettingsBasicInfoPage(scenarioContext);
        }

           
        
        [Given(@"click on the 头像设置")]
        public void GivenClickOnThe头像设置()
        {
            avatarPage.AvatarAddClick();
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
            avatarPage.BasicInfoClick();
            basicInfoPage = new EduSohoPersonalSettingsBasicInfoPage(context);
        }


        [When(@"I update my personal info")]
        public void WhenIUpdateMyPersonalInfo(Table table)
        {
            var tableInfo = table.CreateInstance<PersonalInfo>();
            basicInfoPage.UpdatePersonalInfo(tableInfo);
            basicInfoPage.SubmitClick();
        }

        [Then(@"I can see errors below on the page")]
        public void ThenICanSeeErrorsBelowOnThePage(Table table)
        {
            foreach(var row in table.Rows)
            {
                Assert.IsTrue(driver.PageSource.Contains(row[0]));
            }
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
