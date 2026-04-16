using System.Reflection;
using BuildingBlocks.Application;

namespace QLHD.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddQlhdApplication(this IServiceCollection services)
    {
        services.AddApplicationLayer(Assembly.GetExecutingAssembly());
        return services;
    }
}