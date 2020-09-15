using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using APITarea1._1;
using APITarea1._1.Controllers;

namespace Tarea1._1.Tests.Controllers
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
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
