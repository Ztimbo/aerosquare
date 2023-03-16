using AeroSquare.Entities;
using AeroSquare.Entities.DTOs;
using AeroSquare.Repository.Helpers.DbContent;

namespace AeroSquare.Repository.Repos.Interfaces
{
    public interface IOriginRepository : IGenericRepo<Origin>
    {
        public Task<IEnumerable<OriginDTO>> GetOrigins();
        public Task<bool> SaveOrigin(Origin origin);
        public Task<Origin> UpdateOrigin(Origin origin);
    }
}
