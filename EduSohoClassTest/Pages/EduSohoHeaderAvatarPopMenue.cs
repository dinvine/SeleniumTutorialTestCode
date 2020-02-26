using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace EduSohoClassTest.Pages
{
    public class EduSohoHeaderAvatarPopMenue
    {
        IWebDriver webDriver;
        ScenarioContext context;

        public IWebElement 头像 => webDriver.FindElement(By.ClassName("avatar-xs"));
        public IWebElement 个人设置 => webDriver.FindElement(By.LinkText("个人设置"));
        public IWebElement 个人主页 => webDriver.FindElement(By.LinkText("个人主页"));
        public IWebElement 退出登录 => webDriver.FindElement(By.LinkText("退出登录"));
        public IWebElement 账户中心 => webDriver.FindElement(By.LinkText("账户中心"));



        public EduSohoHeaderAvatarPopMenue(ScenarioContext scenarioContext)
        {
            webDriver = (IWebDriver)scenarioContext["webdriver"];
            context = scenarioContext;
        }
        public void LogOut()
        {
            HoverOnAvatar();
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("退出登录")));
            退出登录.Click();
            context["webdriver"] = webDriver;
        }

        public void HoverOnAvatar()
        {
            Actions builder = new Actions(webDriver);
            Actions hover = builder.MoveToElement(头像);
            hover.Build().Perform();
        }

        /// <summary>
        /// click pop up menue items
        /// </summary>
        public IWebDriver GotoPersonalManage(string menuName)
        {
            HoverOnAvatar();
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(menuName)));
            webDriver.FindElement(By.LinkText(menuName)).Click();
            context["webdriver"] = webDriver;
            return webDriver;
        }
    }
}
