using Application.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController(ISender mediator) : ControllerBase
{
    [HttpGet]
    [Route("GetAllActiveMemberCustomer")]
    public async Task<IActionResult> GetAllActiveMemberCustomer()
    {
        var result = await mediator.Send(new GetActiveMemberCustomersRequest());

        if(result.IsSuccess)
            return Ok(result);

        return BadRequest(result.Errors);
    }
}