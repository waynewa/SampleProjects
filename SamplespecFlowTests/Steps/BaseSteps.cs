using SeleniumBase.Framework.Core.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplespecFlowProject.Steps
{
    [Binding]
    public class BaseSteps
    {
        

        [BeforeTestRun]
        public static void InitializeTest()
        {
          

        }



        [StepDefinition("I navigate to the \"(.*)\"")]
        public void NavigateToUrl(string navigationUrl) {

            Driver.Init("Chrome", false);
            Driver.Goto(navigationUrl);
        }

        [Then("I expect to see the \"(.*)\"")]
        public void ValidateMessage(String message) { 
        
        }

        [AfterTestRun]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
