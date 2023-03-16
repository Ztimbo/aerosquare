using AeroSquare.Entities;
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
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<CityDTO>> GetCities()
        {
            return await _cityRepository.GetCities();
        }

        public async Task<bool> SaveCity(City city)
        {
            return await _cityRepository.SaveCity(city);
        }

        public async Task<City> UpdateCity(City city)
        {
            return await _cityRepository.UpdateCity(city);
        }
    }
}
