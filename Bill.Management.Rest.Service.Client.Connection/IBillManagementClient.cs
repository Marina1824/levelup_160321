﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BillManagement.Core.Abstractions.Data.Results;
using BillManagement.Imlementations.Data;
using Refit;

namespace Bill.Management.Rest.Service.Client.Connection
{
    public interface IBillManagementClient
    {
        [Get("/v1/users/")]
        Task<OperationResult<IReadOnlyList<User>>> GetClients();
        [Put("/v1/users/")]
        Task<OperationResult<User>> CreateUser(User user);
        [Post("/v1/users/")]
        Task<OperationResult<User>> UpdateUser(User user);

        [Get("/v1/bills/")]
        Task<IOperationResult<IReadOnlyList<Invoice>>> GetInvoices();
        [Put("/v1/bills/")]
        Task<IOperationResult<Invoice>> CreateInvoice(Invoice invoice);
        [Post("/v1/bills/")]
        Task<IOperationResult<Invoice>> UpdateInvoiceById(Invoice invoice);
        [Post("/v1/bills/")]
        Task<IOperationResult<Invoice>> DeleteInvoiceById(int id);
    }
}