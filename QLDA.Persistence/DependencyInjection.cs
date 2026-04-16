using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using BuildingBlocks.CrossCutting.Factories;
using QLDA.Domain.Interfaces;
using QLDA.Persistence.Factories;
using QLDA.Persistence.Repositories;

namespace QLDA.Persistence;

public static class DependencyInjection {
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        ConnectionStrings connectionStrings,
        string? migrationsAssembly = "") {
        services.AddDbContext<AppDbContext>((provider, options) => {
            // cấu hình SQL Server
            options.UseSqlServer(
                    connectionStrings.DefaultConnection,
                    sql => {
                        if (!string.IsNullOrEmpty(migrationsAssembly)) {
                            sql.MigrationsAssembly(migrationsAssembly);
                        }

                        sql.UseCompatibilityLevel(120);
                    })
                .EnableSensitiveDataLogging();

            // Lấy interceptor nếu đã đăng ký; nếu không có thì bỏ quam
            var saveInterceptor = provider.GetService<ISaveChangesInterceptor>();
            if (saveInterceptor != null) {
                options.AddInterceptors(saveInterceptor);
            }
        })
            .AddDbContextFactory<AppDbContext>((Action<DbContextOptionsBuilder>)null!, ServiceLifetime.Scoped);

        services.AddRepositories();
        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

        return services;
    }


    private static IServiceCollection AddRepositories(this IServiceCollection services) {
        // Register DbContext so Repository<,> can resolve it
        services.AddScoped<DbContext>(sp => sp.GetRequiredService<AppDbContext>());

        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddScoped(typeof(IDapperRepository), typeof(DapperRepository));

        // UnitOfWork (use QLDA's interface)
        services.AddScoped(typeof(IUnitOfWork),
            serviceProvider => { return serviceProvider.GetRequiredService<AppDbContext>(); });
        services.AddScoped<IDashboardRepository, DashboardRepository>();

        return services;
    }

    public static void MigrateAppDb(this IApplicationBuilder app) {
        using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope()) {
            serviceScope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();
        }
    }
}
