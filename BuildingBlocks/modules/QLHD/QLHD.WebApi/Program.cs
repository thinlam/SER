using QLHD.WebApi;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Configure host with Serilog
    builder.Host.ConfigureWebApiHost(builder.Configuration);

    // Get configuration and app settings
    var configuration = builder.Configuration;
    var appSettings = new AppSettings();
    configuration.Bind(appSettings); 

    // Validate settings and log errors
    ValidateSettings(appSettings);

    builder.Services.Configure<AppSettings>(configuration);

    static void ValidateSettings(AppSettings settings)
    {
        var errors = new List<string>();

        if (settings.Jwt is null)
        {
            errors.Add("Jwt settings is null - check appsettings.json 'Jwt' section");
        }
        else
        {
            if (string.IsNullOrWhiteSpace(settings.Jwt.SecretKey))
                errors.Add("Jwt:SecretKey is missing or empty");
            if (settings.Jwt.SecretKey?.Length < 32)
                errors.Add($"Jwt:SecretKey must be at least 32 characters (current: {settings.Jwt.SecretKey?.Length ?? 0})");
        }

        if (settings.ConnectionStrings is null)
        {
            errors.Add("ConnectionStrings is null - check appsettings.json 'ConnectionStrings' section");
        }
        else
        {
            if (string.IsNullOrWhiteSpace(settings.ConnectionStrings.DefaultConnection))
                errors.Add("ConnectionStrings:DefaultConnection is missing or empty");
        }

        if (errors.Count > 0)
        {
            foreach (var error in errors)
            {
                Log.Error("Configuration Error: {Error}", error);
            }
            throw new InvalidOperationException($"Configuration validation failed:\n{string.Join("\n", errors)}");
        }

        Log.Information("Configuration validated successfully");
    }

    // Add all web API services 
    builder.Services.AddWebApiServices(appSettings, builder.Environment);

    var app = builder.Build();

    // Configure the web application
    app.UseWebApiConfiguration(appSettings);

    app.Run();
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine();
    Console.WriteLine("============================================");
    Console.WriteLine("  QLHD APPLICATION ERROR");
    Console.WriteLine("============================================");
    Console.WriteLine($"  {ex.GetType().Name}: {ex.Message}");
    Console.WriteLine("============================================");
    Console.WriteLine();
    Console.ResetColor();

    if (ex.InnerException != null)
    {
        Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
    }

    // Only wait for key in interactive mode (not in tests)
    if (!Environment.UserInteractive || Console.IsInputRedirected)
    {
        throw;
    }
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}

// Make Program class accessible for integration tests
public partial class Program { }