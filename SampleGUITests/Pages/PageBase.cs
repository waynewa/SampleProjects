using SeleniumBase.Framework.Core.Selenium;
using OpenQA.Selenium;
using SeleniumBase.Framework.Core.Utils;
using System.Threading;

namespace SampleTests.Pages
{
    public abstract class PageBase
    {
        public readonly WWiTHomePage homePage;
        public readonly WWiTContactPage contactPage;

        public PageBase()
        {
            homePage = new WWiTHomePage();
            contactPage = new WWiTContactPage();

        }

        public static IWebElement NavBarItem(string navPage)  => Driver.FindElement(By.LinkText(navPage));


        /// <summary>
        /// Element Identification functions. 
        /// Allows for elements on the page to be Identified and utilized.
        /// </summary>
        public static IWebElement PageHeading(string page) => Driver.FindElement(By.XPath($"//h2[@data-testid='heading_{page}']"));

        public static void NavigatePage(string navPage)
        {
            Utils.ClickOnElement(NavBarItem(navPage));
            Thread.Sleep(3000);
        }

    }
}
