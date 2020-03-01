using EduSohoClassTest.Common;
using EduSohoClassTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace EduSohoClassTest.Steps
{
    [Binding]
    public class AdminArticleManageSteps : BasePageSteps
    {
        EduSohoTopMenuPage normalTopMenu;
//        EduSohoAdminPage adminPage;
        EduSohoAdminArticlePage articlePage;
        EduSohoAdminArticleCategoryAddPage categoryAddPage;

        public AdminArticleManageSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [Given(@"I am in admin article page")]
        public void GivenIAmInAdminArticlePage()
        {

            normalTopMenu = new EduSohoTopMenuPage(context);
            normalTopMenu.GotoPersonalManage("管理后台");
            context["webdriver"] = driver;
            articlePage = new EduSohoAdminArticlePage(context);
            //click 运营
            articlePage.AdminTopClick();
            //click 资讯管理
            articlePage.ArticleManageClick();
            context["webdriver"] = driver;
            articlePage = new EduSohoAdminArticlePage(context);
        }
        
        [Given(@"I enter ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"" to the conditions")]
        public void GivenIEnterToTheConditions(string categoryName, string titleKeyword, string property, string publishStatus)
        {
            //行业资讯
            articlePage.CategoryNameSelect(categoryName);
            //关键字
            articlePage.KeywordEnter(titleKeyword);
            //属性
            articlePage.PropertySelect( property);
            //发布状态
            articlePage.PublishStatusSelect( publishStatus);
        }
        
        [Given(@"I click search button")]
        public void GivenIClickSearchButton()
        {
            articlePage.SearchBtnClick();
        }
        

        [Given(@"I delete the article category coded ""(.*)""")]
        public void GivenIDeleteTheArticleCategoryCoded(string code)
        {
            articlePage.DeleteTheCategoryByCode(code);
            
        }


        [Given(@"I delete the article  named ""(.*)"" if exists")]
        public void GivenIDeleteTheArticleNamedIfExists(string p0)
        {
            articlePage.DeleteTheArticleByName(p0);
        }

       
        [When(@"I click 添加栏目 button")]
        public void WhenIClickCategoryAddButton()
        {
            articlePage.CategoryAddBtnClick();
            categoryAddPage = new EduSohoAdminArticleCategoryAddPage(context);
        }

        /// <summary>
        /// Enter into fields in category add page
        /// "<栏目名称>"," 栏目编码>","<父栏目>","<SEO标题>","<SEO关键字>","<SEO描述>","<启用>"
        /// </summary>
        [When(@"enter ""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"" to the article category add page")]
        public void WhenEnterToTheArticleCategoryAddPage(string name, string code, string parentName, string title, string keyword, string discription, string status)
        {
            categoryAddPage.CategoryNameEnter(name);
            categoryAddPage.CategoryCodeEnter(code.Trim());
            categoryAddPage.CategoryParentEnter(parentName);
            categoryAddPage.SEOTitleEnter(title);
            categoryAddPage.SEOKeywordEnter(keyword);
            categoryAddPage.SEODriscriptionEnter(discription);
            categoryAddPage.StatusSelect(status);
        }
        
        [When(@"click 添加 on  article category add page")]
        public void WhenClick添加OnArticleCategoryAddPage()
        {
            categoryAddPage.SubmitClick();
        }
        
        [Then(@"results table should comform to the  ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"" conditions\.")]
        public void ThenResultsTableShouldComformToTheConditions_(string categoryText, string titleKeyword, string property, string publishStatus)
        {
            articlePage.ArticleTableShouldConformTheCondition("栏目", categoryText, "equal");
            articlePage.ArticleTableShouldConformTheCondition("资讯标题", titleKeyword, "contain");
            articlePage.ArticleTableShouldConformTheCondition("属性", property, "label-success");
            articlePage.ArticleTableShouldConformTheCondition("状态", publishStatus, "equal");
        }

        [When(@"I  select ""(.*)"" action  to the first  ""(.*)"" publish value record and click the right checkbox")]

        public void WhenISelectActionToTheFirstPublishValueRecord(string publishAction, string originPublishStatus)
        {
            articlePage.ModifyPublishStatusOfTheFirstRecord(publishAction, originPublishStatus);
        }


        [Then(@"the 状态 colname of the checked record should change to ""(.*)"" value")]
        public void ThenStatusColnameOfTheRecordShouldChangeToValue(string p0)
        {
            IWebElement articleTable = driver.FindElement(By.Id("article-table"));
            var rows = articleTable.FindElements(By.TagName("tr"));
            string publishStatus = "";
            Boolean findCheckedRecord = false;
            foreach (var row in rows)
            {
                var cells = row.FindElements(By.TagName("td"));
                if (cells.Count == 0)
                    continue;
                if(cells[0].FindElement(By.TagName("input")).Selected==true)
                {
                    findCheckedRecord = true;
                    publishStatus = cells[5].FindElement(By.TagName("span")).Text;
                    Assert.AreEqual(p0, publishStatus, "test failed due to 状态 colume not change as the action");
                }
            }
            Assert.IsTrue(findCheckedRecord, "test failed due to can not find the checked record in the article table");

        }

        [Then(@"new ""(.*)"" caterory code should be found in the article category page")]
        public void ThenNewShouldBeFoundInTheArticleCategoryPage(string code)
        {
//            Thread.Sleep(5000);
             IWebElement Table = Helps.GetIWebElementBy(driver, By.Id("category-table"));
            var rows = Table.FindElements(By.ClassName("tr"));
            Boolean finded = false;
            foreach (var row in rows)
            {
                var cells = row.FindElements(By.ClassName("td"));
                if (cells.Count == 0) continue;
                int cellindex = 0;
                foreach (var cell in cells)
                {

                    if (cell.GetAttribute("class").Contains("code"))
                        if (cell.Text == code)
                        {
                            finded = true;
                            break;
                        }
                    cellindex++;
                }
                if (finded == true)
                    break;
            }
            Assert.IsTrue(finded, "test failed due to new added category code does not show in category table.");
        }

        [When(@"I modify the ""(.*)"" category name to ""(.*)"" new one")]
        public void WhenIModifyTheCategoryNameToNewOne(string name, string newName)
        {
            IWebElement Table = driver.FindElement(By.Id("category-table"));
            var rows = Table.FindElements(By.ClassName("tr"));
            foreach (var row in rows)
            {
                int cellindex = 0;
                var cells = row.FindElements(By.ClassName("td"));
                foreach (var cell in cells)
                {
                    
                    if (cell.GetAttribute("class").Contains("name"))
                        if (cell.Text == name)
                        {
                            cells[cellindex + 3].FindElements(By.ClassName("btn-sm"))[0].Click();
                            Helps.InputClearAndStringOperation(driver, By.Id("category-name-field"), newName);
                            Helps.SubmitOperation(driver, By.Id("category-save-btn"));
                            return;
                        }
                    cellindex++;
                }

            }
        }

        [Then(@"""(.*)"" new category name should be found in the article category page")]
        public void ThenNewCategoryNameShouldBeFoundInTheArticleCategoryPage(string name)
        {
           // Helps.ClickOperation(driver, By.LinkText("栏目管理"));
          //  driver.Navigate().Refresh();
            IWebElement Table = Helps.GetIWebElementBy(driver, By.Id("category-table"));
            var rows = Table.FindElements(By.ClassName("tr"));
            Boolean finded = false;
            foreach (var row in rows)
            {
                var cells = row.FindElements(By.ClassName("td"));
                if (cells[0].Text.Trim() == name)
                {
                    finded = true;
                    break;
                }
            }
            Assert.IsTrue(finded, "test failed due to new edited  name does not show in category table.");
        }





    }
}
