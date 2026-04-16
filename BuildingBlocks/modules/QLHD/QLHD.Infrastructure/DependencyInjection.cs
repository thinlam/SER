using BuildingBlocks.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace QLHD.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddQlhdInfrastructure(this IServiceCollection services)
    {
        services.AddInfrastructureLayer();
        return services;
    }
}