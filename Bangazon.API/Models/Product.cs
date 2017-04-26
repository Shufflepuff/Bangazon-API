using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bangazon.API.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return this.Name + " " + this.Price.ToString();
        }
    }
}