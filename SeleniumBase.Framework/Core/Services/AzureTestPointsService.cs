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
    public class AzureTestPointsService
    {

        private static string DevOpsUrl = "https://rymanhealthcare.visualstudio.com/MyRyman%20Development";
        private static string ApiEndPoint;
        private static string ApiCallVersion = "?api-version=5.0";


        public static IList GetListOfTestPoints(string planName, string suiteName)
        {
            int? planNumber = AzureTestPlanService.GetTestPlanIdByName(planName);
            int? suiteNumber = AzureTestSuiteService.GetSuiteNumberByName(planName, suiteName);
            ApiEndPoint = "_apis/test/plans/" + planNumber + "/suites/" + suiteNumber + "/points/" + ApiCallVersion;
            JObject jBody = new JObject();
            IRestResponse responsePoints = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);
            var suitePoints = JObject.Parse(responsePoints.Content);
            IList pointsList = suitePoints.Value<JArray>("value").Values<int>("id").ToList();
            return pointsList;
        }

        /// <summary>
        /// Get the TestPoints liked to specified test case Id 
        /// </summary>
        /// <param name="testCaseId">DevOps test case number</param>
        /// <returns></returns>
        public static int GetTestPointsByTestCaseId(int testCaseId)
        {
            JArray IDS = new JArray()
            {
                testCaseId
            };

            ApiEndPoint = "_apis/test/points?api-version=6.0-preview.2";
            JObject testCId = new JObject();
            testCId.Add("TestcaseIds",IDS);
            JObject jBody = new JObject();
            jBody.Add("PointsFilter", testCId);
            IRestResponse responsePoints = APIServices.Post(DevOpsUrl, ApiEndPoint, jBody);
            var suitePoints = JObject.Parse(responsePoints.Content);
            var list = suitePoints.Value<JArray>("points").Values<int>("id").ToList();
            return list.Last();

        }
    }

}