using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bangazon.API.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public List<OrderLine> Items { get; set; }
    }
}