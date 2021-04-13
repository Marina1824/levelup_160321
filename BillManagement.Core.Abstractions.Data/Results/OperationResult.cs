using System;
using System.Collections.Generic;

namespace BillManagement.Core.Abstractions.Data.Results
{
    public sealed class OperationResult<TResult> : IOperationResult<TResult>
    {
        public OperationResult(TResult result, IReadOnlyList<IOperationFailure> failures = null)
        {
            Result = result;
            Failures = failures;
        }

        public TResult Result { get; }

        public IReadOnlyList<IOperationFailure> Failures { get; set; }

        public bool Succeed => Failures is null ? true : Failures.Count == 0;

        public static IOperationResult<TResult> FromException(Exception exception)
        {
            return new OperationResult<TResult>(default, new List<IOperationFailure>(1)
            {
                exception is null
                    ? new OperationFailure {PropertyName = "EXCEPTION", Description = "EXCEPTION IS NULL"}
                    : new OperationFailure {PropertyName = "EXCEPTION", Description = exception.Message}
            });
        }
    }
}