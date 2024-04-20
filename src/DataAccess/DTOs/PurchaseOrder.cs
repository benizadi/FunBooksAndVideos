namespace DataAccess.DTOs;

public class PurchaseOrder
{
    public int PurchaseOrderId { get; set; }
    public required Customer Customer { get; set; }
    public List<Product>? Products { get; set; }
    public List<Membership>? Memberships { get; set; }
    public decimal TotalPrice { get; set; }
}