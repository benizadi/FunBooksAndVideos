using Contracts;
using DataAccess.Models;
using MembershipType = DataAccess.Models.Enums.MembershipType;
using ProductType = DataAccess.Models.Enums.ProductType;

namespace Application.Mappers;

public static class EntityMappers
{
    public static PurchaseOrderRow ToPurchaseOrderRow(this PurchaseOrder purchaseOrder, int customerId)
    {
        return new PurchaseOrderRow
        {
            CustomerId = customerId,
            Products = purchaseOrder.Products?.Select(x => x.ToProductRow()).ToList(),
            Memberships = purchaseOrder.Memberships?.Select(x => x.ToMembershipRow()).ToList(),
            TotalPrice = 0
        };
    }

    public static ProductRow ToProductRow(this Product product)
    {
        return new ProductRow
        {
            ProductName = product.ProductName,
            UnitPrice = product.UnitPrice,
            ProductType = (ProductType)product.ProductType
        };
    }

    public static MembershipRow ToMembershipRow(this Membership membership)
    {
        return new MembershipRow
        {
            MembershipFee = membership.MembershipFee,
            MembershipType = (MembershipType)membership.MembershipType
        };
    }
}