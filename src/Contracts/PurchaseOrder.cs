namespace Contracts;

public class PurchaseOrder
{
    public int PurchaseOrderId { get; set; }
    public int CustomerId { get; set; }
    public List<Product> Products { get; set; } = [];
    public List<Membership> Memberships { get; set; } = [];
    public decimal TotalPrice { get; set; }
}