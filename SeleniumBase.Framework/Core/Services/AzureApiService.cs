using System;
using System.Diagnostics;
using System.Net;

namespace SeleniumBase.Framework.Core.Services
{
    public class AzureApiService
    {
        private static string DevOpsUrl = "https://rymanhealthcare.visualstudio.com/MyRyman%20Development";
        private static string DevOps_Comment = "Updated from the Automation Suite :";

        /// <summary>
        /// This function will Pass the test case in the DevOps server
        /// , additional availability check for the DevOps server will be done
        /// </summary>
        /// <param name="testCaseId">id of DevOps testcase</param>
        /// <param name="suiteName">Name of suite where test case is located</param>
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

        /// <summary>
        /// This function will Fail the test case in the DevOps server
        /// , additional availability check for the DevOps server will be done
        /// </summary>
        /// <param name="testCaseId"></param>
        /// <param name="suiteName"></param>
        public static void UpdateDevOpsPerTestCaseFailed(int testCaseId, string suiteName)
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


        /// <summary>
        /// This will create new Run and post results to the test cases in the run 
        /// </summary>
        /// <param name="testCaseId"></param>
        /// <param name="planName"></param>
        /// <param name="suiteName"></param>
        /// <param name="DevOps_Comment"></param>
        private static void PostTestResultsNewRun(int testCaseId, string planName, string suiteName, string DevOps_Comment)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This will check if the DevOps server URL is available and the return boolean value
        /// </summary>
        /// <returns>boolean value</returns>
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
     
    }

}