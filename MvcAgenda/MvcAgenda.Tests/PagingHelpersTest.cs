using MvcAgenda.HtmlHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using MvcAgenda.Models;

namespace MvcAgenda.Tests
{
    
    
    /// <summary>
    ///This is a test class for PagingHelpersTest and is intended
    ///to contain all PagingHelpersTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PagingHelpersTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestMethod()]
        public void PageLinksTest()
        {
            HtmlHelper html = null; // TODO: Initialize to an appropriate value
            PagingInfo pagingInfo = new PagingInfo { CurrentPage =2 , TotalItems=28, ItemsPerPage = 10};
            Func<int, string> pageUrl = i => "Page" + i;

            MvcHtmlString actual = html.PageLinks(pagingInfo, pageUrl);

            Assert.AreEqual(actual.ToString(), @"<a href=""Page1"">1</a><a class=""selected"" href=""Page2"">2</a><a href=""Page3"">3</a>");
        }
    }
}
