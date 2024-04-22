namespace Contracts;

public class Product
{
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public ProductType ProductType { get; set; }
}