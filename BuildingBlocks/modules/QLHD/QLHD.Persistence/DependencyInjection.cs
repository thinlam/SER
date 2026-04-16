using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using BuildingBlocks.Persistence;
using BuildingBlocks.Domain.Interfaces;
using BuildingBlocks.Persistence.Repositories;
using QLHD.Persistence.Schema;

namespace QLHD.Persistence;

public static class DependencyInjection {
    public static IServiceCollection AddQlhdPersistence(this IServiceCollection services,
        ConnectionStrings connectionStrings,
        string? migrationsAssembly = "",
        string? schema = null) {
        var effectiveSchema = !string.IsNullOrEmpty(schema) ? schema : connectionStrings.Schema ?? "dbo";

        // Register ConnectionStrings so AppDbContext can inject it
        services.AddSingleton(connectionStrings);
        services.AddSingleton(new SchemaConfig(effectiveSchema));

        services.AddPersistence();
        services.AddDbContext<AppDbContext>((provider, options) => {
            options.UseSqlServer(
                    connectionStrings.DefaultConnection,
                    sql => {
                        if (!string.IsNullOrEmpty(migrationsAssembly)) {
                            sql.MigrationsAssembly(migrationsAssembly);
                        }
                        // Schema-specific migration history table (separate per environment)
                        sql.MigrationsHistoryTable(AppDbContext.MigrationsHistory, effectiveSchema);
                        sql.UseCompatibilityLevel(120);
                    })
                .EnableSensitiveDataLogging()
                // Different model cache per schema (critical for multi-schema support)
                .ReplaceService<IModelCacheKeyFactory, SchemaAwareModelCacheKeyFactory>()
                // Inject schema into migration SQL generation (enables schema-agnostic migrations)
                .ReplaceService<IMigrationsSqlGenerator, SchemaAwareMigrationsSqlGenerator>()
                // Allow migrations to receive ISchemaAwareDbContext via constructor
                .ReplaceService<IMigrationsAssembly, SchemaAwareMigrationsAssembly>();

            var saveInterceptor = provider.GetService<ISaveChangesInterceptor>();
            if (saveInterceptor != null) {
                options.AddInterceptors(saveInterceptor);
            }
        });

        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services) {
        // Register DbContext so Repository<,> can resolve it
        services.AddScoped<DbContext>(sp => sp.GetRequiredService<AppDbContext>());
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddScoped(typeof(IUnitOfWork),
            serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());

        return services;
    }

    public static void MigrateAppDb(this IApplicationBuilder app) {
        using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope();
        serviceScope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();
    }
}

/// <summary>
/// Simple wrapper to pass schema name through DI to AppDbContext.
/// </summary>
public sealed class SchemaConfig(string schema) {
    public string Schema { get; } = schema;
}
