namespace QLHD.Persistence.Schema;

/// <summary>
/// Marker interface for schema-aware DbContext.
/// Allows model cache key factory to differentiate models by schema.
/// </summary>
public interface ISchemaAwareDbContext
{
    string Schema { get; }
}