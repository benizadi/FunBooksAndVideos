using DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>();
        services.AddTransient<IPurchaseOrderRepository, PurchaseOrderRepository>();
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IShippingSlipRepository, ShippingSlipRepository>();

        return services;
    }
}