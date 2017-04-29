using Bangazon.API.Controllers;
using Bangazon.API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bangazon.API.DAL
{
    public class InvoiceRepository : IInvoiceRepository
    {
        readonly IDbConnection _dbConnection;

        public InvoiceRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }
        public int AddInvoice(Invoice newInvoice)
        {
            var sql = @"insert into Invoice(invoiceid) 
                        Values(@invoiceid); SELECT CAST(SCOPE_IDENTITY() as int)";
                        // this sql will change as the properties on our model changes

            return _dbConnection.Query(sql, newInvoice).Single();
        }

        //public int DeleteInvoice(int InvoiceId)
        //{
        //    var sql = @"DELETE
        //                FROM Invoice
        //                WHERE InvoiceId = @InvoiceId";
        //    _dbConnection.Execute(sql);
        //}

        public IEnumerable<Invoice> GetAll()
        {
           var sql = @"select I.InvoiceId, P.Name, OL.Quantity from Invoice I
                        JOIN OrderLine OL on OL.InvoiceId = I.InvoiceId
                        JOIN Product P on P.ProductId = OL.ProductId";

           return _dbConnection.Query<Invoice>(sql);
        }

        public Invoice GetInvoice(int InvoiceId)
        {
            var sql = @"SELECT * 
                    FROM Invoice 
                    WHERE InvoiceId = @InvoiceId";

            return _dbConnection.QueryFirstOrDefault<Invoice>(sql, new { InvoiceId = InvoiceId });
        }
    }
}