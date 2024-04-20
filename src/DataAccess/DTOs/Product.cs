namespace DataAccess.DTOs;

public class Product
{
    public int ProductId { get; set; }
    public required string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public ProductType ProductType { get; set; }
}