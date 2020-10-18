using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Web.UI;
using static SeleniumBase.Framework.Core.Helpers.LogHelper;

namespace SeleniumBase.Framework.Core.Helpers
{
    public abstract class ExtentReportHelper
    {
        public static AventStack.ExtentReports.ExtentReports Extent => extent ?? throw new NullReferenceException("extent is null. StartReport() first.");
        public static ExtentTest ExtentTest => extentTest ?? throw new NullReferenceException("extenttest is null. CreateTest() first.");
        
        public static ExtentV3HtmlReporter htmlReporter;
        
        [ThreadStatic]
        private static AventStack.ExtentReports.ExtentReports extent;
        [ThreadStatic]
        private static ExtentTest extentTest;

        
        public static AventStack.ExtentReports.ExtentReports StartReport()
        {
            string projectPath = WORKSPACE_DIRECTORY;
            string reportPath = projectPath + "Reports\\TestRunReport.html";
            var extent = new AventStack.ExtentReports.ExtentReports();
            var htmlReporter = new ExtentV3HtmlReporter(reportPath);
            htmlReporter.Config.DocumentTitle = "Automation Testing Report";
            htmlReporter.Config.ReportName = "Regression Testing";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Machine", Environment.MachineName);
            extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
            return extent;
        }

        public static ExtentTest CreateTest(AventStack.ExtentReports.ExtentReports _extent, string testName)
        {
            extentTest = _extent.CreateTest(testName);
            return extentTest;
        }

        public void Info(string message)
        {
            extentTest.Info(message);
        }

        public void Warning(string message)
        {
            extentTest.Warning(message);
        }

        public void Error(string message)
        {
            extentTest.Error(message);
        }

        public void Fatal(string message)
        {
            extentTest.Fatal(message);
        }
        public void AddScreenShots()
        {
            var mediaModel =
        MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build();
            extentTest.Fail("details", mediaModel);
        }
    }
}
