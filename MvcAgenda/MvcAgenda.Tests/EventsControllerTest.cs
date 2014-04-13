using MvcAgenda.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using Moq;
using MvcAgenda.Domain.Entities;
using MvcAgenda.Domain.Abstract;
using System.Linq;
using System.Collections.Generic;
using MvcAgenda.Models;

namespace MvcAgenda.Tests
{
    
    
    /// <summary>
    ///This is a test class for EventsControllerTest and is intended
    ///to contain all EventsControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EventsControllerTest
    {


       // private TestContext testContextInstance;

        ///// <summary>
        /////Gets or sets the test context which provides
        /////information about and functionality for the current test run.
        /////</summary>
        //public TestContext TestContext
        //{
        //    get
        //    {
        //        return testContextInstance;
        //    }
        //    set
        //    {
        //        testContextInstance = value;
        //    }
        //}

        //#region Additional test attributes
        //// 
        ////You can use the following additional attributes as you write your tests:
        ////
        ////Use ClassInitialize to run code before running the first test in the class
        ////[ClassInitialize()]
        ////public static void MyClassInitialize(TestContext testContext)
        ////{
        ////}
        ////
        ////Use ClassCleanup to run code after all tests in a class have run
        ////[ClassCleanup()]
        ////public static void MyClassCleanup()
        ////{
        ////}
        ////
        ////Use TestInitialize to run code before running each test
        ////[TestInitialize()]
        ////public void MyTestInitialize()
        ////{
        ////}
        ////
        ////Use TestCleanup to run code after each test has run
        ////[TestCleanup()]
        ////public void MyTestCleanup()
        ////{
        ////}
        ////
        //#endregion


        ///// <summary>
        /////A test for Create
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        //[TestMethod()]
        //[HostType("ASP.NET")]
        //[AspNetDevelopmentServerHost("C:\\Users\\Silvia\\Desktop\\dotNetCases\\MvcAgenda\\MvcAgenda", "/")]
        //[UrlToTest("http://localhost:41279/")]
        //public void CreateTest()
        //{
        //    //IEmailSender emailsender = null; // TODO: Initialize to an appropriate value
        //    //EventsController target = new EventsController(emailsender); // TODO: Initialize to an appropriate value
        //    //aevent aevent = null; // TODO: Initialize to an appropriate value
        //    //ActionResult expected = null; // TODO: Initialize to an appropriate value
        //    //ActionResult actual;
        //    //actual = target.Create(aevent);
        //    //Assert.AreEqual(expected, actual);
        //    //Assert.Inconclusive("Verify the correctness of this test method.");
        //}
        aevent[] events;

        //ClassInitialize, ClassCleanup, TestInitialize, TestCleanup
        //It.IsAny<string>(), It.Is<int>(s=>s=="hello"), It.IsInRange<int>), It.IsRegex()
        //AreEqual, AreNotEqual, AreSame (same object), AreNotSame, Fail, Inconclusive, IsTrue, IsFalse, IsNull, IsNotNull, IsInstanceOfType, IsNotInstanceOfType

        [TestInitialize]
        public void preTestInitialize()
        {
            events = new aevent[] { 
                new aevent { id = 1, title = "dentist", user_id=1 }, 
                new aevent { id = 2, title = "interview", user_id=2 },
                new aevent { id = 3, title = "chiro", user_id=1 }, 
                new aevent { id = 4, title = "super" , user_id=2},
                new aevent { id = 5, title = "pharmacy", user_id=1 }
            };
        }


        [TestMethod]
        public void CanSendPaginationViewModel()
        {
            //Arrange
            Mock<IEventRepository> mock = new Mock<IEventRepository>();
            mock.Setup(m => m.Events).Returns(events.AsQueryable());

            EventsController controller = new EventsController(mock.Object);
            controller.pageSize = 3;
            EventsListViewModel result = (EventsListViewModel)controller.Index(null, 2).Model;

            //Assert
            aevent[] eventArray = result.Events.ToArray();
            Assert.IsTrue(eventArray.Length == 2);
            Assert.AreEqual(eventArray[0].id, 5);
            Assert.AreEqual(eventArray[1].id, 4);
            //mock.Verify(m => m.ListUsers(1, 1), Times.AtLeastOnce);
            //Assert.IsTrue(true); 


        }

        [TestMethod]
        public void CanFilterEvents()
        {
            //Arrange
            Mock<IEventRepository> mock = new Mock<IEventRepository>();
            mock.Setup(m => m.Events).Returns(events.AsQueryable());

            EventsController controller = new EventsController(mock.Object);
            controller.pageSize = 3;
            EventsListViewModel result = (EventsListViewModel)controller.Index(2, 1).Model;

            //Assert
            aevent[] eventArray = result.Events.ToArray();
            Assert.IsTrue(eventArray.Length == 2);
            Assert.AreEqual(eventArray[0].id, 2);
            Assert.AreEqual(eventArray[1].id, 4);
            //mock.Verify(m => m.ListUsers(1, 1), Times.AtLeastOnce);
            //Assert.IsTrue(true); 


        }

    }
}
