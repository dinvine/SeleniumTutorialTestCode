using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;   
using TechTalk.SpecFlow;
using AutoItX3Lib;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace EduSohoClassTest.Pages
{
    public class EduSohoAdminOrderManagePage: EduSohoAdminTopMenue
    {
        IWebDriver webDriver;
        ScenarioContext context;
       
        public IWebElement 课程订单 => webDriver.FindElement(By.LinkText("课程订单"));
        public IWebElement 班级订单 => webDriver.FindElement(By.LinkText("班级订单"));
        public IWebElement 虚拟币订单 => webDriver.FindElement(By.LinkText("虚拟币订单"));

        public IWebElement 起始时间 => webDriver.FindElement(By.Id("startDate"));
        public IWebElement 结束时间 => webDriver.FindElement(By.Id("endDate"));
        public IWebElement 订单状态 => webDriver.FindElement(By.Name("status"));
        public IWebElement 支付方式 => webDriver.FindElement(By.Name("payment"));
        public IWebElement 关键词type => webDriver.FindElement(By.Name("keywordType"));
        public IWebElement 关键词 => webDriver.FindElement(By.Name("keyword"));
        public IWebElement 搜索 => webDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/form/div[2]/button"));
        public IWebElement 导出结果 => webDriver.FindElement(By.ClassName("btn-export-csv"));

        public IWebElement 查询结果table => webDriver.FindElement(By.Id("order-table"));
        


        public EduSohoAdminOrderManagePage(ScenarioContext scenarioContext):base(scenarioContext)
        {
            webDriver = (IWebDriver)scenarioContext["webdriver"];
            context = scenarioContext;
        }
        /// <summary>
        /// click on the 课程订单
        /// </summary>
        public void 课程订单Click()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("课程订单")));
            课程订单.Click();
            context["webdriver"] = webDriver;
        }

        /// <summary>
        /// click on the 班级订单
        /// </summary>
        public void 班级订单Click()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("班级订单")));
            班级订单.Click();
            context["webdriver"] = webDriver;
        }

        /// <summary>
        /// click on the 虚拟币订单
        /// </summary>
        public void 虚拟币订单Click()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("虚拟币订单")));
            虚拟币订单.Click();
            context["webdriver"] = webDriver;
        }

        public void SelectOrderType(string typeName)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(typeName)));
            webDriver.FindElement(By.LinkText(typeName)).Click();
        }

        /// <summary>
        /// enter in the 起始时间
        /// </summary>
        public void 起始时间Enter(string input)
        {
            if (input == "")
                return;
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("startDate")));
            起始时间.Clear();
            起始时间.SendKeys(input);
            起始时间.Click();
        }

        /// <summary>
        /// enter in the 结束时间
        /// </summary>
        public void 结束时间Enter(string input)
        {
            if (input == "")
                return;
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("endDate")));
            结束时间.Clear();
            结束时间.SendKeys(input);
            结束时间.Click();
        }

        /// <summary>
        /// select in the 订单状态
        /// </summary>
        public void 订单状态Select(string input="已付款")
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("status")));
            
            
            SelectElement selectElement = new SelectElement(订单状态);
            selectElement.SelectByText(input);
        }

        /// <summary>
        /// select in the 支付方式
        /// </summary>
        public void 支付方式Select(string input = "支付宝")
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("payment")));
            SelectElement selectElement = new SelectElement(支付方式);
            selectElement.SelectByText(input);
        }

        /// <summary>
        /// select in the 关键词type
        /// </summary>
        public void 关键词typeSelect(string input = "课程名称")
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("keywordType")));
            SelectElement selectElement = new SelectElement(关键词type);
            selectElement.SelectByText(input);
        }

        /// <summary>
                 /// enter in the 关键词
                 /// </summary>
        public void 关键词Enter(string input)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("keyword")));
            关键词.Clear();
            关键词.SendKeys(input);
            关键词.SendKeys(Keys.Enter);
        }


        /// <summary>
        /// 搜索click
        /// </summary>
        public void 搜索click()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/div[2]/form/div[2]/button")));
            搜索.Click();
        }

        /// <summary>
        /// 导出结果click
        /// </summary>
        public void 导出结果click()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("btn-export-csv")));
            导出结果.Click();
        }

        /// <summary>
        /// 查询结果数量
        /// </summary>
        /// <returns></returns>
        public int ResultCounts()
        {

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("order-table")));
            

            //var columns = 查询结果table.FindElements(By.TagName("th"));
            ////Get all the rows
            //var rows = 查询结果table.FindElements(By.TagName("tr"));
            ////Create row index
            //int rowIndex = 0;
            //foreach (var row in rows)
            //{
            //    int colIndex = 0;
            //    var colDatas = row.FindElements(By.TagName("td"));
            //    foreach (var colValue in colDatas)
            //    {
            //        //_SimpleTBLcollections.Add(new DatacollectionSimpleTBL
            //        //{

            //        //    rowNumber = rowIndex,
            //        //    colName = columns[colIndex].Text != "" ?
            //        //                 columns[colIndex].Text : colIndex.ToString(),
            //        //    colValue = colValue.Text,
            //        //});
            //        //Move to next column
            //        colIndex++;
            //    }
            //    rowIndex++;
            //}

            return 查询结果table.FindElements(By.TagName("tr")).Count;
        }

        /// <summary>
        /// return the counts of rows
        /// if the result is empty then return the first row[0]
        /// </summary>
        /// <returns></returns>
        public string GetResultCountOfTable()
        {
            string rowcountStr = "";
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("order-table")));
            var tbody = 查询结果table.FindElement(By.TagName("tbody"));
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
                        wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/div[2]/form/div[2]/button")));
                        string s = webDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/nav/span")).Text;
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
