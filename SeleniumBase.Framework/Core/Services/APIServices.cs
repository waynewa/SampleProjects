﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
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
        
        /// <summary>
        /// Post request using the RestSharp Api services
        /// </summary>
        /// <param name="Uri">URL used to connect to DevOps Server</param>
        /// <param name="endPoint">Api call end point</param>
        /// <param name="body">Body used in the json request</param>
        /// <returns>Response generated by request</returns>
        public static IRestResponse Post(string Uri, string endPoint, JObject body)
        {
            var client = new RestClient(Uri);
            client.Authenticator = new HttpBasicAuthenticator("", PAT);
            var request = new RestRequest(endPoint, Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Post(request);
            
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(true, response.IsSuccessful);
            return response;
        }

        /// <summary>
        /// Get request using the RestSharp Api services
        /// </summary>
        /// <param name="Uri">URL used to connect to DevOps Server</param>
        /// <param name="endPoint">Api call end point</param>
        /// <param name="body">Body used in the json request</param>
        /// <returns>Response generated by request</returns>
        public static IRestResponse Get(string Uri, string endPoint, JObject body)
        {
            var client = new RestClient(Uri);
            client.Authenticator = new HttpBasicAuthenticator("", PAT);
            var request = new RestRequest(endPoint, Method.GET);
            request.AddParameter("application/json", body);
            var response = client.Get(request);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(true, response.IsSuccessful);
            return response;
        }

        /// <summary>
        /// Put request using the RestSharp Api services
        /// </summary>
        /// <param name="Uri">URL used to connect to DevOps Server</param>
        /// <param name="endPoint">Api call end point</param>
        /// <param name="body">Body used in the json request</param>
        /// <returns>Response generated by request</returns>
        public static IRestResponse Put(string Uri, string endPoint, JObject body)
        {
            var client = new RestClient(Uri);
            client.Authenticator = new HttpBasicAuthenticator("", PAT);
            var request = new RestRequest(endPoint, Method.PUT);
            Debug.WriteLine(body.ToString());
            request.AddParameter("application/json", body);
            var response = client.Put(request);

            Assert.AreEqual(true, response.IsSuccessful);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            return response;
        }

        /// <summary>
        /// Patch request using the RestSharp Api services
        /// </summary>
        /// <param name="Uri">URL used to connect to DevOps Server</param>
        /// <param name="endPoint">Api call end point</param>
        /// <param name="body">Body used in the json request</param>
        /// <returns>Response generated by request</returns>
        public static IRestResponse Patch(string Uri, string endPoint, JObject body)
        {
            var client = new RestClient(Uri);
            client.Authenticator = new HttpBasicAuthenticator("", PAT);
            var request = new RestRequest(endPoint, Method.PATCH);
            Debug.WriteLine(body.ToString());
            request.AddParameter("application/json", body);
            var response = client.Patch(request);

            Assert.AreEqual(true, response.IsSuccessful);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            return response;
        }

        /// <summary>
        /// Delete request using the RestSharp Api services
        /// </summary>
        /// <param name="Uri">URL used to connect to DevOps Server</param>
        /// <param name="endPoint">Api call end point</param>
        /// <returns>Response generated by request</returns>
        public static IRestResponse Delete(string Uri, string endPoint)
        {
            var client = new RestClient(Uri);
            client.Authenticator = new HttpBasicAuthenticator("", PAT);
            var request = new RestRequest(endPoint, Method.DELETE);
            var response = client.Delete(request);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.NoContent);
            Assert.AreEqual(true, response.IsSuccessful);
            return response;
        }
    }
}
  
