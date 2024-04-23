using Contracts;

namespace Application.Extensions;

public static class PurchaseOrderExtension
{
    public static decimal CalculateTotalPrice(this PurchaseOrder purchaseOrder)
    {
        decimal totalPrice = 0;
        if (purchaseOrder.Products.Count != 0)
            totalPrice += purchaseOrder.Products.Sum(x => x.UnitPrice);
        if (purchaseOrder.Membership != null)
            totalPrice += purchaseOrder.Membership.Fee;
        
        return totalPrice;
    }
}