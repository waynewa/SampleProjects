using System;
using System.Diagnostics;
using System.Net;

namespace SeleniumBase.Framework.Core.Services
{
    public class AzureApiService
    {
        private static string DevOpsUrl = "https://rymanhealthcare.visualstudio.com/MyRyman%20Development";
        private static string DevOps_Comment = "Updated from the Automation Suite :";

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
     
    }

}