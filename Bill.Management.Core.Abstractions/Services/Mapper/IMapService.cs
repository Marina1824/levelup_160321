namespace Bill.Management.Core.Abstractions.Services.Mapper
{
    public interface IMapService
    {
        TDestination Map<TSource, TDestination>(TSource data)
            where TSource : class
            where TDestination : class;
    }
}