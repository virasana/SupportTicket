using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InterfacesLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST.ServicesLib;
using ST.SharedEntities.Models;
using ST.Web.Controllers;

namespace ST.Web.Tests.Controllers
{
    [TestClass]
    public partial class STControllerTest
    {
        [TestMethod]
        public void StController_Index()
        {
            // Arrange
            var repo = new RepoFake();
            var stService = new STService<ISTRepo>(repo);
            var controller = new STController(stService);

            // Act
            ViewResult result = controller.Index() as ViewResult;
            
            // Assert
            Assert.IsNotNull(result.Model);
            Assert.IsTrue(((RepoFake)stService.Repo).GetClosedTicketsWasCalled);
            Assert.IsInstanceOfType(result.Model, typeof(ICollection<Ticket>));
            Assert.AreEqual(((ICollection<Ticket>)result.Model).Count(), 10);
        }

        [TestMethod]
        public void StController_AddTicket()
        {
            // Arrange

            var repo = new RepoFake();
            var stService = new STService<ISTRepo>(repo);
            var controller = new STController(stService);
            var expectedTicketId = 1;
            var ticketInfo = new Ticket()
            {
                Description = "Description",
                Problem = "Some Problem",
                SeverityId = 2,
                ProductId = 2,
                Active = true
            };

            // Act
            ViewResult result = controller.AddTicket(ticketInfo.ProductId, ticketInfo.SeverityId, ticketInfo.Problem, ticketInfo.Description, ticketInfo.Active) as ViewResult;

            // Assert
            Assert.IsNotNull(result.ViewBag.Message);
            Assert.IsTrue(((RepoFake)stService.Repo).AddTicketWasCalled);
            Assert.AreEqual(result.ViewBag.Message, $"Your ticket has been created.  Your ticket ID is {expectedTicketId}");
        }

        [TestMethod]
        public void StController_Contact()
        {
            // Arrange
            var repo = new RepoFake();
            var stService = new STService<ISTRepo>(repo);

            var controller = new STController(stService);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
