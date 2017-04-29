using Bangazon.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon.API.Controllers
{
    public interface IInvoiceRepository
    {
        int AddInvoice(Invoice newInvoice);
        Invoice GetInvoice(int InvoiceId);
        // int DeleteInvoice(int InvoiceId);
        IEnumerable<Invoice> GetAll();
    }
}
