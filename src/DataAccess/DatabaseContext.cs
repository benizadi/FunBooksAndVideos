using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class DatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "ProductDb");
    }
    
    public DbSet<PurchaseOrderRow> PurchaseOrders { get; private set; } /// <summary>
                                                                        ///  yoyoyoyoyoyo
                                                                        /// </summary>
    public DbSet<CustomerRow> Customer { get; private set; }
    
    public DbSet<ShippingSlipRow> ShippingSlip { get; private set; }

}

