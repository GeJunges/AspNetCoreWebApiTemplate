using AspNetCoreWebApiTemplate.Domain.DataTransferObject;
using AspNetCoreWebApiTemplate.Domain.ObjectModel;
using AutoMapper;

namespace AspNetCoreWebApiTemplate.API.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
           CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
