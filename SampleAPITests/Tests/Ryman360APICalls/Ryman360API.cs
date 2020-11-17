using Newtonsoft.Json.Linq;
using SeleniumBase.Framework.Core.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPITests.Tests.Ryman360APICalls
{
    public static  class Ryman360API
    {
        private static string Ryman360Url = "https://appsvc-ryman360-dev-syd-backend-testpoc.azurewebsites.net/";



     
        public static void GetPagesList(string AccessToken)
        {
            string ryman360EndPoint = "api/pages:listTiles";
            var response = GenericAPICalls.Get(Ryman360Url + ryman360EndPoint, AccessToken);
            Debug.WriteLine(response.Content);

        }

   
        public static void PostNewManagementPage(string AccessToken)
        {
            JObject newPage = new JObject
            {
                {"oid", null},
                {"pageIdentifier", null},
                {"isPublished", false },
                {"projectLocation", "New Zealand" },
                {"projectName", "Make myRyman great again" },
                {"projectCity", "Christchurch"},
                {"projectPhysicalAddress", "92 Russley Road" },
                {"projectLocalCouncil", "Christchurch City Council" },
                {"projectTeamMembers", "Wayne Walsh, Jun Fernandez" },
            };
            string ryman360EndPoint = "/api/management/pages";
            var newPageResponse = GenericAPICalls.Post(Ryman360Url + ryman360EndPoint, AccessToken, newPage, HttpStatusCode.Created);
            Debug.WriteLine(newPageResponse.Content);
        }
        public static void GetManagementPageByID()
        {
        
        
        }
    }
}
