using Bangazon.API.Interface;
using Bangazon.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Bangazon.API.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomerController : ApiController
    {
        readonly ICustomerRepo _customerRepo;

        public CustomerController(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage AddCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.Name))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please fill in a name.");
            }

            _customerRepo.AddCustomer(customer);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllCustomers()
        {
            var customers = _customerRepo.GetAllCustomers();

            return Request.CreateResponse(HttpStatusCode.OK, customers);
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetCustomer(int id)
        {
            var customer = _customerRepo.GetCustomer(id);

            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage DeleteCustomer(int id)
        {
            _customerRepo.DeleteCustomer(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}