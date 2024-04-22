using Application.Commands;
using Application.Common;
using Application.Queries;
using Contracts;
using FluentResults;

namespace Application.Handlers;

public sealed record CreatePurchaseOrderRequest(PurchaseOrder PurchaseOrder): ICommand<string>
{
    internal sealed class CreatePurchaseOrderRequestHandler(
        ICreatePurchaseOrderCommand createPurchaseOrderCommand, 
        IGetCustomerQuery getCustomerQuery)
        : ICommandHandler<CreatePurchaseOrderRequest, string>
    {
        public async Task<Result<string>> Handle(CreatePurchaseOrderRequest request, CancellationToken cancellationToken)
        {
            var customer = await getCustomerQuery.Execute(new GetCustomerQueryArgs(request.PurchaseOrder.CustomerId));
            
            if(customer == null) return Result.Fail("failed to find a relevant customer for the provided Id");
            
            var result = await createPurchaseOrderCommand.Execute(new CreatePurchaseOrderCommandArgs(request.PurchaseOrder));

            if (result.IsSuccess)
                return Result.Ok();

            return Result.Fail("failed to create purchase order");
        }
    }
}