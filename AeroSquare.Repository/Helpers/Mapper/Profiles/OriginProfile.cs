using AeroSquare.Entities;
using AeroSquare.Entities.DTOs;
using AutoMapper;

namespace AeroSquare.Repository.Helpers.Mapper.Profiles
{
    public class OriginProfile : Profile
    {
        public OriginProfile()
        {
            CreateMap<OriginDTO, Origin>();
        }
    }
}
