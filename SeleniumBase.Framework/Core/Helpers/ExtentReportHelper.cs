using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using static SeleniumBase.Framework.Core.Helpers.LogHelper;

namespace SeleniumBase.Framework.Core.Helpers
{
    public class ExtentReportHelper
    {
        public AventStack.ExtentReports.ExtentReports extent { get; set; }
        public ExtentV3HtmlReporter htmlReporter { get; set; }
        public ExtentTest extentTest { get; set; }

        public ExtentReportHelper StartReport()
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
            return this;
        }

        public void CreateTest(string testName)
        {
            extentTest = extent.CreateTest(testName);
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

            // or:
            extentTest.Fail("details",
                MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build());
        }
    }
}
