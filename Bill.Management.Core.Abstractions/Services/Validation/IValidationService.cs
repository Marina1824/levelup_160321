using System.Collections.Generic;
using Bill.Management.Core.Abstractions.Results;

namespace Bill.Management.Core.Abstractions.Services.Validation
{
    public interface IValidationService<TEntity>
        where TEntity : class
    {
        IReadOnlyList<IOperationFailure> ValidateEntity(TEntity item);
    }
}