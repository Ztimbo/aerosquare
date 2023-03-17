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
    public class OriginRepository : GenericRepo<Origin>, IOriginRepository
    {
        private readonly IFlightsDbContextEF _flightsDbContextEF;
        private readonly IMapper _mapper;

        public OriginRepository(IFlightsDbContextEF flightsDbContextEF, IMapper mapper) : base(flightsDbContextEF)
        {
            _flightsDbContextEF = flightsDbContextEF;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OriginDTO>> GetOrigins()
        {
            var result = _flightsDbContextEF.City;
            return _mapper.Map<IEnumerable<OriginDTO>>(result);
        }

        public async Task<bool> SaveOrigin(Origin origin)
        {
            _flightsDbContextEF.Origin.Add(origin);
            await _flightsDbContextEF.SaveChangesAsync();
            return true;
        }

        public async Task<Origin> UpdateOrigin(Origin origin)
        {
            var savedOrigin = _flightsDbContextEF.Origin.FirstOrDefault(x => x.OriginId == origin.OriginId);

            if (savedOrigin == null)
            {
                throw new FileNotFoundException();
            }

            savedOrigin.City.CityId = origin.City.CityId;

            _flightsDbContextEF.Origin.Update(savedOrigin);
            await _flightsDbContextEF.SaveChangesAsync();
            return savedOrigin;
        }
    }
}
