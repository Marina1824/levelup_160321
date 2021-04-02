using Bill.Management.Core.Abstractions.Container;
using Bill.Management.Core.Abstractions.Services.Validation;

namespace Bill.Management.Core.Abstractions
{
    public static class ServiceExtensions
    {
        public static IContainer AddValidator<TEntity, TValidationService>(this IContainer container)
            where TEntity : class
            where TValidationService : class, IValidationService<TEntity>
        {
            container.BindAsSingleton<IValidationService<TEntity>, TValidationService>();

            return container;
        }
    }
}