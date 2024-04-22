namespace Contracts;

public class Customer
{
    public required string FullName { get; set; }
    public required string Address { get; set; }
    public bool IsActiveMember { get; set; }
}