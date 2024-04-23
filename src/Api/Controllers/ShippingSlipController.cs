using Application.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("ShippingSlips")]
public class ShippingSlipController(ISender mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllShippingSlipsRequest());

        if(result.IsSuccess)
            return Ok(result);

        return BadRequest(result.Errors);
    }
}