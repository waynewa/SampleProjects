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

            /// Validating that the Contact heading is displayed 
            PageBase.NavigatePage("Contact");
            Assert.AreEqual("Contact Us", PageBase.PageHeading("contact").Text);
            
            /// Validating that the About heading is displayed 
            PageBase.NavigatePage("About");
            Assert.AreEqual("About", PageBase.PageHeading("about").Text);

            /// Validating that the Services heading is displayed 
            PageBase.NavigatePage("Services");
            Assert.AreEqual("Services", PageBase.PageHeading("services").Text);


        }
    }
}
