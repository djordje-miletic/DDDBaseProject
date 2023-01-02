using DDD.Domain.Common;
using DDD.Domain.DomainEvents.WeatherForecasts;
using DDD.Domain.Entities.ValueObjects;

namespace DDD.Domain.Entities.AggregateRoots
{
    public class WeatherForecast : AggregateRoot
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public Temperature Temperature { get; set; } = null!;

        public string? Summary { get; set; }

        public WeatherForecast(DateTime date, int temperature, string? summary)
        {
            this.Id = Guid.NewGuid();

            this.Date = date;
            this.Temperature = new(temperature);
            this.Summary = summary;

            this.AddDomainEvent(new WeatherForecastCreated(this));
        }
    }
}
