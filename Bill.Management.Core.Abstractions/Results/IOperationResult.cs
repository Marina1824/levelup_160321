using System.Collections.Generic;

namespace Bill.Management.Core.Abstractions.Results
{
    public interface IOperationResult<TResult>
    {
        TResult Result { get; }

        IReadOnlyList<IOperationFailure> Failures { get; }

        bool Succeed { get; }
    }
}