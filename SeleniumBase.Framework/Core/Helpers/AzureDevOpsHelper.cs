﻿using AventStack.ExtentReports.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
           var body = "{" +
                    "foo1:'" + "bar1'" +
                    "foo2:'" + "bar2'" +
                    "}";
           var response =  APIServices.Post(TestUrl,TestEndPoint,body);
           Console.WriteLine($"The Resposne is {response.Content}");
        }
    }
}