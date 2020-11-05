using Newtonsoft.Json.Linq;
using RestSharp;
using SeleniumBase.Framework.Core.Services;

namespace SeleniumBase.Framework.Core.Helpers
{
    public class AzureDevOpsHelper
    {
        private static string DevOpsUrl = "https://rymanhealthcare.visualstudio.com/MyRyman%20Development";
        private static string ApiEndPoint;
        private static string ApiCallVersion = "?api-version=6.0";

        /// <summary>
        /// This will create new Run and post results to the test cases in the run 
        /// </summary>
        /// <param name="testCaseId"></param>
        /// <param name="planName"></param>
        /// <param name="suiteName"></param>
        /// <param name="DevOps_Comment"></param>
        public static void PostTestResults(int testCaseId, string outcome, string planName, string suiteName)
        {
            int? planId = AzureTestPlanService.GetTestPlanIdByName(planName);
            int? suiteId = AzureTestSuiteService.GetSuiteNumberByName(planName, suiteName);
            int testPointId = AzureTestPointsService.GetTestPointsByTestCaseId(testCaseId);
            JObject testerName = new JObject();
            testerName.Add("displayName", "Wayne Walsh");
            JObject jBody = new JObject();
            jBody.Add("outcome", outcome);
            jBody.Add("tester", testerName);

            ApiEndPoint = $"_apis/test/Plans/{planId}/Suites/{suiteId}/points/{testPointId}{ApiCallVersion}";
            IRestResponse restResponse = APIServices.Patch(DevOpsUrl, ApiEndPoint, jBody);

        }
    }
    }