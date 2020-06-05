using OpenQA.Selenium;
using TechTalk.SpecFlow;
using EduSohoClassTest.Common;

namespace EduSohoClassTest.Pages
{
    public class EduSohoPersonalSettingsLeftMenu:EduSohoTopMenuPage
    {
        //IWebDriver webDriver;
        //ScenarioContext context;
        public IWebElement avatarSetLink => webDriver.FindElement(By.LinkText("头像设置"));
        public IWebElement basicInfoSetLink => webDriver.FindElement(By.LinkText("基础信息"));

        public EduSohoPersonalSettingsLeftMenu(ScenarioContext scenarioContext):base(scenarioContext)
        {
            //webDriver = (IWebDriver)scenarioContext["webdriver"];
            //context = scenarioContext;
        }
        /// <summary>
        /// click on the 头像设置
        /// </summary>
        public void AvatarAddClick()
        {
            Helps.ClickOperation(webDriver, By.LinkText("头像设置"));
            context["webdriver"] = webDriver;
        }

        /// <summary>
        /// click on the 基础信息
        /// </summary>
        public void BasicInfoClick()
        {

            Helps.ClickOperation(webDriver, By.LinkText("基础信息"));
            context["webdriver"] = webDriver;
        }
    }
}
