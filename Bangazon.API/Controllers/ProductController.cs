using Bangazon.API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bangazon.API.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        readonly IProductRepo _productRepo;

        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        [Route("{ProductId}")]
        public HttpResponseMessage GetProduct(int ProductId)
        {
            var product = _productRepo.GetProduct(ProductId);

            if(product == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    $"The Product with an id of {ProductId} does not exist");
            }

            return Request.CreateResponse(HttpStatusCode.OK, product);
        }
    }
}
