using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumBase.Framework.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTests.Tests
{
    [TestClass]
    public class APITests
    {

        [TestMethod]

        public void GetAzureRunInformation()
        {
            //AzureDevOpsHelper.GetAllTestPlans();
            AzureDevOpsHelper.GetActiveTestPlan();
        }

    }
}
