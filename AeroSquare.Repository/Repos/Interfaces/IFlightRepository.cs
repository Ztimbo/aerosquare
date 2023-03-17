using AeroSquare.Entities;
using AeroSquare.Entities.DTOs;
using AeroSquare.Repository.Helpers.DbContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Repository.Repos.Interfaces
{
    public interface IFlightRepository : IGenericRepo<Flight>
    {
        public Task<IEnumerable<FlightDTO>> GetFlights();
    }
}
