using static SeleniumBase.Framework.Core.Helpers.LogHelper;
using static SeleniumBase.Framework.Core.Helpers.ExtentReportHelper;
using SeleniumBase.Framework.Core.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using AventStack.ExtentReports;
using SeleniumBase.Framework.Core.Services;
using SeleniumBase.Framework.Core.Helpers;

namespace SampleAPITests.Tests.Base
{
    [TestClass]
    public abstract class BaseAPITest
    {
        protected static TestContextLoader TestContextLoader;
        public TestContext TestContext { get; set; }
        public static string BrowserType { get; set; }
        private static AventStack.ExtentReports.ExtentReports extent { get; set; }
        public static ExtentTest extentTest { get; set; }
        public static string AccessToken { get; set; }
        public static string PAT { get; set; }
        public static string ServerUrl { get; set; }
        public static string ProjectName { get; set; }
        public static string ApiCallVersion { get; set; }
        public static string TestRunName { get; set; }
        public static string ApiEndPoint { get; set; }

        [AssemblyInitialize]
        public static void BeforeAll(TestContext testContext)
        {
            TestContextLoader = new TestContextLoader(testContext);
            BrowserType = TestContextLoader.GetProperty("BrowserType", "Chrome");
            PAT = TestContextLoader.GetProperty("PAT", "SamplePAT$%^&*()");
            ServerUrl = TestContextLoader.GetProperty("ServerUrl", "Https://SampleURL.com");
            ProjectName = TestContextLoader.GetProperty("ProjectName", "Sample Poject Name");
            ApiCallVersion = TestContextLoader.GetProperty("ApiCallVersion", "?api-version=6.0");
            TestRunName = TestContextLoader.GetProperty("TestRunName", "SampleTestName_99999");
            CreateTestResultsDirectory();
            extent = StartReport();
            
        }

        [TestInitialize]
        public void TestInit()
        {
            extentTest = CreateTest(extent,TestContext.TestName);
            SetLogger(TestContext.TestName);
            AccessToken = MicrosoftLoginHelper.MicrosoftLoginGetAPICode();
            Log.Info("Test Initilization Complete");
        }

        [TestCleanup]
        public void TestClean()
        {
            try
            {
                Driver.Quit();
                Log.Pass(TestContext.TestName);
            }
            catch (Exception e)
            {
                Driver.Quit();
                Log.Error($"Test Clean up Failed :{e.Message}");
            }
        }
        [AssemblyCleanup]
        public static void CleanUpClass()
        {
            Log.Info("Class Clean Up Completed");
            extent.Flush();
        }
        public void WriteStepToLogs(string message)
        {
            Log.Step(message);
        }

        public void WriteFailToLogs(string message)
        {
            Log.Error(message);
        }
    }
}
