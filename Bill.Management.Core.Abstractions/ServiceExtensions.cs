using Bill.Management.Core.Abstractions.Container;
using Bill.Management.Core.Abstractions.Services.Mapper;
using Bill.Management.Core.Abstractions.Services.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace Bill.Management.Core.Abstractions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddValidator<TEntity, TValidationService>(this IServiceCollection container)
            where TEntity : class
            where TValidationService : class, IValidationService<TEntity>
        {
            container.AddSingleton<IValidationService<TEntity>, TValidationService>();

            return container;
        }

        public static IServiceCollection AddMapService<TMapper>(this IServiceCollection container)
            where TMapper : class, IMapService
        {
            container.AddSingleton<IMapService, TMapper>();

            return container;
        }
    }
}