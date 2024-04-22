using Application.Common;
using Application.Queries;
using Contracts;
using FluentResults;

namespace Application.Handlers;

public sealed record GetAllShippingSlipsRequest() : IQuery<List<ShippingSlip>>
{
    internal sealed class GetAllShippingSlipsRequestHandler(
        IGetAllShippingSlipsQuery getAllShippingSlipsQuery)
        : IQueryHandler<GetAllShippingSlipsRequest, List<ShippingSlip>>
    {
        public async Task<Result<List<ShippingSlip>>> Handle(GetAllShippingSlipsRequest request, CancellationToken cancellationToken)
        {
            var shippingSlips = await getAllShippingSlipsQuery.Execute();
            return shippingSlips;
        }
    }
}