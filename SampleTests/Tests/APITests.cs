using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumBase.Framework.Core.Helpers;

namespace SampleTests.Tests
{
    [TestClass]
    public class APITests
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
