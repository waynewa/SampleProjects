using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleTests.Pages;
using SampleTests.Pages.ToolsQAPages;
using SampleTests.Tests.Base;
using SeleniumBase.Framework.Core.Utils;
using System;
using System.Threading;

namespace SampleTests.Tests.ToolsQATests
{
    [TestClass]
    public class ToolsQAFormsTests : BaseTest
    {
        
        [TestMethod]
        public void ClickOnFormsNavTile()
        {
            ToolsQAHomePage.ClickOnNavigationByName("Forms");
            Assert.IsTrue(PageBase.HeaderText.Text == ("Forms"), "The Header does not match the page Header");
            Thread.Sleep(3000);
        }


        [TestMethod]
        public void ClickOnFormsNavTile_Method2()
        {
            Utils.ScrollToElement(ToolsQAHomePage.NavigationTile("Forms"));
            ToolsQAHomePage.NavigationTile("Forms").Click();
            Assert.IsTrue(PageBase.HeaderText.Text == ("Forms"), "The Header does not match the page Header");
            Thread.Sleep(3000);
        }

        [TestMethod]
        public void ClickOnFormsNavTileAndCompletePracticeForm()
        {
            try
            {
                //Steps To Complete Test Case 
                //1. Select the Forms Page Element
                Utils.ScrollToElement(ToolsQAHomePage.NavigationTile("Forms"));
                ToolsQAHomePage.NavigationTile("Forms").Click();
                WriteStepToLogs("Clicking on the Forms Navigation Menu Tile");
                //2. Assert the correct page is loaded 
                Assert.IsTrue(PageBase.HeaderText.Text == ("Forms"), "The Header does not match the page Header");
                WriteStepToLogs("Validated the Page Header");
                //3. Select the Practice Form Menu Item
                Thread.Sleep(3000);
                ToolsQAFormsPage.NavigateToPracticeForm();
                //4. Complete Student Registration form
                ToolsQAFormsPage.CompletePraticeForm();
                            }
            catch (Exception e)
            {
                WriteFailToLogs("Test Failed " + e);
            }

        }
        [TestMethod]
        public void ClickOnFormsNavTileAndCompletePracticeForm_Method2()
        {
            try
            {
                //Steps To Complete Test Case 
                //1. Select the Forms Page Element
                Utils.ScrollToElement(ToolsQAHomePage.NavigationTile("Forms"));
                ToolsQAHomePage.NavigationTile("Forms").Click();
                WriteStepToLogs("Clicking on the Forms Navigation Menu Tile");
                //2. Assert the correct page is loaded 
                Assert.IsTrue(PageBase.HeaderText.Text == ("Forms"), "The Header does not match the page Header");
                WriteStepToLogs("Validated the Page Header");
                //3. Select the Practice Form Menu Item
                Thread.Sleep(3000);
                ToolsQAFormsPage.NavigationFormMenuItem.Click();
                WriteStepToLogs("Clicked on the Navigation Form Menu item");
                ToolsQAFormsPage.PracticeFormMenuItem.Click();
                WriteStepToLogs("Clicked on the 'Practice Form Menu item'");
                //4. Complete Student Registration form
                ToolsQAFormsPage.FirstNameInputField.SendKeys("Tester_FirstName");
                WriteStepToLogs("Entered FirstName Value");
                ToolsQAFormsPage.LastNameInputField.SendKeys("Tester_LastName");
                WriteStepToLogs("Entered LastName Value");
                ToolsQAFormsPage.GenderRadioButton("Male").Click();
                WriteStepToLogs("Selected the Male Radio Button");
                ToolsQAFormsPage.MobileInputField.SendKeys("0272222222");
                WriteStepToLogs("Entered Mobile Number");
                ToolsQAFormsPage.HobbiesCheckBox("Music").Click();
                WriteStepToLogs("Selected the Music hobby checkbox");
                ToolsQAFormsPage.AddressInputTextBox.SendKeys("123 test Road");
                WriteStepToLogs("Entered 123 Test road");
                ToolsQAFormsPage.StateDropDown.Click();
                WriteStepToLogs("Selected the state Dropdown");
                ToolsQAFormsPage.StateItemSelection("Uttar Pradesh").Click();
                WriteStepToLogs("Selected Uttar Pradesh form list");
                ToolsQAFormsPage.CityDropDown.Click();
                WriteStepToLogs("Selected the City Dropdown");
                ToolsQAFormsPage.CityItemSelection("Agra").Click();
                WriteStepToLogs("Selected Agra from list");
                Utils.ScrollToElement(ToolsQAFormsPage.SubmitButton);
                ToolsQAFormsPage.SubmitButton.Click();
                WriteStepToLogs("Clicked the Submit Button");

            }
            catch (Exception e)
            {
                WriteFailToLogs("Test Failed "+ e );
            }



        }

    }
}
