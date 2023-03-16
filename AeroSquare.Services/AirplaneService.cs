using AeroSquare.Entities;
using AeroSquare.Entities.DTOs;
using AeroSquare.Repository.Repos.Interfaces;
using AeroSquare.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AeroSquare.Services
{
    public class AirplaneService : IAirplaneService
    {
        private readonly IAirplaneRepository _airplaneRepository;

        public AirplaneService(IAirplaneRepository airplaneRepository)
        {
            _airplaneRepository = airplaneRepository;
        }

        public async Task<IEnumerable<AirplaneDTO>> GetAirplanes()
        {
            return await _airplaneRepository.GetAirplanes();
        }

        public async Task<bool> SaveAirplane(Airplane airplane)
        {
            return await _airplaneRepository.SaveAirplane(airplane);
        }

        public async Task<Airplane> UpdateAirplane(Airplane airplane)
        {
            return await _airplaneRepository.UpdateAirplane(airplane);
        }
    }
}
