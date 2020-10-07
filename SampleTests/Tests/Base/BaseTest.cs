using Customers.Framework;
using Customers.Framework.Core.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;

namespace SampleTests.Tests.Base
{
    public class BaseTest
    {
        [OneTimeSetUp]
        public void BeforeAll()
        {
            FW.CreateTestResultsDirectory();
        }

        [TestInitialize]
        public void TestInit()
        {
            FW.SetLogger();
            Driver.Init(WebBrowser.Edge);
            Driver.Goto("https://demoqa.com");
            FW.Log.Info("Test Initilization Complete");
        }

        [TestCleanup]
        public void TestClean()
        {
            try
            {
                Driver.Quit();
                FW.Log.Info("Test Clean up Complete");
            }
            catch (Exception e)
            {
                Driver.Quit();
                FW.Log.Fatal($"Test Clean up Failed :{e.Message}");
            }
        }
        [ClassCleanup]
        public void CleanUpClass()
        {
            Driver.Close();
            Driver.Quit();
            FW.Log.Info("Class Clean Up Completed");
        }
    }
}
