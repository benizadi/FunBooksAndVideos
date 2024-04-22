using DataAccess.Repositories;
using FluentResults;

namespace Application.Commands;

public class ActivateMembershipCommandArgs(int customerId)
{
    public int CustomerId { get; set; } = customerId;
}

public interface IActivateMembershipCommand
{
    Task<Result> Execute(ActivateMembershipCommandArgs args);
}

public class ActivateMembershipCommand(ICustomerRepository customerRepository) : IActivateMembershipCommand
{
    public async Task<Result> Execute(ActivateMembershipCommandArgs args)
    {

        await customerRepository.ActivateCustomer(args.CustomerId);
        return Result.Ok();
    }
}