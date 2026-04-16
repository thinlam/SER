using Microsoft.EntityFrameworkCore;

namespace QLHD.Persistence.Schema;

/// <summary>
/// Model cache key that includes schema name.
/// Ensures EF Core caches different models for different schemas.
/// </summary>
internal sealed class SchemaAwareModelCacheKey(DbContext context, bool designTime)
{
    private readonly Type _contextType = context.GetType();
    private readonly bool _designTime = designTime;
    private readonly string? _schema = (context as ISchemaAwareDbContext)?.Schema;

    public override bool Equals(object? obj) =>
        obj is SchemaAwareModelCacheKey other &&
        _contextType == other._contextType &&
        _designTime == other._designTime &&
        _schema == other._schema;

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(_contextType);
        hash.Add(_designTime);
        hash.Add(_schema);
        return hash.ToHashCode();
    }
}