using Bill.Management.Core.Abstractions.Container;
using Ninject;

namespace Bill.Management.Console.Container
{
    internal sealed class NinjectContainer : IContainer
    {
        private IKernel _container;

        public NinjectContainer(IKernel kernel)
        {
            _container = kernel;
        }

        public IContainer BindAsSingleton<TContract, TImplementation>() 
            where TContract : class 
            where TImplementation : class, TContract
        {
            _container.Bind<TContract>().To<TImplementation>().InSingletonScope();

            return this;
        }

        public TContract Resolve<TContract>()
            where TContract : class
        {
            return _container.Get<TContract>();
        }
    }
}