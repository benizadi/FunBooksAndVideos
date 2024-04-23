namespace Contracts;

public class PurchaseOrder
{
    public int CustomerId { get; set; }
    public List<Product> Products { get; set; } = [];
    public Membership Membership { get; set; }
    public decimal TotalPrice { get; set; }
}