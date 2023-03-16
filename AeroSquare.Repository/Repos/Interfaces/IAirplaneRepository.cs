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
    public interface IAirplaneRepository : IGenericRepo<Airplane>
    {
        public Task<IEnumerable<AirplaneDTO>> GetAirplanes();
        public Task<bool> SaveAirplane(Airplane airplane);
        public Task<Airplane> UpdateAirplane(Airplane airplane);
    }
}
