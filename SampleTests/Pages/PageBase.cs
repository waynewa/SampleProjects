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

        public static IWebElement HeaderText => Driver.FindElement(By.XPath("///*[@id=\"root\"]/main/section[1]/div/div/div[1]/div[1]/h1"));
        public static IWebElement NavBarItem(string navPage)  => Driver.FindElement(By.LinkText(navPage));

        public static void NavigatePage(string navPage)
        {
            Utils.ClickOnElement(NavBarItem(navPage));
            Thread.Sleep(3000);
        }

    }
}
