using BuildingBlocks.Domain.Interfaces;

namespace BuildingBlocks.Domain.Entities.Abstractions;

public abstract class EnumDb<TKey> : IHasKey<TKey>
{
    public TKey Id { get; set; } = default!;

    /// <summary>
    /// Tên
    /// </summary>
    public virtual string? Ten { get; set; }

    /// <summary>
    /// Mã
    /// </summary>
    public virtual string? MaString { get; } = null;
}
