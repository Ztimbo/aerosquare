using AeroSquare.Entities;
using AeroSquare.Entities.DTOs;
using AeroSquare.Repository.DataContext;
using AeroSquare.Repository.Helpers.DbContent;
using AeroSquare.Repository.Repos.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Repository.Repos
{
    public class CityRepository : GenericRepo<City>, ICityRepository
    {
        private readonly IFlightsDbContextEF _flightsDbContextEF;
        private readonly IMapper _mapper;

        public CityRepository(IFlightsDbContextEF flightsDbContextEF, IMapper mapper) : base(flightsDbContextEF)
        {
            _flightsDbContextEF = flightsDbContextEF;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDTO>> GetCities()
        {
            var result = _flightsDbContextEF.City;
            return _mapper.Map<IEnumerable<CityDTO>>(result);
        }

        public async Task<bool> SaveCity(City city)
        {
            _flightsDbContextEF.City.Add(city);
            await _flightsDbContextEF.SaveChangesAsync();
            return true;
        }

        public async Task<City> UpdateCity(City city)
        {
            var savedCity = _flightsDbContextEF.City.FirstOrDefault(x => x.Id == city.Id);

            if (savedCity == null)
            {
                throw new FileNotFoundException();
            }

            savedCity.Name = city.Name;
            savedCity.IsOrigin = city.IsOrigin;
            savedCity.IsDestination = city.IsDestination;

            _flightsDbContextEF.City.Update(savedCity);
            await _flightsDbContextEF.SaveChangesAsync();
            return savedCity;
        }
    }
}
