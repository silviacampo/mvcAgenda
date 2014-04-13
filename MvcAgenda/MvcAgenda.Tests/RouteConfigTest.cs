using MvcAgenda;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Routing;
using System.Web;
using Moq;
using System.Reflection;
using System.Web.Mvc;

namespace MvcAgenda.Tests
{
    
    
    /// <summary>
    ///This is a test class for RouteConfigTest and is intended
    ///to contain all RouteConfigTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RouteConfigTest
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


        /// <summary>
        ///A test for RouteConfig Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Silvia\\Desktop\\dotNetCases\\MvcAgenda\\MvcAgenda", "/")]
        [UrlToTest("http://localhost:41279/")]
        public void RouteConfigConstructorTest()
        {
            RouteConfig target = new RouteConfig();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for RegisterRoutes
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Silvia\\Desktop\\dotNetCases\\MvcAgenda\\MvcAgenda", "/")]
        [UrlToTest("http://localhost:41279/")]
        public void RegisterRoutesTest()
        {
            RouteCollection routes = null; // TODO: Initialize to an appropriate value
            RouteConfig.RegisterRoutes(routes);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        private HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET") { 
        //create a mock request
            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            //create the mock response
            Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

            //create the mock context using the request and the response
            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            //return the mock context
            return mockContext.Object;
        }

        private void TestRouteMatch(string url, string controller, string action, object routeProperties = null, string httpMethod = "GET")
        {
        //Arrange
            RouteCollection routes = new RouteCollection();
            MvcAgenda.RouteConfig.RegisterRoutes(routes);

            //Act
            RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProperties));
        }

        private bool TestIncomingRouteResult(RouteData routeResult, string controller, string action, object propertySet = null)
        {
            Func<object, object, bool> valCompare = (v1, v2) =>
            {
                return StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0;
            };
            bool result = valCompare(routeResult.Values["controller"], controller) 
                && valCompare(routeResult.Values["action"], action);

            if (propertySet != null) {
                PropertyInfo[] propInfo = propertySet.GetType().GetProperties();
                foreach (PropertyInfo pi in propInfo)
                {
                    if (!(routeResult.Values.ContainsKey(pi.Name) && valCompare(routeResult.Values[pi.Name], pi.GetValue(propertySet, null)))) {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        private void TestRouteFail(string url) { 
        //Arrange
            RouteCollection routes = new RouteCollection();
            MvcAgenda.RouteConfig.RegisterRoutes(routes);
            //Act
            RouteData result = routes.GetRouteData(CreateHttpContext(url));
            //Assert
            Assert.IsTrue(result == null || result.Route == null);

        }

        [TestMethod]
        public void TestIncomingRoutes() { 
        //check for the url that we hope to receive
            TestRouteMatch("~/Users/Index", "Users", "Index");
            //check that the values are being obtained from the segments
            TestRouteMatch("~/One/Two", "One", "Two");

            //ensure that too many or too few segments fails to match
            TestRouteFail("~/Users/Index/Page1");
            TestRouteFail("~/Admin");

        }
        [TestMethod]
        public void TestOutgoingRoutes() {
        //Arrange
            RouteCollection routes = new RouteCollection();
            MvcAgenda.RouteConfig.RegisterRoutes(routes);
            RequestContext context = new RequestContext(CreateHttpContext(), new RouteData());

            //act
            string result = UrlHelper.GenerateUrl(null, "Index","Home", null, routes, context,true);

            //Assert
            Assert.AreEqual("/", result);
        
        }

    }
}
