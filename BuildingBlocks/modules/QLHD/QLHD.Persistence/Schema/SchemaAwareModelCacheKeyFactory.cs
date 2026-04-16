using Microsoft.EntityFrameworkCore.Infrastructure;

namespace QLHD.Persistence.Schema;

/// <summary>
/// Factory for creating schema-aware model cache keys.
/// Registered in AppDbContext.OnConfiguring to enable per-schema model caching.
/// </summary>
internal sealed class SchemaAwareModelCacheKeyFactory : IModelCacheKeyFactory
{
    public object Create(DbContext context, bool designTime)
        => new SchemaAwareModelCacheKey(context, designTime);
}