using Application.Commands;
using Application.Extensions;
using Application.Queries;
using Contracts;
using FluentResults;

namespace Application.Services.Processors;

public class ShippingSlipRuleProcessor(
    IGenerateShippingSlipCommand generateShippingSlipCommand,
    IGetCustomerQuery getCustomerQuery) : IPurchaseOrderTypeProcessor
{
    public bool IsMatch(PurchaseOrder purchaseOrder)
    {
        return purchaseOrder.Products.HasPhysicalProduct();
    }

    public async Task<Result> ProcessAsync(PurchaseOrder purchaseOrder)
    {
        var customer = await getCustomerQuery.Execute(new GetCustomerQueryArgs(purchaseOrder.CustomerId));
        
        if(customer == null)
        {
            return Result.Fail("Failed to retrieve the customer while processing Shipping Slip");
        };
        
        var result = await generateShippingSlipCommand.Execute(
            new GenerateShippingSlipCommandArgs(purchaseOrder, customer!));

        if (result.IsFailed)
            return Result.Fail("Failed to generate shipping slip");
        
        return Result.Ok();
    }
}