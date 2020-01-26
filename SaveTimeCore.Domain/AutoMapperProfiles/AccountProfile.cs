using AutoMapper;
using SaveTimeCore.DataModels.Organization;
using SaveTimeCore.Domain.DTOs;
using SaveTimeCore.Domain.Resources;

namespace SaveTimeCore.Domain.AutoMapperProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDTO>();
            CreateMap<AccountDTO, AccountResource>();
            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<AccountDTO, AccountResource>().ReverseMap();
        }
    }
}
