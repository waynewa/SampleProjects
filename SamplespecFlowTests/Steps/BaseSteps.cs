using static SeleniumBase.Framework.Core.Helpers.LogHelper;
using static SeleniumBase.Framework.Core.Helpers.ExtentReportHelper;
using SeleniumBase.Framework.Core.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using SeleniumBase.Framework.Core.Helpers;


namespace SamplespecFlowProject.Steps
{
    [Binding]
    public class BaseSteps
    {
        private static AventStack.ExtentReports.ExtentReports extent { get; set; }
        public static ExtentTest _extentTest { get; set; }

        [BeforeTestRun]
        public static void InitializeTest()
        {
            CreateTestResultsDirectory();
            extent = StartReport();
        }



        [StepDefinition("I navigate to the \"(.*)\"")]
        public void NavigateToUrl(string navigationUrl) {


            _extentTest = CreateTest(extent, "Navigation");
            SetLogger("SpecFlow Tests");
            Driver.Init("Chrome", true);
            Driver.Goto(navigationUrl);
            Driver.Quit();
        }

        [Then("I expect to see the \"(.*)\"")]
        public void ValidateMessage(String message) { 
        
        }

        [AfterTestRun]
        public static void TearDown()
        {
        }
    }
}
