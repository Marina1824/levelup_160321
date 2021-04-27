using System.Collections.Generic;
using Bill.Management.Abstractions;
using BillManagement.Core.Abstractions.Data.Results;
using BillManagement.Imlementations.Data;

namespace Bill.Management.Implementations.Data.Users.Managers
{
    public interface IUsersCollectionManager
    {
        IOperationResult<IReadOnlyList<User>> GetAllUsers();

        IOperationResult<User> CreateUser(User user);
        IOperationResult<User> UpdateUser(User user);

        IOperationResult<User> UpdateUserText(int id, string text);
    }
}