using BuildingBlocks.Persistence.Interceptors;
using BuildingBlocks.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<ISaveChangesInterceptor, AuditInterceptor>();
        services.AddScoped(typeof(IJunctionRepository<>), typeof(JunctionRepository<>));
        return services;
    }
}