using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public interface ICustomerRepository
{
    Task<CustomerRow?> GetCustomerById(int customerId);
}

public class CustomerRepository : ICustomerRepository
{
    private readonly DatabaseContext _context;

    public CustomerRepository(DatabaseContext context)
    {
        _context = context;
        BuildInMemoryData();
    }

    public async Task<CustomerRow?> GetCustomerById(int customerId)
    {
        var customer = await _context.Customer
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.CustomerId == customerId);

        return customer;
    }
    
    private void BuildInMemoryData()  // only for ease up the api tests (in real world this code should not be merged)
    {
        for (var i = 1; i <= 10; i++)
        {
            _context.Customer.Add(new CustomerRow
            {
                FullName = $"Customer{i}",
                Address = $"Address{i}",
                IsActiveMember = false
            });
        }
        _context.SaveChanges();
    }
}