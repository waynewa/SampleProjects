using Customers.Framework.Core.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleTests.Tests.Base
{
    public class BaseTest
    {

        [TestInitialize]
        public void TestInit()
        {
            Driver.Init(WebBrowser.Edge);
            Driver.Goto("https://demoqa.com");
        }

        [TestCleanup]
        public void TestClean()
        {
            Driver.Current.Quit();
        }

    }
}
