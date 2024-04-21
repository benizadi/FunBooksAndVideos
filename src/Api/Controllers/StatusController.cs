using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StatusController : ControllerBase
{
    [HttpGet(Name = "GetStatus")]
    public IActionResult Get()
    {
        return Ok();
    }
}