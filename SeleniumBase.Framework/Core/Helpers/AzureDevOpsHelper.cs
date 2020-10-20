using AventStack.ExtentReports.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using Newtonsoft.Json;
using RestSharp;
using SeleniumBase.Framework.Core.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBase.Framework.Core.Helpers
{[TestClass]
    public class AzureDevOpsHelper
    {
        private static string TestUrl = "https://postman-echo.com/post";
        private static string TestEndPoint = "/hi/there?hand=wave";

        private static int testPointId;
       [TestMethod]
        public void Post_New_Run()
        {
            var body = new JContent();
            body.foo1 = "bar1";
            body.foo2 = "bar2";

           var response =  APIServices.Get(TestUrl,TestEndPoint,body.ToJson());
           Console.WriteLine($"The Resposne is {response.Content}");
        }
    }
}
