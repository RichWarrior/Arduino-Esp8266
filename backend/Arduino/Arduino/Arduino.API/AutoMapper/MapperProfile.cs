using Arduino.API.Dto.Request.Auth;
using Arduino.API.Dto.Request.Device;
using Arduino.API.Dto.Response.Auth;
using AutoMapper;
using Core.Entities;

namespace Arduino.API.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegisterRequestDTO, User>();
            CreateMap<User, LogInResponse>();
            CreateMap<InsertDeviceRequestDTO, Device>();
        }
    }
}
