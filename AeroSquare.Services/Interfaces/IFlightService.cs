using AeroSquare.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Services.Interfaces
{
    public interface IFlightService
    {
        public Task<IEnumerable<FlightDTO>> GetFlights();
    }
}
