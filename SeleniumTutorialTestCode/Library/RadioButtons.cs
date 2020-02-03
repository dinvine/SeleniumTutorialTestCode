using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTutorialTestCode.Library
{
    class RadioButtons
    {
        public IWebDriver webDriver { get; }
        public ReadOnlyCollection <IWebElement> webElements { get; }
        public RadioButtons(IWebDriver driver, ReadOnlyCollection <IWebElement> radioButtons)
        {
            webDriver = driver;
            webElements = radioButtons;
        }

        public void SetButtonSelected(string value)
        {
            webElements.Single(we => we.GetAttribute("value") == value).Click();
        }

        public string GetButtonSelected()
        {
           return webElements.Single(we => we.Selected==true).GetAttribute("value");
        }
    }
}
