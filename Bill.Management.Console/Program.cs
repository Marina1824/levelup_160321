using System.Collections.Generic;
using Bill.Management.Abstractions;
using Bill.Management.Console.Container;
using Bill.Management.Core.Abstractions.Container;
using Bill.Management.Core.Abstractions.Results;
using Bill.Management.Core.Implementations;
using Bill.Management.Implementations;
using Bill.Management.Implementations.Data.Users.Managers;
using Ninject;

namespace Bill.Management.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer container = new NinjectContainer(new StandardKernel())
                .AddLogger()
                .AddJson()
                .AddEntitiesValidation()
                .AddSqlRepositories()
                .AddCollectionManagers();

            IUsersCollectionManager manager = container.Resolve<IUsersCollectionManager>();

            IOperationResult<User> operationResult = DisplayFailuresIfExists(manager.CreateUser(new User()));

            if (operationResult.Succeed)
            {
                foreach (IOperationFailure user in operationResult.Failures)
                {
                    
                }
            }

        }

        public static IOperationResult<TResult> DisplayFailuresIfExists<TResult>(IOperationResult<TResult> result)
        {
            if (result.Succeed)
            {
                return result;
            }

            foreach (IOperationFailure failure in result.Failures)
            {
                System.Console.WriteLine($"{failure.PropertyName} - {failure.Description}");
            }

            return result;
        }
    }
}
