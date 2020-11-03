using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;


namespace SeleniumBase.Framework.Core.Services
{
    /// <summary>
    /// This services Class requires some refactoring as it is only
    /// exsample indications at the moment
    /// </summary>
    public static class AzureTestPlanService
    {
        private static string DevOpsUrl = "https://rymanhealthcare.visualstudio.com/MyRyman%20Development";
        private static string ApiEndPoint;
        private static string ApiCallVersion = "?api-version=6.0";

        /// <summary>
        /// Gets all test planes in the DevOps project
        /// </summary>
        public static void GetAllTestPlans()
        {
            ApiEndPoint = "/_apis/test/plans" + ApiCallVersion;
            JObject jBody = new JObject();
            var TestPlans = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);

            Debug.WriteLine(TestPlans.Content);
        }

        /// <summary>
        /// Gets test plan id by Name of the test plan
        /// </summary>
        /// <param name="planName"></param>
        /// <returns>test plan Id</returns>
        public static int? GetTestPlanIdByName(string planName)
        {
            try
            {
                string ApiEndPoint = "_apis/test/plans" + ApiCallVersion;
                JObject jBody = new JObject();
                IRestResponse responsePlan = APIServices.Get(DevOpsUrl, ApiEndPoint, jBody);

                var planList = JObject.Parse(responsePlan.Content);
                var id = planList.Value<JArray>("value").FirstOrDefault(p => p.Value<string>("name") == planName)?.Value<int?>("id");
                return id;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Assert.Fail();
                return null;
            }

        }



    }
}
  
