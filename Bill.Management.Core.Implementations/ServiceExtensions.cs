using Bill.Management.Core.Abstractions.Container;
using Bill.Management.Core.Abstractions.Services.JsonPersistence;
using Bill.Management.Core.Abstractions.Services.Logging;
using Bill.Management.Core.Abstractions.Services.Validation;
using Bill.Management.Core.Implementations.Services.JsonPersistence;
using Bill.Management.Core.Implementations.Services.Logging;

namespace Bill.Management.Core.Implementations
{
    public static class ServiceExtensions
    {
        public static IContainer AddLogger(this IContainer container)
        {
            container.BindAsSingleton<ILoggerService, LoggerService>();

            return container;
        }

        public static IContainer AddJson(this IContainer container)
        {
            container.BindAsSingleton<IJsonPersistenceService, NewtonsoftJsonPersistenceService>();

            return container;
        }

        
    }
}
