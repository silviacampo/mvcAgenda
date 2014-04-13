using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using Moq;
using MvcAgenda.Domain.Abstract;
using MvcAgenda.Domain.Entities;
using MvcAgenda.Models;

namespace MvcAgenda.Tests
{
    [TestClass]
    public class UnitTest1
    {
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
