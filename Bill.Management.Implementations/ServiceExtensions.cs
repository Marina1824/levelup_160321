using Bill.Management.Abstractions;
using Bill.Management.Abstractions.Data.Users;
using Bill.Management.Core.Abstractions;
using Bill.Management.Core.Abstractions.Container;
using Bill.Management.Implementations.Data.Users;
using Bill.Management.Implementations.Data.Users.Managers;
using Bill.Management.Implementations.Data.Users.Repositories;
using Bill.Management.Implementations.Data.Users.Validators;

namespace Bill.Management.Implementations
{
    public static class ServiceExtensions
    {
        public static IContainer AddSqlRepositories(this IContainer container)
        {
            container.BindAsSingleton<IUserRepository, UserSqlRepository>();

            return container;
        }

        public static IContainer AddJsonRepositories(this IContainer container)
        {
            return container;
        }

        public static IContainer AddEntitiesValidation(this IContainer container)
        {
            container.AddValidator<User, UserValidationService>();

            return container;
        }

        public static IContainer AddCollectionManagers(this IContainer container)
        {
            container.BindAsSingleton<IUsersCollectionManager, UsersCollectionManager>();

            return container;
        }
    }
}