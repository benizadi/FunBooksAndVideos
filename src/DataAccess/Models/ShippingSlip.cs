using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataAccess.Models;

public class ShippingSlip
{
    public int ShippingSlipId { get; set; }
    public required string Address { get; set; }
}