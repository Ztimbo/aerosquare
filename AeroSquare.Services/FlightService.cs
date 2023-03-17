using AeroSquare.Entities.DTOs;
using AeroSquare.Repository.Repos.Interfaces;
using AeroSquare.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }
        public async Task<IEnumerable<FlightDTO>> GetFlights()
        {
            return await _flightRepository.GetFlights();
        }
    }
}
