namespace Contracts;

public class PurchaseOrder
{
    public required Customer Customer { get; set; }
    public ICollection<Product>? Products { get; set; }
    public ICollection<Membership>? Memberships { get; set; }
    public decimal TotalPrice { get; set; }
}