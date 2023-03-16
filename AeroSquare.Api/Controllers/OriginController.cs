using AeroSquare.Entities;
using AeroSquare.Entities.DTOs;
using AeroSquare.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AeroSquare.Api.Controllers
{
    [ApiController]
    [Route("api/origin")]
    [EnableCors("AllowAll")]
    public class OriginController : ControllerBase
    {
        private readonly IOriginService _originService;
        public OriginController(IOriginService originService)
        {
            _originService = originService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<OriginDTO>> Get()
        {
            return await _originService.GetOrigins();
        }

        [HttpPost]
        public async Task<bool> Save([FromBody] Origin origin)
        {
            return await _originService.SaveOrigin(origin);
        }

        [HttpPut]
        public async Task<Origin> Update([FromBody] Origin origin)
        {
            return await _originService.UpdateOrigin(origin);
        }
    }
}
