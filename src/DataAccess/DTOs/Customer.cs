using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DataAccess.DTOs;

public class Customer
{
    public int CustomerId { get; set; }
    public required Address Address { get; set; }
    public required string FullName { get; set; }
    public bool IsActiveMember { get; set; }
}