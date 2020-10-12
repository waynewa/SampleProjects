﻿using static SeleniumBase.Framework.Core.Helpers.LogHelper;
using SeleniumBase.Framework.Core.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace SampleTests.Tests.Base
{
    [TestClass]
    public abstract class BaseTest
    {
        protected static TestContextLoader TestContextLoader;
        public TestContext TestContext { get; set; }
        public static string TestUrl { get; set; }
        public static string BrowserType { get; set; }


        [AssemblyInitialize]
        public static void BeforeAll(TestContext testContext)
        {
            TestContextLoader = new TestContextLoader(testContext);
            TestUrl = TestContextLoader.GetProperty("TestUrl", "https://demoqa.com");
            BrowserType = TestContextLoader.GetProperty("BrowserType", "Chrome");
            CreateTestResultsDirectory();
        }

        [TestInitialize]
        public void TestInit()
        {
            SetLogger(TestContext.TestName);
            Driver.Init(BrowserType);
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
                Log.Info("Test Clean up Complete");
            }
            catch (Exception e)
            {
                Driver.Quit();
                Log.Fatal($"Test Clean up Failed :{e.Message}");
            }
        }
        [ClassCleanup]
        public void CleanUpClass()
        {
            Driver.Close();
            Driver.Quit();
            Log.Info("Class Clean Up Completed");
        }
    }
}
