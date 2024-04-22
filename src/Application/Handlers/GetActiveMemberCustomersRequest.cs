using Application.Common;
using Application.Queries;
using Contracts;
using FluentResults;

namespace Application.Handlers;

public sealed record GetActiveMemberCustomersRequest() : IQuery<List<Customer>>
{
    internal sealed class GetActiveMemberCustomersRequestHandler(
        IGetActiveCustomersQuery getActiveCustomersQuery)
        : IQueryHandler<GetActiveMemberCustomersRequest, List<Customer>>
    {
        public async Task<Result<List<Customer>>> Handle(GetActiveMemberCustomersRequest request, CancellationToken cancellationToken)
        {
            var activeCustomers = await getActiveCustomersQuery.Execute();
            return activeCustomers;
        }
    }
}