using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleTests.Pages;
using SampleTests.Pages.ToolsQAPages;
using SampleTests.Tests.Base;
using SeleniumBase.Framework.Core.Utils;
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
            ToolsQAElementsPage.CompleteTextBoxFields("Test User","test@user.com","123 test street","456 Another test street");
            PageBase.ClickOnSubmitButton();
        
        }

        [TestMethod]
        public void ClickOnElementsNavTitleAndClickOnCheckBoxes()
        {
            ToolsQAElementsPage.NaviageToElementMenuItem("Check Box");
            PageBase.NavigateToSubMenuItem("Check Box");
            Utils.ClickOnElement(ToolsQAElementsPage.CheckboxHomeDropDown, "Check box DropDown Arrow");
            Utils.ClickOnElement(ToolsQAElementsPage.CheckboxSelection("Home"), "Home Selector");
            Thread.Sleep(3000);
            Utils.ClickOnElement(ToolsQAElementsPage.CheckboxSelection("Desktop"), "Desktop Selector");
            Thread.Sleep(3000);
            Utils.ClickOnElement(ToolsQAElementsPage.CheckboxSelection("Documents"), "Documents Selector");
            Thread.Sleep(3000);
            Utils.ClickOnElement(ToolsQAElementsPage.CheckboxSelection("Downloads"), "Downloads Selector");
            Thread.Sleep(30000);

        }
    }
}
