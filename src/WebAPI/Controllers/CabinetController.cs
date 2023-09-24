using CabinetManagement.Application.IO.CreateCabinetType;
using Microsoft.AspNetCore.Mvc;

namespace CabinetManagement.WebAPI.Controllers;

public class CabinetController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateCabinetTypeResponse>> CreateCabinet([FromBody] CreateCabinetTypeCommand request)
    {
        return await Mediator.Send(request);
    }
}
