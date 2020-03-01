using OpenQA.Selenium;
using System;   
using TechTalk.SpecFlow;
using EduSohoClassTest.Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;

namespace EduSohoClassTest.Pages
{
    public class EduSohoAdminArticlePage: EduSohoAdminTopMenue
    {
        public IWebElement resultTable;     


        public EduSohoAdminArticlePage(ScenarioContext scenarioContext):base(scenarioContext)
        {
            webDriver = (IWebDriver)scenarioContext["webdriver"];
            context = scenarioContext;
        }
        
        /// <summary>
        /// 所属栏目
        /// </summary>
        /// <param name="input"></param>
        public void CategoryNameSelect(string input)
        {
            Helps.ClickOperation(webDriver, By.ClassName("select2-choice"));
            Helps.InputClearAndStringOperation(webDriver, By.XPath("/html/body/div[7]/div/input"), input);
            Helps.InputClearAndStringOperation(webDriver, By.XPath("/html/body/div[7]/div/input"), Keys.Enter);
        }

        /// <summary>
        /// 标题关键词
        /// </summary>
        /// <param name="input"></param>
        public void KeywordEnter(string input)
        {
            Helps.InputClearAndStringOperation(webDriver, By.Name("keywords"), input);
        }

        /// <summary>
        /// 属性
        /// </summary>
        /// <param name="input"></param>
        public void PropertySelect(string input)
        {
            Helps.SelectOperation(webDriver, By.Name("property"), input);
        }

        /// <summary>
        /// 发布状态
        /// </summary>
        /// <param name="input"></param>
        public void PublishStatusSelect(string input)
        {
            Helps.SelectOperation(webDriver, By.Name("status"), input);
        }


        //| 所属栏目 | 标题关键词	| 属性	| 发布状态	|


        /// <summary>
        /// 资讯管理
        /// </summary>
        public void ArticleManageClick()
        {
            Helps.ClickOperation(webDriver, By.LinkText("资讯管理"));
        }
        /// <summary>
        /// 栏目管理
        /// </summary>
        public void ArticleCategoryManageClick()
        {
            Helps.ClickOperation(webDriver, By.LinkText("栏目管理"));
        }

        /// <summary>
        /// click 搜索按钮
        /// </summary>
        public void SearchBtnClick()
        {
            Helps.ClickOperation(webDriver, By.ClassName("btn-primary"));
        }


        public void CategoryAddBtnClick()
        {
            Helps.ClickOperation(webDriver, By.ClassName("btn-success"));
            context["webdriver"] = webDriver;
            
        }

        /// <summary>
        /// delete the article category by name
        /// </summary>
        /// <param name="categoryName"></param>
        public void DeleteTheCategoryByCode(string categoryCode)
        {
            IWebElement Table = webDriver.FindElement(By.Id("category-table"));
            var rows = Table.FindElements(By.ClassName("tr"));
            int rowIndex = 0;
            foreach (var row in rows)
            {
                var cells = row.FindElements(By.ClassName("td"));
                if (cells.Count == 0) continue;
                int cellindex = 0;
                foreach (var cell in cells)
                {
                    if (cell.GetAttribute("class").Contains("code"))
                        if (cell.Text == categoryCode)
                        {
                            cells[cellindex + 1].FindElements(By.ClassName("btn-sm"))[0].Click();
                            Helps.ClickOperation(webDriver, By.ClassName("delete-category"));
                            IAlert alert = webDriver.SwitchTo().Alert();
                            alert.Accept();
                            Thread.Sleep(3000);
                            return;
                        }
                    cellindex++;
                }
                rowIndex++;
            }
        }

        /// <summary>
        /// delete the article  by name
        /// </summary>
        /// <param name="deleteName"></param>
        public void DeleteTheArticleByName(string deleteName)
        {
            IWebElement articleTable = webDriver.FindElement(By.Id("article-table"));
            var rows = articleTable.FindElements(By.TagName("tr"));
            string articleName = "";
            foreach (var row in rows)
            {
                var cells = row.FindElements(By.TagName("td"));
                articleName = cells[1].FindElement(By.TagName("a")).Text;
                if (articleName.Trim() == deleteName.Trim())
                {
                    IWebElement chkbxArticle = cells[0].FindElement(By.TagName("input"));
                    chkbxArticle.Click();
                    Helps.ClickOperation(webDriver, By.ClassName("mlm"));
                    Helps.confirmDialog("lyratesting2.co.nz says", "", "{ENTER}");
                    return;
                }
            }
        }

        public void ArticleTableShouldConformTheCondition(string ColumName,string conditionValue,string compare)
        {

            IWebElement articleTable = webDriver.FindElement(By.Id("article-table"));
            IWebElement head = articleTable.FindElement(By.TagName("thead"));
            int columIndex = 0;
            Boolean finded = false;
            Boolean consistent = true;
            foreach(var headCell in head.FindElements(By.TagName("th")))
            {
                if (headCell.Text.Trim() == ColumName)
                {
                    finded = true;
                    break;
                }
                    
                columIndex++;
            }
            Assert.IsTrue(finded, "test failed due to ColumName:"+ ColumName + " not found in the table.");

            var rows = articleTable.FindElements(By.TagName("tr"));
            foreach (var row in rows)
            {
                var cells = row.FindElements(By.TagName("td"));
                if (cells.Count == 0)
                    continue;
                
                if (compare == "equal")
                {
                    if (cells[columIndex].Text != conditionValue)
                    {
                        consistent = false;
                        break;
                    }

                }
                if (compare == "contain")
                {
                    if (!cells[columIndex].Text.Contains(conditionValue))
                    {
                        consistent = false;
                        break;
                    }
                }
                if(compare== "label-success")
                {
                    finded = false;
                    IList<IWebElement> successLabels = cells[columIndex].FindElements(By.ClassName("label-success"));
                    foreach (var label in successLabels)
                    {
                        if (label.Text == conditionValue)
                        {
                            finded = true;
                        }
                    }
                    if(finded==false)
                    {
                        consistent = false;
                        break;
                    }
                }
                Assert.IsTrue(consistent, "test failed due to ColumName:" + ColumName + " not consistant to the conditionValue:"+ conditionValue + " in the table.");

                //if (titleKeyword != "")
                //{
                //    cellValue = cells[1].FindElement(By.TagName("a")).Text;
                //    Assert.IsTrue(cellValue.Contains(titleKeyword), "test failed due to titleKeyword not contained in the results tilename");
                //}

                //if (categoryText != "")
                //{
                //    cellValue = cells[2].FindElement(By.TagName("a")).Text;
                //    Assert.AreEqual(categoryText, cellValue, "test failed due to category in the results  doesnt conform to the condition");
                //}

                //if (property != "")
                //{
                //    Boolean propertyFinded = false;
                //    IList<IWebElement> successLabels = cells[4].FindElements(By.ClassName("label-success"));
                //    foreach (var label in successLabels)
                //    {
                //        if (label.Text == property)
                //        {
                //            propertyFinded = true;
                //        }
                //    }
                //    Assert.IsTrue(propertyFinded, "test failed due to property in the results  doesnt conform to the condition");

                //}
                //if (publishStatus != "")
                //{
                //    cellValue = cells[5].FindElement(By.TagName("span")).Text;
                //    Assert.AreEqual(publishStatus, cellValue, "test failed due to publishStatus in the results  doesnt conform to the condition");
                //}
            }
        }


        public void ModifyPublishStatusOfTheFirstRecord(string publishAction, string originPublishStatus)
        {
            IWebElement articleTable = webDriver.FindElement(By.Id("article-table"));
            var rows = articleTable.FindElements(By.TagName("tr"));
            string cellValue = "";
            foreach (var row in rows)
            {
                var cells = row.FindElements(By.TagName("td"));
                if (cells.Count == 0)
                    continue;
                //get text of publish status cell
                cellValue = cells[5].FindElement(By.TagName("span")).Text;
                if (cellValue == originPublishStatus)
                {
                    //click downArrow
                    IWebElement downArrow = cells[6].FindElement(By.ClassName("dropdown-toggle"));
                    downArrow.Click();
                    Thread.Sleep(1000);
                    //click publish action menu
                    cells[6].FindElement(By.LinkText(publishAction)).Click();
                    //click left checkbox to help locate this record in next step            
                    cells[0].FindElement(By.TagName("input")).Click();
                    Thread.Sleep(5000);
                    return;
                }
            }
        }

        /// <summary>
        /// return the counts of rows
        /// if the result is empty then return the first row[0]
        /// </summary>
        /// <returns></returns>
        public string GetResultCountOfTable()
        {
            string rowcountStr = "";
            resultTable = Helps.GetIWebElementBy(webDriver, By.Id("order-table"));
            var tbody = resultTable.FindElement(By.TagName("tbody"));
            var rows= tbody.FindElements(By.TagName("tr"));           
            var firstRowItems=rows[0].FindElements(By.TagName("td"));
            if (rows.Count == 1 && firstRowItems.Count == 1)
                return firstRowItems[0].Text;
            else
            {
                rowcountStr = rows.Count.ToString();
                if (rowcountStr == "20")
                {
                    try
                    {
                        string s = Helps.GetTextFromElement(webDriver, By.XPath("/html/body/div[2]/div/div[2]/div[2]/nav/span"));
                        int startIndex = s.IndexOf('/')+1;
                        string totalNumberStr = s.Substring(startIndex, s.Length - startIndex).Trim();
                        return totalNumberStr;

                    }
                    catch (Exception)
                    {
                        return "20";
                    }

                }
                else
                    return rowcountStr;
            }
                
        }
    }
}
