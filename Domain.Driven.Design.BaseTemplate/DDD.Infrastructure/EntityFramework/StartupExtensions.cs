using DDD.Application.Interfaces;
using DDD.Infrastructure.EntityFramework.Contexts;
using DDD.Infrastructure.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Infrastructure.EntityFramework
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddEntityFrameworkServices(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<WeatherForecastDBContext>(options);

            services.AddTransient<IWeatherForecastRepository, WeatherForecastRepository>();

            services.AddScoped<IUnitOfWork, DDD.Infrastructure.EntityFramework.UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}
