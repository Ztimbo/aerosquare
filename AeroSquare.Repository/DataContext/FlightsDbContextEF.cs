using AeroSquare.Entities;
using AeroSquare.Repository.Helpers.DbContent;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AeroSquare.Repository.DataContext
{
    public class FlightsDbContextEF : BaseDbContext<FlightsDbContextEF>, IFlightsDbContextEF
    {
        private readonly string _connectionString;

        public FlightsDbContextEF(IConfiguration configuration) : base()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<FlightsDbContextEF, EF6Console.Migrations.Configuration>());
            _connectionString = configuration["SqlDbConnectionString"];
        }

        public DbSet<Airplane> Airplane { get; set; }
        public DbSet<City> City { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString, b => b.MigrationsAssembly("AeroSquare.Api"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>(entity =>
            {
                entity.ToTable("Airplane");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Capacity).HasMaxLength(32767);
                entity.Property(e => e.FlightCrew).HasMaxLength(32767);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(100);
            });
        }
    }
}
