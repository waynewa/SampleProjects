using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleTests.Pages;
using SampleTests.Tests.Base;

namespace SampleTests.Tests.WWiTTests
{
    [TestClass]
    public class LoadHomePageAndValidateHeader : BaseTest
    {
        [TestMethod]
        public void LoadHomePageValidateHeader()
        {

            Assert.IsTrue(WWiTHomePage.HeaderTitle.Displayed, "Welcome To WWiT");
        }

    }
}
