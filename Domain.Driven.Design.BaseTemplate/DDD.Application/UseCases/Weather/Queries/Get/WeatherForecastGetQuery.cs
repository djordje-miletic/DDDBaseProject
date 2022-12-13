using MediatR;

namespace DDD.Application.UseCases.Weather.Queries.Get
{
    public record WeatherForecastGetQuery(int DaysSelected) : IRequest<WeatherForecastViewModel>;
}
