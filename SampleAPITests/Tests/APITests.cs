using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using SampleAPITests.Tests.Base;
using SeleniumBase.Framework.Core.Services;
using System;
using System.Net;

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
            Assert.IsTrue(display.Contains("id"));
            Assert.IsTrue(display.Contains("email"));
            WriteStepToLogs($"Response : {display}");
        }
    }
}
