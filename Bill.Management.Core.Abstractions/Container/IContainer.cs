namespace Bill.Management.Core.Abstractions.Container
{
    public interface IContainer
    {
        IContainer BindAsSingleton<TContract, TImplementation>()
            where TImplementation : class, TContract
            where TContract : class;

        TContract Resolve<TContract>()
            where TContract : class;

    }
}