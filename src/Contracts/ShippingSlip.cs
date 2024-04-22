namespace Contracts;

public class ShippingSlip
{
    public int PurchaseOrderId { get; set; }
    public string CustomerName { get; set; }
    public string Address { get; set; }
}