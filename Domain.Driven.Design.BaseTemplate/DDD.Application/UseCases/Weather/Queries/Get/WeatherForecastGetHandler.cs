using DDD.Domain.Entities;
using MediatR;

namespace DDD.Application.UseCases.Weather.Queries.Get
{
    public class WeatherForecastGetHandler : IRequestHandler<WeatherForecastGetQuery, WeatherForecastViewModel>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecastViewModel> Handle(WeatherForecastGetQuery request, CancellationToken cancellationToken)
        {
            Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            return Task.FromResult(new WeatherForecastViewModel());
        }
    }
}
