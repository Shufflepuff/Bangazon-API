using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bangazon.API.Controllers;
using Moq;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using Bangazon.API.Models;
using System.Net;
using System.Linq;

namespace Bangazon.API.Tests
{

    [TestClass]

    public class InvoiceRetrievalTests
    {
        Mock<IInvoiceRepository> _mockedInvoiceRepository;
        InvoiceController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _mockedInvoiceRepository = new Mock<IInvoiceRepository>();

            _controller = new InvoiceController(_mockedInvoiceRepository.Object);
            _controller.Request = new System.Net.Http.HttpRequestMessage();
            _controller.Request.SetConfiguration(new HttpConfiguration());
        }
        [TestMethod]
        public void ReturnAllInvoices()
        {
            // arrange
            _mockedInvoiceRepository.Setup(x => x.GetAll())
                .Returns(() =>
                    new List<Invoice>
                    {
                        new Invoice {Name = "Too many Oranges"},
                        new Invoice {Name = "Alicia"},
                        new Invoice {Name = "Owen"}
                    });
            // act
            var result = _controller.GetAll();

            // assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            var content = result.Content as ObjectContent<IEnumerable<Invoice>>;
            var returnValue = content.Value as IEnumerable<Invoice>;
            Assert.AreEqual(3, returnValue.Count());
        }
        [TestMethod]
        public void GetOneInvoice()
        {
            //arrange
            _mockedInvoiceRepository.Setup(x => x.GetInvoice(1))
                .Returns(() => 
                    new Invoice {InvoiceId = 1, Name = "Your Products",  Quantity = 5 });
            //act
            var result = _controller.GetInvoice(1);
            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            var content = result.Content as ObjectContent<Invoice>;
            var returnValue = content.Value as Invoice;
            Assert.IsTrue(returnValue.InvoiceId == 1);
        }
    }
}
