using DDD.Application.Interfaces;
using DDD.Domain.Entities.AggregateRoots;
using DDD.Infrastructure.EntityFramework.Contexts;

namespace DDD.Infrastructure.EntityFramework.Repositories
{
    public class WeatherForecastRepository : GenericRepository<WeatherForecast, WeatherForecastDBContext>, IWeatherForecastRepository
    {
        public WeatherForecastRepository(WeatherForecastDBContext context) 
            : base(context) 
        {
        }
    }
}
