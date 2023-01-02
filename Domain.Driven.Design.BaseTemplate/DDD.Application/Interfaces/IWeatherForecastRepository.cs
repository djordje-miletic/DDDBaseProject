using DDD.Domain.Entities.AggregateRoots;

namespace DDD.Application.Interfaces
{
    public interface IWeatherForecastRepository : IGenericRepository<WeatherForecast>
    {
    }
}
