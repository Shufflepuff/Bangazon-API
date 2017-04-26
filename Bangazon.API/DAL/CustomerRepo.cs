﻿using Bangazon.API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bangazon.API.Models;
using System.Data;
using Dapper;

namespace Bangazon.API.DAL
{
    public class CustomerRepo : ICustomerRepo
    {
        readonly IDbConnection _dbConnection;

        public CustomerRepo(IDbConnection connection)
        {
            _dbConnection = connection;
        }

        public void AddCustomer(Customer customer)
        {
            var sql = @"Insert into Customer(name,address,city,state,zip,phone)
                        Values(@name,@address,@city,@state,@zip,@phone)";

            _dbConnection.Execute(sql);
        }

        public void DeleteCustomer(int id)
        {
            var sql = @"Delete from Customer where customerId = @id";

            _dbConnection.Execute(sql);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var sql = @"Select name,address,city,state,zip,phone from Customer";

            return _dbConnection.Query<Customer>(sql);
        }

        public Customer GetCustomer(int id)
        {
            var sql = @"Select name,address,city,state,zip,phone from Customer where customerId = @id";

            return _dbConnection.QueryFirst<Customer>(sql);
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}