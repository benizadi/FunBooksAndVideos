namespace Contracts;

public class PurchaseOrder
{
    public required Customer Customer { get; set; }
    public List<Product>? Products { get; set; }
    public List<Membership>? Memberships { get; set; }
    public decimal TotalPrice { get; set; }
}