using AeroSquare.Entities.DTOs;
using AeroSquare.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AeroSquare.Api.Controllers
{
    [ApiController]
    [Route("api/flight")]
    [EnableCors("AllowAll")]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<FlightDTO>> Get()
        {
            return await _flightService.GetFlights();
        }
    }
}
