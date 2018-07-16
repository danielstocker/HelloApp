using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloApp;
using HelloApp.Controllers;

namespace HelloApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void HelloWithoutName()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Hello(null) as ViewResult;

            // Assert
            Assert.IsTrue(result.ViewBag.Message.StartsWith("Hello, please enter your name. Supply it as a GET parameter."));
            Assert.IsFalse(result.ViewBag.Message.Contains("Bruce"));
        }

        [TestMethod]
        public void HelloWithName()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Hello("Bruce") as ViewResult;

            // Assert
            Assert.IsTrue(result.ViewBag.Message.Contains("Bruce"));
        }

    }
}
