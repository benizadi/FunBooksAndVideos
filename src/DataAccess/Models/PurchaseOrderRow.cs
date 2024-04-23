using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class PurchaseOrderRow
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long PurchaseOrderId { get; set; }
    public int CustomerId { get; set; }
    public ICollection<ProductRow>? Products { get; set; }
    public MembershipRow? Memberships { get; set; }
    public decimal TotalPrice { get; set; }
}