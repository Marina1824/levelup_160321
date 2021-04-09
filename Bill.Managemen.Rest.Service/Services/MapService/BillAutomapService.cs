using AutoMapper;
using Bill.Management.Abstractions;
using Bill.Management.Core.Implementations.Services.Mapper;
using Bill.Management.Data.Transfer;

namespace Bill.Managemen.Rest.Service.Services.MapService
{
    internal sealed class BillAutomapService : AutoMapperService
    {
        protected override void Configure(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression
                .CreateMap<User, UserTransfer>()
                .ForMember(
                    dst => dst.Name, 
                    opt => opt.MapFrom(src => src.FirstName))
                .ForMember(
                    dst => dst.SecondName,
                    opt => opt.MapFrom(src => src.LastName))
                .ForMember(
                    dst => dst.ThirdName,
                    opt => opt.MapFrom(src => src.MiddleName))
                .ForMember(
                    dst => dst.INN, 
                    opt => opt.MapFrom(src => string.Empty)/*opt.Ignore()*/);

            mapperConfigurationExpression
                .CreateMap<UserTransfer, User>()
                .ForMember(
                    dst => dst.FirstName,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(
                    dst => dst.LastName,
                    opt => opt.MapFrom(src => src.SecondName))
                .ForMember(
                    dst => dst.MiddleName,
                    opt => opt.MapFrom(src => src.ThirdName));
        }
    }
}