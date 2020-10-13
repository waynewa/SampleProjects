using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleTests.Pages;
using SampleTests.Pages.ToolsQAPages;
using SampleTests.Tests.Base;
using System.Threading;

namespace SampleTests.Tests.ToolsQATests
{
    [TestClass]
    public class ToolsQAElementsTests :BaseTest
    {

        [TestMethod]
        public void ClickOnElementsNavTile()
        {
            ToolsQAHomePage.ClickOnNavigationByName("Elements");
            Assert.IsTrue(PageBase.HeaderText.Text == ("Elements"), "The Header does not match the page Header");
            Thread.Sleep(3000);
        }

        [TestMethod]
        public void ClickOnElementsNavTitleAndCompleteElementsTextBoxSample()
        {
            ToolsQAElementsPage.NaviageToElementMenuItem("Text Box");
            PageBase.NavigateToSubMenuItem("Text Box");
            ToolsQAElementsPage.CompleteTextBoxFields("Test User","test@user.com","123 test street","456 onother test street");
            PageBase.ClickOnSubmitButton();
        
        }

    }
}
