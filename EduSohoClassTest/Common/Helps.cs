using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
namespace EduSohoClassTest.Common
{
    public enum SexType
    {
        Male,
        Female
    }



    public static class Helps
    {
        public static string GetConfigurationValue(string key)
        {
            string values = ConfigurationManager.AppSettings[key];
            return values;
        }

        public static void LabelShowMsgAsExpected(IWebDriver webDriver, By by,string expectMsg, string labelName)
        {
            if (expectMsg == "")
                return;
            string msgShown = "";
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            msgShown = webDriver.FindElement(by).Text;
            Assert.AreEqual(expectMsg, msgShown, "test failed due to Error message of " + labelName + " shown in register page");
        }

        public static void LabelShowMsgAsExpected(IWebElement webElement, string expectMsg, string labelName)
        {
            string msgShown = "";
            msgShown = webElement.Text;
            Assert.AreEqual(expectMsg, msgShown, "test failed due to Error message of " + labelName + " shown in register page");
        }
    }

    public class DatacollectionSimpleTBL
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
    }

    public class DatacollectionComplexTBL : DatacollectionSimpleTBL
    {
        public List<IWebElement> colSpecialValues { get; set; }
    }
    class HTMLSimpleTableHelper
    {

        public static List<DatacollectionSimpleTBL> _SimpleTBLcollections = new List<DatacollectionSimpleTBL>();
        //     public static List<DatacollectionComplexTBL> _ComplexTBLcollections = new List<DatacollectionComplexTBL>();
        public static void ReadSimpleTable(IWebElement table)
        {
            //Get all the columns from the table
            var columns = table.FindElements(By.TagName("th"));
            //Get all the rows
            var rows = table.FindElements(By.TagName("tr"));
            //Create row index
            int rowIndex = 0;
            foreach (var row in rows)
            {
                int colIndex = 0;
                var colDatas = row.FindElements(By.TagName("td"));
                foreach (var colValue in colDatas)
                {
                    _SimpleTBLcollections.Add(new DatacollectionSimpleTBL
                    {

                        rowNumber = rowIndex,
                        colName = columns[colIndex].Text != "" ?
                                     columns[colIndex].Text : colIndex.ToString(),
                        colValue = colValue.Text,
                    });
                    //Move to next column
                    colIndex++;
                }
                rowIndex++;
            }
        }






        public static string ReadCell(string columnName, int rowNumber)
        {
            var data = (from e in _SimpleTBLcollections
                        where e.colName == columnName && e.rowNumber == rowNumber
                        select e.colValue).SingleOrDefault();

            return data;
        }


    }

    class HTMLComplexTableHelper
    {

        //public static List<DatacollectionSimpleTBL> _SimpleTBLcollections = new List<DatacollectionSimpleTBL>();
        public static List<DatacollectionComplexTBL> _ComplexTBLcollections = new List<DatacollectionComplexTBL>();

        public static void ReadComplexTable(IWebElement table)
        {
            //Get all the columns from the table
            var columns = table.FindElements(By.TagName("th"));

            //Get all the rows
            var rows = table.FindElements(By.TagName("tr"));

            //Create row index
            int rowIndex = 0;

            foreach (var row in rows)
            {
                int colIndex = 0;

                var colDatas = row.FindElements(By.TagName("td"));

                foreach (var colValue in colDatas)
                {
                    _ComplexTBLcollections.Add(new DatacollectionComplexTBL
                    {
                        rowNumber = rowIndex,
                        colName = columns[colIndex].Text != "" ?
                                     columns[colIndex].Text : colIndex.ToString(),
                        colValue = colValue.Text,
                        colSpecialValues = colValue.Text != "" ? null :
                                              new List<IWebElement>((colValue.FindElements(By.TagName("input"))))
                    });
                    //Move to next column
                    colIndex++;
                }
                rowIndex++;
            }
        }
        public static void PerformActionOnCell(string columnIndex, string refColumnName, string refColumnValue,
                string controlToOperate = null)
        {
            foreach (int rowNumber in GetDynamicRowNumber(refColumnName, refColumnValue))
            {
                var cell = (from e in _ComplexTBLcollections
                            where e.colName == columnIndex && e.rowNumber == rowNumber
                            select e.colSpecialValues).SingleOrDefault();


                //Need to operate on those controls
                if (controlToOperate != null && cell != null)
                {
                    var returnedControl = (from c in cell
                                           where c.GetAttribute("value") == controlToOperate
                                           select c).SingleOrDefault();
                    //ToDo: Currenly only click is supported, future is not taken care here
                    returnedControl?.Click();
                }
                else
                {
                    cell?.First().Click();
                }
            }
        }

        private static IEnumerable<int> GetDynamicRowNumber(string columnName, string columnValue)
        {

            //dynamic row
            foreach (var table in _ComplexTBLcollections)
            {
                if (table.colName == columnName && table.colValue == columnValue)
                    yield return table.rowNumber;
            }

        }
        public static string ReadCell(string columnName, int rowNumber)
        {
            var data = (from e in _ComplexTBLcollections
                        where e.colName == columnName && e.rowNumber == rowNumber
                        select e.colValue).SingleOrDefault();

            return data;
        }



    }
}
