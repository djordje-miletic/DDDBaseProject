using MediatR;

namespace DDD.Application.UseCases.Weather.Queries.Get
{
    public record WeatherForecastGetQuery(Guid DaysSelected) : IRequest<WeatherForecastViewModel>;
}
