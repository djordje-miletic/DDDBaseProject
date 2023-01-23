using DDD.Domain.Entities.AggregateRoots;

namespace DDD.Application.UseCases.Weather.Queries.Get
{
    public class WeatherForecastViewModel
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }

        public WeatherForecastViewModel(WeatherForecast weatherForecast)
        {
            this.Date = weatherForecast.Date;
            this.TemperatureC = weatherForecast.Temperature.TemperatureC;
            this.Summary= weatherForecast.Summary;
        }
    }
}
