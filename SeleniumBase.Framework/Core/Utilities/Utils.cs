﻿using OpenQA.Selenium;
using SeleniumBase.Framework.Core.Selenium;
using static SeleniumBase.Framework.Core.Helpers.LogHelper;

namespace SeleniumBase.Framework.Core.Utils
{
    /// <summary>
    /// This class is used to house all the custome set fuction in the framework  
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// This method allows for the entering of text into a input element.
        /// </summary>
        /// <param name="element">Element to interact with</param>
        /// <param name="value">The value of the text to enter</param>
        public static void SendKeys(IWebElement element, string value)
        {
            element.SendKeys(value);
            Log.Step($"Entered the {value} into the search box");
        }

        /// <summary>
        /// This method allows for a click on a specified element
        /// </summary>
        /// <param name="element">Element to interact with</param>
        public static void ClickOnElement(IWebElement element, string elementDescription = "Element")
        {
            element.Click();
            if (elementDescription == "Element")
            {
                Log.Step($"Clicked on {element.Text}");
            }
            else
            {
                Log.Step($"Clicked on {elementDescription}");
            }
        }

        /// <summary>
        /// Scroll on the page until the given element is found 
        /// </summary>
        /// <param name="element"></param>
        public static void ScrollToElement(IWebElement element)
        {
            Log.Info($"Scrolling to {element.Text}");
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.Current;
            //This will scroll the page till the element is found		
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }


    }
}