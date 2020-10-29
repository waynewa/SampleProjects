using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SeleniumBase.Framework.Core.Services
{
    public class AzureApiService
    {

        private static string DevOpsUrl = "https://rymanhealthcare.visualstudio.com/MyRyman%20Development";
        private static string ApiEndPoint;
        private static string apicallversion = "?api-version=5.0";
        private static int RunId;
        private static string TestRunName = "Automation Test Run";
        private static int TestPointId;
        private static string DevOps_Comment = "Updated from the Automation Suite :";
        private static int TestCaseId = 100683;
        private static string SuiteName = "";
        private static int PlanNumber = 114985;

        public static int GetTestCasePoint { get; private set; }

        public static void PostNewRun(int testCaseId, string suiteName)
        {
            ApiEndPoint = "_apis/test/runs/" + RunId + "/results?api-version=5.0";

            //int planNumber = GetActiveTestPlan(); ///Collect info from DevOps 
            TestPointId = GetTestCasePoint; /// Collect Data From DevOps (testCaseID, suiteName)
            JObject jPlan = new JObject();
            jPlan.Add("id", PlanNumber);
            JObject jBody = new JObject();
            jBody.Add("automated", false);
            jBody.Add("name", TestRunName);
            jBody.Add("plan", jPlan);
            jBody.Add("comments", "This is a Test Case");
            jBody.Add("completedDate", "");/// Set GetDate function
            jBody.Add("pointsIds", TestPointId);
            jBody.Add("runTimeout", 600);
            jBody.Add("state", "InProgress");

            var response = APIServices.Post(DevOpsUrl, ApiEndPoint, jBody);
            Console.WriteLine($"The Resposne is {response.Content}");
        }

        public static string GetActiveTestPlan()
        {
            try
            {
                string ApiEndPoint = "_apis/test/plans" + apicallversion;
                JObject jBody = new JObject();
                IRestResponse responseplan = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);

                var planList = JObject.Parse(responseplan.Content);
                var id = planList.Value<JArray>("value").FirstOrDefault(p => p.Value<string>("name") == "2020 Sprints")?.Value<int?>("id");
                Debug.WriteLine(id);
                string activePlan = responseplan.Content;
                return activePlan;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Assert.Fail();
                return null;
            }

        }

        public static void GetAllTestPlans()
        {
            ApiEndPoint = "/_apis/test/plans?api-version=5.0";
            JObject jBody = new JObject();
            var TestPlans = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);

            Debug.WriteLine(TestPlans.Content);
        }

        public static void PatchUpdateCompletedRun(int RunId)
        {
            ApiEndPoint = "_apis/test/runs/" + RunId + "?api-version=5.0";

            /** Successfully creates a new run with no tests at the moment **/
            JObject jBody = new JObject();
            jBody.Add("state", "Completed");
            jBody.Add("completedDate", DateTime.Now);

            var response = APIServices.Patch(DevOpsUrl, ApiEndPoint, jBody);
            Console.WriteLine($"The Resposne is {response.Content}");
        }


        public static void PatchUpdateCompletedTestRun(int RunId, string comment)
        {
            ApiEndPoint = "_apis/test/runs/" + RunId + "/results?api-version=5.0";

            /** Successfully creates a new run with no tests at the moment **/
            JObject jBody = new JObject();
            jBody.Add("id", 100000);
            jBody.Add("state", "Completed");
            jBody.Add("completedDate", DateTime.Now);
            jBody.Add("comment", comment);

            var response = APIServices.Patch(DevOpsUrl, ApiEndPoint, jBody);
            Console.WriteLine($"The Resposne is {response.Content}");
        }


        public static void GetRunInfo(int RunId)
        {
            ApiEndPoint = "_apis/test/runs/" + RunId + "/Statistics?api-version=5.0";

            JObject jBody = new JObject();
            IRestResponse getRun = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);
            Debug.WriteLine(getRun.ToString());

        }

        public static void GetRunResults(int RunId)
        {
            ApiEndPoint = "_apis/test/runs/" + RunId + "/results?api-version=5.0";

            Debug.WriteLine(RunId.ToString());

            JObject jBody = new JObject();
            IRestResponse getRun = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);
            Debug.WriteLine(getRun.ToString());

        }

        /******This function will Pass the test case oin the TFS server, additional availability check for the TFS server will be done*************/

        public static void UpdateDevOpsPerTestCasePassed(int testCaseId, string suiteName)
        {
            if (CheckUrl() == true && Boolean.Parse("true"))
            {
                Debug.WriteLine("TFS Server is available");
                PostTestResultsNewRun(testCaseId, "Passed", suiteName, DevOps_Comment);
            }
            else
            {
                Debug.WriteLine("*************************TFS Server is not available, no TFS Updates will be done*************************************");
            }

        }

        private static void PostTestResultsNewRun(int testCaseId, string v, string suiteName, string DevOps_Comment)
        {
            throw new NotImplementedException();
        }

        public static void UpdateDevOpsPerTestCaseFailed(int testCaseId, String suiteName)
        {
            if (CheckUrl() == true && Boolean.Parse("true"))
            {
                Debug.WriteLine("TFS Server is available");
                PostTestResultsNewRun(testCaseId, "Failed", suiteName, DevOps_Comment);
            }
            else
            {
                Debug.WriteLine("*************************TFS Server is not available, no TFS Updates will be done*************************************");
            }
        }

        public static Boolean CheckUrl()
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(DevOpsUrl) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                //Any exception will returns false.
                return false;
            }
        }
        public static async void GetProjects()
        {
            try
            {
                var personalaccesstoken = "j7c5wxdbimp7ufoz5crmrtsxygaamlv7vbvkgbexwjyfokkurcfa";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(
                            System.Text.Encoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", "", personalaccesstoken))));

                    using (HttpResponseMessage response = await client.GetAsync(
                                DevOpsUrl))
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine($"This is the DevOps Projects: {responseBody}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

}