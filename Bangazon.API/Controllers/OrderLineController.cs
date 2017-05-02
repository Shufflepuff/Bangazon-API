using Bangazon.API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bangazon.API.Controllers
{
    [RoutePrefix("api/orderline")]
    public class OrderLineController : ApiController
    {
        readonly IOrderLineRepo _orderLineRepo;

        public OrderLineController(IOrderLineRepo orderLineRepo)
        {
            _orderLineRepo = orderLineRepo;
        }

        [HttpPost]
        public HttpResponseMessage AddNewOrderLine(OrderLine newOrderLine)
        {
            _orderLineRepo.AddOrderLine(newOrderLine);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var orderLine = _orderLineRepo.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, orderLine);
        }

        [HttpGet]
        [Route ("{OrderLineId}")]
        public HttpResponseMessage GetOrderLineById(int OrderLineId)
        {
            var orderLineById = _orderLineRepo.GetOrderLine(OrderLineId);

            return Request.CreateResponse(HttpStatusCode.OK, orderLineById);
        }

        [HttpPut]
        [Route ("update/{OrderLineId}")]
        public HttpResponseMessage UpdateOrderLineById(OrderLine updateOrderLine, int OrderLineId)
        {
            _orderLineRepo.UpdateOrderLine(updateOrderLine, OrderLineId);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
