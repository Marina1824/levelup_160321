using Bill.Management.Core.Abstractions.Data;
using BillManagement.Core.Abstractions.Data;

namespace Bill.Management.Core.Abstractions.Managers
{
    public interface ICollectionManager<TDataItem, TUniqueIdType>
        where TDataItem : BaseEntity<TUniqueIdType>
        where TUniqueIdType : struct
    {
        
    }
}