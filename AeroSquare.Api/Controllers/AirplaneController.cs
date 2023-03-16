using AeroSquare.Entities;
using AeroSquare.Entities.DTOs;
using AeroSquare.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AeroSquare.Api.Controllers
{
    [ApiController]
    [Route("api/airplane")]
    [EnableCors("AllowAll")]
    public class AirplaneController : ControllerBase
    {
        private readonly IAirplaneService _airplaneService;
        public AirplaneController(IAirplaneService airplaneService)
        {
            _airplaneService = airplaneService;
        }

        [HttpGet]
        public async Task<IEnumerable<AirplaneDTO>> Get()
        {
            return await _airplaneService.GetAirplanes();
        }

        [HttpPost]
        public async Task<bool> Save([FromBody] Airplane airplane)
        {
            return await _airplaneService.SaveAirplane(airplane);
        }

        [HttpPut]
        public async Task<Airplane> Update([FromBody] Airplane airplane)
        {
            return await _airplaneService.UpdateAirplane(airplane);
        }
    }
}
