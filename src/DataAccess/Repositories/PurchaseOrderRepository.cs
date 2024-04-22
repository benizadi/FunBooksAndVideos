using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public interface IPurchaseOrderRepository
{
    Task<int> AddPurchaseOrder(PurchaseOrderRow purchaseOrder);
}

public class PurchaseOrderRepository(DatabaseContext context) : IPurchaseOrderRepository
{
    public async Task<int> AddPurchaseOrder(PurchaseOrderRow purchaseOrder)
    {
        try
        {
            await context.PurchaseOrders.AddAsync(purchaseOrder);
            return await context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine("failed to persist purchase order: " +
                              ex.Message); // in real world this will be logged in Application insights 
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine("unpredictable exception while persisting purchase order: " + 
                              ex.Message);
            throw;
        }
    }
}

