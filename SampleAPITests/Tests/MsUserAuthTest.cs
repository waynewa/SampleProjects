using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumBase.Framework.Core.Services;
using System.Diagnostics;
using SeleniumBase.Framework.Core.Selenium;
using SampleAPITests.Tests.Base;

namespace SampleAPITests.Tests
{
    [TestClass]
    public class MsUserAuthTest : BaseAPITest
    {
        private static string MSUrl = "https://login.microsoftonline.com/";
        private static string TenantId = "c92c5826-4969-414a-a289-1409683ebac0";
        private static string ClientId = "0603f71f-37ac-4945-87df-e40f050e049d";
        private static string AuthEndPoint = "/oauth2/v2.0/authorize";
        private static string TokenEndPoint = "/oauth2/v2.0/token";
        private static string Scope = "http://OAuth-Ryman360-Dev/project.read";
        private static string State = "";
        private static string RedirectUrl = "https://appsvc-ryman360-dev-syd-backend-testpoc.azurewebsites.net/docs/oauth2-redirect.html";
        private static string Ryman360Url = "https://appsvc-ryman360-dev-syd-backend-testpoc.azurewebsites.net/api/pages:listTiles";
        private static string TokenString = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6ImtnMkxZczJUMENUaklmajRydDZKSXluZW4zOCJ9.eyJhdWQiOiIwNjAzZjcxZi0zN2FjLTQ5NDUtODdkZi1lNDBmMDUwZTA0OWQiLCJpc3MiOiJodHRwczovL2xvZ2luLm1pY3Jvc29mdG9ubGluZS5jb20vYzkyYzU4MjYtNDk2OS00MTRhLWEyODktMTQwOTY4M2ViYWMwL3YyLjAiLCJpYXQiOjE2MDU0ODAyMDEsIm5iZiI6MTYwNTQ4MDIwMSwiZXhwIjoxNjA1NDg0MTAxLCJhaW8iOiJBVFFBeS84UkFBQUE2cjNBQmlVeDZFb1Vic0ZMVkNXNTV4TTZSK1VTY0ptUzlvcmxEMkF2a2JKUWtONlVwcG1SMCt2VnRRMlorNm00IiwiYXpwIjoiMDYwM2Y3MWYtMzdhYy00OTQ1LTg3ZGYtZTQwZjA1MGUwNDlkIiwiYXpwYWNyIjoiMCIsIm5hbWUiOiJXYXluZSBXYWxzaCIsIm9pZCI6ImI5NDM2YzM3LTU0ZmQtNDFiYi05MWM3LWMwZTYyNzM2NGRiYyIsInByZWZlcnJlZF91c2VybmFtZSI6IldheW5lLldhbHNoQHJ5bWFuaGVhbHRoY2FyZS5jb20iLCJyaCI6IjAuQUFBQUpsZ3N5V2xKU2tHaWlSUUphRDY2d0JfM0F3YXNOMFZKaDlfa0R3VU9CSjFuQUcwLiIsInNjcCI6InByb2plY3QucmVhZCIsInN1YiI6ImQ3dThmVE5QM2VqeHZLRy1HN3lYVzQxX3lFbm4zajJtbEJKVnBRejhIeW8iLCJ0aWQiOiJjOTJjNTgyNi00OTY5LTQxNGEtYTI4OS0xNDA5NjgzZWJhYzAiLCJ1cG4iOiJXYXluZS5XYWxzaEByeW1hbmhlYWx0aGNhcmUuY29tIiwidXRpIjoiTUlBNFktcUdsRUt6UElGWVAzcERBQSIsInZlciI6IjIuMCJ9.F-FuMcLdUfZycpVA4dVqLw5OzQXuMdGRT15KBvqdBXEtu-MHgzmVgRL03SRixsUCu2uTYAT1QEJYuInRjHHuND2juK6MiYChB0Db1NmFe4LudSJ6FDq5Z64g3L_jZybe1Qy2c4mK3sc981ecvECA30B4HlNbfFE7IXhXGB-XYdWwP5-6mtwzdaFToRFyLpvUTAng2dVMnFj4HZgrfNvEmTX-lrdlJRN_eNDBoYYdrKo64af3SccbA4WbrRxXbHbmKDABYUQmi-w5xm77nBG5-Y3V7mroRzyJLVglBxhMbubP3cuKzjhPkFXCI-sOpmA4iVnkbeH0g4VE284lOyoR1g";
        

        [TestMethod]
        public void AuthRyman360()
        {
            string endPointRequest = $"?client_id={ClientId}&response_type=code&redirect_uri={RedirectUrl}&response_mode=query&scope={Scope}&state={State}";
            var BaseURL = MSUrl + TenantId + AuthEndPoint+ endPointRequest;
           
            Driver.Goto(BaseURL);
            Driver.WaitForPageLoad(10);
            
        }

        [TestMethod]
        public void GetPagesList()
        {
            var response = GenericAPICalls.Get(Ryman360Url, TokenString);
            Debug.WriteLine(response.Content);

        }
    }
}
