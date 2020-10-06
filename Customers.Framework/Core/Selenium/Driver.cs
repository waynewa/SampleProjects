using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Customers.Framework.Core.Selenium
{
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;
        private static WebDriverWait wait;

        public static void Init(WebBrowser webBrowser)
        {
            _driver = new WebDriverFactory().CreateWebDriver(webBrowser);
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("Driver is Null");

        public static void Goto(string url)
        {
            if (!url.StartsWith("http"))
            {
                url = $"http://{url}";
            }
            Debug.WriteLine(url);
            Current.Navigate().GoToUrl(url);
            Thread.Sleep(1000);
        }

        public static IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
        }

        public static IList<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }

        public static void WaitforVisibiltyOfElement(IWebElement element, int waitTime = 10)
        {
            wait = new WebDriverWait(Current, TimeSpan.FromSeconds(waitTime));
            wait.Until(driver => element.Displayed);
        }

        public static void WaitforEnaledOfElement(IWebElement element, int waitTime = 10)
        {
            wait = new WebDriverWait(Current, TimeSpan.FromSeconds(waitTime));
            wait.Until(driver => element.Enabled);
        }
    }
}
