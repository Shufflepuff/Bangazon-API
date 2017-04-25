using Bangazon.API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bangazon.API.Models;

namespace Bangazon.API.DAL
{
    public class ProductRepo : IProductRepo
    {
        public Product GetProduct(int ProductId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public void GetProducts(int ProductId, string Name, int Price)
        {
            throw new NotImplementedException();
        }
    }
}