using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleTests.Pages;
using SampleTests.Pages.ToolsQAPages;
using SampleTests.Tests.Base;
using SeleniumBase.Framework.Core.Utils;
using System.Threading;

namespace SampleTests.Tests.ToolsQATests
{
    [TestClass]
    public class LoadHomePageAndValidateHeader : BaseTest
    {
        [TestMethod]
        public void LoadHomePageValidateHeader()
        {
            Assert.IsTrue(ToolsQAHomePage.HeaderTitle.Displayed, "The Home page does not display correct Title");
        }



     
    }
}
