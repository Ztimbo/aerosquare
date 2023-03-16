using AeroSquare.Entities;
using AeroSquare.Entities.DTOs;
using AutoMapper;

namespace AeroSquare.Repository.Helpers.Mapper.Profiles
{
    public class AirplaneProfile : Profile
    {
        public AirplaneProfile()
        {
            CreateMap<AirplaneDTO, Airplane>();
        }
    }
}
