namespace Contracts;

public class Product
{
    public required string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public ProductType ProductType { get; set; }
}