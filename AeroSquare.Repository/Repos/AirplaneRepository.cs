using AeroSquare.Entities;
using AeroSquare.Entities.DTOs;
using AeroSquare.Repository.DataContext;
using AeroSquare.Repository.Helpers.DbContent;
using AeroSquare.Repository.Repos.Interfaces;
using AutoMapper;

namespace AeroSquare.Repository.Repos
{
    public class AirplaneRepository : GenericRepo<Airplane>, IAirplaneRepository
    {
        private readonly IFlightsDbContextEF _flightsDbContextEF;
        private readonly IMapper _mapper;

        public AirplaneRepository(IFlightsDbContextEF flightsDbContextEF, IMapper mapper) : base(flightsDbContextEF)
        {
            _flightsDbContextEF = flightsDbContextEF;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AirplaneDTO>> GetAirplanes()
        {
            var result = _flightsDbContextEF.Airplane;
            return _mapper.Map<IEnumerable<AirplaneDTO>>(result);
        }

        public async Task<bool> SaveAirplane(Airplane airplane)
        {
            _flightsDbContextEF.Airplane.Add(airplane);
            await _flightsDbContextEF.SaveChangesAsync();
            return true;
        }

        public async Task<Airplane> UpdateAirplane(Airplane airplane)
        {
            var savedAirplane = _flightsDbContextEF.Airplane.FirstOrDefault(x => x.AirplaneId == airplane.AirplaneId);

            if(savedAirplane == null)
            {
                throw new FileNotFoundException();
            }

            savedAirplane.Name = airplane.Name;
            savedAirplane.Capacity = airplane.Capacity;
            savedAirplane.FlightCrew = airplane.FlightCrew;
            _flightsDbContextEF.Airplane.Update(savedAirplane);
            await _flightsDbContextEF.SaveChangesAsync();
            return savedAirplane;
        }
    }
}
