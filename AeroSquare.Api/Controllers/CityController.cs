using AeroSquare.Entities;
using AeroSquare.Entities.DTOs;
using AeroSquare.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AeroSquare.Api.Controllers
{
    [ApiController]
    [Route("api/city")]
    [EnableCors("AllowAll")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<CityDTO>> Get()
        {
            return await _cityService.GetCities();
        }

        [HttpPost]
        public async Task<bool> Save([FromBody] City city)
        {
            return await _cityService.SaveCity(city);
        }

        [HttpPut]
        public async Task<City> Update([FromBody] City city)
        {
            return await _cityService.UpdateCity(city);
        }
    }
}
