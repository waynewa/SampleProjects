using SeleniumBase.Framework.Core.Selenium;
using OpenQA.Selenium;
using SampleTests.Pages.ToolsQAPages;
using SeleniumBase.Framework.Core.Utils;

namespace SampleTests.Pages
{
    public abstract class PageBase
    {
        public readonly ToolsQAHomePage homePage;
        public readonly ToolsQAElementsPage elementsPage;
        public readonly ToolsQAFormsPage formsPage;

        public PageBase()
        {
            homePage = new ToolsQAHomePage();
            elementsPage = new ToolsQAElementsPage();
            formsPage = new ToolsQAFormsPage();
        }

        public static IWebElement HeaderText => Driver.FindElement(By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[1]"));
        public static IWebElement SubMenuItem(string menuItem) => Driver.FindElement(By.XPath($"//span[contains(text(),'{menuItem}')]"));

        public static void NavigateToSubMenuItem(string menuItem)
        {
            Utils.ClickOnElement(SubMenuItem(menuItem));
        }
    }
}
