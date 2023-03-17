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
                entity.HasData(
                        new Airplane { AirplaneId = 1, Name = "Embraer 317", Capacity = 126, FlightCrew = 6 },
                        new Airplane { AirplaneId = 2, Name = "Airbus 320", Capacity = 180, FlightCrew = 8 },
                        new Airplane { AirplaneId = 3, Name = "Boeing 767", Capacity = 186, FlightCrew = 10 }
                    );
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");
                entity.HasKey(e => e.CityId);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.HasData(
                        new City { CityId = 1, Name = "Portland" },
                        new City { CityId = 2, Name = "Las Vegas" },
                        new City { CityId = 3, Name = "Chicago" },
                        new City { CityId = 4, Name = "Boise" },
                        new City { CityId = 5, Name = "Dallas" }
                    );
            });

            modelBuilder.Entity<Origin>(entity =>
            {
                entity.ToTable("Origin");
                entity.HasKey(e => e.OriginId);
                entity.HasOne(x => x.City).WithMany().HasForeignKey(x => x.CityId).OnDelete(DeleteBehavior.NoAction);
                entity.HasData(
                        new Origin { OriginId = 1, CityId = 1 },
                        new Origin { OriginId = 4, CityId = 2 },
                        new Origin { OriginId = 2, CityId = 3 },
                        new Origin { OriginId = 5, CityId = 4 },
                        new Origin { OriginId = 3, CityId = 5 }
                    );
            });

            modelBuilder.Entity<Destination>(entity =>
            {
                entity.ToTable("Destination");
                entity.HasKey(e => e.DestinationId);
                entity.HasOne(x => x.City).WithMany().HasForeignKey(x => x.CityId).OnDelete(DeleteBehavior.NoAction);
                entity.HasData(
                        new Destination { DestinationId = 1, CityId = 2 },
                        new Destination { DestinationId = 2, CityId = 3 },
                        new Destination { DestinationId = 3, CityId = 4 },
                        new Destination { DestinationId = 4, CityId = 5 }
                    );
            });

            modelBuilder.Entity<FlightDays>(entity =>
            {
                entity.ToTable("FlightDays");
                entity.HasKey(e => e.FlightDayId);
                entity.HasMany(x => x.Flights).WithMany(x => x.FlightDays);
                entity.HasData(
                        new FlightDays { FlightDayId = 1, Name = "Monday" },
                        new FlightDays { FlightDayId = 2, Name = "Tuesday" },
                        new FlightDays { FlightDayId = 3, Name = "Wednesday" },
                        new FlightDays { FlightDayId = 4, Name = "Thursday" },
                        new FlightDays { FlightDayId = 5, Name = "Friday" },
                        new FlightDays { FlightDayId = 6, Name = "Saturday" },
                        new FlightDays { FlightDayId = 7, Name = "Sunday" }
                    );
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("Flight");
                entity.HasKey(e => e.FlightId);
                entity.HasOne(x => x.Origin).WithMany().HasForeignKey(x => x.OriginId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(x => x.Destination).WithMany().HasForeignKey(x => x.DestinationId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(x => x.Airplane).WithMany().HasForeignKey(x => x.AirplaneId).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(x => x.FlightDays).WithMany(x => x.Flights);
                entity.HasData(
                        new Flight { FlightId = 1, FlightNumber = "AES 108", OriginId = 1, DestinationId = 1, DepartureTime = new DateTime(1900, 1, 1, 6, 15, 0), ArrivalTime = new DateTime(1900, 1, 1, 7, 45, 0), AirplaneId = 1, ListPrice = 1037.28 },
                        new Flight { FlightId = 2, FlightNumber = "AES 210", OriginId = 4, DestinationId = 3, DepartureTime = new DateTime(1900, 1, 1, 10, 23, 0), ArrivalTime = new DateTime(1900, 1, 1, 14, 16, 0), AirplaneId = 2, ListPrice = 1500.17 },
                        new Flight { FlightId = 3, FlightNumber = "AES 325", OriginId = 3, DestinationId = 1, DepartureTime = new DateTime(1900, 1, 1, 20, 16, 0), ArrivalTime = new DateTime(1900, 1, 1, 21, 25, 0), AirplaneId = 3, ListPrice = 927 }
                    );
            });
        }
    }
}
