using AutoMapper;
using SaveTimeCore.DataModels.Dictionary;
using SaveTimeCore.Domain.DTOs;
using SaveTimeCore.Domain.Resources;

namespace SaveTimeCore.Domain.AutoMapperProfiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Service, ServiceDTO>();
            CreateMap<ServiceDTO, ServiceResource>();
            CreateMap<Service, ServiceDTO>().ReverseMap();
            CreateMap<ServiceDTO, ServiceResource>().ReverseMap();
        }
    }
}
