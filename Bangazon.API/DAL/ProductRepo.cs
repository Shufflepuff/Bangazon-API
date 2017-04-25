using Bangazon.API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bangazon.API.Models;
using System.Data;
using Dapper;

namespace Bangazon.API.DAL
{
    public class ProductRepo : IProductRepo
    {
        readonly IDbConnection _dbConnection;

        public ProductRepo(IDbConnection connection)
        {
            _dbConnection = connection;
        }
        public Product GetProduct(int ProductId)
        {
            var sql = @"SELECT * 
                    FROM Product 
                    WHERE ProductId = @ProductId";

            return _dbConnection.Query(sql, Product);
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