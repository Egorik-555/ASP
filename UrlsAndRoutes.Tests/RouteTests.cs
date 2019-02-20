﻿using System;
using System.Reflection;
using System.Web;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UrlsAndRoutes.Tests
{
    [TestClass]
    public class RouteTests
    {
        private HttpContextBase GetHttContext(string targetUrl = null, string httpMethod = "GET")
        {
            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            return mockContext.Object;
        }

        private void TestRoutMatch(string url, string controller, string action,
            object routeProperties = null, string httpMethod = "GET")
        {
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            RouteData result = routes.GetRouteData(GetHttContext(url, httpMethod));

            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, controller,
                                                  action, routeProperties));

        }

        private bool TestIncomingRouteResult(RouteData routeResult,
            string controller, string action, object propertySet = null)
        {

            Func<object, object, bool> valCompare = (v1, v2) =>
            {
                return StringComparer.InvariantCultureIgnoreCase
                    .Compare(v1, v2) == 0;
            };

            bool result = valCompare(routeResult.Values["controller"], controller)
                && valCompare(routeResult.Values["action"], action);

            if (propertySet != null)
            {
                PropertyInfo[] propInfo = propertySet.GetType().GetProperties();
                foreach (PropertyInfo pi in propInfo)
                {
                    if (!(routeResult.Values.ContainsKey(pi.Name)
                    && valCompare(routeResult.Values[pi.Name],
                    pi.GetValue(propertySet, null))))
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        private void TestRouteFail(string url)
        {
            // Организация
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Действие - обработка маршрута
            RouteData result = routes.GetRouteData(GetHttContext(url));

            // Утверждение
            Assert.IsTrue(result == null || result.Route == null);
        }



        [TestMethod]
        public void TestIncomingRoutes()
        {
            TestRoutMatch("~/", "Home", "Index");

            TestRouteFail("~/Admin/Index");
            TestRouteFail("~/One/Two");
           

            TestRouteFail("~/Admin/Index/One/Delete");
        }
    }
}
