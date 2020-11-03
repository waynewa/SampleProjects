using System;
using System.Diagnostics;

namespace SeleniumBase.Framework.Core.Helpers
{
    public class AzureDevOpsHelper
    {
        public static string path;
        private static int TestPointId;

        /// <summary>
        /// Currently stil busy developing this class features
        /// </summary>

        public static void Post_New_Run()
        {
            int planNumber = GetActivePlanNumber();
            TestPointId = GetTestCasePoint();
            var plan = new { id = planNumber };
            Debug.WriteLine(plan);
        }

        private static int GetTestCasePoint()
        {
            throw new NotImplementedException();
        }

        private static int GetActivePlanNumber()
        {
            throw new NotImplementedException();
        }
    }
}