using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Diagnostics;

namespace SeleniumBase.Framework.Core.Services
{
    public class AzureTestRunService
    {

        private static string DevOpsUrl = "https://rymanhealthcare.visualstudio.com/MyRyman%20Development";
        private static string ApiEndPoint;
        private static string ApiCallVersion = "?api-version=6.0";
        private static string TestRunName = "Selenium Automation Framework Test Run";
        
        /// <summary>
        /// Create a new Test Run in the DevOps Service 
        /// </summary>
        /// <param name="planName">Name on the Test Plan</param>
        /// <param name="testCaseNumber">Test case number relating to the test run</param>
        /// <returns>RunID - used to update test case outcome </returns>
        public static int CreateNewTestRun(string planName,int testCaseNumber)
        {
            int? planNumber  = AzureTestPlanService.GetTestPlanIdByName(planName);
            int? pointIds = AzureTestPointsService.GetTestPointsByTestCaseId(testCaseNumber);
            ApiEndPoint = "_apis/test/runs" + ApiCallVersion;
            JArray PIds = new JArray()
            {
                pointIds
            };
            JObject jPlan = new JObject();
            jPlan.Add("id", planNumber);
            JObject jBody = new JObject();
            jBody.Add("automated", false);
            jBody.Add("name", TestRunName);
            jBody.Add("plan", jPlan);
            jBody.Add("comments", "This is a Test Case");
            jBody.Add("completedDate", DateTime.Now);
            jBody.Add("pointsIds", PIds);
            jBody.Add("runTimeout", 600);
            jBody.Add("state", "InProgress");

            IRestResponse responseRun = APIServices.Post(DevOpsUrl, ApiEndPoint, jBody);
            var content = JObject.Parse(responseRun.Content);
            var runId = content.Value<int>("id");
            Debug.WriteLine(runId);
            return runId;
        }

        /// <summary>
        /// Deletes a Test Run with specified run Id
        /// </summary>
        /// <param name="runId">Indentifier of the test run</param>
        public static void DeleteTestRun(int runId)
        {
            ApiEndPoint = "_apis/test/runs/"+runId + ApiCallVersion;
            JObject jBody = new JObject();
            APIServices.Delete(DevOpsUrl, ApiEndPoint);
        }

        /// <summary>
        /// Update the test run linked to the run ID
        /// </summary>
        /// <param name="runId">Indentifier of the test run</param>
        public static void PatchUpdateCompletedRun(int runId)
        {
            ApiEndPoint = "_apis/test/runs/" + runId + "" + ApiCallVersion;

            /** Successfully creates a new run with no tests at the moment **/
            JObject jBody = new JObject();
            jBody.Add("state", "Completed");
            jBody.Add("completedDate", DateTime.Now);

            var response = APIServices.Patch(DevOpsUrl, ApiEndPoint, jBody);
            Console.WriteLine($"The Resposne is {response.Content}");
        }

        /// <summary>
        /// Update the test run linked to the run ID
        /// </summary>
        /// <param name="runId">Indentifier of the test run</param>
        /// <param name="comment">Text comment for run</param>
        public static void PatchUpdateCompletedTestRun(int runId, string comment)
        {
            ApiEndPoint = "_apis/test/runs/" + runId + "/results" + ApiCallVersion;

            /** Successfully creates a new run with no tests at the moment **/
            JObject jBody = new JObject();
            jBody.Add("id", 100000);
            jBody.Add("state", "Completed");
            jBody.Add("completedDate", DateTime.Now);
            jBody.Add("comment", comment);

            var response = APIServices.Patch(DevOpsUrl, ApiEndPoint, jBody);
            Console.WriteLine($"The Resposne is {response.Content}");
        }

        /// <summary>
        /// Get a test run by its ID.
        /// </summary>
        /// <param name="runId">Test Run Id</param>
        public static void GetTestRunById(int runId)
        {
            ApiEndPoint = "_apis/test/runs/"+runId+ ApiCallVersion;
            JObject jBody = new JObject();
            IRestResponse responsePlan = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);
            var content = responsePlan.Content;
            Debug.WriteLine(content);
        }

        /// <summary>
        /// Get a list of runs linked to the Suite name
        /// </summary>
        /// <param name="planName">Test plan name parameter</param>
        /// <param name="suiteName">Test suite name </param>
        public static void GetSuiteRuns(string planName, string suiteName)
        {
            int? planNumber = AzureTestPlanService.GetTestPlanIdByName(planName);
            int? suiteNumber = AzureTestSuiteService.GetSuiteNumberByName(planName, suiteName);
            ApiEndPoint = "_apis/test/plans/" + planNumber + "/suites/" + suiteNumber + "/runs" + ApiCallVersion;
            JObject jBody = new JObject();
            IRestResponse responseRun = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);
            var suiteRuns = JObject.Parse(responseRun.Content);
            Debug.WriteLine(suiteRuns);
        }

        /// <summary>
        /// Get Results from test run with run id
        /// </summary>
        /// <param name="runId">Test run identifier</param>
        public static void GetRunResults(Int32 runId)
        {
            ApiEndPoint = "_apis/test/runs/" + runId + "/results" + ApiCallVersion;
            JObject jBody = new JObject();
            IRestResponse getRun = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);
            var runResults = JObject.Parse(getRun.Content);
            Debug.WriteLine(runResults);
        }

        /// <summary>
        /// Get test run statistics , used when we want to get summary of a run by outcome.
        /// </summary>
        /// <param name="runId">Test Run Id</param>
        public static void GetTestRunStatistics(int runId)
        {
            ApiEndPoint = "_apis/test/runs/" + runId+"/Statistics" + ApiCallVersion;
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
            ApiEndPoint = "_apis/test/runs"+ ApiCallVersion;
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
            ApiEndPoint = "_apis/test/runs" + ApiCallVersion;
            JObject jBody = new JObject();
            IRestResponse responsePlan = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);
            var content = responsePlan.Content;
            Debug.WriteLine(content);

        }
    }

}