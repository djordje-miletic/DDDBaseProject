using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DDD.API.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IMediator Mediator => this.HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
