using SeleniumBase.Framework.Core.Selenium;
using SeleniumBase.Framework.Core.Utils;
using OpenQA.Selenium;
using static SeleniumBase.Framework.Core.Helpers.LogHelper;
using System.Threading;

namespace SampleTests.Pages
{
    /// <summary>
    /// This is the class for the WWiT HomePage, all items linked to the home page
    /// that are not shared with other pages are listed in this page 
    /// </summary>
    public class WWiTHomePage : PageBase
    {
        /// <summary>
        /// Element Identification functions. 
        /// Allows for elements on the page to be Identified and utilized.
        /// </summary>
        public static IWebElement HeaderTitle => Driver.FindElement(By.XPath("//h1[@data-testid='heading_home']"));
        public static IWebElement NavigationTile(string NavName) => Driver.FindElement(By.LinkText(NavName));

        ///// <summary>
        ///// This method will click on the Navigation link by Name defiend in parameter "name"
        ///// </summary>
        ///// <param name="navigationLinkName">Name of navigation link</param>
        //public static void ClickOnNavigationByName(string navigationLinkName)
        //{
        //    Log.Info(NavigationTile(navigationLinkName).Text);
        //    Utils.ClickOnElement(NavigationTile(navigationLinkName));
        //    Thread.Sleep(3000);

        //}

    }
}
