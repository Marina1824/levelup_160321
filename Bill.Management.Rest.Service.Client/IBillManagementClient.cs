using System.Collections.Generic;
using System.Threading.Tasks;
using Bill.Management.Abstractions;
using Bill.Management.Core.Abstractions.Results;
using Refit;

namespace Bill.Management.Rest.Service.Client
{
    public interface IBillManagementClient
    {
        [Get("/v1/users/")]
        Task<IOperationResult<IReadOnlyList<User>>> GetClients();
    }
}