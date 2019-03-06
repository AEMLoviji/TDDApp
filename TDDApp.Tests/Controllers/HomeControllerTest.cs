using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;
using TDDApp.Controllers;
using TDDApp.Models;
using TDDApp.Repositories;

namespace TDDApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        [TestMethod]
        public void IndexViewModelIsNotNull()
        {
            // Arrange
            var mock = new Mock<IPersonRepository>();
            mock.Setup(m => m.GetList()).Returns(new List<Person>());
            HomeController controller = new HomeController(mock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void IndexViewBagMessage()
        {
            // Arrange
            var mock = new Mock<IPersonRepository>();
            mock.Setup(a => a.GetList()).Returns(new List<Person>() { new Person() });
            HomeController controller = new HomeController(mock.Object);
            string expected = "1 Person object in database.";

            // Act
            ViewResult result = controller.Index() as ViewResult;
            string actual = result.ViewBag.Message as string;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreatePostAction_RedirectToIndexView()
        {
            // Arrange
            var mock = new Mock<IPersonRepository>();
            HomeController controller = new HomeController(mock.Object);
            Person person = new Person();
            string expected = "Index";

            // Act
            RedirectToRouteResult result = controller.Create(person) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        [TestMethod]
        public void CreatePostAction_SaveModel()
        {
            // Arrange
            var mock = new Mock<IPersonRepository>();
            HomeController controller = new HomeController(mock.Object);
            Person person = new Person();

            // Act
            RedirectToRouteResult result = controller.Create(person) as RedirectToRouteResult;

            // Assert
            mock.Verify(a => a.Create(person));
            mock.Verify(a => a.Save());
        }

    }
}
