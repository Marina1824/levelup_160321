namespace Bill.Management.Windows.ViewModels.Factories
{
    public interface ICustomDynamicFactory<TData>
        where TData : class
    {
        TMainData Create<TMainData>()
            where TMainData : TData;
    }
}