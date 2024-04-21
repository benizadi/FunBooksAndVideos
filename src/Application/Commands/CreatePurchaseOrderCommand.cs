using Contracts;
using FluentResults;

namespace Application.Commands;

public class CreatePurchaseOrderCommandArgs(PurchaseOrder purchaseOrder)
{
    public PurchaseOrder PurchaseOrder { get; private set; } = purchaseOrder;
}

public interface ICreatePurchaseOrderCommand
{
    public Task<Result> Execute(CreatePurchaseOrderCommandArgs args);
}

public class CreatePurchaseOrderCommand : ICreatePurchaseOrderCommand
{
    public async Task<Result> Execute(CreatePurchaseOrderCommandArgs args)
    {
        return Result.Ok();
    }
}