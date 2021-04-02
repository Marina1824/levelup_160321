using System;
using System.Collections.Generic;
using Bill.Management.Abstractions;
using Bill.Management.Abstractions.Data.Users;
using Bill.Management.Core.Abstractions.Managers;
using Bill.Management.Core.Abstractions.Results;
using Bill.Management.Core.Abstractions.Services.Logging;
using Bill.Management.Core.Abstractions.Services.Validation;

namespace Bill.Management.Implementations.Data.Users.Managers
{
    internal sealed class UsersCollectionManager : CollectionManager<User, int>, IUsersCollectionManager
    {
        public UsersCollectionManager(
            IUserRepository repository, 
            IValidationService<User> validationService,
            ILoggerService loggerService) 
            : base(repository, validationService, loggerService)
        {
        }

        public IOperationResult<IReadOnlyList<User>> GetAllUsers()
        {
            Logger.Information("Calling for users...");

            try
            {
                IReadOnlyList<User> users = Repository.Read();

                return new OperationResult<IReadOnlyList<User>>(users);
            }
            catch (Exception exception)
            {
                return OperationResult<IReadOnlyList<User>>.FromException(exception);
            }
        }

        public IOperationResult<User> CreateUser(User user)
        {
            Logger.Information("Calling for creating users...");

            try
            {

                IReadOnlyList<IOperationFailure> failures = Validation.ValidateEntity(user);

                if (failures.Count > 0)
                {
                    return new OperationResult<User>(user, failures);
                }

                Repository.Create(user);

                return new OperationResult<User>(user);
            }
            catch (Exception exception)
            {
                return OperationResult<User>.FromException(exception);
            }
        }
    }
}