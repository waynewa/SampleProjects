using NUnit.Framework;
using System;
using System.IO;
using Customers.Framework.Core.Logging;
using System.Diagnostics;

namespace Customers.Framework
{
    public class FW
    {
        public static string WORKSPACE_DIRECTORY = @"C:\temp\";//Path.GetFullPath(@"../../../../");

        public static Logger Log => _logger ?? throw new NullReferenceException("_logger is null. SetLogger() first.");

        [ThreadStatic]
        public static DirectoryInfo CurrentTestDirectory;
        [ThreadStatic]
        private static Logger _logger;
        public static DirectoryInfo CreateTestResultsDirectory()
        {
            var testDirectory = WORKSPACE_DIRECTORY = "TestResults";
            if (Directory.Exists(testDirectory))
            {
                Debug.WriteLine("Driectory Exists!");
                Directory.Delete(testDirectory, recursive: true);
            }

            return Directory.CreateDirectory(testDirectory);
        }

        public static void SetLogger()
        {
            var testResultsDir = WORKSPACE_DIRECTORY + "TestResults";
            var testName = TestContext.CurrentContext.Test.Name;
            var fullPath = $"{testResultsDir}\\{testName}";
            CurrentTestDirectory = Directory.CreateDirectory(fullPath);
            _logger = new Logger(testName, CurrentTestDirectory.FullName + "/log.txt");
            Debug.WriteLine("Log File Created");
        }
    }
}
