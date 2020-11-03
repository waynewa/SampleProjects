using Newtonsoft.Json.Linq;
using RestSharp;
using System.Diagnostics;
using System.Linq;

namespace SeleniumBase.Framework.Core.Services
{
    public class AzureTestSuiteService
    {

        private static string DevOpsUrl = "https://rymanhealthcare.visualstudio.com/MyRyman%20Development";
        private static string ApiEndPoint;
        private static string apicallversion = "?api-version=5.0";

        /// <summary>
        /// Get Suite number by using the suite name
        /// </summary>
        /// <param name="planName">Test plan name</param>
        /// <param name="suiteName">Test suite name</param>
        /// <returns>suite id </returns>
        public static int GetSuiteNumberByName(string planName,string suiteName)
        {
            int? planNumber = AzureTestPlanService.GetTestPlanIdByName(planName);
            ApiEndPoint = "_apis/test/plans/" + planNumber + "/suites/" + apicallversion;
            JObject jBody = new JObject();
            IRestResponse responseSuite = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);
            var suiteList = JObject.Parse(responseSuite.Content);
            var id = suiteList.Value<JArray>("value").FirstOrDefault(p => p.Value<string>("name") == suiteName).Value<int>("id");
            return id;

        }

        /// <summary>
        /// Get runs linked to the suite name
        /// </summary>
        /// <param name="planName">Test plan name</param>
        /// <param name="suiteName">Test suite name</param>
        public static void GetSuiteRuns(string planName, string suiteName)
        {
            int? planNumber = AzureTestPlanService.GetTestPlanIdByName(planName);
            Debug.WriteLine(planNumber);
            int? suiteNumber = GetSuiteNumberByName(planName, suiteName);
            Debug.WriteLine(suiteNumber);
            ApiEndPoint = "_apis/test/plans/" + planNumber + "/suites/" + suiteNumber +"/runs"+apicallversion;
            JObject jBody = new JObject();
            IRestResponse responseRun = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);
            var suiteRuns = JObject.Parse(responseRun.Content);
            Debug.WriteLine(suiteRuns);
        }
        
    }

}