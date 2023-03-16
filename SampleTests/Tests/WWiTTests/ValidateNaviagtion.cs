using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleTests.Pages;
using SampleTests.Tests.Base;


namespace SampleTests.Tests.WWiTTests
{
    [TestClass]
    public class ValidateNaviagtion : BaseTest
    {


        [TestMethod]
        public void ClickOnContactNavigationLink() {

            PageBase.NavigatePage("Contact");
            Assert.IsTrue(WWiTContactPage.ContactTitle.Displayed, "Contact");

        }
    }
}
