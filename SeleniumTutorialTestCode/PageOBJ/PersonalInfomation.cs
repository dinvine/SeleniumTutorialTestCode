using OpenQA.Selenium;
using NUnit.Framework;
using SeleniumTutorialTestCode.Library;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.IO;
using System;
using System.Text;
using System.Collections.Generic;
/// <summary>
/// http://106.15.238.71/testpage1.html
/// </summary>
namespace SeleniumTutorialTestCode.PageOBJ
{
   public class PersonalInfomation
    {
        public Browser browser;
        public IWebDriver webDriver;

        public IWebElement signInLink => webDriver.FindElement(By.LinkText("Partial Link Test"));
        public IWebElement testLink => webDriver.FindElement(By.LinkText("Link Test"));
        public IWebElement firstNmTextBx => webDriver.FindElement(By.Name("firstname"));
        public IWebElement lastNmTextBx => webDriver.FindElement(By.Name("lastname"));

        IList <IWebElement> sexRadioBx => webDriver.FindElements(By.Name("sex"));
        //RadioButtons sexRadioButtons;


        IList <IWebElement> experienceRadioBx => webDriver.FindElements(By.Name("exp"));
        //RadioButtons experienceRadioButtons;

        public IWebElement dateTxtbox => webDriver.FindElement(By.Id("datepicker"));


        IList <IWebElement> professionCHKBox => webDriver.FindElements(By.Name("profession"));
       // RadioButtons professionCheckButtons;


        public IWebElement photoFileBtn => webDriver.FindElement(By.Id("photo"));

        public IWebElement hybridFrameworkLink => webDriver.FindElement(By.LinkText("Selenium Automation Hybrid Framework"));
        public IWebElement fileDownLoadLink => webDriver.FindElement(By.LinkText("Test File to Download"));

        IList <IWebElement> amtoolChxbox => webDriver.FindElements(By.Name("tool"));
       // RadioButtons amtoolCheckButtons;

        public IWebElement continentsDDL => webDriver.FindElement(By.Id("continents"));

        public IWebElement seleniumcmdITL => webDriver.FindElement(By.Id("selenium_commands"));

        public IWebElement submitBtn => webDriver.FindElement(By.Id("submit"));

        public PersonalInfomation(BrowserType browserType = BrowserType.Firefox, string URL = "http://106.15.238.71/testpage1.html")
        {
            browser = new Browser(browserType, URL);
            webDriver = browser.GetDriver();
        }

        public void LinkClick()
        {
            signInLink.Click();
            webDriver.Navigate().Back();
            testLink.Click();
            webDriver.Navigate().Back();
        }

        public void NameInput()
        {
            firstNmTextBx.SendKeys("Trump");
            lastNmTextBx.SendKeys("Donald");
        }

        public void SexSet(string sexStr="Male")
        {
            foreach(var element in sexRadioBx)
            {
                if (element.GetAttribute("value") == sexStr)
                    element.Click();
            }
        }

        public void ExperienceSet(string expStr = "7")
        {
            foreach (var element in experienceRadioBx)
            {
                string value = element.GetAttribute("value");
                if (value == expStr)
                    element.Click();
            }
        }

        public void ProfessionSet(string[] profGroup)
        {
            //"Manual Tester"  "Automation Tester"
            foreach (var element in professionCHKBox)
                foreach( string instr in profGroup)
                    if (instr == element.GetAttribute("value").ToString())
                        element.Click();
        }

        public void AMToolSet(string[] toolGroup)
        {
            // "Selenium IDE"   "Selenium Webdriver"
            foreach (var element in amtoolChxbox)
                foreach (string instr in toolGroup)
                    if (instr == element.GetAttribute("value").ToString())
                        element.Click();
        }


        public void TextBoxInputDate()
        {
            dateTxtbox.SendKeys(@"15/01/2020"); 
        }

        public void fileUploadBtnClick()
        {
            CreateFile(@"D:\UploadFileTest.txt");
            photoFileBtn.SendKeys(@"D:\UploadFileTest.txt");
        }

        public void CreateFile(string fileName)
        {
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file     
                using (FileStream fs = File.Create(fileName))
                {
                    // Add some text to file    
                    Byte[] title = new UTF8Encoding(true).GetBytes("New Text File");
                    fs.Write(title, 0, title.Length);

                }

                // Open the stream and read it back.    
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        public void fileDownloadLinkClick()
        {
            hybridFrameworkLink.Click();
            webDriver.Navigate().Back();
            fileDownLoadLink.Click();
           // webDriver.SwitchTo().Alert();

//            webDriver.Navigate().Back();
        }

         

        public void DropDownListSelect(string selectStr="Africa")
        {
            SelectElement selectElement = new SelectElement(continentsDDL);
            selectElement.SelectByText(selectStr);
            /*
            foreach(var elem in selectElement.Options)
            {
                if (elem.Text == selectStr)
                {
                    selectElement.SelectByText(selectStr);
                    break;
                }
                    
            }
            */
        }

        public void ListBoxSelect(string[] txtGroup)
        {
            SelectElement selectElement = new SelectElement(seleniumcmdITL);
            foreach (string str in txtGroup)
                selectElement.SelectByText(str);

        }

        public void SubmitClick()
        {
            submitBtn.Submit();
        }

    }




}
