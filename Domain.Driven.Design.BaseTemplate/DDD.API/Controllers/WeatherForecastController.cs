using DDD.Application.UseCases.Weather.Queries.Get;
using DDD.Domain.Entities.AggregateRoots;
using DDD.Domain.Entities.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace DDD.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseController
    {
        public WeatherForecastController()
        {
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<WeatherForecastViewModel>> Get([FromRoute] Guid id)
        {
            return await this.Mediator.Send(new WeatherForecastGetQuery(id));
        }
    }
}