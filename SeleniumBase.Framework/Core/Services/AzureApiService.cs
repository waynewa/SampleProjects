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
        private static int RunId;
        private static string TestRunName = "Automation TFS Run";
        private static int TestPointId;
        private static string TFS_Server_URL = "https://tfs.datacomdev.co.nz/tfs/SANDIAKL/";
        private static string DevOps_Comment = "Updated from the Automation Suite :";

        public static void Post_New_Run()
        {
            int planNumber = GetActivePlanNumber();
            TestPointId = GetTestCasePoint();
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
