using AeroSquare.Entities;
using AeroSquare.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Services.Interfaces
{
    public interface ICityService
    {
        public Task<IEnumerable<CityDTO>> GetCities();
        public Task<bool> SaveCity(City city);
        public Task<City> UpdateCity(City city);
    }
}
