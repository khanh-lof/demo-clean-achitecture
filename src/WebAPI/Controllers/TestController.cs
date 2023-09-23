using CabinetManagement.Application.IO.Test;
using Microsoft.AspNetCore.Mvc;

namespace CabinetManagement.WebAPI.Controllers;

public class TestController : ApiControllerBase
{
    [HttpGet]
    [Route("/get")]
    public async Task<ActionResult<TestResponse>> GetWard([FromQuery] TestRequest request)
    {
        return await Mediator.Send(request);
    }
}
