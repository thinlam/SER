using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using BuildingBlocks.Domain.Constants;
using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Tests.Integration.Infrastructure;

/// <summary>
/// WebApplicationFactory for QLHD.WebApi with InMemory database and mock authentication.
/// </summary>
public class TestWebApplicationFactory : WebApplicationFactory<Program>
{
    /// <summary>
    /// Unique database name per test run to isolate tests.
    /// </summary>
    private static readonly string DatabaseName = $"QLHD_Test_{Guid.NewGuid()}";

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // Set environment variables for test configuration
        builder.UseSetting("ConnectionStrings:DefaultConnection", "Server=localhost;Database=QLHD_Test;Trusted_Connection=True");
        builder.UseSetting("Jwt:SecretKey", "TestSecretKeyForIntegrationTesting12345678");
        builder.UseSetting("SwaggerPathBase", "");

        builder.ConfigureServices(services =>
        {
            // Remove real DbContext and related services
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
            if (dbContextDescriptor != null)
                services.Remove(dbContextDescriptor);

            var dbContextDescriptor2 = services.SingleOrDefault(
                d => d.ServiceType == typeof(AppDbContext));
            if (dbContextDescriptor2 != null)
                services.Remove(dbContextDescriptor2);

            // Add InMemory DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase(DatabaseName)
                    .ConfigureWarnings(w => w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.InMemoryEventId.TransactionIgnoredWarning)));

            // Remove real authentication
            var authDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(Microsoft.AspNetCore.Authentication.IAuthenticationSchemeProvider));
            if (authDescriptor != null)
                services.Remove(authDescriptor);

            // Add mock authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "TestScheme";
                options.DefaultChallengeScheme = "TestScheme";
            })
            .AddScheme<Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions, MockAuthenticationHandler>(
                "TestScheme", null);

            // Build service provider to seed data
            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Ensure database is created and seeded
            db.Database.EnsureCreated();
            TestDataSeeder.Seed(db);
        });

        builder.UseEnvironment("Testing");
    }
}