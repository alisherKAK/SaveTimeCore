using AutoMapper;
using SaveTimeCore.DataModels.Business;
using SaveTimeCore.Domain.DTOs;
using SaveTimeCore.Domain.Resources;

namespace SaveTimeCore.Domain.AutoMapperProfiles
{
    public class RecordProfile : Profile
    {
        public RecordProfile()
        {
            CreateMap<Record, RecordDTO>();
            CreateMap<RecordDTO, RecordResource>();
            CreateMap<Record, RecordDTO>().ReverseMap();
            CreateMap<RecordDTO, RecordResource>().ReverseMap();
        }
    }
}
