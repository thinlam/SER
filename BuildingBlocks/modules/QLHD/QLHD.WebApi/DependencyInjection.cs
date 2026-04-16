using BuildingBlocks.Application.Middlewares;
using BuildingBlocks.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QLHD.WebApi.Filters;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using QLHD.Application;
using QLHD.Infrastructure;
using QLHD.Persistence;
using BuildingBlocks.Infrastructure;
using BuildingBlocks.Domain.Constants;

namespace QLHD.WebApi;

public static class DependencyInjection {
    public static IHostBuilder ConfigureWebApiHost(this IHostBuilder host, IConfiguration configuration) {
        host.UseSerilog((context, loggerConfiguration) => {
            loggerConfiguration.ReadFrom.Configuration(configuration);
        });
        return host;
    }

    public static IServiceCollection AddControllersWithJson(this IServiceCollection services) {
        services.AddControllers()
            .AddJsonOptions(options => {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.AddBuildingBlocksConverters();
            });

        services.AddEndpointsApiExplorer();

        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services) {
        services.AddSwaggerGen(options => {
            ConfigureSwagger(options);
            options.SchemaFilter<MonthYearSchemaFilter>();
        });
        return services;
    }

    private static void ConfigureSwagger(SwaggerGenOptions options) {
        options.SupportNonNullableReferenceTypes();

        options.SwaggerDoc("v1", new OpenApiInfo {
            Version = "v1",
            Title = "QLHD API",
            Description = "API quản lý hợp đồng"
        });

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT"
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                },
                Array.Empty<string>()
            }
        });

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        if (File.Exists(xmlPath))
            options.IncludeXmlComments(xmlPath);
    }

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, JwtSettings jwt, IWebHostEnvironment environment) {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SecretKey));

        services
            .AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    RoleClaimType = ClaimConstants.Role,
                    ValidateLifetime = environment.IsProduction(),
                };
            });

        return services;
    }

    public static IServiceCollection AddAuthentication(this IServiceCollection services, AppSettings appSettings, IWebHostEnvironment environment) {
        services.AddJwtAuthentication(appSettings.Jwt, environment);
        return services;
    }

    public static IServiceCollection AddCommonServices(this IServiceCollection services) {
        services.AddDateTimeProvider();
        services.AddHealthChecks();
        services.AddMemoryCache();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        return services;
    }

    public static IServiceCollection AddProjectDependencies(this IServiceCollection services, AppSettings appSettings) {
        services
            .AddQlhdApplication()
            .AddQlhdInfrastructure()
            .AddQlhdPersistence(appSettings.ConnectionStrings);

        return services;
    }

    public static IServiceCollection AddWebApiServices(this IServiceCollection services, AppSettings appSettings, IWebHostEnvironment environment) {
        services.AddControllersWithJson();
        services.AddSwagger();
        services.AddAuthentication(appSettings, environment);

        services.AddAuthorization(options => {
            var allPermissions = PermissionHelper.GetAllPermissions();
            foreach (var permission in allPermissions) {
                options.AddPolicy(permission, policy =>
                    policy.RequireClaim(ClaimConstants.Permission, permission));
            }
        });

        services.AddCommonServices();
        services.AddProjectDependencies(appSettings);

        return services;
    }
}

public static class WebApiAppExtensions {
    public static WebApplication UseWebApiAppBuilder(this WebApplication app) {
        app.UseAuthentication();
        app.UseAuthorization();
        return app;
    }

    public static WebApplication UseSwaggerWithUI(this WebApplication app, AppSettings appSettings) {
        if (app.Environment.IsDevelopment()) {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.EnableFilter();
                c.DocExpansion(DocExpansion.None);
            });
            return app;
        }

        if (app.Environment.IsStaging()) {
            var pathBase = appSettings.SwaggerPathBase;
            if (string.IsNullOrEmpty(pathBase)) {
                return app;
            }

            app.UseSwagger(c => {
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) => {
                    string prefix = pathBase.TrimEnd('/');
                    string baseUrl = $"{httpReq.Scheme}://{httpReq.Host.Value}{prefix}";
                    swaggerDoc.Servers = [new OpenApiServer { Url = baseUrl }];
                });
            });

            app.UseSwaggerUI(c => {
                c.EnableFilter();
                c.DocExpansion(DocExpansion.None);
                c.SwaggerEndpoint($"{pathBase}/swagger/v1/swagger.json", "QLHD API v1");
                c.RoutePrefix = "swagger";
            });
        }

        return app;
    }

    public static WebApplication UseCorsPolicy(this WebApplication app) {
        app.UseCors(options => {
            options.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
        return app;
    }

    public static WebApplication UseLogging(this WebApplication app) {
        app.UseSerilogRequestLogging();
        return app;
    }

    public static WebApplication UseHealthChecksEndpoint(this WebApplication app) {
        app.UseHealthChecks("/health");
        return app;
    }

    public static WebApplication UseControllers(this WebApplication app) {
        app.MapControllers();
        return app;
    }

    public static WebApplication UseWebApiConfiguration(this WebApplication app, AppSettings appSettings) {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseSwaggerWithUI(appSettings);
        app.UseCorsPolicy();
        app.UseLogging();
        app.UseWebApiAppBuilder();
        app.UseHealthChecksEndpoint();
        app.UseControllers();

        return app;
    }
}