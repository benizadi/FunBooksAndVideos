using Application.Mappers;
using Contracts;
using DataAccess.Repositories;
using FluentResults;

namespace Application.Commands;

public class CreatePurchaseOrderCommandArgs(PurchaseOrder purchaseOrder, int CustomerId)
{
    public PurchaseOrder PurchaseOrder { get; private set; } = purchaseOrder;
    public int CustomerId { get; set; }
}

public interface ICreatePurchaseOrderCommand
{
    public Task<Result> Execute(CreatePurchaseOrderCommandArgs args);
}

public class CreatePurchaseOrderCommand(IPurchaseOrderRepository purchaseOrderRepository) : ICreatePurchaseOrderCommand
{
    public async Task<Result> Execute(CreatePurchaseOrderCommandArgs args)
    {
        var result = await purchaseOrderRepository.AddPurchaseOrder(args.PurchaseOrder.ToPurchaseOrderRow(args.CustomerId));
        return Result.Ok();
    }
}