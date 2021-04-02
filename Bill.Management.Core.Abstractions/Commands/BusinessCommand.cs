﻿using Bill.Management.Core.Abstractions.Results;

namespace Bill.Management.Core.Abstractions.Commands
{
    public abstract class BusinessCommand<TResult> : IBusinessCommand<TResult>
    {
        public IOperationResult<TResult> Execute()
        {
            return new OperationResult<TResult>(Run());
        }

        protected abstract TResult Run();
    }
}