using System.Collections.Generic;
using System.Linq;
using Bill.Management.Abstractions.Data.Invoices;
using Bill.Management.Abstractions.Data.Users;
using Bill.Management.Implementations.Data.Users.Repositories.Contexts;
using BillManagement.Imlementations.Data;
using Microsoft.EntityFrameworkCore;

namespace Bill.Management.Implementations.Data.Users.Repositories
{
    internal sealed class InvoiceEfRepository : IInvoiceRepository
    {
        private readonly BillDbContext _context;

        public InvoiceEfRepository()
        {
            _context = new BillDbContext();
        }

        public IReadOnlyList<Invoice> Read()
        {
            return _context.Invoices.Where(x=> x.IsDeleted == false).ToList();
        }

        public void Create(Invoice data)
        {
            _context.Invoices.Add(data);
            
            Commit();
        }

        public void Update(Invoice data)
        {
            Invoice invoice = _context.Invoices.FirstOrDefault(x => x.Id == data.Id);

            if (invoice is null)
            {
                return;
            }

            invoice.Comment = data.Comment;
            invoice.ShopName = data.ShopName;
            invoice.Sum = data.Sum;

            Commit();
        }

        public void Delete(int id)
        {
            Invoice invoice = GetInvoiceById(id);
            invoice.IsDeleted = true;
            
            Commit();
        }

        public Invoice GetInvoiceById(int id)
        {
            return _context.Invoices.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefault();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
