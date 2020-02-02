using AutoMapper;
using SaveTimeCore.Domain.AutoMapperProfiles;

namespace SaveTimeCore.Domain.AutoMapperConfigurations
{
    public class AutoMapperConfiguration
    {
        public static IMapper Config()
        {
            return new MapperConfiguration(c =>
            {
                c.AddProfile<BarberProfile>();
                c.AddProfile<AccountProfile>();
                c.AddProfile<ClientProfile>();
                c.AddProfile<RecordProfile>();
            }).CreateMapper();
        }
    }
}
