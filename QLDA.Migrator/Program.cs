using System.Reflection;
using Polly;
using QLDA.Infrastructure;
using QLDA.Migrator.ConfigurationOptions;
using QLDA.Persistence;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var services = builder.Services;
var configuration = builder.Configuration;

var appSettings = new AppSettings();
configuration.Bind(appSettings);

services.Configure<AppSettings>(configuration);
services.AddDateTimeProvider();
services.AddPersistence(appSettings.ConnectionStrings,
    Assembly.GetExecutingAssembly().GetName().Name);

var app = builder.Build();
Policy.Handle<Exception>().WaitAndRetry(new[] {
        TimeSpan.FromSeconds(10),
        TimeSpan.FromSeconds(20),
        TimeSpan.FromSeconds(30),
    })
    .Execute(() => { app.MigrateAppDb(); });
app.MapGet("/", () => "Hello World!");
// app.MapGet("/", () => Results.Redirect("/swagger"));
app.Run();