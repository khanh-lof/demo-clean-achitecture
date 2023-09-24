using CabinetManagement.WebAPI.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CabinetManagement.WebAPI.Controllers;

[ApiController]
[ApiExceptionFilter]
[Route("api/v1/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{

    protected IMediator Mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();
}
