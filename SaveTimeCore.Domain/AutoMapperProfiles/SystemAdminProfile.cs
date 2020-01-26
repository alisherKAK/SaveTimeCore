using AutoMapper;
using SaveTimeCore.DataModels.Organization;
using SaveTimeCore.Domain.DTOs;
using SaveTimeCore.Domain.Resources;

namespace SaveTimeCore.Domain.AutoMapperProfiles
{
    public class SystemAdminProfile : Profile
    {
        public SystemAdminProfile()
        {
            CreateMap<SystemAdmin, SystemAdminDTO>();
            CreateMap<SystemAdminDTO, SystemAdminResource>();
            CreateMap<SystemAdmin, SystemAdminDTO>().ReverseMap();
            CreateMap<SystemAdminDTO, SystemAdminResource>().ReverseMap();
        }
    }
}
