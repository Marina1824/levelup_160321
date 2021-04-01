using Bill.Management.Core.Abstractions.Data.Repository;

namespace Bill.Management.Abstractions.Data.Users
{
    public interface IUserRepository : IRepository<User, int>
    {
        
    }
}