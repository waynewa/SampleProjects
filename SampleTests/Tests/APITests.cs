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
            // AzureApiService.GetAllTestPlans();
            // Debug.WriteLine($"The Tesplan Id is : {AzureApiService.GetTestPlanIdByName("2020 Sprints")}");
            // AzureApiService.GetRunResults(1118580);
            AzureApiService.GetTestPoints();
        }

    }
}
