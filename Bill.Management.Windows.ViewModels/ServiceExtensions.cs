using Bill.Management.Windows.ViewModels.Factories;
using Bill.Management.Windows.ViewModels.Services.Dialog;
using Bill.Management.Windows.ViewModels.View;
using Ninject;
using Ninject.Extensions.Factory;

namespace Bill.Management.Windows.ViewModels
{
    public static class ServiceExtensions
    {
        public static IKernel AddDialogService(this IKernel kernel)
        {
            kernel.Bind<IDialogService>().To<DialogService>().InSingletonScope();

            return kernel;
        }

        public static IKernel AddCommandFactory(this IKernel kernel)
        {
            kernel.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            return kernel;
        }

        public static IKernel AddDialogFactory(this IKernel kernel)
        {
            kernel.Bind<ICustomDynamicFactory<IDialogView>>().ToFactory().InSingletonScope();

            return kernel;
        }

        public static IKernel AddFactory<TFactory, TData>(this IKernel kernel) 
            where TFactory : class, IDynamicFactory<TData>
            where TData : class
        {
            kernel.Bind<TData>().ToSelf().InTransientScope();

            kernel.Bind<TFactory>().ToFactory().InSingletonScope();


            return kernel;
        }
    }
}