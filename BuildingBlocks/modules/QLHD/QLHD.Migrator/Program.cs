using System.Reflection;
using BuildingBlocks.Infrastructure;
using QLHD.Migrator.ConfigurationOptions;
using QLHD.Persistence;
using Polly;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

var appSettings = new AppSettings();
configuration.Bind(appSettings);

services.Configure<AppSettings>(configuration);
services.AddDateTimeProvider();
services.AddQlhdPersistence(appSettings.ConnectionStrings, Assembly.GetExecutingAssembly().GetName().Name);

var app = builder.Build();
Policy.Handle<Exception>().WaitAndRetry([
        TimeSpan.FromSeconds(10),
        TimeSpan.FromSeconds(20),
        TimeSpan.FromSeconds(30)
    ])
    .Execute(() => { app.MigrateAppDb(); });
app.MapGet("/", () => "QLHD Migrator - Database migration complete!");
app.Run();