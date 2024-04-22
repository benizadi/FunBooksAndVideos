using Application.Commands;
using Application.Common;
using Contracts;
using FluentResults;

namespace Application.Handlers;

public sealed record CreatePurchaseOrderRequest(PurchaseOrder PurchaseOrder): ICommand<string>
{
    internal sealed class CreatePurchaseOrderRequestHandler(ICreatePurchaseOrderCommand createPurchaseOrderCommand)
        : ICommandHandler<CreatePurchaseOrderRequest, string>
    {
        public async Task<Result<string>> Handle(CreatePurchaseOrderRequest request, CancellationToken cancellationToken)
        {
            var tempCustomerId = 1;
            var result = await createPurchaseOrderCommand.Execute(new CreatePurchaseOrderCommandArgs(request.PurchaseOrder, tempCustomerId));

            if (result.IsSuccess)
                return "Successfully Created a purchase Order";

            return "failed to create purchase order";
        }
    }
}