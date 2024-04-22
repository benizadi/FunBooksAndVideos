using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class DatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "ProductDb");
    }
    
    public DbSet<PurchaseOrderRow> PurchaseOrders { get; set; }

}

