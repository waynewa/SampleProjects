using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace SeleniumBase.Framework.Core.Services
{
    public class AzureTestRunServices
    {

        private static string DevOpsUrl = "https://rymanhealthcare.visualstudio.com/MyRyman%20Development";
        private static string ApiEndPoint;
        private static string apicallversion = "?api-version=5.0";
        private static string TestRunName = "Automation Test Run";
        private static int TestPointId;
        private static string DevOps_Comment = "Updated from the Automation Suite :";


        public static void CreateNewTestRun(string planName,string suiteName,int testCaseNumber)
        {
            int? planNumber  = AzureApiService.GetTestPlanIdByName(planName);
            int? pointIds = AzureApiService.GetTestCasePoint(planName,suiteName,testCaseNumber);
            ApiEndPoint = "_apis/test/runs" + apicallversion;
            JObject jPlan = new JObject();
            jPlan.Add("id", planNumber);
            JObject jBody = new JObject();
            jBody.Add("name", "NewTestRun");
            jBody.Add("plan", jPlan);
            jBody.Add("poindIds", pointIds);

            IRestResponse responsePlan = APIServices.Post(DevOpsUrl, ApiEndPoint, jBody);
            var content = responsePlan.Content;
            Debug.WriteLine(content);

        }
        public static void DeleteTestRun()
        {
            ApiEndPoint = "_apis/test/runs" + apicallversion;
            JObject jBody = new JObject();
            IRestResponse responsePlan = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);

        }
        public static void UpdateTestRun()
        {
            ApiEndPoint = "_apis/test/runs" + apicallversion;
            JObject jBody = new JObject();
            IRestResponse responsePlan = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);

        }

        /// <summary>
        /// Get a test run by its ID.
        /// </summary>
        /// <param name="runId">Test Run Id</param>
        public static void GetTestRunById(int runId)
        {
            ApiEndPoint = "_apis/test/runs/"+runId+ apicallversion;
            JObject jBody = new JObject();
            IRestResponse responsePlan = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);
            var content = responsePlan.Content;
            Debug.WriteLine(content);
        }

        /// <summary>
        /// Get test run statistics , used when we want to get summary of a run by outcome.
        /// </summary>
        /// <param name="runId">Test Run Id</param>
        public static void GetTestRunStatistics(int runId)
        {
            ApiEndPoint = "_apis/test/runs/" + runId+"/Statistics" + apicallversion;
            JObject jBody = new JObject();
            IRestResponse responsePlan = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);
            var content = responsePlan.Content;
            Debug.WriteLine(content);
        }

        /// <summary>
        /// Get a list of test runs.
        /// </summary>
        public static void GetListOfTestRuns()
        {
            ApiEndPoint = "_apis/test/runs"+ apicallversion;
            JObject jBody = new JObject();
            IRestResponse responsePlan = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);
            var content = responsePlan.Content;
            Debug.WriteLine(content);
        }


        /// <summary>
        /// Get the latest run number from list of test runs.
        /// </summary>
        public static void GetLatestTestRunNumber()
        {
            ApiEndPoint = "_apis/test/runs" + apicallversion;
            JObject jBody = new JObject();
            IRestResponse responsePlan = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);
            var content = responsePlan.Content;
            Debug.WriteLine(content);

        }
    }

}