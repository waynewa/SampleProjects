using SeleniumBase.Framework.Core.Selenium;
using OpenQA.Selenium;
using SeleniumBase.Framework.Core.Utils;
using AventStack.ExtentReports.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System;

namespace SampleTests.Pages.ToolsQAPages
{
    /// <summary>
    /// This is the class for the ToolsQA ElementsPage, all items linked to the elements page
    /// that are not shared with other pages are listed in this page 
    /// </summary>
    public class ToolsQAWidgetsPage : PageBase
    {
        
        /// <summary>
        /// Element Identification functions. 
        /// Allows for elements on the page to be Identified and utilized.
        /// </summary>
        public static IWebElement NavigationElementMenuItem => Driver.FindElement(By.XPath("//body/div[@id='app']/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/span[1]/div[1]/div[1]"));
        
        public static IWebElement FullNameInputField => Driver.FindElement(By.CssSelector("#userName"));
        public static IWebElement EmailInputField => Driver.FindElement(By.CssSelector("#userEmail"));
        public static IWebElement CurrentAddressTextBox => Driver.FindElement(By.CssSelector("#currentAddress"));
        public static IWebElement PermanentAddressTextBox => Driver.FindElement(By.CssSelector("#permanentAddress"));
        


        public static void NaviageToElementMenuItem(string subMenuItem)
        {
            ToolsQAHomePage.ClickOnNavigationByName("Elements");
            Assert.IsTrue(HeaderText.Text == ("Elements"), "The Header does not match the page Header");
            Thread.Sleep(3000);
            if (!SubMenuItem(subMenuItem).Displayed)
            {
                Utils.ClickOnElement(NavigationElementMenuItem, "Navigation Item 'Elements'");
            }
            else 
            {
                Console.WriteLine("Menu already expanded");
            }
        }

        public static void CompleteTextBoxFields(string fullName,string eMail, string currectAddress, string permanentAddress)
        {

                Utils.SendKeys(FullNameInputField, fullName);
                Assert.AreEqual(Utils.ReturnTextFromElement(FullNameInputField), fullName);
                Utils.SendKeys(EmailInputField, eMail);
                Assert.AreEqual(Utils.ReturnTextFromElement(EmailInputField) , eMail);
                Utils.SendKeys(CurrentAddressTextBox, currectAddress);
                Assert.AreEqual(Utils.ReturnTextFromElement(CurrentAddressTextBox) , currectAddress);
                Utils.SendKeys(PermanentAddressTextBox, permanentAddress);
                Assert.AreEqual(Utils.ReturnTextFromElement(PermanentAddressTextBox) , permanentAddress);

        }



    }
}

