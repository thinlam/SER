using System.Reflection;
using BuildingBlocks.Application;

namespace QLDA.Application;

public static class DependencyInjection {
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services) {
        services.AddApplicationLayer(Assembly.GetExecutingAssembly());
        return services;
    }
}