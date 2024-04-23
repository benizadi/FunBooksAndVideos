using Contracts;
using DataAccess.Models;
using MembershipType = DataAccess.Models.Enums.MembershipType;
using ProductType = DataAccess.Models.Enums.ProductType;

namespace Application.Mappers;

public static class EntityMappers
{
    public static PurchaseOrderRow ToPurchaseOrderRow(this PurchaseOrder purchaseOrder)
    {
        return new PurchaseOrderRow
        {
            CustomerId = purchaseOrder.CustomerId,
            Products = purchaseOrder.Products?.Select(x => x.ToProductRow()).ToList(),
            Memberships = purchaseOrder.Membership?.ToMembershipRow(),
            TotalPrice = purchaseOrder.TotalPrice
        };
    }

    private static ProductRow ToProductRow(this Product product)
    {
        return new ProductRow
        {
            ProductName = product.ProductName,
            ProductType = (ProductType)product.ProductType
        };
    }

    private static MembershipRow ToMembershipRow(this Membership membership)
    {
        return new MembershipRow
        {
            MembershipType = (MembershipType)membership.MembershipType
        };
    }

    public static Customer ToCustomer(this CustomerRow customerRow)
    {
        return new Customer
        {
            FullName = customerRow.FullName,
            Address = customerRow.Address,
            IsActiveMember = customerRow.IsActiveMember
        };
    }    
    public static ShippingSlip ToShippingSlip(this ShippingSlipRow shippingSlipRow)
    {
        return new ShippingSlip
        {
            CustomerName = shippingSlipRow.CustomerName,
            Address = shippingSlipRow.Address
        };
    }
}