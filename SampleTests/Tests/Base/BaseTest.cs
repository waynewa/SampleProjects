﻿using static SeleniumBase.Framework.Core.Helpers.LogHelper;
using static SeleniumBase.Framework.Core.Helpers.ExtentReportHelper;
using SeleniumBase.Framework.Core.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using AventStack.ExtentReports;
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
        public static string GridUrl { get; set; }
        private static AventStack.ExtentReports.ExtentReports extent { get; set; }
        public static ExtentTest extentTest { get; set; }

        [AssemblyInitialize]
        public static void BeforeAll(TestContext testContext)
        {
            TestContextLoader = new TestContextLoader(testContext);
            TestUrl = TestContextLoader.GetProperty("TestUrl", "https://demoqa.com");
            BrowserType = TestContextLoader.GetProperty("BrowserType", "Chrome");
            GridUrl = TestContextLoader.GetProperty("GridUrl", "http://127.0.0.1:4444/wd/hub");
            CreateTestResultsDirectory();
            extent = StartReport();
        }

        [TestInitialize]
        public void TestInit()
        {
            extentTest = CreateTest(extent,TestContext.TestName);
            SetLogger(TestContext.TestName);
            if (BrowserType == "Remote")
            { Driver.Init(BrowserType, GridUrl); }
            else 
            { Driver.Init(BrowserType); }
            Driver.Goto(TestUrl);
            Thread.Sleep(3000);
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
