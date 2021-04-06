using Bill.Management.Core.Abstractions.Container;
using Bill.Management.Core.Abstractions.Services.JsonPersistence;
using Bill.Management.Core.Abstractions.Services.Logging;
using Bill.Management.Core.Abstractions.Services.Validation;
using Bill.Management.Core.Implementations.Services.JsonPersistence;
using Bill.Management.Core.Implementations.Services.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Bill.Management.Core.Implementations
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddLogger(this IServiceCollection container)
        {
            container.AddSingleton<ILoggerService, LoggerService>();

            return container;
        }

        public static IServiceCollection AddJson(this IServiceCollection container)
        {
            container.AddSingleton<IJsonPersistenceService, NewtonsoftJsonPersistenceService>();

            return container;
        }

        
    }
}
