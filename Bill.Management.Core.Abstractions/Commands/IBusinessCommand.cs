using BillManagement.Core.Abstractions.Data.Results;

namespace Bill.Management.Core.Abstractions.Commands
{
    public interface IBusinessCommand<TResult>
    {
        IOperationResult<TResult> Execute();
    }
}