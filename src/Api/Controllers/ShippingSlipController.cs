using Application.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ShippingSlipController(ISender mediator) : ControllerBase
{
    [HttpGet]
    [Route("GetAllShippingSlips")]
    public async Task<IActionResult> GetAllShippingSlips()
    {
        var result = await mediator.Send(new GetAllShippingSlipsRequest());

        if(result.IsSuccess)
            return Ok(result);

        return BadRequest(result.Errors);
    }
}