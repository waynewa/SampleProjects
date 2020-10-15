using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleTests.Pages;
using SampleTests.Pages.ToolsQAPages;
using SampleTests.Tests.Base;
using SeleniumBase.Framework.Core.Utils;
using System;
using System.Threading;

namespace SampleTests.Tests.ToolsQATests
{
    [TestClass]
    public class ToolsQAWidgetsTests : BaseTest
    {

        [TestMethod]
        public void ClickOnWidgetsNavTile()
        {
            ToolsQAHomePage.ClickOnNavigationByName("Widgets");
            Assert.IsTrue(PageBase.HeaderText.Text == ("Widgets"), "The Header does not match the page Header");
            Thread.Sleep(3000);
        }



    }
}
