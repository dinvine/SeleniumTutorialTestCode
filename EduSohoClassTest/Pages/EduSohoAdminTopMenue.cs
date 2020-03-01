using OpenQA.Selenium;
using TechTalk.SpecFlow;
using EduSohoClassTest.Common;

namespace EduSohoClassTest.Pages
{
    public class EduSohoAdminTopMenue: EduSohuBasePage
    { 
        //public IWebElement EduSoho管理后台 => webDriver.FindElement(By.LinkText("EduSoho管理后台"));
        //public IWebElement 用户 => webDriver.FindElement(By.LinkText("用户"));
        //public IWebElement 课程 => webDriver.FindElement(By.LinkText("课程"));
        //public IWebElement 运营 => webDriver.FindElement(By.LinkText("运营"));
        //public IWebElement 订单 => webDriver.FindElement(By.LinkText("订单"));
        //public IWebElement 账务 => webDriver.FindElement(By.LinkText("账务"));
        //public IWebElement 教育云 => webDriver.FindElement(By.LinkText("教育云"));
        //public IWebElement 系统 => webDriver.FindElement(By.LinkText("系统"));
        //public IWebElement 常用 => webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/ul[2]/li[1]/a"));
        //public IWebElement 回首页 => webDriver.FindElement(By.ClassName("glyphicon-home"));
        //public IWebElement Admin => webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/ul[2]/li[3]/a"));      
        
        public EduSohoAdminTopMenue(ScenarioContext scenarioContext) : base(scenarioContext)
        { 
        }
        /// <summary>
        /// click on the 用户
        /// </summary>
        public void UserClick()
        {
            Helps.ClickOperation(webDriver, By.LinkText("用户"));
        }

        /// <summary>
        /// click on the 课程
        /// </summary>
        public void CourseClick()
        {
            Helps.ClickOperation(webDriver, By.LinkText("课程"));
        }

        /// <summary>
        /// click on the 运营
        /// </summary>
        public void AdminTopClick()
        {
            Helps.ClickOperation(webDriver, By.LinkText("运营"));
        }

        /// <summary>
        /// click on the 订单
        /// </summary>
        public void OrderTopClick()
        {
            Helps.ClickOperation(webDriver, By.LinkText("订单"));
        }

        /// <summary>
        /// click on the 账务
        /// </summary>
        public void FinanceClick()
        {
            Helps.ClickOperation(webDriver, By.LinkText("财务"));
        }

        /// <summary>
        /// click on the 教育云
        /// </summary>
        public void EduCloudClick()
        {
            Helps.ClickOperation(webDriver, By.LinkText("教育云"));
        }

        /// <summary>
        /// click on the 系统
        /// </summary>
        public void SystemClick()
        {
            Helps.ClickOperation(webDriver, By.LinkText("系统"));
        }

        /// <summary>
        /// click on the 常用
        /// </summary>
        public void CommonUseClick()
        {
            Helps.ClickOperation(webDriver, By.XPath("/html/body/div[1]/div/div[2]/ul[2]/li[1]/a"));
        }

        /// <summary>
        /// click on the 回首页
        /// </summary>
        public void 回首页Click()
        {

            Helps.ClickOperation(webDriver, By.ClassName("glyphicon-home"));
        }

        /// <summary>
        /// click on the Admin
        /// </summary>
        public void RightTopAdminClick()
        {
            Helps.ClickOperation(webDriver, By.XPath("/html/body/div[1]/div/div[2]/ul[2]/li[3]/a"));
        }

    }
}
