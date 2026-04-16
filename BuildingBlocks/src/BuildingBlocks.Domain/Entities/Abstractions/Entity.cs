using BuildingBlocks.Domain.Interfaces;
using SequentialGuid;

namespace BuildingBlocks.Domain.Entities.Abstractions;

public abstract class Entity<TKey> : IHasKey<TKey>, IEntityMetadata, IMayHaveDelete,
    IMayHaveCreated, IMayHaveUpdate, IUnixTimeIndex
{
    public TKey Id { get; set; } = typeof(TKey) == typeof(Guid) ? (TKey)(object)SequentialGuidGenerator.Instance.NewGuid() : default!;
    public virtual string CreatedBy { get; set; } = string.Empty;
    public virtual DateTimeOffset CreatedAt { get; set; }
    public virtual string UpdatedBy { get; set; } = string.Empty;
    public virtual DateTimeOffset? UpdatedAt { get; set; }
    public virtual bool IsDeleted { get; set; }
    public virtual long Index { get; set; }
}
