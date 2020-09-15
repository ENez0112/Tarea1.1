using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using APITarea1._1.Controllers;
using APITarea1._1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tarea1._1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGet()
        {
            // ARRANGE
            nunezsController controller = new nunezsController();
            // ACT
            var lista = controller.Getnunezs();
            // ASSERT
            Assert.IsNotNull(lista);
        }
        [TestMethod]
        public void TestPost()
        {
            nunezsController controller = new nunezsController();
            nunez nunez = new nunez()
            {
                nunezID = 1,
                Friendofnunez = "Josito Hurtado",
                Place = Places.Porongo,
                Email = "JoseAndresHV@gmail.com",
                Birthdate = DateTime.Now
            };

            IHttpActionResult actionResult = controller.Postnunez(nunez);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<nunez>;

            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }
        [TestMethod]
        public void TestPut()
        {
            nunezsController controller = new nunezsController();
            nunez nunez = new nunez()
            {
                nunezID = 2,
                Friendofnunez = "Sebastian Ferrufino",
                Place = Places.Montero,
                Email = "sfvm@gmail.com",
                Birthdate = DateTime.Now
            };
            IHttpActionResult actionResultPost = controller.Postnunez(nunez);
            var result = controller.Putnunez(nunez.nunezID, nunez) as StatusCodeResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }
        [TestMethod]
        public void TestDelete()
        {
            nunezsController controller = new nunezsController();
            nunez nunez = new nunez()
            {
                nunezID = 3,
                Friendofnunez = "Andre Del Saco",
                Place = Places.Warnes,
                Email = "andresito@gmail.com",
                Birthdate = DateTime.Now
            };

            IHttpActionResult actionResultPost = controller.Postnunez(nunez);
            IHttpActionResult actionResultDelete = controller.Deletenunez(nunez.nunezID);

            Assert.IsInstanceOfType(actionResultDelete, typeof(OkNegotiatedContentResult<nunez>));
        }
    }
}
