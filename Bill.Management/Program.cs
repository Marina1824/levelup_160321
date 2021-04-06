using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bill.Management.Abstractions;
using Bill.Management.Core.Abstractions.Results;
using Bill.Management.Rest.Service.Client;

namespace Bill.Management
{
    class Program
    {

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IBillManagementClient client = ClientFactory.Create("http://localhost:58755");

            IOperationResult<IReadOnlyList<User>> usersList = await client.GetClients();

            Console.ReadLine();
        }
    }
}
