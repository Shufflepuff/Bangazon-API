using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Bangazon.API.Controllers;
using Bangazon.API.Models;
using Dapper;

namespace Bangazon.API.DAL
{
    public class OrderLineRepo : IOrderLineRepo
    {
        readonly IDbConnection _dbConnection;

        public OrderLineRepo(IDbConnection connection)
        {
            _dbConnection = connection;
        }

        public void AddOrderLine(OrderLine newOrderLine)
        {
            var sql = @"Insert into OrderLine(InvoiceId,ProductId,Quantity) values(@InvoiceId,@ProductId,@Quantity)";

            _dbConnection.Execute(sql, newOrderLine);
        }

        public IEnumerable<OrderLine> GetAll()
        {
            var sql = @"SELECT Quantity FROM OrderLine";

           return _dbConnection.Query<OrderLine>(sql);
        }

        public IEnumerable<OrderLine> GetByInvoice(int InvoiceId)
        {
            var sql = @"SELECT * FROM OrderLine WHERE InvoiceId = @InvoiceId";

            return _dbConnection.Query<OrderLine>(sql, new { InvoiceId = InvoiceId});
        }

        public OrderLine GetOrderLine(int OrderLineId)
        {
            var sql = @"SELECT * 
                    FROM OrderLine 
                    WHERE OrderLineId = @OrderLineId";

            return _dbConnection.QueryFirstOrDefault<OrderLine>(sql, new { OrderLineId = OrderLineId });
        }
    }
}