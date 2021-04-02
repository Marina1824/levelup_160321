using Bill.Management.Core.Abstractions.Results;

namespace Bill.Management.Core.Abstractions.Commands
{
    public interface IBusinessCommand<TResult>
    {
        IOperationResult<TResult> Execute();
    }
}