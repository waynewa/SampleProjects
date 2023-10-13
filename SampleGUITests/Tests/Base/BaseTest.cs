using static SeleniumBase.Framework.Core.Helpers.LogHelper;
using static SeleniumBase.Framework.Core.Helpers.ExtentReportHelper;
using SeleniumBase.Framework.Core.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using SeleniumBase.Framework.Core.Helpers;

namespace SampleTests.Tests.Base
{
    [TestClass]
    public abstract class BaseTest
    {
        protected static TestContextLoader TestContextLoader;
        public TestContext TestContext { get; set; }
        public static string TestUrl { get; set; }
        public static string BrowserType { get; set; }
        public static bool ChromeHeadlessMode { get; set; }
        private static AventStack.ExtentReports.ExtentReports extent { get; set; }
        public static ExtentTest extentTest { get; set; }



        [AssemblyInitialize]
        public static void BeforeAll(TestContext testContext)
        {
            TestContextLoader = new TestContextLoader(testContext);
            TestUrl = TestContextLoader.GetProperty("TestUrl", "https://wwit.netlify.app");
            BrowserType = TestContextLoader.GetProperty("BrowserType", "Chrome");
            ChromeHeadlessMode = TestContextLoader.GetProperty("ChromeHeadlessMode", false);
            CreateTestResultsDirectory();
            extent = StartReport();
            Driver.Init(BrowserType, ChromeHeadlessMode);
            
            
        }

        [TestInitialize]
        public void TestInit()
        {
            extentTest = CreateTest(extent,TestContext.TestName);
            SetLogger(TestContext.TestName);
            Driver.Goto(TestUrl);
            Thread.Sleep(3000);
            LogHelper.Log.Info("Test Initilization Complete");
        }

        [TestCleanup]
        public void TestClean()
        {
            try
            {
                LogHelper.Log.Pass(TestContext.TestName);
            }
            catch (Exception e)
            {

                LogHelper.Log.Error($"Test Clean up Failed :{e.Message}");
            }
        }
        [AssemblyCleanup]
        public static void CleanUpClass()
        {
            LogHelper.Log.Info("Class Clean Up Completed");
            Driver.Quit();
            extent.Flush();
        }
        public void WriteStepToLogs(string message)
        {
            LogHelper.Log.Step(message);
        }

        public void WriteFailToLogs(string message)
        {
            LogHelper.Log.Error(message);
        }
    }
}
