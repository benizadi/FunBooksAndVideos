using Application.Common;
using Application.Mappers;
using Contracts;
using DataAccess.Repositories;

namespace Application.Queries;

public class GetCustomerQueryArgs(int customerId)
{
    public int CustomerId { get; private set; } = customerId;
}
public interface IGetCustomerQuery : IQueryWithArgs<GetCustomerQueryArgs, Task<Customer?>>
{
}

public class GetCustomerQuery(ICustomerRepository customerRepository) : IGetCustomerQuery
{
    public async Task<Customer?> Execute(GetCustomerQueryArgs args)
    {
        var customerRow = await customerRepository.GetCustomerById(args.CustomerId);

        return customerRow?.ToCustomer();
    }
}

