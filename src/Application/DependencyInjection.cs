using System.Reflection;
using Application.Commands;
using Application.Queries;
using Application.Services;
using Application.Services.Processors;
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
        services.AddScoped<IActivateMembershipCommand, ActivateMembershipCommand>();
        services.AddScoped<IGenerateShippingSlipCommand, GenerateShippingSlipCommand>();
        
        services.AddScoped<IGetCustomerQuery, GetCustomerQuery>();
        services.AddScoped<IGetActiveCustomersQuery, GetActiveCustomersQuery>();
        services.AddScoped<IGetAllShippingSlipsQuery, GetAllShippingSlipsQuery>();
        
        services.AddScoped<IPurchaseOrderRuleProcessor, PurchaseOrderRuleEngine>();
        services.AddScoped<IPurchaseOrderTypeProcessor, MemberActivationRuleProcessor>();
        services.AddScoped<IPurchaseOrderTypeProcessor, ShippingSlipRuleProcessor>();
        
        
        return services;
    }
}