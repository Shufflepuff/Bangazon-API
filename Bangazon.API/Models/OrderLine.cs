using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bangazon.API.Models
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }

        public int InvoiceId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}