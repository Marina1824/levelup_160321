using Bill.Management.Abstractions.Data.Users;
using Bill.Management.Implementations.Data.Users;
using Ninject;

namespace Bill.Management.Implementations
{
    public static class Bootstrapper
    {
        public static IKernel AddSqlRepositories(this IKernel container)
        {
            container.Bind<IUserRepository>().To<UserSqlRepository>().InSingletonScope();

            return container;
        }

        public static IKernel AddJsonRepositories(this IKernel container)
        {
            return container;
        }
    }
}