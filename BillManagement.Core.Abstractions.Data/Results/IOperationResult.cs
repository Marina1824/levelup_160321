using System.Collections.Generic;

namespace BillManagement.Core.Abstractions.Data.Results
{
    public interface IOperationResult<TResult>
    {
        TResult Result { get; }

        IReadOnlyList<IOperationFailure> Failures { get; }

        bool Succeed { get; }
    }
}