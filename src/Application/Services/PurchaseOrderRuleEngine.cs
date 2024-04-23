using Contracts;
using FluentResults;

namespace Application.Services;

public interface IPurchaseOrderTypeProcessor
{
    bool IsMatch(PurchaseOrder purchaseOrder);
    Task<Result> ProcessAsync(PurchaseOrder purchaseOrder);
}

public interface IPurchaseOrderRuleProcessor
{
    Task<Result> ProcessAsync(PurchaseOrder purchaseOrder);
}

public class PurchaseOrderRuleEngine(IEnumerable<IPurchaseOrderTypeProcessor> purchaseOrderTypeProcessors)
    : IPurchaseOrderRuleProcessor
{
    public async Task<Result> ProcessAsync(PurchaseOrder purchaseOrder)
    {
        var processors = purchaseOrderTypeProcessors.Where(p => p.IsMatch(purchaseOrder));
        foreach (var processor in processors)
        {
            await processor.ProcessAsync(purchaseOrder);
        }
        
        return Result.Ok();
    }
}