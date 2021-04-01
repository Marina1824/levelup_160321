using Bill.Management.Abstractions.Data.Users;
using Bill.Management.Core.Implementations;
using Bill.Management.Implementations;
using Ninject;

namespace Bill.Management.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel()
                .AddLogger()
                .AddJson()
                .AddSqlRepositories();
            
            IUserRepository userRepository = kernel.Get<IUserRepository>();

            userRepository.Read();

        }
    }
}
