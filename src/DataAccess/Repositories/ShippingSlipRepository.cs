using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public interface IShippingSlipRepository
{
    Task GenerateShippingSlip(ShippingSlipRow shippingSlipRow);
}

public class ShippingSlipRepository(DatabaseContext context) : IShippingSlipRepository
{
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