using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bangazon.API.Models
{
    public class LineItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}