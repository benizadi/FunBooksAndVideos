using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class PurchaseOrderRow
{
    [Key]
    public int PurchaseOrderId { get; set; }
    public int CustomerId { get; set; }
    public ICollection<ProductRow>? Products { get; set; }
    public ICollection<MembershipRow>? Memberships { get; set; }
    public decimal TotalPrice { get; set; }
}