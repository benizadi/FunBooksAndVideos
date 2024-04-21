using System.Reflection;
using Application.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        services.AddScoped<ICreatePurchaseOrderCommand, CreatePurchaseOrderCommand>();
        return services;
    }
}