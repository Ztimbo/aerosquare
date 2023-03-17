using AeroSquare.Entities;
using AeroSquare.Entities.DTOs;
using AeroSquare.Repository.DataContext;
using AeroSquare.Repository.Helpers.DbContent;
using AeroSquare.Repository.Repos.Interfaces;
using AutoMapper;

namespace AeroSquare.Repository.Repos
{
    public class FlightRepository : GenericRepo<Flight>, IFlightRepository
    {
        private readonly IFlightsDbContextEF _flightsDbContextEF;
        private readonly IMapper _mapper;

        public FlightRepository(IFlightsDbContextEF flightsDbContextEF, IMapper mapper) : base(flightsDbContextEF)
        {
            _flightsDbContextEF = flightsDbContextEF;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FlightDTO>> GetFlights()
        {
            var result = _flightsDbContextEF.Flight.Select(x => new FlightDTO
            { 
                FlightId = x.FlightId,
                FlightNumber = x.FlightNumber, 
                Origin = x.Origin.City.Name, 
                Destination = x.Destination.City.Name,
                DepartureTime = x.DepartureTime,
                ArrivalTime= x.ArrivalTime,
                Airplane = x.Airplane.Name,
                ListPrice = x.ListPrice
            });

            return result.ToList();
        }
    }
}
