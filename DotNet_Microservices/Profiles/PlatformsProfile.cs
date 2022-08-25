using AutoMapper;
using DotNet_Microservices.Dtos;
using DotNet_Microservices.Models;

namespace DotNet_Microservices.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            CreateMap<Platform,PlatformReadDto>();
            CreateMap<PlatformCreateDto,Platform>();
        }
    }
}