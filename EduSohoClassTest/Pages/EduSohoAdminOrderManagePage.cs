using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;   
using TechTalk.SpecFlow;
//using AutoItX3Lib;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using EduSohoClassTest.Common;

namespace EduSohoClassTest.Pages
{
    public class EduSohoAdminOrderManagePage: EduSohoAdminTopMenue
    {
        //public IWebElement 课程订单 => webDriver.FindElement(By.LinkText("课程订单"));
        //public IWebElement 班级订单 => webDriver.FindElement(By.LinkText("班级订单"));
        //public IWebElement 虚拟币订单 => webDriver.FindElement(By.LinkText("虚拟币订单"));

        //public IWebElement 起始时间 => webDriver.FindElement(By.Id("startDate"));
        //public IWebElement 结束时间 => webDriver.FindElement(By.Id("endDate"));
        //public IWebElement 订单状态 => webDriver.FindElement(By.Name("status"));
        //public IWebElement 支付方式 => webDriver.FindElement(By.Name("payment"));
        //public IWebElement 关键词type => webDriver.FindElement(By.Name("keywordType"));
        //public IWebElement 关键词 => webDriver.FindElement(By.Name("keyword"));
        //public IWebElement 搜索 => webDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/form/div[2]/button"));
        //public IWebElement 导出结果 => webDriver.FindElement(By.ClassName("btn-export-csv"));

        //public IWebElement resultTable;

        public EduSohoAdminOrderManagePage(ScenarioContext scenarioContext):base(scenarioContext)
        {
        }
        /// <summary>
        /// click on the 课程订单
        /// </summary>
        public void CourseOrderClick()
        {
            Helps.ClickOperation(webDriver, By.LinkText("课程订单"));
            context["webdriver"] = webDriver;
        }

        /// <summary>
        /// click on the 班级订单
        /// </summary>
        public void ClassRoomOrderClick()
        {
            Helps.ClickOperation(webDriver, By.LinkText("班级订单"));
            context["webdriver"] = webDriver;
        }

        /// <summary>
        /// click on the 虚拟币订单
        /// </summary>
        public void VirtualCoinOrderClick()
        {
            Helps.ClickOperation(webDriver, By.LinkText("虚拟币订单"));
            context["webdriver"] = webDriver;
        }

        public void SelectOrderType(string typeName)
        {
            Helps.ClickOperation(webDriver, By.LinkText(typeName));
        }

        /// <summary>
        /// enter in the 起始时间
        /// </summary>
        public void BeginTimeEnter(string input)
        {
            if (input == "")
                return;
            Helps.InputClearAndStringOperation(webDriver, By.Id("startDate"), input);
            Helps.InputAddingStringOperation(webDriver, By.Id("startDate"), Keys.Enter);
            Helps.InputAddingStringOperation(webDriver, By.Id("startDate"), Keys.Enter);
            Helps.InputAddingStringOperation(webDriver, By.Id("startDate"), Keys.Enter);
            //            Helps.clickBlankArea(webDriver);
        }

        /// <summary>
        /// enter in the 结束时间
        /// </summary>
        public void EndTimeEnter(string input)
        {
            if (input == "")
                return;
            Helps.InputClearAndStringOperation(webDriver, By.Id("endDate"), input);
            Helps.InputAddingStringOperation(webDriver, By.Id("endDate"), Keys.Enter);
            Helps.InputAddingStringOperation(webDriver, By.Id("endDate"), Keys.Enter);
            Helps.InputAddingStringOperation(webDriver, By.Id("endDate"), Keys.Enter);
            //            Helps.clickBlankArea(webDriver);
        }

        /// <summary>
        /// select in the 订单状态
        /// </summary>
        public void OrderStatusSelect(string input="已付款")
        {
            Helps.SelectOperation(webDriver, By.Name("status"), input);
        }

        /// <summary>
        /// select in the 支付方式
        /// </summary>
        public void PayMethodSelect(string input = "支付宝")
        {
            Helps.SelectOperation(webDriver, By.Name("payment"), input);
        }

        /// <summary>
        /// select in the 关键词type
        /// </summary>
        public void KeywordTypeSelect(string input = "课程名称")
        {
            Helps.SelectOperation(webDriver, By.Name("keywordType"), input);

        }

        /// <summary>
                 /// enter in the 关键词
                 /// </summary>
        public void KeywordEnter(string input)
        {
            if (input == "")
                return;
            Helps.InputClearAndStringOperation(webDriver, By.Name("keyword"), input);
            Helps.clickBlankArea(webDriver);
        }


        /// <summary>
        /// 搜索click
        /// </summary>
        public void SearchButtonclick()
        {
            Helps.ClickOperation(webDriver, By.XPath("/html/body/div[2]/div/div[2]/form/div[2]/button"));
        }

        /// <summary>
        /// 导出结果click
        /// </summary>
        public void ExportResultButtonclick()
        {
            Helps.ClickOperation(webDriver, By.ClassName("btn-export-csv"));
        }

        /// <summary>
        /// 查询结果数量
        /// </summary>
        /// <returns></returns>
        public int ResultCounts()
        {
            return Helps.GetIWebElementBy(webDriver, By.Id("order-table")).FindElements(By.TagName("tr")).Count;
        }

        /// <summary>
        /// return the counts of rows
        /// if the result is empty then return the first row[0]
        /// </summary>
        /// <returns></returns>
        public string GetResultCountOfTable()
        {
            string rowcountStr = "";
            var tbody = Helps.GetIWebElementBy(webDriver, By.Id("order-table")).FindElement(By.TagName("tbody"));
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
                        string s = Helps.GetTextFromElement(webDriver, By.ClassName("page-num"));
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
