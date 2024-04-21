using Application.Handlers;
using Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PurchaseOrderController(ISender mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePurchaseOrder(PurchaseOrder purchaseOrder)
    {
        var result = await mediator.Send(new CreatePurchaseOrderRequest( purchaseOrder));
        return Ok(result);
    }
}