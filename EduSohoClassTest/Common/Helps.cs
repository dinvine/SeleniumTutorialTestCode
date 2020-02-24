using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSohoClassTest.Common
{
    public static class Helps
    {
        public static string GetConfigurationValue(string key)
        {
            string values = ConfigurationManager.AppSettings[key];
            return values;
        }

        public static void LabelShowMsgAsExpected(IWebDriver webDriver, By by,string expectMsg, string labelName)
        {
            string msgShown = "";
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            msgShown = webDriver.FindElement(by).Text;
            Assert.AreEqual(expectMsg, msgShown, "test failed due to Error message of " + labelName + " shown in register page");
        }
    }
}
