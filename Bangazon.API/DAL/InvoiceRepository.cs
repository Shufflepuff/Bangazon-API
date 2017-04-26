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
        public int Save(Invoice newInvoice)
        {
            var sql = @"insert into Invoice(invoiceid, items) 
                        Values(@invoiceid, items); SELECT CAST(SCOPE_IDENTITY() as int)";
                        // this sql will change as the properties on our model changes

            return _dbConnection.Query(sql, newInvoice).Single();
        }

       public IEnumerable<Invoice> GetAll()
        {
           var sql = @"select paymentid, items from Invoice";

           return _dbConnection.Query<Invoice>(sql);
        }
    }
}