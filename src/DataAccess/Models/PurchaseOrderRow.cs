using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class PurchaseOrderRow
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PurchaseOrderId { get; set; }
    
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public CustomerRow? CustomerRow { get; set; }
    public ICollection<ProductRow>? Products { get; set; }
    public ICollection<MembershipRow>? Memberships { get; set; }
    public decimal TotalPrice { get; set; }
}