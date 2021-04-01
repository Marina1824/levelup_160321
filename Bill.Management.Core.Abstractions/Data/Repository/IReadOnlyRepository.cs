using System.Collections.Generic;

namespace Bill.Management.Core.Abstractions.Data.Repository
{
    public interface IReadOnlyRepository<TDataItem> 
        where TDataItem : class
    {
        IReadOnlyList<TDataItem> Read();
    }
}