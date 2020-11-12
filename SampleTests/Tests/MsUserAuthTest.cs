using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumBase.Framework.Core.Helpers;
using Microsoft.Identity.Client;

namespace SampleTests.Tests
{
    [TestClass]
    public class MsUserAuthTest
    {
        private static string AuthUrl = "https://login.microsoftonline.com/c92c5826-4969-414a-a289-1409683ebac0/oauth2/v2.0/authorize";
      [TestMethod]
        public async void MsLoginTest()
        {
           await MicrosoftLoginHelper.GetATokenForMSUser(AuthUrl);


        }

    }
}
