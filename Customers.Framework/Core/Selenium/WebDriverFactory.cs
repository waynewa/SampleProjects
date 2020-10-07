using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Customers.Framework.Core.Selenium
{
    public class WebDriverFactory
    {
        IWebDriver Driver;
        /// <summary>
        /// Initilizes IWebDriver based on the given WebBrowser name.
        /// </summary>
        /// <param name="name">Browser name i.e.: Chrome</param>
        /// <returns></returns>
        public IWebDriver CreateWebDriver(WebBrowser name)
        {
            switch (name)
            {
                case WebBrowser.Firefox:
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    Driver = new FirefoxDriver();
                    return Driver;
                case WebBrowser.Edge:
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    Driver = new EdgeDriver();
                    return Driver;
                case WebBrowser.InternetExplorer:
                    new DriverManager().SetUpDriver(new InternetExplorerConfig());
                    Driver = new InternetExplorerDriver();
                    return Driver;
                case WebBrowser.Remote:
                    return null;
                case WebBrowser.Chrome:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    ChromeOptions options = new WebDriverOptions().GetChromeOptions();
                    Driver = new ChromeDriver(options);
                    return Driver;
                default:
                    Assert.Fail("Unable to select valid browser");
                    return null;
            }
        }
    }

    /// <summary>
    /// Enumaratble values of the WebBrowser types
    /// </summary>
    public enum WebBrowser
    {
        Edge,
        InternetExplorer,
        Firefox,
        Chrome,
        Remote
    }
}