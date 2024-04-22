using Application.Common;
using Application.Mappers;
using Contracts;
using DataAccess.Repositories;

namespace Application.Queries;


public interface IGetActiveCustomersQuery : IQuery<Task<List<Customer>>>
{
    Task<List<Customer>> Execute();
}

public class GetActiveCustomersQuery(ICustomerRepository customerRepository) : IGetActiveCustomersQuery
{
    public async Task<List<Customer>> Execute()
    {
        var customerRow = await customerRepository.GetAllActiveCustomer();

        if (customerRow.Count == 0)
            return new List<Customer>();
        
        return customerRow.Select(x => x.ToCustomer()).ToList();
    }
}

