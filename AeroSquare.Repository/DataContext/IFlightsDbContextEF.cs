using AeroSquare.Entities;
using AeroSquare.Repository.Helpers.DbContent;
using Microsoft.EntityFrameworkCore;

namespace AeroSquare.Repository.DataContext
{
    public interface IFlightsDbContextEF : IDbContext
    {
        public DbSet<Airplane> Airplane { get; set; }
        public DbSet<City> City { get; set; }
    }
}
