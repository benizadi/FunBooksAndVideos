using Application.Commands;
using Contracts;
using FluentResults;

namespace Application.Services.Processors;

public class MemberActivationRuleProcessor(
    IActivateMembershipCommand activateMembershipCommand)
    : IPurchaseOrderTypeProcessor
{
    public bool IsMatch(PurchaseOrder purchaseOrder)
    {
        return purchaseOrder.Membership != null;
    }

    public async Task<Result> ProcessAsync(PurchaseOrder purchaseOrder)
    {
        var result = await activateMembershipCommand.Execute(new ActivateMembershipCommandArgs(purchaseOrder.CustomerId));
        
        if (result.IsFailed)
            return Result.Fail("Failed to generate shipping slip");
        
        return Result.Ok();
    }
}