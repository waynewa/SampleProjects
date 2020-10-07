using Customers.Framework.Core.Selenium;
using OpenQA.Selenium;
using System;


namespace Customers.Framework.Core.Utils
{
    public static class Utilities
    {
        public static void SendKeysToSearchBox(IWebElement element, string value)
        {
            element.SendKeys(value);
            FW.Log.Info($"Entered the {value} into the search box");
        }

        public static void ClickOnElement(IWebElement element)
        {
            element.Click();
            FW.Log.Info($"Clicked on {element.Text}");
        }
    }
}
