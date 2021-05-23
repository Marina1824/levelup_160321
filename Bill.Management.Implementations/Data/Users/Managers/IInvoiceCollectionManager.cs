using System.Collections.Generic;
using Bill.Management.Abstractions;
using BillManagement.Core.Abstractions.Data.Results;
using BillManagement.Imlementations.Data;

namespace Bill.Management.Implementations.Data.Users.Managers
{
    public interface IInvoiceCollectionManager
    {
        public IOperationResult<IReadOnlyList<Invoice>> GetAllInvoices();
        public IOperationResult<Invoice> GetInvoiceById(int id);
        public IOperationResult<Invoice> CreateInvoice(Invoice invoice);
        public IOperationResult<Invoice> UpdateInvoiceById(Invoice invoice);
        public IOperationResult<Invoice> DeleteInvoiceById(int id);
    }
}