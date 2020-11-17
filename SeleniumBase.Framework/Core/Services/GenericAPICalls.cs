using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace SeleniumBase.Framework.Core.Services
{
    public class GenericAPICalls
    {

        public static IRestResponse Get(string BaseUrl, string Token)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {Token}");
            var response = client.Get(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(true, response.IsSuccessful);
            return response;

        }

        public static IRestResponse Post(string BaseUrl, string Token,JObject Body,HttpStatusCode httpStatusCode)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {Token}");
            request.AddParameter("application/json", Body, ParameterType.RequestBody);
            var response = client.Post(request);
            Assert.AreEqual(response.StatusCode, httpStatusCode);
            Assert.AreEqual(true, response.IsSuccessful);
            return response;

        }
    }
}
