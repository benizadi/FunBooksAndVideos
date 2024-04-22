using System.Reflection;
using Application.Commands;
using Application.Queries;
using DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddDataAccess();
        
        services.AddScoped<ICreatePurchaseOrderCommand, CreatePurchaseOrderCommand>();
        services.AddScoped<IGetCustomerQuery, GetCustomerQuery>();
        
        return services;
    }
}