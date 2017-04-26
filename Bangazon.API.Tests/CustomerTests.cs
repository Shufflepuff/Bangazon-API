using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bangazon.API.Controllers;
using Moq;
using Bangazon.API.Interface;
using System.Net.Http;
using System.Web.Http;
using Bangazon.API.Models;
using System.Net;

namespace Bangazon.API.Tests
{
    [TestClass]
    public class CustomerTests
    {
        CustomerController _customerController;
        Mock<ICustomerRepo> _mockICustomerRepo;

        [TestInitialize]
        public void Initialize()
        {
            _mockICustomerRepo = new Mock<ICustomerRepo>();
            _customerController = new CustomerController(_mockICustomerRepo.Object);
            _customerController.Request = new HttpRequestMessage();
            _customerController.Request.SetConfiguration(new HttpConfiguration());
        }

        [TestMethod]
        public void EnsureICanAddACustomer()
        {
            var newCustomer = new Customer
            {
                Name = "Zoe Ames",
                StreetAddress = "123 Mockingbird Lane",
                City = "Nashville",
                State = "TN",
                Zip = 37209,
                Phone = "954-427-5454"
            };

            var expected_result = HttpStatusCode.OK;
            var actual_result = _customerController.AddCustomer(newCustomer);

            Assert.AreEqual(expected_result,actual_result.StatusCode);
        }
    }
}
