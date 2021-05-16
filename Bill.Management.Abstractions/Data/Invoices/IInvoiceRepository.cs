using Bill.Management.Core.Abstractions.Data.Repository;
using BillManagement.Imlementations.Data;

namespace Bill.Management.Abstractions.Data.Invoices
{
    public interface IInvoiceRepository : IRepository<Invoice, int>
    {
        Invoice GetInvoiceById(int id);

        void Commit();
    }
}