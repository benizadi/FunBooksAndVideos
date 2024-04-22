using Application.Commands;
using Application.Common;
using Application.Extensions;
using Application.Queries;
using Contracts;
using FluentResults;

namespace Application.Handlers;

public sealed record CreatePurchaseOrderRequest(PurchaseOrder PurchaseOrder): ICommand<string>
{
    internal sealed class CreatePurchaseOrderRequestHandler(
        ICreatePurchaseOrderCommand createPurchaseOrderCommand,
        IActivateMembershipCommand activateMembershipCommand,
        IGenerateShippingSlipCommand generateShippingSlipCommand,
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

            if (request.PurchaseOrder.Memberships.Any())
                await activateMembershipCommand.Execute(new ActivateMembershipCommandArgs(request.PurchaseOrder.CustomerId));

            if (request.PurchaseOrder.Products.HasPhysicalProduct())
                await generateShippingSlipCommand.Execute(
                    new GenerateShippingSlipCommandArgs(request.PurchaseOrder, customer));

            return Result.Ok(); 
        }
    }
}