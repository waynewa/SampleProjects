using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleAPITests.Tests.Base;
using SampleAPITests.Tests.Ryman360APICalls;
using System;

namespace SampleAPITests.Tests
{

    [TestClass]
    public class Ryman360Tests : BaseAPITest
    {
        
        public static string PageId = "X7QaWps3uQbwxmX7";


        [TestMethod]
        public void GetPagesList()
        {
            Ryman360API.GetPagesList(AccessToken);
        }

        [TestMethod]
        public void PostNewManagementPage()
        {
          PageId = Ryman360API.PostNewManagementPage(AccessToken,$"Automating Ryman360{RandomNumber(10,999)}");
        }

        public void GetManagementPageById()
        {
            Ryman360API.GetManagementPageByID(AccessToken, PageId);
        }

        [TestMethod]
        public void GetPageListTree()
        {
            Ryman360API.GetPagesListTree(AccessToken,false);
        }


        [TestMethod]
        public void DeleteManagementPageById()
        {
            Ryman360API.DeleteManagementPageById(AccessToken, PageId);
        }

        [TestMethod]
        public void SoftDeleteManagementPageById()
        {
            Ryman360API.SoftDeleteManagementPageById(AccessToken, PageId);
        }

        [TestMethod]
        public void UnDeleteManagementPageById()
        {
            Ryman360API.UnDeleteManagementPageById(AccessToken, PageId);
        }

        private readonly Random _random = new Random();

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
