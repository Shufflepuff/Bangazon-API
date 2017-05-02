﻿using Bangazon.API.Models;
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
        Invoice UpdateInvoice(int InvoiceId);
        bool DeleteInvoice(bool InvoiceId);
        IEnumerable<Invoice> GetAll();
    }
}