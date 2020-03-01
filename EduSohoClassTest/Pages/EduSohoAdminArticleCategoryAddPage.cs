using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Interactions;
using EduSohoClassTest.Common;
using System.Collections.Generic;
using System.Threading;

namespace EduSohoClassTest.Pages
{
    public class EduSohoAdminArticleCategoryAddPage: EduSohuBasePage
    {

        //保存
        public IWebElement btnSave => webDriver.FindElement(By.Id("profile-save-btn"));
        public IWebElement txtSuccessSave => webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/form/div[1]"));
        public EduSohoAdminArticleCategoryAddPage(ScenarioContext scenarioContext):base(scenarioContext)
        {
            webDriver = (IWebDriver)scenarioContext["webdriver"];
            context = scenarioContext;
        }

        //| 栏目名称	| 栏目编码		| 父栏目			| SEO标题		|SEO关键字	| SEO描述					| 启用	|

        /// <summary>
        /// input the 栏目名称
        /// </summary>
        public void CategoryNameEnter(string inputStr)
        {
            Helps.InputClearAndStringOperation(webDriver, By.Id("category-name-field"), inputStr);
        }
        /// <summary>
        /// input the 栏目编码
        /// </summary>
        public void CategoryCodeEnter(string inputStr)
        {
            Helps.InputClearAndStringOperation(webDriver, By.Id("category-code-field"), inputStr);
        }

        /// <summary>
        /// input the 父栏目
        /// </summary>
        public void CategoryParentEnter(string inputStr)
        {
            Helps.ClickOperation(webDriver, By.ClassName("select2-choice"));
            Helps.InputClearAndStringOperation(webDriver, By.ClassName("select2-input"), inputStr);
            Helps.InputClearAndStringOperation(webDriver, By.ClassName("select2-input"), Keys.Enter);
        }

        /// <summary>
        /// input the SEO标题
        /// </summary>
        public void SEOTitleEnter(string inputStr)
        {
            Helps.InputClearAndStringOperation(webDriver, By.Id("category-seoTitle-field"), inputStr);
        }

        /// <summary>
        /// input the SEO关键字
        /// </summary>
        public void SEOKeywordEnter(string inputStr)
        {
            Helps.InputClearAndStringOperation(webDriver, By.Id("category-seoKeyword-field"), inputStr);
        }

        /// <summary>
        /// input the SEO描述
        /// </summary>
        public void SEODriscriptionEnter(string inputStr)
        {
            Helps.InputClearAndStringOperation(webDriver, By.Id("category-seoDesc-field"), inputStr);
        }

        /// <summary>
        /// input the 启用
        /// </summary>
        public void StatusSelect(string inputStr)
        {
            Helps.SelectFromRadioOperation(webDriver, By.Id("category-published-field"), inputStr);
        }

        /// <summary>
        //保存
        //public IWebElement btnSave => webDriver.FindElement(By.Id("profile-save-btn"));
        /// </summary>
        public void SubmitClick()
        {
            Helps.SubmitOperation(webDriver, By.Id("category-save-btn"));
            Thread.Sleep(5000);
        }                   




        public void SuccessSaveShown(string successStr)
        {
            Assert.AreEqual(successStr,txtSuccessSave.Text,"test failed due to success info not shown after save");
        }

    }
}
