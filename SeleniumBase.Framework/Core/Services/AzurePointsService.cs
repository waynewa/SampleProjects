using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace SeleniumBase.Framework.Core.Services
{
    public class AzurePointsService
    {

        private static string DevOpsUrl = "https://rymanhealthcare.visualstudio.com/MyRyman%20Development";
        private static string ApiEndPoint;
        private static string apicallversion = "?api-version=5.0";
        private static int RunId;
        private static string TestRunName = "Automation Test Run";
        private static int TestPointId;
        private static string DevOps_Comment = "Updated from the Automation Suite :";



        public static IList GetListOfTestPoints(string planName, string suiteName)
        {
            int? planNumber = AzureApiService.GetTestPlanIdByName(planName);
            int? suiteNumber = AzureApiService.GetSuiteNumberByName(planName, suiteName);
            ApiEndPoint = "_apis/test/plans/" + planNumber + "/suites/" + suiteNumber + "/points/" + apicallversion;
            JObject jBody = new JObject();
            IRestResponse responsePoints = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);
            var suitePoints = JObject.Parse(responsePoints.Content);
            IList pointsList = suitePoints.Value<JArray>("value").Values<int>("id").ToList();
            return pointsList;
        }

        public static void GetTestPointsByTestCaseId(string planName, string suiteName, int testCaseId)
        {
            int? planNumber = AzureApiService.GetTestPlanIdByName(planName);
            int? suiteNumber = AzureApiService.GetSuiteNumberByName(planName, suiteName);
            ApiEndPoint = "_apis/test/plans/" + planNumber + "/suites/" + suiteNumber + "/points/" + apicallversion;
            JObject jBody = new JObject();
            IRestResponse responsePoints = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);
            var suitePoints = JObject.Parse(responsePoints.Content);
            var id = suitePoints.Value<string>("value");
            Debug.WriteLine(id.ToString());

        }
    }

}