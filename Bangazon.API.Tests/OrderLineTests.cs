using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bangazon.API.Controllers;
using Bangazon.API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Bangazon.API.Tests
{
    [TestClass]
    public class OrderLineTests
    {
        OrderLineController _controller;
        Mock<IOrderLineRepo> _mockedOrderLineRepo;

        [TestInitialize]
        public void Initialize()
        {
            _mockedOrderLineRepo = new Mock<IOrderLineRepo>();

            _controller = new OrderLineController(_mockedOrderLineRepo.Object);
            _controller.Request = new HttpRequestMessage();
            _controller.Request.SetConfiguration(new HttpConfiguration());
        }

        [TestMethod]
        public void EnsureAddOrderLineMethodWorks()
        {
            // Arrange
            var newOrderLine = new OrderLine
            {
                InvoiceId = 2,
                OrderLineId = 3,
                ProductId = 4,
                Quantity = 3273
            };

            // Act
            var result = _controller.AddNewOrderLine(newOrderLine);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

            _mockedOrderLineRepo.Verify(x => x.AddOrderLine(newOrderLine));
        }
    }
}
