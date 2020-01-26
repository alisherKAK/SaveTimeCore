using AutoMapper;
using SaveTimeCore.DataModels.Business;
using SaveTimeCore.Domain.DTOs;
using SaveTimeCore.Domain.Resources;

namespace SaveTimeCore.Domain.AutoMapperProfiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<ClientDTO, ClientResource>();
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<ClientDTO, ClientResource>().ReverseMap();
        }
    }
}
