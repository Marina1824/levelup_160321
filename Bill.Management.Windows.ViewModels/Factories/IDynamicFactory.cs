namespace Bill.Management.Windows.ViewModels.Factories
{
    public interface IDynamicFactory<TData>
        where TData : class
    {
        TData Create();
    }

    public interface IDynamicFactory<TData, TArgument>
        where TData : class
    {
        TData Create(TArgument argument);
    }
}