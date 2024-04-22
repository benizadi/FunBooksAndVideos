using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public interface ICustomerRepository
{
    Task<CustomerRow?> GetCustomerById(int customerId);
    Task<List<CustomerRow>> GetAllActiveCustomer();
    Task ActivateCustomer(int customerId);
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
    
    public async Task<List<CustomerRow>> GetAllActiveCustomer()
    {
        var customer = await _context.Customer
            .AsNoTracking()
            .Where(x => x.IsActiveMember == true)
            .ToListAsync();

        return customer;
    }

    public async Task ActivateCustomer(int customerId)
    {
        try
        {
            var customer = await _context.Customer.SingleAsync(x => x.CustomerId == customerId);
        
            customer.IsActiveMember = true;

            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine("failed to activate the customer: {0}", ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine("unpredictable exception while activating the customer: {0}", ex.Message);
            throw;
        }

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