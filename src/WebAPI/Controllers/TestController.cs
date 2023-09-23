using CabinetManagement.Application.IO.CreateCabinetType;
using Microsoft.AspNetCore.Mvc;

namespace CabinetManagement.WebAPI.Controllers;

public class TestController : ApiControllerBase
{
    [HttpGet]
    [Route("/create")]
    public async Task<ActionResult<CreateCabinetTypeResponse>> GetWard([FromQuery] CreateCabinetTypeCommand request)
    {
        return await Mediator.Send(request);
    }
}
