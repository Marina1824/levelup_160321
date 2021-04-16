namespace Bill.Management.Windows.ViewModels.Factories
{
    public interface IDynamicFactory<TData>
        where TData : class
    {
        TData Create();
    }
}