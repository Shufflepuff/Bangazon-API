using Bangazon.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon.API.Interface
{
    public interface ICustomerRepo
    {
        Customer GetCustomer(int id);
        IEnumerable<Customer> GetAllCustomers();
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int id);
    }
}
