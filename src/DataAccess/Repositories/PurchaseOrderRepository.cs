using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public interface IPurchaseOrderRepository
{
    Task AddPurchaseOrder(PurchaseOrderRow purchaseOrder);
}

public class PurchaseOrderRepository(DatabaseContext context) : IPurchaseOrderRepository
{
    public async Task AddPurchaseOrder(PurchaseOrderRow purchaseOrder)
    {
        try
        {
            await context.PurchaseOrders.AddAsync(purchaseOrder);
            await context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine("failed to persist purchase order: {0}", ex.Message); // in real world this will be logged in Application insights 
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine("unpredictable exception while persisting purchase order: {0}", ex.Message);
            throw;
        }
    }
}

