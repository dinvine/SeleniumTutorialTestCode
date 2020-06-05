//using AutoItX3Lib;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;

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

        public static IWebDriver ClickOperation(IWebDriver dr,By by, int seconds=10)
        {
            WebDriverWait wait = new WebDriverWait(dr, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            dr.FindElement(by).Click();
//            Thread.Sleep(300);
            return dr;
        }



        public static IWebDriver SubmitOperation(IWebDriver dr, By by, int seconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(dr, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            dr.FindElement(by).Submit();
            Thread.Sleep(200);
            return dr;
        }

        public static IWebDriver InputClearAndStringOperation(IWebDriver dr, By by,string input, int seconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(dr, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            dr.FindElement(by).Clear();
            dr.FindElement(by).SendKeys(input);
 //           Thread.Sleep(300);
            return dr;
        }

        public static IWebDriver InputAddingStringOperation(IWebDriver dr, By by, string input, int seconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(dr, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            dr.FindElement(by).SendKeys(input);
 //           Thread.Sleep(300);
            return dr;
        }


        public static IWebDriver SelectOperation(IWebDriver dr, By by, string selectTxt, int seconds = 10)
        {
            if(selectTxt!="")
            {
                WebDriverWait wait = new WebDriverWait(dr, TimeSpan.FromSeconds(seconds));
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));            
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
                SelectElement selectElement = new SelectElement(dr.FindElement(by));
                selectElement.SelectByText(selectTxt);
            }
//            Thread.Sleep(300);
            return dr;
        }

        public static IWebDriver SelectFromRadioOperation(IWebDriver dr, By by, string selectTxt, int seconds = 10)
        {
            if (selectTxt != "")
            {
                WebDriverWait wait = new WebDriverWait(dr, TimeSpan.FromSeconds(seconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                IList<IWebElement> elements = dr.FindElements(by);
                foreach (var element in elements)
                {
                    if (element.Text.Trim() == selectTxt)
                    {
                        element.Click();
                        break;
                    }
                }
            }
            Thread.Sleep(300);
            return dr;
        }

        public static IWebDriver SelectFromChkbxOperation(IWebDriver dr, By by, string[] selectTxtList, int seconds = 10)
        {

            IList<IWebElement> elements = GetIWebElementsBy(dr, by);
            foreach(var ele in elements)
            {
                if (selectTxtList.Contains(ele.Text) ^ ele.Selected)
                    ele.Click();
            }
//            Thread.Sleep(300);
            return dr;
        }

        public static IWebDriver SelectFromChkbxOperationByIndex(IWebDriver dr, By by, int index,Boolean status, int seconds = 10)
        {

            IList<IWebElement> elements = GetIWebElementsBy(dr, by);          
            if (status ^ elements[index].Selected)
                elements[index].Click();
//            Thread.Sleep(300);
            return dr;
        }

        public static string GetTextFromElement(IWebDriver dr, By by, int seconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(dr, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            
            return dr.FindElement(by).Text.Trim();
        }

        public static IWebElement GetIWebElementBy(IWebDriver dr, By by, int seconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(dr, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            return dr.FindElement(by);
        }

        public static IList<IWebElement> GetIWebElementsBy(IWebDriver dr, By by, int seconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(dr, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            return dr.FindElements(by);
        }

        public static void confirmDialog(string title, string path, string confirm)
        {

            //AutoItX3 autoIt = new AutoItX3();
            //autoIt.WinActivate(title);
            //autoIt.Send(path);
            //Thread.Sleep(500);
            //autoIt.Send(confirm);
            //Thread.Sleep(500);

        }

        

        public static void clickBlankArea(IWebDriver dr)
        {
            //Actions actions = new Actions(dr);
            //actions.MoveByOffset(0, 0).Click().Build().Perform();
            dr.FindElement(By.XPath("//body")).Click();
            Thread.Sleep(100);
        }

        public static String getAbsoluteXPath(IWebDriver driver,IWebElement element)
        {
            return (String)((IJavaScriptExecutor)driver).ExecuteScript(
                    "function absoluteXPath(element) {" +
                            "var comp, comps = [];" +
                            "var parent = null;" +
                            "var xpath = '';" +
                            "var getPos = function(element) {" +
                            "var position = 1, curNode;" +
                            "if (element.nodeType == Node.ATTRIBUTE_NODE) {" +
                            "return null;" +
                            "}" +
                            "for (curNode = element.previousSibling; curNode; curNode = curNode.previousSibling){ "+
                        "if (curNode.nodeName == element.nodeName) {" +
                        "++position;" +
                        "}" +
                        "}" +
                        "return position;" +
                        "};" +
                        "if (element instanceof Document) {" +
                        "return '/';" +
                        "}" +
                        "for (; element && !(element instanceof Document); element = element.nodeType ==Node.ATTRIBUTE_NODE? element.ownerElement: element.parentNode) { "+
                        "comp = comps[comps.length] = {};" +
                        "switch (element.nodeType) {" +
                        "case Node.TEXT_NODE:" +
                        "comp.name = 'text()';" +
                        "break;" +
                        "case Node.ATTRIBUTE_NODE:" +
                        "comp.name = '@' + element.nodeName;" +
                        "break;" +
                        "case Node.PROCESSING_INSTRUCTION_NODE:" +
                        "comp.name = 'processing-instruction()';" +
                        "break;" +
                        "case Node.COMMENT_NODE:" +
                        "comp.name = 'comment()';" +
                        "break;" +
                        "case Node.ELEMENT_NODE:" +
                        "comp.name = element.nodeName;" +
                        "break;" +
                        "}" +
                        "comp.position = getPos(element);" +
                        "}" +

                        "for (var i = comps.length - 1; i >= 0; i--) {" +
                        "comp = comps[i];" +
                        "xpath += '/' + comp.name.toLowerCase();" +
                        "if (comp.position !== null) {" +
                        "xpath += '[' + comp.position + ']';" +
                        "}" +
                        "}" +
                        "return xpath;" +
                    "} return absoluteXPath(arguments[0]);", element);
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
