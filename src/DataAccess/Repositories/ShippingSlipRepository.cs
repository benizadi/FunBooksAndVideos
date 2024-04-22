using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public interface IShippingSlipRepository
{
    Task GenerateShippingSlip(ShippingSlipRow shippingSlipRow);
    Task<List<ShippingSlipRow>> GetAllShippingSlips();

}

public class ShippingSlipRepository(DatabaseContext context) : IShippingSlipRepository
{
    public async Task<List<ShippingSlipRow>> GetAllShippingSlips()
    {
        var shippingSlipRows = await context.ShippingSlip
            .AsNoTracking()
            .ToListAsync();

        return shippingSlipRows;
    }
    public async Task GenerateShippingSlip(ShippingSlipRow shippingSlipRow)
    {
        try
        {
            await context.ShippingSlip.AddRangeAsync(shippingSlipRow);
            await context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine("failed to generate shipping slip: {0}", ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine("unpredictable exception while generating shipping slip: {0}", ex.Message);
            throw;
        }
    }
}