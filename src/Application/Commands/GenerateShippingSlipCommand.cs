using Contracts;
using DataAccess.Models;
using DataAccess.Repositories;
using FluentResults;

namespace Application.Commands;

public class GenerateShippingSlipCommandArgs(PurchaseOrder purchaseOrder, Customer customer)
{
    public PurchaseOrder PurchaseOrder { get; set; } = purchaseOrder;
    public Customer Customer { get; set; } = customer;
}

public interface IGenerateShippingSlipCommand
{
    Task<Result> Execute(GenerateShippingSlipCommandArgs args);
}

public class GenerateShippingSlipCommand(IShippingSlipRepository shippingSlipRepository) : IGenerateShippingSlipCommand
{
    public async Task<Result> Execute(GenerateShippingSlipCommandArgs args)
    {
        var shippingSlip = new ShippingSlipRow()
        {
            PurchaseOrderId = args.PurchaseOrder.PurchaseOrderId,
            CustomerName = args.Customer.FullName,
            Address = args.Customer.Address
        };

        await shippingSlipRepository.GenerateShippingSlip(shippingSlip);
        return Result.Ok();
    }
}