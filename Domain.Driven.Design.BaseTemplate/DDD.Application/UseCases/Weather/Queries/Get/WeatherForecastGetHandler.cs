using DDD.Domain.Entities;
using DDD.Domain.Entities.AggregateRoots;
using DDD.Domain.Entities.ValueObjects;
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
            Enumerable.Range(1, 5).Select(index => new WeatherForecast(DateTime.Now.AddDays(index),
                Random.Shared.Next(-20, 55),
                Summaries[Random.Shared.Next(Summaries.Length)]))
            .ToArray();

            return Task.FromResult(new WeatherForecastViewModel());
        }
    }
}
