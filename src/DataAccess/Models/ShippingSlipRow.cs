using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataAccess.Models;

public class ShippingSlipRow
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ShippingSlipId { get; set; }
    public int PurchaseOrderId { get; set; }
    public string CustomerName { get; set; }
    public string Address { get; set; }
}