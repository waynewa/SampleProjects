using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumBase.Framework.Core.Services;
using System.Diagnostics;

namespace SampleTests.Tests
{
    [TestClass]
    public class APITests
    {

        [TestMethod]

        public void GetAzureRunInformation()
        {
            var list = AzurePointsService.GetListOfTestPoints("2020 Releases", "Release #3.5 - Smoke Test - Post Refresh");

            foreach(int id in list)
            {
                Debug.WriteLine(id.ToString());
            }
        }

        [TestMethod]
        public void GetTestPointByTestCaseID()
        {

            AzurePointsService.GetTestPointsByTestCaseId("2020 Releases", "Release #3.5 - Smoke Test - Post Refresh", 91994);

        }
    }
}
