using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using static SeleniumBase.Framework.Core.Helpers.LogHelper;

namespace SeleniumBase.Framework.Core.Selenium
{
    public static class Driver
    {
        /// <summary>
        /// The Thread Static tag allows for paralization.
        /// </summary>
        [ThreadStatic]
        //Initial instantiation of the Selenium WebDriver 
        private static IWebDriver _driver;

        /// <summary>
        /// The Thread Static tag allows for paralization.
        /// </summary>
        [ThreadStatic]
        //Initial instatiation of the WebDriverWait Function
        public static Wait Wait;

        /// <summary>
        /// Initializing the Webdriver with parameter 'webBrowser', this sets the browser type i.e.: Chorme
        /// </summary>
        /// <param name="webBrowser">Browser Type i.e.: Chrome,Edge</param>
        public static void Init(WebBrowser webBrowser)
        {
            _driver = new WebDriverFactory().CreateWebDriver(webBrowser);
            Wait = new Wait(30);
            Log.Info("Driver Initialization Complete");
        }
        /// <summary>
        /// Currnet driver session utilized at the time
        /// </summary>
        public static IWebDriver Current => _driver ?? throw new NullReferenceException("Driver is Null");

        /// <summary>
        /// Navigates to the specified URL : 
        /// </summary>
        /// <param name="url">String Url value</param>
        public static void Goto(string url)
        {
            if (!url.StartsWith("http"))
            {
                url = $"http://{url}";
            }
            Current.Navigate().GoToUrl(url);
            Log.Step($"Navigating to URL : {url}");
        }

        /// <summary>
        /// Find Element fucntion for custom driver functionality, finds single element 
        /// </summary>
        /// <param name="by">Element identifier</param>
        /// <returns></returns>
        public static IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
        }

        /// <summary>
        /// Find Elements fucntion for custom driver functionality, finds multiple elements
        /// </summary>
        /// <param name="by">Element identifier</param>
        public static IList<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }

        /// <summary>
        /// Retrieves the current page title
        /// </summary>
        /// <returns>Page title</returns>
        public static string Title()
        {
            return Current.Title;
        }
        /// <summary>
        /// Waits for the current page to load with configurable wait time 
        /// </summary>
        /// <param name="pageWaitTime">Interger wait time in seconds</param>
        public static void WaitForPageLoad(int pageWaitTime)
        {
            Log.Info($"Waiting {pageWaitTime} seconds for the page to load ");
            Current.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageWaitTime);
        }

        /// <summary>
        /// Browser session close function
        /// </summary>
        public static void Close()
        {
            Current.Close();
            Log.Info("Driver Session Closed");
        }

        /// <summary>
        /// WebDriver Quit function
        /// </summary>
        public static void Quit()
        {
            Current.Quit();
            Log.Info("Quit Driver Session");
        }
    }
}
