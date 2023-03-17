using SeleniumBase.Framework.Core.Selenium;
using OpenQA.Selenium;

namespace SampleTests.Pages
{
    /// <summary>
    /// This is the class for the WWiT HomePage, all items linked to the home page
    /// that are not shared with other pages are listed in this page 
    /// </summary>
    public class WWiTContactPage : PageBase
    {
        /// <summary>
        /// Element Identification functions. 
        /// Allows for elements on the page to be Identified and utilized.
        /// </summary>
        public static IWebElement ContactTitle => Driver.FindElement(By.XPath("//*[@id=\"root\"]/main/section/div/div/div/div[1]/h3"));
        
    }
}
