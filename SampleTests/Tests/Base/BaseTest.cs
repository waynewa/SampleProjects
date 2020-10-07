using static Customers.Framework.Core.Helpers.LogHelper;
using Customers.Framework.Core.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace SampleTests.Tests.Base
{
    public class BaseTest
    {
        public TestContext TestContext { get; set; }

        private static TestContext _testContext;
        [ClassInitialize]
        public void BeforeAll(TestContext testContext)
        {
            _testContext = testContext;
            CreateTestResultsDirectory();
        }

        [TestInitialize]
        public void TestInit()
        {
            SetLogger(TestContext.TestName);
            Driver.Init(WebBrowser.Edge);
            Driver.Goto("https://demoqa.com");
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
