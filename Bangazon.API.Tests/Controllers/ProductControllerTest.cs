using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Bangazon.API.Interface;
using Bangazon.API.Controllers;
using System.Web.Http;
using System.Net.Http;
using Bangazon.API.Models;
using System.Collections.Generic;
using System.Net;
using System.Linq;

namespace Bangazon.API.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        Mock<IProductRepo> _mockedProductRepository;
        ProductController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _mockedProductRepository = new Mock<IProductRepo>();

            _controller = new ProductController(_mockedProductRepository.Object);
            _controller.Request = new System.Net.Http.HttpRequestMessage();
            _controller.Request.SetConfiguration(new HttpConfiguration());
        }

        [TestMethod]
        public void GetAllProductsShouldReturnAllProducts()
        {
            //arrange
            _mockedProductRepository.Setup(x => x.GetProducts())
                .Returns(() =>
                    new List<Product>
                    {
                        new Product {Name = "Orange" },
                        new Product {Name = "Apple" },
                        new Product {Name = "GrapeFruit" }
                    });

            //act
            var result = _controller.GetProducts();

            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            var content = result.Content as ObjectContent<IEnumerable<Product>>;
            var returnValue = content.Value as IEnumerable<Product>;
            Assert.AreEqual(3, returnValue.Count());
        }
    }
}
