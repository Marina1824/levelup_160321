using System;
using System.Collections.Generic;
using Bill.Management.Abstractions;
using Bill.Management.Abstractions.Data.Invoices;
using Bill.Management.Abstractions.Data.Users;
using Bill.Management.Abstractions.Exceptions;
using Bill.Management.Core.Abstractions.Managers;
using Bill.Management.Core.Abstractions.Services.Logging;
using Bill.Management.Core.Abstractions.Services.Validation;
using BillManagement.Core.Abstractions.Data.Results;
using BillManagement.Imlementations.Data;

namespace Bill.Management.Implementations.Data.Users.Managers
{
    internal sealed class InvoiceCollectionManager : CollectionManager<Invoice, int>, IInvoiceCollectionManager
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceCollectionManager(
            IInvoiceRepository repository, 
            IValidationService<Invoice> validationService,
            ILoggerService loggerService) 
            : base(repository, validationService, loggerService)
        {
            _invoiceRepository = repository;
        }
        
        public IOperationResult<Invoice> CreateInvoice(Invoice invoice)
        {
            Logger.Information("Calling for creating invoice...");

            try
            {
                IReadOnlyList<IOperationFailure> failures = Validation.ValidateEntity(invoice);

                if (failures.Count > 0)
                {
                    return new OperationResult<Invoice>(invoice, failures);
                }

                Repository.Create(invoice);

                return new OperationResult<Invoice>(invoice);
            }
            catch (Exception exception)
            {
                return OperationResult<Invoice>.FromException(exception);
            }
        }

        public IOperationResult<Invoice> UpdateInvoiceById(Invoice invoice)
        {
            Invoice oldInvoice = _invoiceRepository.GetInvoiceById(invoice.Id);

            oldInvoice.Comment = invoice.Comment;
            oldInvoice.ShopName = invoice.ShopName;
            oldInvoice.Sum = invoice.Sum;

            _invoiceRepository.Commit();

            return new OperationResult<Invoice>(oldInvoice);
        }

        public IOperationResult<Invoice> GetInvoiceById(int id)
        {
            Invoice invoice = _invoiceRepository.GetInvoiceById(id);
            
            return new OperationResult<Invoice>(invoice);
        }

        public IOperationResult<Invoice> DeleteInvoiceById(int id)
        {
            Invoice invoice = _invoiceRepository.GetInvoiceById(id);

            invoice.IsDeleted = true;

            _invoiceRepository.Commit();

            return new OperationResult<Invoice>(invoice);
        }
    }
}