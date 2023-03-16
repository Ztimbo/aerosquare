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
        public DbSet<Destination> Destination { get; set; }
        public DbSet<Origin> Origin { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<FlightDays> FlightDays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString, b => b.MigrationsAssembly("AeroSquare.Api"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>(entity =>
            {
                entity.ToTable("Airplane");
                entity.HasKey(e => e.AirplaneId);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Capacity).HasMaxLength(32767);
                entity.Property(e => e.FlightCrew).HasMaxLength(32767);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");
                entity.HasKey(e => e.CityId);
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Origin>(entity =>
            {
                entity.ToTable("Origin");
                entity.HasKey(e => e.OriginId);
                entity.HasOne(x => x.City).WithOne(x => x.Origin).HasForeignKey<City>(x => x.CityId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Destination>(entity =>
            {
                entity.ToTable("Destination");
                entity.HasKey(e => e.DestinationId);
                entity.HasOne(x => x.City).WithOne(x => x.Destination).HasForeignKey<City>(x => x.CityId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<FlightDays>(entity =>
            {
                entity.ToTable("FlightDays");
                entity.HasKey(e => e.FlightDayId);
                entity.HasMany(x => x.Flights).WithMany(x => x.FlightDays);
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("Flight");
                entity.HasKey(e => e.FlightId);
                entity.HasOne(x => x.Origin).WithOne(x => x.Flight).HasForeignKey<Origin>(x => x.OriginId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(x => x.Destination).WithOne(x => x.Flight).HasForeignKey<Destination>(x => x.DestinationId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(x => x.Airplane).WithOne(x => x.Flight).HasForeignKey<Airplane>(x => x.AirplaneId).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(x => x.FlightDays).WithMany(x => x.Flights);
            });
        }
    }
}
