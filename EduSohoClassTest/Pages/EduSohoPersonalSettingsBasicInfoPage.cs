using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using EduSohoClassTest.Common;
using EduSohoClassTest.Models;

namespace EduSohoClassTest.Pages
{
    public class EduSohoPersonalSettingsBasicInfoPage: EduSohoPersonalSettingsLeftMenu
    {

        //IWebDriver webDriver;
        //ScenarioContext context;
        ////用户名
        //public IWebElement txtUsername => webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/form/div[1]/div/div"));
        //public IWebElement linkUsernameModify => webDriver.FindElement(By.LinkText("修改"));
        ////真实姓名
        //public IWebElement txtTruename => webDriver.FindElement(By.Id("profile_truename"));
        //public IWebElement labelTruename => webDriver.FindElement(By.Id("profile_truename-error"));
        ////性别
        //IList<IWebElement> sexRadioBx => webDriver.FindElements(By.Name("profile[gender]"));

        ////身份证
        //public IWebElement txtIdcard => webDriver.FindElement(By.Id("profile_idcard"));
        //public IWebElement labelIdcard => webDriver.FindElement(By.Id("profile_idcard-error"));

        ////手机        
        //public IWebElement txtMobile => webDriver.FindElement(By.Id("profile_mobile"));
        //public IWebElement labelMobile => webDriver.FindElement(By.Id("profile_mobile-error"));

        ////公司        
        //public IWebElement txtCompany => webDriver.FindElement(By.Id("profile_company"));
        //public IWebElement labelCompany => webDriver.FindElement(By.Id("profile_company-error"));

        ////职业 profile_job
        //public IWebElement txtJob => webDriver.FindElement(By.Id("profile_job"));
        //public IWebElement labelJob => webDriver.FindElement(By.Id("profile_job-error"));

        ////头衔 profile_title
        //public IWebElement txtTitle => webDriver.FindElement(By.Id("profile_title"));
        //public IWebElement labelTitle => webDriver.FindElement(By.Id("profile_title-error"));

        ////signature
        //public IWebElement txtSignature => webDriver.FindElement(By.Id("profile_signature"));
        //public IWebElement labelSignature => webDriver.FindElement(By.Id("profile_signature-error"));

        ////自我介绍
        //public IWebElement txtIntroduction => webDriver.FindElement(By.XPath("/html/body"));



        ////个人空间 profile_site
        //public IWebElement txtSite => webDriver.FindElement(By.Id("profile_site"));
        //public IWebElement labelSite => webDriver.FindElement(By.Id("profile_site-error"));

        ////微博 weibo
        //public IWebElement txtWeibo => webDriver.FindElement(By.Id("weibo"));
        //public IWebElement labelWeibo => webDriver.FindElement(By.Id("weibo-error"));

        ////QQ profile_qq
        //public IWebElement txtQQ => webDriver.FindElement(By.Id("profile_qq"));
        //public IWebElement labelQQ => webDriver.FindElement(By.Id("profile_qq-error"));

        ////保存
        //public IWebElement btnSave => webDriver.FindElement(By.Id("profile-save-btn"));
        public IWebElement txtSuccessSave => webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/form/div[1]"));
        

        public EduSohoPersonalSettingsBasicInfoPage(ScenarioContext scenarioContext):base(scenarioContext)
        {
            //webDriver = (IWebDriver)scenarioContext["webdriver"];
            //context = scenarioContext;
        }

        /// <summary>
        /// input the 真实姓名
        /// </summary>
        public void TruenameEnter(string inputStr)
        {
            Helps.InputClearAndStringOperation(webDriver, By.Id("profile_truename"), inputStr);
            Helps.InputAddingStringOperation(webDriver, By.Id("profile_truename"), Keys.Tab);
        }

        /// <summary>
        /// input the Sex
        /// </summary>
        public void SexSelect(string inputStr="男")
        {
            //WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("profile[gender]")));

            //foreach (var element in sexRadioBx)
            //{
            //    if (element.GetAttribute("value") == inputStr)
            //        element.Click();
            //}
            Helps.SelectFromRadioOperation(webDriver, By.Name("profile[gender]"), inputStr);
        }


        /// <summary>
        ////身份证
        //public IWebElement txtIdcard => webDriver.FindElement(By.Id("profile_idcard"));
        /// </summary>
        public void IdcardEnter(string inputStr)
        {
            Helps.InputClearAndStringOperation(webDriver, By.Id("profile_idcard"), inputStr);
            Helps.InputAddingStringOperation(webDriver, By.Id("profile_idcard"), Keys.Tab);

        }

        /// <summary>
        //手机        
        //public IWebElement txtMobile => webDriver.FindElement(By.Id("profile_mobile"));
        /// </summary>
        public void MobileEnter(string inputStr)
        {

            Helps.InputClearAndStringOperation(webDriver, By.Id("profile_mobile"), inputStr);
            Helps.InputAddingStringOperation(webDriver, By.Id("profile_mobile"), Keys.Tab);

        }



        /// <summary>
        //公司        
        //public IWebElement txtCompany => webDriver.FindElement(By.Id("profile_company"));
        /// </summary>
        public void CompanyEnter(string inputStr)
        {

            Helps.InputClearAndStringOperation(webDriver, By.Id("profile_company"), inputStr);
            Helps.InputAddingStringOperation(webDriver, By.Id("profile_company"), Keys.Tab);

        }

        ///// <summary>
        ////职业 profile_job
        //public IWebElement txtJob => webDriver.FindElement(By.Id("profile_job"));
        /// </summary>
        public void JobEnter(string inputStr)
        {

            Helps.InputClearAndStringOperation(webDriver, By.Id("profile_job"), inputStr);
            Helps.InputAddingStringOperation(webDriver, By.Id("profile_job"), Keys.Tab);
        }

        /// <summary>
        //        //头衔 profile_title
        //public IWebElement txtTitle => webDriver.FindElement(By.Id("profile_title"));
        /// </summary>
        public void TitleEnter(string inputStr)
        {
            Helps.InputClearAndStringOperation(webDriver, By.Id("profile_title"), inputStr);
            Helps.InputAddingStringOperation(webDriver, By.Id("profile_title"), Keys.Tab);
        }

        /// <summary>
        //signature
        //public IWebElement txtSignature => webDriver.FindElement(By.Id("profile_signature"));
        /// </summary>
        public void SignatureEnter(string inputStr)
        {

            Helps.InputClearAndStringOperation(webDriver, By.Id("profile_signature"), inputStr);
            Helps.InputAddingStringOperation(webDriver, By.Id("profile_signature"), Keys.Tab);
        }

        /// <summary>
        //自我介绍
        //public IWebElement txtIntroduction => webDriver.FindElement(By.ClassName("cke_editable_themed"));
        /// </summary>
        public void IntroductionEnter(string inputStr)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.TagName("iframe")));
            webDriver.SwitchTo().Frame(0);            
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("cke_editable_themed")));
            //txtIntroduction.Clear();
            //txtIntroduction.SendKeys(inputStr);
            Helps.InputClearAndStringOperation(webDriver, By.ClassName("cke_editable_themed"), inputStr);
            Helps.InputAddingStringOperation(webDriver, By.ClassName("cke_editable_themed"), Keys.Tab);
            webDriver.SwitchTo().ParentFrame();
        }

        /// <summary>
        //个人空间 profile_site
        //public IWebElement txtSite => webDriver.FindElement(By.Id("profile_site"));
        /// </summary>
        public void SiteEnter(string inputStr)
        {
            Helps.InputClearAndStringOperation(webDriver, By.Id("profile_site"), inputStr);
            Helps.InputAddingStringOperation(webDriver, By.Id("profile_site"), Keys.Tab);
        }

        /// <summary>
        //微博 weibo
        //public IWebElement txtWeibo => webDriver.FindElement(By.Id("weibo"));
        /// </summary>
        public void WeiboEnter(string inputStr)
        {

            Helps.InputClearAndStringOperation(webDriver, By.Id("weibo"), inputStr);
            Helps.InputAddingStringOperation(webDriver, By.Id("weibo"), Keys.Tab);
        }

        /// <summary>
        //QQ profile_qq
        //public IWebElement txtQQ => webDriver.FindElement(By.Id("profile_qq"));
        /// </summary>
        public void QQEnter(string inputStr)
        {
            Helps.InputClearAndStringOperation(webDriver, By.Id("profile_qq"), inputStr);
            Helps.InputAddingStringOperation(webDriver, By.Id("profile_qq"), Keys.Tab);
        }
        public void UpdatePersonalInfo(PersonalInfo person)
        {

            TruenameEnter(person.Name);
            SexSelect(person.Gender);
            IdcardEnter(person.ID);
            JobEnter(person.Job);
            MobileEnter(person.Mobile);
            SiteEnter(person.MySpace);
            SignatureEnter(person.Signature);
            IntroductionEnter(person.SelfIntro);
            TitleEnter(person.Title);
            WeiboEnter(person.Weibo);
            QQEnter(person.QQ);
        }
        /// <summary>
        //保存
        //public IWebElement btnSave => webDriver.FindElement(By.Id("profile-save-btn"));
        /// </summary>
        public void SubmitClick()
        {
            Helps.SubmitOperation(webDriver, By.Id("profile-save-btn"));
        }
                          





        public void EnterOneTableRecordToPersonalBasicInfoPage(string fieldName, string inputStr)
        {

            switch (fieldName)
            {
                case "真实姓名":
                    TruenameEnter(inputStr);
                    break;
                case "性别":
                    SexSelect(inputStr);
                    break;
                case "身份证号码":
                    IdcardEnter(inputStr);
                    break;
                case "手机号码":
                    MobileEnter(inputStr);
                    break;
                case "公司":
                    CompanyEnter(inputStr);
                    break;
                case "职业":
                    JobEnter(inputStr);
                    break;
                case "头衔":
                    TitleEnter(inputStr);
                    break;
                case "个人签名":                    
                    SignatureEnter(inputStr);
                    Helps.clickBlankArea(webDriver);
                    break;
                case "自我介绍":
                    IntroductionEnter(inputStr);
                    Helps.clickBlankArea(webDriver);
                    break;
                case "个人空间":
                    SiteEnter(inputStr);
                    break;
                case "微博":
                    WeiboEnter(inputStr);
                    break;
                case "QQ":
                    QQEnter(inputStr);
                    break;
            }
           
        }


        public void ShouldDisplayMsgAt(string fieldName, string inputStr)
        {
                By by = null;
            switch (fieldName)
            {
                case "真实姓名":
                    by = By.Id("profile_truename-error");
                    break;
                case "性别":
                    by = By.Name("profile[gender]-error");
                    break;
                case "身份证号码":
                    by = By.Id("profile_idcard-error");
                    break;
                case "手机号码":
                    by = By.Id("profile_mobile-error");
                    break;
                case "公司":
                    by = By.Id("profile_company-error");
                    break;
                case "职业":
                    by = By.Id("profile_job-error");
                    break;
                case "头衔":
                    by = By.Id("profile_title-error");
                    break;
                case "个人签名":
                    by = By.Id("profile_signature-error");
                    break;
                case "自我介绍":
                    by = By.ClassName("cke_editable_themed-error");
                    break;
                case "个人空间":
                    by = By.Id("profile_site-error");
                    break;
                case "微博":
                    by = By.Id("weibo-error");
                    break;
                case "QQ":
                    by = By.Id("profile_qq-error");
                    break;
            }
            Helps.LabelShowMsgAsExpected(webDriver, by, inputStr, fieldName);
        }
        public void SuccessSaveShown(string successStr)
        {
            //Assert.AreEqual(successStr,txtSuccessSave.Text,"test failed due to success info not shown after save");
            Helps.LabelShowMsgAsExpected(webDriver, By.XPath("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/form/div[1]"), successStr,"save success!");

        }

    }
}
