
using Customers.Framework.Core.Selenium;
using Customers.Framework.Core.Utils;
using OpenQA.Selenium;
using System;
using System.Diagnostics;

namespace SampleTests.Pages
{
    public class ToolsQAHomePage : PageBase
    {

        public static IWebElement HeaderTitle => Driver.FindElement(By.CssSelector("a[href*='https://demoqa.com']"));
        public static IWebElement NavigationTile(string NavName) => Driver.FindElement(By.XPath($"//h5[contains(text(),'{NavName}')]"));


        public static void ClickOnNavigationByName(string name)
        {
            Debug.WriteLine(NavigationTile(name));
            Utilities.ClickOnElement(NavigationTile(name));
        }
 
    }
}
