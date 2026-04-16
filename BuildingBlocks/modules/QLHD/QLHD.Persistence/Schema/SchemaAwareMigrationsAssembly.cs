using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System.Reflection;

namespace QLHD.Persistence.Schema;

/// <summary>
/// Custom migrations assembly that allows migrations to receive ISchemaAwareDbContext
/// via constructor injection. Enables schema-aware migrations without EF Core's default
/// constructor requirements.
/// </summary>
#pragma warning disable EF1001 // Internal EF Core API usage
public class SchemaAwareMigrationsAssembly(
    ICurrentDbContext currentContext,
    IDbContextOptions options,
    IMigrationsIdGenerator idGenerator,
    IDiagnosticsLogger<DbLoggerCategory.Migrations> logger
    ) : MigrationsAssembly(currentContext, options, idGenerator, logger), IMigrationsAssembly {
    private readonly DbContext _context = currentContext.Context;

    public override Migration CreateMigration(TypeInfo migrationClass, string activeProvider) {
        if (activeProvider == null || activeProvider == string.Empty) {
            throw new ArgumentNullException(nameof(activeProvider));
        }

        // Check if migration has constructor accepting ISchemaAwareDbContext
        bool isSchemaAwareMigration = migrationClass.GetConstructor(new[] { typeof(ISchemaAwareDbContext) }) != null;

        if (isSchemaAwareMigration && _context is ISchemaAwareDbContext schemaContext) {
            Migration? migration = (Migration?)Activator.CreateInstance(migrationClass.AsType(), schemaContext);

            if (migration != null) {
                migration.ActiveProvider = activeProvider;
                return migration;
            }
        }

        // Fallback to base implementation for standard migrations
        return base.CreateMigration(migrationClass, activeProvider);
    }
}