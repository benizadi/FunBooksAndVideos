namespace DataAccess.DTOs;

public class PurchaseOrderRow
{
    public int PurchaseOrderId { get; set; }
    public required CustomerRow CustomerRow { get; set; }
    public ICollection<ProductRow>? Products { get; set; }
    public ICollection<MembershipRow>? Memberships { get; set; }
    public decimal TotalPrice { get; set; }
}