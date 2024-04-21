namespace DataAccess.DTOs;

public class CustomerRow
{
    public int CustomerId { get; set; }
    public required AddressRow AddressRow { get; set; }
    public required string FullName { get; set; }
    public bool IsActiveMember { get; set; }
}