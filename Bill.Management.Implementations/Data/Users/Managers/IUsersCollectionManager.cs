using System.Collections.Generic;
using Bill.Management.Abstractions;
using Bill.Management.Core.Abstractions.Results;

namespace Bill.Management.Implementations.Data.Users.Managers
{
    public interface IUsersCollectionManager
    {
        IOperationResult<IReadOnlyList<User>> GetAllUsers();

        IOperationResult<User> CreateUser(User user);
    }
}