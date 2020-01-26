using AutoMapper;
using SaveTimeCore.DataModels.Organization;
using SaveTimeCore.Domain.DTOs;
using SaveTimeCore.Domain.Resources;

namespace SaveTimeCore.Domain.AutoMapperProfiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, CompanyResource>();
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<CompanyDTO, CompanyResource>().ReverseMap();
        }
    }
}
