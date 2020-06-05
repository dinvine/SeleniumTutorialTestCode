//using SpecFlow;
using System;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using EduSohoClassTest.Common;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.IO;
//using SpecFlow.Pages;

namespace EduSohoClassTest.Hooks
{

    [Binding]
    public sealed class Hooks
    {
        IWebDriver driver;
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        public static string ProjectPath;
 //       static ScenarioContext _scenarioContext;
       // static FeatureContext _featureContext;

        public Hooks()
        {
 //           _scenarioContext = scenarioContext;
//            _featureContext = featureContext;
            string browsertype = Helps.GetConfigurationValue("BrowserType");
            switch (browsertype)
            {
                case "Firefox":
                    FirefoxOptions options = new FirefoxOptions();
                    //                    options.AddArguments("--headless");
                    driver = new FirefoxDriver(options);
                    break;
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
            }
        }
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //        DriverContext.Initialize();
            //        Page.Initialize();
            ProjectPath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            
            string path = ProjectPath + "Output\\Reports\\index.html";
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            //Create dynamic feature name
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            Console.WriteLine("BeforeFeature");
        }
        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            Console.WriteLine("BeforeScenario");
            scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            string baseURL = Helps.GetConfigurationValue("EduSohoHomePageURL");
            driver.Navigate().GoToUrl(baseURL);
            scenarioContext["webdriver"] = driver;
        }

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text);
            }
            else if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
            }
        }
        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            Console.WriteLine("AfterScenario");
            //implement logic that has to run after executing each scenario
            ScreenShot(scenarioContext);
            if(driver !=null )
                driver.Quit();
        }
        public void ScreenShot(ScenarioContext scenarioContext)
        {
            try
            {
                if (scenarioContext.TestError != null)
                {
                    Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                    string title = scenarioContext.ScenarioInfo.Title;
                    string Runname = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
                    string drive = Path.GetPathRoot(ProjectPath+"Output\\Screenshots\\");
                    if (!Directory.Exists(drive))
                    {
                        ss.SaveAsFile("C:\\Recording\\" + Runname + ".jpg", ScreenshotImageFormat.Jpeg);
                    }
                    else
                    {
                        string screenshotfilename = drive+Runname + ".jpg";
                        ss.SaveAsFile(screenshotfilename, ScreenshotImageFormat.Jpeg);
                        string urlfile = "http://storage/screenshots/" + Runname + ".jpg";
                        //Console.WriteLine(" ");
                        Console.WriteLine("" + urlfile);
                    }
                }
            }
            catch
            {
                //Console.WriteLine("catch");   
            }
            
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            //       DriverContext.Driver.Close();
            //       DriverContext.Driver.Dispose();
            //kill the browser
            //Flush report once test completes
            extent.Flush();
           // File.Move(ProjectPath + "Output\\Reports\\index.html", ProjectPath + "Output\\Reports\\TestReport" + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss") + ".html");
            //kill the browser
        }
    }
}