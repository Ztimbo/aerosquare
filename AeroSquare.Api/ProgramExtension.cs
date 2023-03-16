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

            //Repos
            services.AddTransient<IAirplaneRepository, AirplaneRepository>();
            services.AddTransient<ICityRepository, CityRepository>();

            //AutoMapper
            services.AddAutoMapper(typeof(Program));

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AirplaneProfile());
                mc.AddProfile(new CityProfile());
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
