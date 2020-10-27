using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Diagnostics;
using System.Net;


namespace SeleniumBase.Framework.Core.Services
{
    /// <summary>
    /// This services Class requires some refactoring as it is only
    /// exsample indications at the moment
    /// </summary>
    public static class APIServices
    {
        private static string PAT = "j7c5wxdbimp7ufoz5crmrtsxygaamlv7vbvkgbexwjyfokkurcfa";

        public static IRestResponse Post(string Uri, string endPoint, JObject body)
        {
            var client = new RestClient(Uri);
            client.Authenticator = new HttpBasicAuthenticator("", PAT);
            var request = new RestRequest(endPoint, Method.POST);
            Debug.WriteLine(body.ToString());
            request.AddParameter("application/json", body);
            var response = client.Post(request);
            var content = response.Content;
            Console.WriteLine(content);
            Assert.AreEqual(true, response.IsSuccessful);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            return response;
        }

        public static IRestResponse Get(string Uri, string endPoint, JObject body)
        {
            var client = new RestClient(Uri);
            client.Authenticator = new HttpBasicAuthenticator("", PAT);
            var request = new RestRequest(endPoint, Method.GET);
            request.AddParameter("application/json", body);
            var response = client.Get(request);

            Assert.AreEqual(true, response.IsSuccessful);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            return response;
        }
        public static IRestResponse Put(string Uri, string endPoint, JObject body)
        {
            var client = new RestClient(Uri);
            client.Authenticator = new HttpBasicAuthenticator("", PAT);
            var request = new RestRequest(endPoint, Method.PUT);
            Debug.WriteLine(body.ToString());
            request.AddParameter("application/json", body);
            var response = client.Put(request);
            var content = response.Content;
            Console.WriteLine(content);
            Assert.AreEqual(true, response.IsSuccessful);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            return response;
        }

        public static IRestResponse Patch(string Uri, string endPoint, JObject body)
        {
            var client = new RestClient(Uri);
            client.Authenticator = new HttpBasicAuthenticator("", PAT);
            var request = new RestRequest(endPoint, Method.PATCH);
            Debug.WriteLine(body.ToString());
            request.AddParameter("application/json", body);
            var response = client.Patch(request);
            var content = response.Content;
            Console.WriteLine(content);
            Assert.AreEqual(true, response.IsSuccessful);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            return response;
        }

        public static IRestResponse Delete(string Uri, string endPoint, JObject body)
        {
            var client = new RestClient(Uri);
            client.Authenticator = new HttpBasicAuthenticator("", PAT);
            var request = new RestRequest(endPoint, Method.DELETE);
            Debug.WriteLine(body.ToString());
            request.AddParameter("application/json", body);
            var response = client.Delete(request);
            var content = response.Content;
            Console.WriteLine(content);
            Assert.AreEqual(true, response.IsSuccessful);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            return response;
        }
    }
}
  
