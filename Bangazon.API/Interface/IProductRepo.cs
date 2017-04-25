﻿using Bangazon.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon.API.Interface
{
    interface IProductRepo
    {
        void GetProducts(int ProductId, string Name, int Price);
        Product GetProduct(int ProductId);
        List<Product> GetProducts();
    }
}