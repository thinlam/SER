using System.Reflection;
using System.Text.Json;
using BuildingBlocks.Application.Common.Behaviors;
using BuildingBlocks.Application.Common.Converters;
using BuildingBlocks.Application.Common.Services;
using BuildingBlocks.Domain.Providers;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Application;

public static class DependencyInjection {

    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {

        services.AddScoped(typeof(ICrudService<,>), typeof(CrudService<,>));
        services.AddScoped<IUserProvider, UserProvider>();
        // services.AddScoped<IHistoryQueryService, HistoryQueryService>();

        return services;
    }
    public static IServiceCollection AddApplicationMediatR(this IServiceCollection services,
    Assembly? childAssembly = null) {


        // First register BuildingBlocks.Application as the main assembly
        Assembly currentAssembly = Assembly.GetExecutingAssembly();

        services.AddValidatorsFromAssembly(currentAssembly);
        if (childAssembly != null)
            services.AddValidatorsFromAssembly(childAssembly);

        // Đăng ký MediatR CHỈ MỘT LẦN với tất cả assemblies
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(currentAssembly);

            if (childAssembly != null)
                cfg.RegisterServicesFromAssembly(childAssembly); // ← Đăng ký cùng lúc

            // Behaviors sẽ áp dụng cho TẤT CẢ handlers
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));
            cfg.AddRequestPreProcessor(typeof(IRequestPreProcessor<>), typeof(LoggingBehavior<>));
        });
        return services;
    }

    /// <summary>
    /// Configures JSON options with BuildingBlocks converters (e.g., MonthYearJsonConverter)
    /// </summary>
    public static JsonSerializerOptions AddBuildingBlocksConverters(this JsonSerializerOptions options) {
        options.Converters.Add(new MonthYearJsonConverter());
        return options;
    }

    public static IServiceCollection AddApplicationLayer(this IServiceCollection services,
    Assembly? childAssembly = null) {
        services.AddApplicationServices();
        services.AddApplicationMediatR(childAssembly);

        return services;
    }
}
