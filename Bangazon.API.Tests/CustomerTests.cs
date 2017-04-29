using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bangazon.API.Controllers;
using Moq;
using Bangazon.API.Interface;
using System.Net.Http;
using System.Web.Http;
using Bangazon.API.Models;
using System.Net;
using System.Diagnostics;
using System.Collections.Generic;

namespace Bangazon.API.Tests
{
    [TestClass]
    public class CustomerTests
    {
        CustomerController _customerController;
        Mock<ICustomerRepo> _mockICustomerRepo;
        Customer newCustomer;

        [TestInitialize]
        public void Initialize()
        {
            _mockICustomerRepo = new Mock<ICustomerRepo>();
            _customerController = new CustomerController(_mockICustomerRepo.Object);
            
            _customerController.Request = new HttpRequestMessage();
            _customerController.Request.SetConfiguration(new HttpConfiguration());
            newCustomer = new Customer
            {
                Name = "Zoe Ames",
                StreetAddress = "123 Mockingbird Lane",
                City = "Nashville",
                State = "TN",
                Zip = 37209,
                Phone = "954-427-5454"
            };
        }

        [TestMethod]
        public void EnsureICanAddACustomer()
        {
            var expected_result = HttpStatusCode.OK;
            var actual_result = _customerController.AddCustomer(newCustomer);

            Assert.AreEqual(expected_result,actual_result.StatusCode);
            _mockICustomerRepo.Verify(x => x.AddCustomer(newCustomer), Times.Once);
        }

        [TestMethod]
        public void EnsureICanGetCustomerById()
        {
            _mockICustomerRepo.Setup(c => c.GetCustomer(It.Is<int>(x => x == 1)))
                .Returns(new Customer() { Name = "Alex" });

            var actual_result = _customerController.GetCustomer(1);

            Assert.AreEqual("Alex", actual_result.GetContentValue<Customer>().Name);
        }

        [TestMethod]
        public void EnsureICanGetAllCustomers()
        {
            _mockICustomerRepo.Setup(c => c.GetAllCustomers())
                .Returns(new List<Customer>() { new Customer()
                {
                    Name = "Joe",
                    StreetAddress = "1445 Deez Lane",
                    City = "Fort Lauderdale",
                    State = "FL",
                    Zip = 33308,
                    Phone = "954-465-9453"
                },
                new Customer()
                {
                    Name = "Joe",
                    StreetAddress = "1445 Deez Lane",
                    City = "Fort Lauderdale",
                    State = "FL",
                    Zip = 33308,
                    Phone = "954-465-9453"
                },
                new Customer()
                {
                    Name = "Joe",
                    StreetAddress = "1445 Deez Lane",
                    City = "Fort Lauderdale",
                    State = "FL",
                    Zip = 33308,
                    Phone = "954-465-9453"
                } });

            var actual_result = _customerController.GetAllCustomers();

            Assert.AreEqual("Alex", actual_result.GetContentValue<IEnumerable<Customer>>());
            _mockICustomerRepo.Verify(x => x.GetAllCustomers(), Times.Once);
        }
    }
}
