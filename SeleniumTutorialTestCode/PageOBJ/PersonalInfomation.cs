using OpenQA.Selenium;
using NUnit.Framework;
using SeleniumTutorialTestCode.Library;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.IO;
using System;
using System.Text;

namespace SeleniumTutorialTestCode.PageOBJ
{
    class PersonalInfomation
    {
        public IWebDriver webDriver;

        public IWebElement signInLink => webDriver.FindElement(By.LinkText("Partial Link Test"));
        public IWebElement testLink => webDriver.FindElement(By.LinkText("Link Test"));
        public IWebElement firstNmTextBx => webDriver.FindElement(By.Name("firstname"));
        public IWebElement lastNmTextBx => webDriver.FindElement(By.Name("lastname"));

        ReadOnlyCollection<IWebElement> sexRadioBx => webDriver.FindElements(By.Name("sex"));
        RadioButtons sexRadioButtons;


        ReadOnlyCollection<IWebElement> experienceRadioBx => webDriver.FindElements(By.Name("exp"));
        RadioButtons experienceRadioButtons;

        public IWebElement dateTxtbox => webDriver.FindElement(By.Id("datepicker"));


        ReadOnlyCollection<IWebElement> professionCHKBox => webDriver.FindElements(By.Name("profession"));
        RadioButtons professionCheckButtons;


        public IWebElement photoFileBtn => webDriver.FindElement(By.Id("photo"));

        public IWebElement hybridFrameworkLink => webDriver.FindElement(By.LinkText("Selenium Automation Hybrid Framework"));
        public IWebElement fileDownLoadLink => webDriver.FindElement(By.LinkText("Test File to Download"));

        ReadOnlyCollection<IWebElement> amtoolChxbox => webDriver.FindElements(By.Name("tool"));
        RadioButtons amtoolCheckButtons;

        public IWebElement continentsDDL => webDriver.FindElement(By.Id("continents"));





        public IWebElement seleniumcmdITL => webDriver.FindElement(By.Id("selenium_commands"));

        public IWebElement submitBtn => webDriver.FindElement(By.Id("submit"));

        public PersonalInfomation(IWebDriver driver)
        {
            webDriver = driver;

 //           sexRadioButtons = new RadioButtons(driver, sexRadioBx);
//            experienceRadioButtons = new RadioButtons(driver, experienceRadioBx);
//            professionCheckButtons = new RadioButtons(driver, professionCHKBox);
//            amtoolCheckButtons= new RadioButtons(driver, amtoolChxbox);

        }

        public void PageLinkClick()
        {
            signInLink.Click();
            webDriver.Navigate().Back();
            testLink.Click();
            webDriver.Navigate().Back();
        }

        public void TextBoxInput()
        {
            firstNmTextBx.SendKeys("Trump");
            lastNmTextBx.SendKeys("Donald");
        }

        public void radioButtonsClick()
        {
            sexRadioButtons = new RadioButtons(webDriver, sexRadioBx);
            experienceRadioButtons = new RadioButtons(webDriver, experienceRadioBx);
            sexRadioButtons.SetButtonSelected("Male");
            experienceRadioButtons.SetButtonSelected("5");

        }

        public void TextBoxInputDate()
        {
            dateTxtbox.SendKeys(@"15/01/2020"); 
        }

        public void fileUploadBtnClick()
        {
            string fileName = @"D:\UploadFileTest.txt";

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

            photoFileBtn.SendKeys(@"D:\UploadFileTest.txt");
//            photoFileBtn.Click();
        }

        public void fileDownloadLinkClick()
        {
            hybridFrameworkLink.Click();
            webDriver.Navigate().Back();
            fileDownLoadLink.Click();
//            webDriver.Navigate().Back();
        }


        public void CheckBoxClick()
        {
            professionCheckButtons = new RadioButtons(webDriver, professionCHKBox);
            amtoolCheckButtons= new RadioButtons(webDriver, amtoolChxbox);

            professionCheckButtons.SetButtonSelected("Manual Tester");
            professionCheckButtons.SetButtonSelected("Automation Tester");

            amtoolCheckButtons.SetButtonSelected("Selenium IDE");
            amtoolCheckButtons.SetButtonSelected("Selenium Webdriver");          

        }

        public void DropDownListSelect()
        {
            continentsDDL.Click();
            continentsDDL.FindElement(By.XPath("//option[. = 'Australia']")).Click();
        }

        public void ListBoxSelect()
        {
            Actions builder = new Actions(webDriver);
            builder.KeyDown(Keys.LeftControl);
            builder.Click(seleniumcmdITL.FindElement(By.XPath("//option[. = 'Switch Commands']")));
            builder.Click(seleniumcmdITL.FindElement(By.XPath("//option[. = 'Wait Commands']")));
            builder.KeyUp(Keys.LeftControl);

        }

        public void SubmitClick()
        {
            submitBtn.Submit();
        }

    }




}
