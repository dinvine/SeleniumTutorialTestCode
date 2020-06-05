using EduSohoClassTest.Common;
using EduSohoClassTest.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace EduSohoClassTest.Steps
{
    [Binding]
    public class AdminOrderManageSteps : BasePageSteps
    {
        EduSohoAdminPage adminPage;
        EduSohoAdminOrderManagePage orderPage;
        AdminOrderManageSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }
        [Given(@"I click 订单 in admin  order manage page")]
        public void GivenIAmInAdminOrderManagePage()
        {
            adminPage = new EduSohoAdminPage(context);
            adminPage.OrderTopClick();
            context["webdriver"] = driver;
            orderPage = new EduSohoAdminOrderManagePage(context);
        }


        [When(@"I select ""(.*)""订单类型 in the left menue")]
        public void WhenISelectOrderTypeInTheLeftMenue(string p0)
        {
            orderPage.SelectOrderType(p0);
        }
        
        [When(@"I enter ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"" into the conditions")]
        public void WhenIEnterIntoTheConditions(string beginTime, string endTime, string orderStatus, string payMethod, string keywordType, string keyword)
        {
            orderPage.BeginTimeEnter(beginTime);
            orderPage.EndTimeEnter(endTime);
            orderPage.OrderStatusSelect(orderStatus);
            orderPage.PayMethodSelect(payMethod);
            orderPage.KeywordTypeSelect(keywordType);
            orderPage.KeywordEnter(keyword);
        }
        
        [When(@"I click search button")]
        public void WhenIClickSearchButton()
        {
            orderPage.SearchButtonclick();
            System.Threading.Thread.Sleep(3000);
            
        }
        
        [Then(@"there should be (.*) search results")]
        public void ThenThereShouldBeSearchResults(string p0)
        {
            // string resultCountStr = "";
            //// int resultCount=orderPage.ResultCounts();
            // if (p0.Length>4)
            // {
            //     resultCountStr = orderPage.GetResultCountOfTable();
            //     Assert.AreEqual(p0,)
            // }
            // else
            string resultCountStr = "";
            resultCountStr = orderPage.GetResultCountOfTable();
            Assert.AreEqual(p0, resultCountStr, "test failed due to the count of search results does not match ");
        }
    }
}
