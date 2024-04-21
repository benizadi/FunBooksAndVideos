namespace Contracts;

public class Customer
{
    public required Address Address { get; set; }
    public required string FullName { get; set; }
    public bool IsActiveMember { get; set; }
}