using System;

namespace SeleniumBase.Framework.Core.Helpers
{
    public class AzureDevOpsHelper
    {
        public static string path;
        private static string body = "";
        private static int RunId;
        private static string TestRunName = "Automation TFS Run";
        private static int TestPointId;
        private static string TFS_Server_URL = "https://tfs.datacomdev.co.nz/tfs/SANDIAKL/";
        private static string DevOps_Comment = "Updated from the Automation Suite :";

        public static void Post_New_Run()
        {
            int planNumber = GetActivePlanNumber();
            TestPointId = GetTestCasePoint();
            var plan = new { id = planNumber };
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