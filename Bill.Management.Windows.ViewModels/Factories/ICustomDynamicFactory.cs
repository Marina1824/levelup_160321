namespace Bill.Management.Windows.ViewModels.Factories
{
    public interface ICustomDynamicFactory<TData>
        where TData : class
    {
        TData Create<TMainData>()
            where TMainData : TData;
    }
}