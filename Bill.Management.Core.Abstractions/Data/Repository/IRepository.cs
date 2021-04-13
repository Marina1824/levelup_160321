using BillManagement.Core.Abstractions.Data;

namespace Bill.Management.Core.Abstractions.Data.Repository
{
    public interface IRepository<TDataItem, TUniqueIdType> : IReadOnlyRepository<TDataItem>
        where TDataItem : BaseEntity<TUniqueIdType>
        where TUniqueIdType : struct
    {
        void Create(TDataItem data);

        void Update(TDataItem data);

        void Delete(TUniqueIdType id);
    }
}