using Bill.Management.Abstractions;
using Bill.Management.Abstractions.Data.Invoices;
using Bill.Management.Abstractions.Data.Users;
using Bill.Management.Core.Abstractions;
using Bill.Management.Core.Abstractions.Container;
using Bill.Management.Implementations.Data.Users;
using Bill.Management.Implementations.Data.Users.Managers;
using Bill.Management.Implementations.Data.Users.Repositories;
using Bill.Management.Implementations.Data.Users.Validators;
using BillManagement.Imlementations.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Bill.Management.Implementations
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddSqlRepositories(this IServiceCollection container)
        {
            /* Используем даппер либо быстрый доступ */
            //container.AddSingleton<IUserRepository, UserSqlRepository>();
            
            /* Используем EF Core репозиторий */
            container.AddSingleton<IUserRepository, UseEfRepository>();

            container.AddSingleton<IInvoiceRepository, InvoiceEfRepository>();

            return container;
        }

        public static IServiceCollection AddJsonRepositories(this IServiceCollection container)
        {
            return container;
        }

        public static IServiceCollection AddEntitiesValidation(this IServiceCollection container)
        {
            container.AddValidator<User, UserValidationService>();
            container.AddValidator<Invoice, InvoiceValidationService>();

            return container;
        }

        public static IServiceCollection AddCollectionManagers(this IServiceCollection container)
        {
            container.AddSingleton<IUsersCollectionManager, UsersCollectionManager>();
            container.AddSingleton<IInvoiceCollectionManager, InvoiceCollectionManager>();

            return container;
        }
    }
}