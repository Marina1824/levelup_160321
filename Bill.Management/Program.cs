using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bill.Management.Abstractions;
using Bill.Management.Rest.Service.Client;
using Bill.Management.Rest.Service.Client.Connection;
using BillManagement.Core.Abstractions.Data.Results;
using BillManagement.Imlementations.Data;

namespace Bill.Management
{
    class Program
    {

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IBillManagementClient client = ClientFactory.Create("http://localhost:58755");

            IOperationResult<IReadOnlyList<Invoice>> invoicesList = await client.GetInvoices();

            Console.ReadLine();
        }
    }
}
