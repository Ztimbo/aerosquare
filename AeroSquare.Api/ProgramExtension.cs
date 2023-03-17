using AeroSquare.Repository.DataContext;
using AeroSquare.Repository.Helpers.Mapper.Profiles;
using AeroSquare.Repository.Repos;
using AeroSquare.Repository.Repos.Interfaces;
using AeroSquare.Services;
using AeroSquare.Services.Interfaces;
using AutoMapper;

namespace AeroSquare.Api
{
    public static class ProgramExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //Context
            services.AddDbContext<IFlightsDbContextEF, FlightsDbContextEF>();

            //Services
            services.AddTransient<IAirplaneService, AirplaneService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IOriginService, OriginService>();
            services.AddTransient<IFlightService, FlightService>();

            //Repos
            services.AddTransient<IAirplaneRepository, AirplaneRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IOriginRepository, OriginRepository>();
            services.AddTransient<IFlightRepository, FlightRepository>();

            //AutoMapper
            services.AddAutoMapper(typeof(Program));

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AirplaneProfile());
                mc.AddProfile(new CityProfile());
                mc.AddProfile(new OriginProfile());
                mc.AddProfile(new FlightProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            //CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            return services;

        }
    }
}
