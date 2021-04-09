using AutoMapper;
using Bill.Management.Core.Abstractions.Services.Mapper;

namespace Bill.Management.Core.Implementations.Services.Mapper
{
    public abstract class AutoMapperService : IMapService
    {
        private IMapper _mapper;

        protected AutoMapperService()
        {
            Init();
        }

        public TDestination Map<TSource, TDestination>(TSource data)
            where TSource : class
            where TDestination : class
        {
            return _mapper.Map<TSource, TDestination>(data);
        }

        protected abstract void Configure(IMapperConfigurationExpression mapperConfigurationExpression);

        private void Init()
        {
            MapperConfiguration configuration = new MapperConfiguration(Configure);

            _mapper = configuration.CreateMapper();
        }
    }
}