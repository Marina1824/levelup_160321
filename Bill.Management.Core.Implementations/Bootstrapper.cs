using System;
using Bill.Management.Core.Abstractions;
using Bill.Management.Core.Abstractions.Logging;
using Bill.Management.Core.Abstractions.Services.JsonPersistence;
using Bill.Management.Core.Implementations.Logging;
using Bill.Management.Core.Implementations.Services.JsonPersistence;
using Ninject;

namespace Bill.Management.Core.Implementations
{
    public static class Bootstrapper
    {
        public static IKernel AddLogger(this IKernel container)
        {
            container.Bind<ILoggerService>().To<LoggerService>().InSingletonScope();

            return container;
        }

        public static IKernel AddJson(this IKernel container)
        {
            container.Bind<IJsonPersistenceService>().To<NewtonsoftJsonPersistenceService>().InSingletonScope();

            return container;
        }
    }
}
