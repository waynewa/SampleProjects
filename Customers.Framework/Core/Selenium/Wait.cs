using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace Customers.Framework.Core.Selenium
{
    public class Wait
    {
        private readonly WebDriverWait _wait;

        public Wait(int waitSeconds)
        {
            _wait = new WebDriverWait(Driver.Current, TimeSpan.FromSeconds(waitSeconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };

            _wait.IgnoreExceptionTypes(
                typeof(NoSuchElementException),
                typeof(ElementNotVisibleException),
                typeof(StaleElementReferenceException)
                );
        }

        public bool Until(Func<IWebDriver, bool> condition)
        {

            return _wait.Until(condition);
        }

        public void WaitForElementToBeDisplayed(IWebElement webElement, string elementDescription = "Element")
        {
            try
            {
                Driver.Wait.Until(driver => webElement.Displayed);
                FW.Log.Info($"The {elementDescription} is Displayed");
            }
            catch (Exception e)
            {
                FW.Log.Error($"Element not Displayed error: {e.Message}");
            }
        }

    }
}
