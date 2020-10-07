using Customers.Framework.Core.Selenium;
using Customers.Framework.Core.Utils;
using OpenQA.Selenium;
using static Customers.Framework.Core.Helpers.LogHelper;

namespace SampleTests.Pages
{
    /// <summary>
    /// This is the class for the ToolsQA HomePage, all items linked to the home page
    /// that are not shared with other pages are listed in this page 
    /// </summary>
    public class ToolsQAHomePage : PageBase
    {
        /// <summary>
        /// Element Identification functions. 
        /// Allows for elements on the page to be Identified and utilized.
        /// </summary>
        public static IWebElement HeaderTitle => Driver.FindElement(By.CssSelector("a[href*='https://demoqa.com']"));
        public static IWebElement NavigationTile(string NavName) => Driver.FindElement(By.XPath($"//h5[contains(text(),'{NavName}')]"));

        /// <summary>
        /// This method will click on the Navigation link by Name defiend in parameter "name"
        /// </summary>
        /// <param name="navigationLinkName">Name of navigation link</param>
        public static void ClickOnNavigationByName(string navigationLinkName)
        {
            Log.Info(NavigationTile(navigationLinkName).Text);
            Utils.ClickOnElement(NavigationTile(navigationLinkName));
        }

    }
}
