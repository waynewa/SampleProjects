using OpenQA.Selenium;
using SeleniumBase.Framework.Core.Selenium;
using SeleniumBase.Framework.Core.Utils;

namespace SampleTests.Pages.ToolsQAPages
{

    /// <summary>
    /// This is the class for the ToolsQA FormsPage, all items linked to the froms page
    /// that are not shared with other pages are listed in this page 
    /// </summary>
    public class ToolsQAFormsPage : PageBase
    {
        /// Element Identification functions. 
        /// Allows for elements on the page to be Identified and utilized.
        /// </summary>
        public static IWebElement NavigationFormMenuItem => Driver.FindElement(By.XPath("//body/div[@id='app']/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/span[1]/div[1]"));
        public static IWebElement PracticeFormMenuItem => Driver.FindElement(By.XPath("//span[contains(text(),'Practice Form')]"));
        public static IWebElement FirstNameInputField => Driver.FindElement(By.CssSelector("#firstName"));
        public static IWebElement LastNameInputField => Driver.FindElement(By.CssSelector("#lastName"));
        public static IWebElement EmailInputField => Driver.FindElement(By.CssSelector("#userEmail"));
        public static IWebElement GenderRadioButton(string gender) => Driver.FindElement(By.XPath($"//label[contains(text(),'{gender}')]"));
        public static IWebElement MobileInputField => Driver.FindElement(By.CssSelector("#userNumber"));
        public static IWebElement DateOfBirthInputField => Driver.FindElement(By.CssSelector("#dateOfBirthInput")); 
        public static IWebElement SubjectsInputField => Driver.FindElement(By.XPath("//body/div[@id='app']/div[1]/div[1]/div[2]/div[2]/div[1]/form[1]/div[6]/div[2]/div[1]/div[1]/div[1]"));
        public static IWebElement HobbiesCheckBox(string hobby) => Driver.FindElement(By.XPath($"//label[contains(text(),'{hobby}')]"));
        public static IWebElement SelectPicture => Driver.FindElement(By.XPath(""));
        public static IWebElement AddressInputTextBox => Driver.FindElement(By.XPath("//textarea[@id='currentAddress']"));
        public static IWebElement StateDropDown => Driver.FindElement(By.XPath("//body/div[@id='app']/div[1]/div[1]/div[2]/div[2]/div[1]/form[1]/div[10]/div[2]/div[1]/div[1]/div[2]/div[1]/*[1]"));
        public static IWebElement StateItemSelection(string stateValue) => Driver.FindElement(By.XPath($"//div[contains(text(),'{stateValue}')]"));
        public static IWebElement CityDropDown => Driver.FindElement(By.XPath("//body/div[@id='app']/div[1]/div[1]/div[2]/div[2]/div[1]/form[1]/div[10]/div[3]/div[1]/div[1]/div[2]/div[1]/*[1]"));
        public static IWebElement CityItemSelection(string cityValue) => Driver.FindElement(By.XPath($"//div[contains(text(),'{cityValue}')]"));
        public static IWebElement SubmitButton => Driver.FindElement(By.CssSelector("#submit"));

     


        public static void NavigateToPracticeForm()
        {
            Utils.ClickOnElement(NavigationFormMenuItem);
            Utils.ClickOnElement(PracticeFormMenuItem);
        }
        public static void CompletePraticeForm()
        {
            //4. Complete Student Registration form
            Utils.SendKeys(FirstNameInputField,"Tester_FirstName");
            Utils.SendKeys(LastNameInputField,"Tester_LastName");
            Utils.ClickOnElement(GenderRadioButton("Male"));
            Utils.SendKeys(MobileInputField,"0272222222");
            Utils.ClickOnElement(HobbiesCheckBox("Music"));
            Utils.SendKeys(AddressInputTextBox,"123 test Road");
            Utils.ClickOnElement(StateDropDown);
            Utils.ClickOnElement(StateItemSelection("Uttar Pradesh"));
            Utils.ClickOnElement(CityDropDown);
            Utils.ClickOnElement(CityItemSelection("Agra"));
            Utils.ScrollToElement(SubmitButton);
            Driver.Wait.WaitForElementToBeDisplayed(SubmitButton);
            Utils.ClickOnElement(SubmitButton);
        }
    }


}
