using Application.Common;
using Application.Mappers;
using Contracts;
using DataAccess.Repositories;

namespace Application.Queries;

public interface IGetAllShippingSlipsQuery : IQuery<Task<List<ShippingSlip>>>
{
    Task<List<ShippingSlip>> Execute();
}

public class GetAllShippingSlipsQuery(IShippingSlipRepository shippingSlipRepository) : IGetAllShippingSlipsQuery
{
    public async Task<List<ShippingSlip>> Execute()
    {
        var customerRow = await shippingSlipRepository.GetAllShippingSlips();

        if (customerRow.Count == 0)
            return new List<ShippingSlip>();
        
        return customerRow.Select(x => x.ToShippingSlip()).ToList();
    }
}