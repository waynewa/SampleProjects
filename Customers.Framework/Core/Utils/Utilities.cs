using Customers.Framework.Core.Selenium;
using OpenQA.Selenium;
using System;


namespace Customers.Framework.Core.Utils
{
    public static class Utilities
    {
        public static void SendKeysToSearchBox(IWebElement element, string value)
        {
            Driver.WaitforVisibiltyOfElement(element);
            element.SendKeys(value);
            Console.WriteLine($"Entered the {value} into the search box");
        }

        public static void ClickOnElement(IWebElement element)
        {
            Driver.WaitforVisibiltyOfElement(element);
            element.Click();
            Console.WriteLine($"Clicked on {element.Text}");
        }


    }
}
