
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SmallBig.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        int count = 0;

        static AventStack.ExtentReports.ExtentReports extent;
        static AventStack.ExtentReports.ExtentTest feature;
        AventStack.ExtentReports.ExtentTest scenario,step;

        //Path For Extent Report
        static string reportPath = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Result"
            + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("ddMMyyyy HHmmss");

        static string logPath = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Logs"
            + Path.DirectorySeparatorChar + "Logs_" + DateTime.Now.ToString("ddMMyyyy HHmmss");

        static string ScreenShotPath = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Screenshots"
            + Path.DirectorySeparatorChar + "ss_" + DateTime.Now.ToString("ddMMyyyy HHmmss")+".png";


        [BeforeTestRun]

        public static void BeforeTestRun()
        {
            ExtentHtmlReporter htmlreport = new ExtentHtmlReporter(reportPath);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlreport);

            //Initilize logger using serilog
            LoggingLevelSwitch levelSwitch = new LoggingLevelSwitch(LogEventLevel.Debug);
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.ControlledBy(levelSwitch)
                        .WriteTo.File(logPath + @"\logs.txt",
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff}} | {Level:u3} | {Message} {NewLine}",
                        rollingInterval: RollingInterval.Day).CreateLogger();
                        
        }

        [BeforeFeature]

        public static void BeforeFeature(FeatureContext context)
        {
            feature = extent.CreateTest(context.FeatureInfo.Title);
            Log.Information("Selecting feature file {0} to run", context.FeatureInfo.Title);
        }

        [BeforeScenario]

        public void BeforeScenario(ScenarioContext context)
        {
            scenario = feature.CreateNode(context.ScenarioInfo.Title);
            Log.Information("Selecting feature file {0} to run", context.ScenarioInfo.Title);
        }

        [BeforeStep]

        public void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if(context.TestError == null)
            {
                step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if (context.TestError != null)
            {
                Log.Error("Test Step Failed | " + context.TestError.Message);
                step.Log(Status.Fail, context.StepContext.StepInfo.Text);
            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Thread.Sleep(1500);
            IWebDriver driver = BrowserFactory.GetBrowserInstance();
            Thread.Sleep(2000);
            string dateString = DateTime.Now.ToString("MM-dd-yyyy hh-mm-ss");
            Console.WriteLine(dateString);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(dateString+" Test"+(count++)+".png", ScreenshotImageFormat.Png);

            driver.Quit();
            Log.Information("The above scenario sxecuted successfully");
            Log.Information("The Driver exited normally");
            
        }
    }
}
