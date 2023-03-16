using AeroSquare.Entities;
using AeroSquare.Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AeroSquare.Services.Interfaces
{
    public interface IAirplaneService
    {
        public Task<IEnumerable<AirplaneDTO>> GetAirplanes();
        public Task<bool> SaveAirplane(Airplane airplane);
        public Task<Airplane> UpdateAirplane(Airplane airplane);
    }
}
