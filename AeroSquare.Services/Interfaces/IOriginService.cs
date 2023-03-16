using AeroSquare.Entities;
using AeroSquare.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSquare.Services.Interfaces
{
    public interface IOriginService
    {
        public Task<IEnumerable<OriginDTO>> GetOrigins();
        public Task<bool> SaveOrigin(Origin origin);
        public Task<Origin> UpdateOrigin(Origin origin);
    }
}
