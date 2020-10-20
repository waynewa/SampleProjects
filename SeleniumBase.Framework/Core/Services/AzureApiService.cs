using AngleSharp.Io;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBase.Framework.Core.Services
{
    public class AzureApiService
    {
        public static string path;
        private static string body = "";
        private static int runId;
        private static string testRunName = "Automation TFS Run";
        private static int testPointId;
        private static string TFS_Server_URL = "https://tfs.datacomdev.co.nz/tfs/SANDIAKL/";
        private static string TFS_Comment = "Updated from the Automation Suite :";

        public static void Post_New_Run()
        {
            int planNumber = GetActivePlanNumber();
            testPointId = GetTestCasePoint();
            var plan = new {id = planNumber };
            

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
