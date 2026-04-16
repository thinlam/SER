using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.EntityFrameworkCore.Storage;

namespace QLHD.Persistence.Schema;

/// <summary>
/// Custom SQL generator that injects schema into migration operations at runtime.
/// Enables schema-agnostic migrations that can be applied to any schema.
/// </summary>
public class SchemaAwareMigrationsSqlGenerator(
    MigrationsSqlGeneratorDependencies dependencies,
    ICommandBatchPreparer commandBatchPreparer) : SqlServerMigrationsSqlGenerator(dependencies, commandBatchPreparer) {
    private static string? RuntimeSchema =>
        Environment.GetEnvironmentVariable("ConnectionStrings__Schema") switch {
            null or "dbo" or "" => null,
            var schema => schema
        };

    private static void InjectSchema(MigrationOperation operation) {
        if (RuntimeSchema == null) return;

        var schemaProperty = operation.GetType().GetProperty("Schema");
        if (schemaProperty != null && schemaProperty.CanWrite) {
            var currentSchema = schemaProperty.GetValue(operation) as string;
            if (string.IsNullOrEmpty(currentSchema)) {
                schemaProperty.SetValue(operation, RuntimeSchema);
            }
        }

        var principalSchemaProperty = operation.GetType().GetProperty("PrincipalSchema");
        if (principalSchemaProperty != null && principalSchemaProperty.CanWrite) {
            var currentPrincipalSchema = principalSchemaProperty.GetValue(operation) as string;
            if (string.IsNullOrEmpty(currentPrincipalSchema)) {
                principalSchemaProperty.SetValue(operation, RuntimeSchema);
            }
        }
    }

    protected override void Generate(CreateTableOperation operation, IModel? model, MigrationCommandListBuilder builder, bool terminate = true) {
        InjectSchema(operation);
        foreach (var fk in operation.ForeignKeys) InjectSchema(fk);
        base.Generate(operation, model, builder, terminate);
    }

    protected override void Generate(DropTableOperation operation, IModel? model, MigrationCommandListBuilder builder, bool terminate = true) {
        InjectSchema(operation);
        base.Generate(operation, model, builder, terminate);
    }

    protected override void Generate(CreateIndexOperation operation, IModel? model, MigrationCommandListBuilder builder, bool terminate = true) {
        InjectSchema(operation);
        base.Generate(operation, model, builder, terminate);
    }

    protected override void Generate(DropIndexOperation operation, IModel? model, MigrationCommandListBuilder builder, bool terminate = true) {
        InjectSchema(operation);
        base.Generate(operation, model, builder, terminate);
    }

    protected override void Generate(AddPrimaryKeyOperation operation, IModel? model, MigrationCommandListBuilder builder, bool terminate = true) {
        InjectSchema(operation);
        base.Generate(operation, model, builder, terminate);
    }

    protected override void Generate(DropPrimaryKeyOperation operation, IModel? model, MigrationCommandListBuilder builder, bool terminate = true) {
        InjectSchema(operation);
        base.Generate(operation, model, builder, terminate);
    }

    protected override void Generate(RenameTableOperation operation, IModel? model, MigrationCommandListBuilder builder) {
        InjectSchema(operation);
        base.Generate(operation, model, builder);
    }

    protected override void Generate(DropForeignKeyOperation operation, IModel? model, MigrationCommandListBuilder builder, bool terminate = true) {
        InjectSchema(operation);
        base.Generate(operation, model, builder, terminate);
    }

    protected override void Generate(AddUniqueConstraintOperation operation, IModel? model, MigrationCommandListBuilder builder) {
        InjectSchema(operation);
        base.Generate(operation, model, builder);
    }

    protected override void Generate(DropUniqueConstraintOperation operation, IModel? model, MigrationCommandListBuilder builder) {
        InjectSchema(operation);
        base.Generate(operation, model, builder);
    }

    protected override void Generate(DropColumnOperation operation, IModel? model, MigrationCommandListBuilder builder, bool terminate = true) {
        InjectSchema(operation);
        base.Generate(operation, model, builder, terminate);
    }

    protected override void Generate(AddColumnOperation operation, IModel? model, MigrationCommandListBuilder builder, bool terminate = true) {
        InjectSchema(operation);
        base.Generate(operation, model, builder, terminate);
    }

    protected override void Generate(AlterColumnOperation operation, IModel? model, MigrationCommandListBuilder builder) {
        InjectSchema(operation);
        base.Generate(operation, model, builder);
    }

    /// <summary>
    /// InsertData: Generate raw INSERT SQL with schema injection.
    /// Bypasses EF Core model validation by generating SQL directly.
    /// Uses IF NOT EXISTS for idempotency.
    /// Handles IDENTITY columns by wrapping with SET IDENTITY_INSERT ON/OFF.
    /// </summary>
    protected override void Generate(InsertDataOperation operation, IModel? model, MigrationCommandListBuilder builder, bool terminate = true) {
        var schema = RuntimeSchema ?? "dbo";
        GenerateInsertSql(operation, schema, model, builder);

        if (terminate) {
            builder.AppendLine(Dependencies.SqlGenerationHelper.StatementTerminator);
            builder.EndCommand();
        }
    }

    /// <summary>
    /// Generates DELETE SQL with schema injection (for future use).
    /// Note: DeleteDataOperation is handled by base class, schema injection via InjectSchema works.
    /// </summary>

    /// <summary>
    /// Generates SQL value literal for various types.
    /// </summary>
    private static string GenerateValueLiteral(object? value) {
        if (value == null) return "NULL";
        if (value is string s) return $"N'{s.Replace("'", "''")}'";
        if (value is Guid g) return $"'{g}'";
        if (value is DateTime dt) return $"'{dt:yyyy-MM-ddTHH:mm:ss}'";
        if (value is DateTimeOffset dto) return $"'{dto:yyyy-MM-ddTHH:mm:ssZ}'";
        if (value is DateOnly d) return $"'{d:yyyy-MM-dd}'";
        if (value is bool b) return b ? "1" : "0";
        if (value is decimal dec) return dec.ToString(CultureInfo.InvariantCulture);
        if (value is int i) return i.ToString();
        if (value is long l) return l.ToString();
        if (value is byte bt) return bt.ToString();
        return value.ToString() ?? "NULL";
    }

    /// <summary>
    /// Generates INSERT SQL with schema and IF NOT EXISTS check for idempotency.
    /// Handles IDENTITY columns by wrapping with SET IDENTITY_INSERT ON/OFF.
    /// </summary>
    private void GenerateInsertSql(InsertDataOperation operation, string schema, IModel? model, MigrationCommandListBuilder builder) {
        var table = operation.Table;
        var columns = operation.Columns;
        var keyColumn = columns[0]; // Assume first column is primary key (usually Id)

        // Check if the entity uses int key (IDENTITY column)
        var useIdentityInsert = RequiresIdentityInsert(operation, model);

        // EF Core generates Values as 2D array: object?[rows, columns]
        var values = operation.Values;
        var rowCount = values.GetLength(0);
        var columnCount = values.GetLength(1);

        // Wrap all inserts for this table with IDENTITY_INSERT if needed
        if (useIdentityInsert) {
            builder.AppendLine($"SET IDENTITY_INSERT [{schema}].[{table}] ON;");
        }

        for (int row = 0; row < rowCount; row++) {
            var rowValues = new object?[columnCount];
            for (int col = 0; col < columnCount; col++) {
                rowValues[col] = values[row, col];
            }
            GenerateSingleInsert(schema, table, columns, keyColumn, rowValues, builder);
        }

        if (useIdentityInsert) {
            builder.AppendLine($"SET IDENTITY_INSERT [{schema}].[{table}] OFF;");
        }
    }

    /// <summary>
    /// Determines if the entity requires IDENTITY_INSERT for seed data.
    /// Returns true for int-key entities (which use IDENTITY in SQL Server).
    /// </summary>
    private static bool RequiresIdentityInsert(InsertDataOperation operation, IModel? model) {
        if (model == null) return false;

        // Find entity type by table name
        var entityType = model.GetEntityTypes()
            .FirstOrDefault(e => e.GetTableName() == operation.Table);

        if (entityType == null) return false;

        // Check if primary key is int
        var primaryKey = entityType.FindPrimaryKey();
        if (primaryKey == null) return false;

        var keyProperty = primaryKey.Properties.FirstOrDefault();
        if (keyProperty == null) return false;

        // Check if the key type is int (IDENTITY)
        return keyProperty.ClrType == typeof(int);
    }

    /// <summary>
    /// Generates a single INSERT statement with IF NOT EXISTS check.
    /// </summary>
    private static void GenerateSingleInsert(
        string schema,
        string table,
        IReadOnlyList<string> columns,
        string keyColumn,
        object?[] rowValues,
        MigrationCommandListBuilder builder) {
        var keyValue = GenerateValueLiteral(rowValues[0]);

        builder.AppendLine($"IF NOT EXISTS (SELECT 1 FROM [{schema}].[{table}] WHERE [{keyColumn}] = {keyValue})");
        builder.AppendLine("BEGIN");
        builder.Append($"    INSERT INTO [{schema}].[{table}] (");

        for (int i = 0; i < columns.Count; i++) {
            if (i > 0) builder.Append(", ");
            builder.Append($"[{columns[i]}]");
        }

        builder.Append(") VALUES (");

        for (int i = 0; i < rowValues.Length; i++) {
            if (i > 0) builder.Append(", ");
            builder.Append(GenerateValueLiteral(rowValues[i]));
        }

        builder.AppendLine(");");
        builder.AppendLine("END");
    }

}