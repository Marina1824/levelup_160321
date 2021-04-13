using Bill.Management.Core.Abstractions.Data.Repository;
using BillManagement.Imlementations.Data;

namespace Bill.Management.Abstractions.Data.Users
{
    public interface IUserRepository : IRepository<User, int>
    {
        User GetUserById(int id);

        void Commit();
    }
}