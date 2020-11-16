using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleAPITests.Tests.Base;
using SeleniumBase.Framework.Core.Helpers;

namespace SampleAPITests.Tests
{
    [TestClass]
    public class APITests : BaseAPITest
    {

        [TestMethod]
        public void PassTest()
        {
            AzureDevOpsHelper.PostTestResults(114360,"Passed","2020 Releases","3.1 - DVT");
        }
        [TestMethod]
        public void FailTest()
        {
            AzureDevOpsHelper.PostTestResults(114360,"Failed", "2020 Releases", "3.1 - DVT");
        }
    }
}
