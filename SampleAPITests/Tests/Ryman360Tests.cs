using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleAPITests.Tests.Base;
using SampleAPITests.Tests.Ryman360APICalls;
using System;
using System.Diagnostics;
using System.Net;

namespace SampleAPITests.Tests
{

    [TestClass]
    public class Ryman360Tests : BaseAPITest
    {

        public static string PageId; //"X7MoNps3uQbwxmXy";
                                    //X7MpB5s3uQbwxmXz
                                    //X7Mq35s3uQbwxmX0
                                    //X7M1a5s3uQbwxmX1
                                    //X7M2Yps3uQbwxmX2            

        /// <summary>
        /// Gets a list of published pages
        /// </summary>
        [TestMethod]
        public void GetPagesList()
        {
            Ryman360API.GetPagesList(AccessToken);
        }

        /// <summary>
        /// Completes various basic tasks, e.g.: Create unpublished page and returns 'PageId', gets page deatils per returned 'PageId',
        /// SoftDeletes the page per 'PageId', UnDeletes the page per 'PageId' , finnally deletes the Page per 'PageId'
        /// </summary>
        [TestMethod]
        public void BasicFunctionsLinkedToManagementPages()
        {
            PageId = Ryman360API.PostNewManagementPage(AccessToken, $"Automating Ryman360{RandomNumber(10, 999)}");
            Ryman360API.GetManagementPageByID(AccessToken, PageId, HttpStatusCode.OK);
            Ryman360API.SoftDeleteManagementPageById(AccessToken, PageId);
            Ryman360API.GetManagementPageByID(AccessToken, PageId, HttpStatusCode.NotFound);
            Ryman360API.UnDeleteManagementPageById(AccessToken, PageId);
            Ryman360API.GetManagementPageByID(AccessToken, PageId, HttpStatusCode.OK);
            Ryman360API.DeleteManagementPageById(AccessToken, PageId);
            Ryman360API.GetManagementPageByID(AccessToken, PageId, HttpStatusCode.NotFound);

        }

        /// <summary>
        /// Creates new unpublished management page
        /// </summary>
        [TestMethod]
        public void PostNewManagementPage()
        {
          PageId = Ryman360API.PostNewManagementPage(AccessToken,$"Automating Ryman360{RandomNumber(10,999)}");

        }

        /// <summary>
        /// Gets the management page by 'PageId'
        /// </summary>
        [TestMethod]
        public void GetManagementPageById()
        {
           string etag = Ryman360API.GetManagementPageByID(AccessToken, PageId,HttpStatusCode.OK);
           Debug.WriteLine($"The e-Tag for this page is : {etag}");
        }

        /// <summary>
        /// Gets a list of pages with include deleted flag set to either true or false
        /// </summary>
        [TestMethod]
        public void GetPageListTree()
        {
            Debug.WriteLine("*************Listing Page Ids with include Deleted flag set to 'false'*********");
            Ryman360API.GetPagesListTree(AccessToken,false);
            Debug.WriteLine("*************Listing Page Ids with include Deleted flag set to 'true'**********");
            Ryman360API.GetPagesListTree(AccessToken, true);
        }

        /// <summary>
        /// Deletes a management page by 'PageId'
        /// </summary>
        [TestMethod]
        public void DeleteManagementPageById()
        {
            Ryman360API.DeleteManagementPageById(AccessToken, PageId);
        }

        /// <summary>
        /// Soft deletes a management page by 'PageId'
        /// </summary>
        [TestMethod]
        public void SoftDeleteManagementPageById()
        {
            Ryman360API.SoftDeleteManagementPageById(AccessToken, PageId);
        }

        /// <summary>
        /// UnDeletes a management page by 'PageId'
        /// </summary>
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
