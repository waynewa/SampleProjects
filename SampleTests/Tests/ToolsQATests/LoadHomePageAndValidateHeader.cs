using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleTests.Pages;
using SampleTests.Pages.ToolsQAPages;
using SampleTests.Tests.Base;

namespace SampleTests.Tests.ToolsQATests
{
    [TestClass]
    public class LoadHomePageAndValidateHeader : BaseTest
    {
        [TestMethod]
        public void LoadHomePageValidateHeader()
        {
            Assert.IsTrue(ToolsQAHomePage.HeaderTitle.Displayed,"The Home page does not display correct Title");
        }

        [TestMethod]
        public void ClickOnElementsNavTile()
        {
            ToolsQAHomePage.ClickOnNavigationByName("Elements");
            Assert.IsTrue(PageBase.HeaderText.Text == ("Elements"), "The Header does not match the page Header");
        }
    }
}
