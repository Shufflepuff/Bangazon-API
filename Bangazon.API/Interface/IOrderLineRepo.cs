using Bangazon.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bangazon.API.Controllers
{
    public interface IOrderLineRepo
    {
        void AddOrderLine(OrderLine newOrderLine);
        IEnumerable<OrderLine> GetAll();
        IEnumerable<OrderLine> GetByInvoice(int InvoiceId);
        OrderLine GetOrderLine(int OrderLineId);
    }
}
