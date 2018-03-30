using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using FakeItEasy;
using InterfacesLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST.ServicesLib;
using ST.SharedEntities.Models;
using ST.SQLRepoLib;
using ST.Web.ApiControllers;
using ST.Web.Controllers;

namespace ST.Web.Tests.Controllers
{
    /// <summary>
    /// Summary description for APITests
    /// </summary>
    [TestClass]
    public class TicketsControllerTest
    {
        #region Setup
        public TicketsControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        #endregion

        [TestMethod]
        public void TicketsController_GetProducts()
        {
            // Arrange
            var repo = new RepoFake();
            var stService = new STService<RepoFake>(repo);
            var controller = new TicketsController(stService);

            // Act
            var result = controller.GetProducts();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Product>));
            Assert.IsTrue(result.Any());
            Assert.IsTrue(((RepoFake)stService.Repo).GetProductsWasCalled);
        }

        [TestMethod]
        public void TicketsController_GetSeverities()
        {
            // Arrange
            var repo = new RepoFake();
            var stService = new STService<RepoFake>(repo);
            var controller = new TicketsController(stService);

            // Act
            var result = controller.GetSeverities();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Severity>));
            Assert.IsTrue(result.Any());
            Assert.IsTrue(((RepoFake)stService.Repo).GetSeveritiesWasCalled);
        }

        [TestMethod]
        public void TicketsController_AddTicket()
        {
            // Arrange
            var repo = A.Fake<SQLRepo>();
            var stService = new STService<ISTRepo>(repo);
            var controller = new TicketsController(stService);
            var ticket = A.Fake<Ticket>();
            A.CallTo(() => repo.AddTicket(ticket)).Returns(ticket);
            
            // Act
            var result = controller.PostTicket(ticket);

            // Assert
            Assert.IsNotNull(result);
            var content = ((CreatedNegotiatedContentResult<Ticket>) result).Content;
            Assert.IsInstanceOfType(content, typeof(Ticket));
            A.CallTo(() => repo.AddTicket(ticket)).MustHaveHappened();
        }

    }
}
