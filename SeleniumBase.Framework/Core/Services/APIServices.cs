using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using SeleniumBase.Framework.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using static SeleniumBase.Framework.Core.Helpers.LogHelper;


namespace SeleniumBase.Framework.Core.Services
{  
     /// <summary>
     /// This services Class requires some refactoring as it is only
     /// exsample indications at the moment
     /// </summary>
    public static class APIServices
    {
        public static IRestResponse Post(string Uri,string endPoint,string body)
        {
            var client = new RestClient(Uri);
            var request = new RestRequest(endPoint,Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type","application/json");
            request.AddJsonBody(body);
            

            var response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine(content);
            Assert.AreEqual(200,response.StatusCode);
            return response;
        }


    }
    }
