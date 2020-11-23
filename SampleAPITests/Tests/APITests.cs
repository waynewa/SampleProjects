using AzureAPITestCaseUpdate.AzureAPIServices.AzureTestCaseUpdateService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleAPITests.Tests.Base;

namespace SampleAPITests.Tests
{
    [TestClass]
    public class APITests : BaseAPITest
    {

        [TestMethod]
        public void PassTest()
        {
            AzureUpdateTestCase.PostTestResults(
             PAT,
             ServerUrl,
             ProjectName,
             "myRyman - Master",
            "101659 - Progress notes race condition",
            101743,
            "Jun Fernandez",
            "Passed", ApiCallVersion);
        }
        [TestMethod]
        public void FailTest()
        {
            AzureUpdateTestCase.PostTestResults(
             PAT,
             ServerUrl,
             ProjectName,
             "myRyman - Master",
            "101659 - Progress notes race condition",
             101743,
            "Jun Fernandez",
            "Failed", ApiCallVersion);
        }
    }
}
