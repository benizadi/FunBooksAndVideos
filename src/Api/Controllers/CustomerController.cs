using Application.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("Customers")]
public class CustomerController(ISender mediator) : ControllerBase
{
    [HttpGet]
    [Route("ActiveMembership")]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetActiveMemberCustomersRequest());

        if(result.IsSuccess)
            return Ok(result);

        return BadRequest(result.Errors);
    }
}