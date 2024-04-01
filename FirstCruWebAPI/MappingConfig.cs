using AutoMapper;
using FirstCruWebAPI.Models;
using FirstCruWebAPI.Models.Dto;

namespace FirstCruWebAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<UserRegistrationDto, UserRegistration>();
                config.CreateMap<UserRegistration, UserRegistrationDto>();
            });
            return mappingConfig;
        }
    }
}
