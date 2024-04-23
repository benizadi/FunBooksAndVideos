using Application.Commands;
using Application.Common;
using Application.Queries;
using Application.Services;
using Contracts;
using FluentResults;

namespace Application.Handlers;

public sealed record CreatePurchaseOrderRequest(PurchaseOrder PurchaseOrder) : ICommand<string>
{
    internal sealed class CreatePurchaseOrderRequestHandler(
        ICreatePurchaseOrderCommand createPurchaseOrderCommand,
        IPurchaseOrderRuleProcessor purchaseOrderRuleProcessor,
        IGetCustomerQuery getCustomerQuery)
        : ICommandHandler<CreatePurchaseOrderRequest, string>
    {
        public async Task<Result<string>> Handle(CreatePurchaseOrderRequest request, CancellationToken cancellationToken)
        {
            var customer = await getCustomerQuery.Execute(new GetCustomerQueryArgs(request.PurchaseOrder.CustomerId));
            
            if(customer == null) return Result.Fail("failed to find a relevant customer for the provided Id");
            
            var result = await createPurchaseOrderCommand.Execute(new CreatePurchaseOrderCommandArgs(request.PurchaseOrder));
            
            if (result.IsFailed)
                return Result.Fail("failed to create purchase order");

            var ruleResult = await purchaseOrderRuleProcessor.ProcessAsync(request.PurchaseOrder);
            
            if (ruleResult.IsFailed)
                return Result.Fail(ruleResult.Errors);

            return Result.Ok(); 
        }
    }
}