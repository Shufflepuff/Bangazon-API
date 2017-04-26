using Bangazon.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bangazon.API.Controllers
{
    [RoutePrefix("api/invoice")]
    public class InvoiceController : ApiController
    {
        readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpPost]
        public IHttpActionResult CreateInvoice(Invoice invoice)
        {
                if (! ModelState.IsValid)
            {
                return BadRequest("Invalid invoice");
            }
            int newInvoiceId = _invoiceRepository.Save(invoice);

            return Created("api/invoice/" + newInvoiceId, invoice);
        }

        [HttpGet]

        public HttpResponseMessage GetAll()
        {
            var invoices = _invoiceRepository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, invoices);
        }
        // Get individual
       // [HttpPut] - update
       // Delete
    }
}
