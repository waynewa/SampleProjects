using static SeleniumBase.Framework.Core.Helpers.LogHelper;
using static SeleniumBase.Framework.Core.Helpers.ExtentReportHelper;
using SeleniumBase.Framework.Core.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AventStack.ExtentReports;

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
        public static string TestUrl { get; set; }
        public static string Path { get; set; }


        [AssemblyInitialize]
        public static void BeforeAll(TestContext testContext)
        {
            TestContextLoader = new TestContextLoader(testContext);
            CreateTestResultsDirectory();
            TestUrl = TestContextLoader.GetProperty("TestUrl", "https://reqres.in/");
            Path = TestContextLoader.GetProperty("Path", "api/users?page=2");
            extent = StartReport();
            
        }

        [TestInitialize]
        public void TestInit()
        {
            extentTest = CreateTest(extent,TestContext.TestName);
            SetLogger(TestContext.TestName);
            Log.Info("Test Initilization Complete");
        }

        [TestCleanup]
        public void TestClean()
        {
            try
            {
                Log.Pass(TestContext.TestName);
            }
            catch (Exception e)
            {
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
