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
            int newInvoiceId = _invoiceRepository.AddInvoice(invoice);

            return Created("api/invoice/" + newInvoiceId, invoice);
        }

        [HttpGet]

        public HttpResponseMessage GetAll()
        {
            var invoices = _invoiceRepository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, invoices);
        }

        // get one 
        [HttpGet]
        [Route("{InvoiceId}")]
        public HttpResponseMessage GetInvoice(int invoiceId)
        {
            var invoice = _invoiceRepository.GetInvoice(invoiceId);
            return Request.CreateResponse(HttpStatusCode.OK, invoice);
        }

        // delete
        [HttpDelete]
        [Route("Delete/{InvoiceId}")]
        public HttpResponseMessage DeleteInvoice(int invoiceId)
        {
            var invoice = _invoiceRepository.DeleteInvoice(true);
            return Request.CreateResponse(HttpStatusCode.OK, invoice);
        }
        
       // [HttpPut] - update
    }
}
