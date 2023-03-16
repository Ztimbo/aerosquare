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
    public class OriginService : IOriginService
    {
        private readonly IOriginRepository _originRepository;

        public OriginService(IOriginRepository originRepository)
        {
            _originRepository = originRepository;
        }

        public async Task<IEnumerable<OriginDTO>> GetOrigins()
        {
            return await _originRepository.GetOrigins();
        }

        public async Task<bool> SaveOrigin(Origin origin)
        {
            return await _originRepository.SaveOrigin(origin);
        }

        public async Task<Origin> UpdateOrigin(Origin origin)
        {
            return await _originRepository.UpdateOrigin(origin);
        }
    }
}
