using AutoMapper;
using SaveTimeCore.DataModels.Organization;
using SaveTimeCore.Domain.DTOs;
using SaveTimeCore.Domain.Resources;

namespace SaveTimeCore.Domain.AutoMapperProfiles
{
    public class BarberProfile : Profile
    {
        public BarberProfile()
        {
            CreateMap<Barber, BarberDTO>();
            CreateMap<BarberDTO, BarberResource>();
            CreateMap<Barber, BarberDTO>().ReverseMap();
            CreateMap<BarberDTO, BarberResource>().ReverseMap();
        }
    }
}
