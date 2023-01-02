using DDD.Domain.Common;
using DDD.Domain.Entities.AggregateRoots;
using DDD.Domain.Entities.ValueObjects;

namespace DDD.Domain.DomainEvents.WeatherForecasts
{
    public class WeatherForecastCreated : IDomainEvent
    {
        public DateTime Date { get; set; }

        public Temperature Temperature { get; set; } = null!;

        public string? Summary { get; set; }

        public WeatherForecastCreated(WeatherForecast weatherForecast)
        {
            Date = weatherForecast.Date;
            Temperature = weatherForecast.Temperature;
            Summary = weatherForecast.Summary;
        }
    }
}
