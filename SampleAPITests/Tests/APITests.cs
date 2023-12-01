using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorEngine.Compilation.ImpromptuInterface;
using RestSharp;
using SampleAPITests.Tests.Base;
using SeleniumBase.Framework.Core.Services;
using System;
using System.Diagnostics;
using System.Net;
using System.Text.Json.Nodes;

namespace SampleAPITests.Tests
{
    [TestClass]
    public class APITests : BaseAPITest
    {
        [TestMethod]
        public void PostRequestToDemoURL()
        {
            var Url = TestUrl + Path;
            JsonObject body = new JsonObject();
            //body.Add("property", "[Sites]"); Saple Body to add 

            var response = GenericAPICalls.Post(Url, body, HttpStatusCode.Created);
            WriteStepToLogs($"Response : {response}");
        }

        [TestMethod]
        public void GetRequestToDemoURL()
        {
            var Url = TestUrl + Path;
            var response = GenericAPICalls.Get(Url,  HttpStatusCode.OK);
            var display = response.Content.ToString();
            Debug.WriteLine(display);
            Assert.IsTrue(display.Contains("page"),"Page is not displayed");
            Assert.IsTrue(display.Contains("data"),"Data is not displayed");
            WriteStepToLogs($"Response : {display}");
        }
    }
}
