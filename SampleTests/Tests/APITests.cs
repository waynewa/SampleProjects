using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using SeleniumBase.Framework.Core.Services;
using System;
using System.Diagnostics;

namespace SampleTests.Tests
{
    [TestClass]
    public class APITests
    {

        [TestMethod]
        public void PassTest()
        {
            AzureApiService.UpdateDevOpsPerTestCasePassed(114360,"2020 Releases","3.1 - DVT");
        }
        [TestMethod]
        public void FailTest()
        {
            AzureApiService.UpdateDevOpsPerTestCaseFailed(114360, "2020 Releases", "3.1 - DVT");
        }
    }
}
