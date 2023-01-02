using DDD.Domain.Common;
using DDD.Domain.DomainEvents.WeatherForecasts;
using DDD.Domain.Entities.ValueObjects;
using DDD.Domain.Interfaces;

namespace DDD.Domain.Entities.AggregateRoots
{
    public class WeatherForecast : AggregateRoot, IAudit
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public Temperature Temperature { get; set; } = null!;

        public string? Summary { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }

        private WeatherForecast()
        {

        }

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
