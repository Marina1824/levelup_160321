using System;
using System.Collections.Generic;
using Bill.Management.Abstractions;
using Bill.Management.Abstractions.Data.Users;
using Bill.Management.Abstractions.Exceptions;
using Bill.Management.Core.Abstractions.Managers;
using Bill.Management.Core.Abstractions.Services.Logging;
using Bill.Management.Core.Abstractions.Services.Validation;
using BillManagement.Core.Abstractions.Data.Results;
using BillManagement.Imlementations.Data;

namespace Bill.Management.Implementations.Data.Users.Managers
{
    internal sealed class UsersCollectionManager : CollectionManager<User, int>, IUsersCollectionManager
    {
        private readonly IUserRepository _userRepository;

        public UsersCollectionManager(
            IUserRepository repository, 
            IValidationService<User> validationService,
            ILoggerService loggerService) 
            : base(repository, validationService, loggerService)
        {
            _userRepository = repository;
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

        public IOperationResult<User> UpdateUserText(int id, string text)
        {
            User user = _userRepository.GetUserById(id);

            if (user is null)
            {
                return OperationResult<User>.FromException(new UserRepositoryFailureException());
            }

            user.Text = text;

            _userRepository.Commit();

            return new OperationResult<User>(user);
        }
    }
}