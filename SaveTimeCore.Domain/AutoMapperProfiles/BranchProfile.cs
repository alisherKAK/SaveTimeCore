using AutoMapper;
using SaveTimeCore.DataModels.Organization;
using SaveTimeCore.Domain.DTOs;
using SaveTimeCore.Domain.Resources;

namespace SaveTimeCore.Domain.AutoMapperProfiles
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<Branch, BranchDTO>();
            CreateMap<BranchDTO, BranchResource>();
            CreateMap<Branch, BranchDTO>().ReverseMap();
            CreateMap<BranchDTO, BranchResource>().ReverseMap();
        }
    }
}
