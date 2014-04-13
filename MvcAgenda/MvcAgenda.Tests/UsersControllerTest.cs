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
    ///This is a test class for UsersControllerTest and is intended
    ///to contain all UsersControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UsersControllerTest
    {
//        private TestContext testContextInstance;

//        /// <summary>
//        ///Gets or sets the test context which provides
//        ///information about and functionality for the current test run.
//        ///</summary>
//        public TestContext TestContext
//        {
//            get
//            {
//                return testContextInstance;
//            }
//            set
//            {
//                testContextInstance = value;
//            }
//        }

//        #region Additional test attributes
//        // 
//        //You can use the following additional attributes as you write your tests:
//        //
//        //Use ClassInitialize to run code before running the first test in the class
//        //[ClassInitialize()]
//        //public static void MyClassInitialize(TestContext testContext)
//        //{
//        //}
//        //
//        //Use ClassCleanup to run code after all tests in a class have run
//        //[ClassCleanup()]
//        //public static void MyClassCleanup()
//        //{
//        //}
//        //
//        //Use TestInitialize to run code before running each test
//        //[TestInitialize()]
//        //public void MyTestInitialize()
//        //{
//        //}
//        //
//        //Use TestCleanup to run code after each test has run
//        //[TestCleanup()]
//        //public void MyTestCleanup()
//        //{
//        //}
//        //
//        #endregion


//        /// <summary>
//        ///A test for IsUsernameAvailable
//        ///</summary>
//        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
//        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
//        // whether you are testing a page, web service, or a WCF service.
//        [TestMethod()]
//        [HostType("ASP.NET")]
//        [AspNetDevelopmentServerHost("C:\\Users\\Silvia\\Desktop\\dotNetCases\\MvcAgenda\\MvcAgenda", "/")]
//        [UrlToTest("http://localhost:41279/")]
//        public void IsUsernameAvailableTest()
//        {
//            UsersController target = new UsersController(); // TODO: Initialize to an appropriate value
//            string username = string.Empty; // TODO: Initialize to an appropriate value
//            JsonResult expected = null; // TODO: Initialize to an appropriate value
//            JsonResult actual;
//            actual = target.IsUsernameAvailable(username);
//            Assert.AreEqual(expected, actual);
//            Assert.Inconclusive("Verify the correctness of this test method.");
//        }

//        [TestMethod()]
//        public void IsNewUsernameTest()
//        {
//            //Arrange
//            UsersController target = new UsersController();
//           // Mock<user> muser = new Mock<user>();
//          //  muser.Setup(m=> m.username).Returns("silvia");
//            JsonResult actual;
//            string username = "silvia"; //muser.Object.username; // 

//            //Act
//            actual = target.IsUsernameAvailable(username);
//            //Assert
//            Assert.IsTrue((bool)actual.Data);
//        }

//        [TestMethod()]
//        public void IsUsedUsernameTest()
//        {
//            //Arrange
//            UsersController target = new UsersController();
//          //  Mock<user> muser = new Mock<user>();
//          //  muser.Setup(m => m.username).Returns("!!!!!!!!!");
//            JsonResult actual;
//            string username = "!!!!!"; //muser.Object.username;

//            //Act
//            actual = target.IsUsernameAvailable(username);
//            //Assert
//            Assert.IsTrue((bool)actual.Data);
//        }

//        /// <summary>
//        ///A test for IsEmailAvailable
//        ///</summary>
//        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
//        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
//        // whether you are testing a page, web service, or a WCF service.
//        [TestMethod()]
//        [HostType("ASP.NET")]
//        [AspNetDevelopmentServerHost("C:\\Users\\Silvia\\Desktop\\dotNetCases\\MvcAgenda\\MvcAgenda", "/")]
//        [UrlToTest("http://localhost:41279/")]
//        public void IsEmailAvailableTest()
//        {
//            //UsersController target = new UsersController(); // TODO: Initialize to an appropriate value
//            //string email = string.Empty; // TODO: Initialize to an appropriate value
//            //JsonResult expected = null; // TODO: Initialize to an appropriate value
//            //JsonResult actual;
//            //actual = target.IsEmailAvailable(email);
//            //Assert.AreEqual(expected, actual);
//            //Assert.Inconclusive("Verify the correctness of this test method.");
//        }

//        [TestMethod]
//        public void Index_Can_Paginate() { 
//        //Arrange
//            Mock<IUserRepository> mock = new Mock<IUserRepository>();
//            mock.Setup(m => m.Users).Returns(new User[] { new User { username = "a" }, 
//                new User { username = "aa" }, 
//                new User { username = "aaa" }}.AsQueryable());
           
//            UsersController controller = new UsersController(mock.Object);           
//            controller.pageSize = 2;
            
//            //Action
//            IEnumerable<User> result = (IEnumerable<User>)controller.Index(2).Model;
//            Assert.IsTrue(true);
//            //Assert
//           // User[] userArray = result.ToArray();
//           // Assert.IsTrue(userArray.Length == 1);
//           // Assert.AreEqual(userArray[0].username,"aaa");
//        }

        user[] users;

        //ClassInitialize, ClassCleanup, TestInitialize, TestCleanup
        //It.IsAny<string>(), It.Is<int>(s=>s=="hello"), It.IsInRange<int>), It.IsRegex()
        //AreEqual, AreNotEqual, AreSame (same object), AreNotSame, Fail, Inconclusive, IsTrue, IsFalse, IsNull, IsNotNull, IsInstanceOfType, IsNotInstanceOfType

        [TestInitialize]
        public void preTestInitialize() {

            users = new user[] {
                new user {id = 1, email = "silvia1@silvia.com" },
                new user {id = 2, email = "silvia2@silvia.com" },
                new user {id = 3, email = "silvia3@silvia.com" },
                new user {id = 4, email = "silvia4@silvia.com" },
                new user {id = 5, email = "silvia5@silvia.com" }
            };
        }


        [TestMethod]
        public void CanSendPaginationViewModel()
        {
            //Arrange
            Mock<IUserRepository> mock = new Mock<IUserRepository>();
            //mock.Setup(m => m.SubmitChanges()).Throws( new Exception());
            //Domain.Entities.user silvia = new Domain.Entities.user { id = 1, email = "silvia@silvia.com" };
            //mock.Setup(m => m.FindUser(1)).Returns(silvia);

            mock.Setup(m => m.Users).Returns(users.AsQueryable());

            MvcAgenda.Controllers.UsersController controller = new MvcAgenda.Controllers.UsersController(mock.Object);
            controller.pageSize = 3;
            UsersListViewModel result = (UsersListViewModel)controller.Index(2).Model;

            //Assert
            user[] userArray = result.Users.ToArray();
            Assert.IsTrue(userArray.Length == 2);
            Assert.AreEqual(userArray[0].id, 4);
            Assert.AreEqual(userArray[1].id, 5);
            //mock.Verify(m => m.ListUsers(1, 1), Times.AtLeastOnce);
            //Assert.IsTrue(true); 


        }


    }
}
