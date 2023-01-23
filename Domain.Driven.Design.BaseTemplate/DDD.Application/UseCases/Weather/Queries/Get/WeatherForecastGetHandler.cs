using DDD.Domain.Entities.AggregateRoots;
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
            WeatherForecast forecast = new WeatherForecast(DateTime.Now.AddDays(1),
                Random.Shared.Next(-20, 55),
                Summaries[Random.Shared.Next(Summaries.Length)]);

            return Task.FromResult(new WeatherForecastViewModel(forecast));
        }
    }
}
