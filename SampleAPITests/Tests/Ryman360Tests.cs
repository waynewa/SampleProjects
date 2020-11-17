using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumBase.Framework.Core.Services;
using System.Diagnostics;
using SeleniumBase.Framework.Core.Selenium;
using SampleAPITests.Tests.Base;
using SeleniumBase.Framework.Core.Helpers;
using System.Threading;
using AngleSharp;
using Newtonsoft.Json.Linq;
using System.Net;
using SampleAPITests.Tests.Ryman360APICalls;

namespace SampleAPITests.Tests
{
    [TestClass]
    public class Ryman360Tests : BaseAPITest
    {
        
       


        [TestMethod]
        public void GetPagesList()
        {
            Ryman360API.GetPagesList(AccessToken);

        }

        [TestMethod]
        public void PostNewPage()
        {
            Ryman360API.PostNewManagementPage(AccessToken);
        }
    }
}
