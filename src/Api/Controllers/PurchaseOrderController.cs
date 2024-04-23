using Application.Handlers;
using Contracts;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("PurchaseOrder")]
public class PurchaseOrderController(ISender mediator, IValidator<PurchaseOrder> validator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(PurchaseOrder purchaseOrder)
    {
        var validationResult = await validator.ValidateAsync(purchaseOrder);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        
        var result = await mediator.Send(new CreatePurchaseOrderRequest( purchaseOrder));
        
        if(result.IsSuccess)
            return Ok(result);
        
        return BadRequest(result.Errors);
    }
}