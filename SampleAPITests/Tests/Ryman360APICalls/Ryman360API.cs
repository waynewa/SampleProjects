using Newtonsoft.Json.Linq;
using SeleniumBase.Framework.Core.Services;
using System.Diagnostics;
using System.Linq;
using System.Net;
using PageInformation;
using OpenQA.Selenium.Remote;
using RestSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleAPITests.Tests.Ryman360APICalls
{
    public static  class Ryman360API
    {
        private static string Ryman360Url = "https://appsvc-ryman360-dev-syd-backend-testpoc.azurewebsites.net";



     
        public static void GetPagesList(string AccessToken)
        {
            string ryman360EndPoint = "/api/pages:listTiles";
            var response = GenericAPICalls.Get(Ryman360Url + ryman360EndPoint, AccessToken,HttpStatusCode.OK);
            Debug.WriteLine(response.Content);

        }

        public static void GetPagesListTree(string AccessToken,bool includeDeleted)
        {
            
            string ryman360EndPoint = $"/api/management/pages:listTree?includeDeleted={includeDeleted}";
            var response = GenericAPICalls.Get(Ryman360Url + ryman360EndPoint, AccessToken,HttpStatusCode.OK);
            var PageInfo = PageInformation.PageInfo.FromJson(response.Content);
            var pageList = PageInfo.Root.Children[0].Children.ToList();
            foreach (var pageObject in pageList)
            {
                Debug.WriteLine(pageObject.PageRef.Oid.ToString());
            }
        }


        public static string PostNewManagementPage(string AccessToken,string projectName)
        {
            JObject bodyContent = new JObject
            {
                {"oid", null},
                {"pageIdentifier", null},
                {"isPublished", false },
                {"projectLocation", "New Zealand" },
                {"projectName", projectName },
                {"projectCity", "Christchurch"},
                {"projectPhysicalAddress", "92 Russley Road" },
                {"projectLocalCouncil", "Christchurch City Council" },
                {"projectTeamMembers", "Wayne Walsh, Jun Fernandez" },
            };
            string ryman360EndPoint = "/api/management/pages";
            var newPageResponse = GenericAPICalls.Post(Ryman360Url + ryman360EndPoint, AccessToken, bodyContent, HttpStatusCode.Created);
            JObject pageInfo = JObject.Parse(newPageResponse.Content);
            string oid = pageInfo.GetValue("oid").ToString();
            Assert.IsTrue(projectName == pageInfo.GetValue("projectName").ToString());
            Debug.WriteLine(oid);
            return oid;
        }
        public static string GetManagementPageByID(string AccessToken, string pageId ,HttpStatusCode httpStatusCode)
        {
            string ryman360EndPoint = $"/api/management/pages/{pageId}";
            var pageDetails = GenericAPICalls.Get(Ryman360Url + ryman360EndPoint, AccessToken,httpStatusCode);
            try
            {
                Assert.IsTrue(pageDetails.Content.Contains(pageId),"No Page Id Found");
            }
            catch (AssertFailedException a)
            {
                Debug.WriteLine($"No Page Id Found, Error : {a.Message}");
            }
            JObject pageInfo = JObject.Parse(pageDetails.Content);
            string etag = pageInfo.GetValue("etag").ToString();
            //Debug.WriteLine(pageDetails.Content);
            return etag;

        }

        public static void DeleteManagementPageById(string AccessToken, string pageId)
        {
            string ryman360EndPoint = $"/api/management/pages/{pageId}";
            var deletedPageResponse = GenericAPICalls.Delete(Ryman360Url + ryman360EndPoint, AccessToken, HttpStatusCode.NoContent);
            Debug.WriteLine($"The Page has been successfully deleted {deletedPageResponse.Content}");
        }

        public static void SoftDeleteManagementPageById(string AccessToken, string pageId)
        {
            string ryman360EndPoint = $"/api/management/pages/{pageId}:softDelete";
            JObject bodyContent = new JObject
            {
            };
            var deletedPageResponse = GenericAPICalls.Post(Ryman360Url + ryman360EndPoint, AccessToken,bodyContent, HttpStatusCode.NoContent);
            Debug.WriteLine($"The page softdelete has been successfull {deletedPageResponse.Content}");
        }
        public static void UnDeleteManagementPageById(string AccessToken, string pageId)
        {
            string ryman360EndPoint = $"/api/management/pages/{pageId}:undelete";
            JObject bodyContent = new JObject
            {
            };
            var deletedPageResponse = GenericAPICalls.Post(Ryman360Url + ryman360EndPoint, AccessToken, bodyContent, HttpStatusCode.NoContent);
            Debug.WriteLine($"The page undelete has been successfull {deletedPageResponse.Content}");
        }
    }
 
}
