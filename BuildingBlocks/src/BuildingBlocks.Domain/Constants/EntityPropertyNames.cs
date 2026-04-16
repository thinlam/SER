namespace BuildingBlocks.Domain.Constants;

/// <summary>
/// Constants for entity property names used in Repository operations
/// ✅ Centralized property names để dễ maintain và tránh typo
/// </summary>
public static class EntityPropertyNames
{
    /// <summary>
    /// Property name cho soft delete functionality
    /// </summary>
    public const string IsDeleted = nameof(IsDeleted);

    /// <summary>
    /// Property name cho Used functionality trong DanhMuc entities
    /// </summary>
    public const string Used = nameof(Used);

    /// <summary>
    /// Property name cho Unix time index ordering
    /// </summary>
    public const string Index = nameof(Index);

    /// <summary>
    /// Property name cho materialized path trong hierarchical entities
    /// </summary>
    public const string Path = nameof(Path);

    /// <summary>
    /// Property name cho level trong hierarchical entities
    /// </summary>
    public const string Level = nameof(Level);

    /// <summary>
    /// Property name cho ParentId trong hierarchical entities
    /// </summary>
    public const string ParentId = nameof(ParentId);
}
