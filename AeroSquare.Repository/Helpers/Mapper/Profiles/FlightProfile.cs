using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AeroSquare.Entities;
using AeroSquare.Entities.DTOs;
using AutoMapper;

namespace AeroSquare.Repository.Helpers.Mapper.Profiles
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, FlightDTO>()
                .ForMember(x => x.Destination, y => y.MapFrom(src => src.Destination.City.Name))
                .ForMember(x => x.Origin, y => y.MapFrom(src => src.Origin.City.Name))
                .ForMember(x => x.Airplane, y => y.MapFrom(src => src.Airplane));
        }
    }
}
