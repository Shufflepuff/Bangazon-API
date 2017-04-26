using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bangazon.API.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        
        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}