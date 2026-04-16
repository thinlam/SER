using BuildingBlocks.Domain.Interfaces;
using SequentialGuid;

namespace BuildingBlocks.Domain.Entities.Abstractions;
/// <summary>
/// </summary>
/// <typeparam name="TKey"></typeparam>
public abstract class MaterializedPathEntity<TKey> : IMaterializedPathEntity<TKey>, IEntityMetadata, IMayHaveDelete,
    IMayHaveCreated, IMayHaveUpdate, IUnixTimeIndex
{
    public TKey Id { get; set; } = typeof(TKey) == typeof(Guid) ? (TKey)(object)SequentialGuidGenerator.Instance.NewGuid() : default!;
    public virtual string CreatedBy { get; set; } = string.Empty;
    public virtual DateTimeOffset CreatedAt { get; set; }
    public virtual string UpdatedBy { get; set; } = string.Empty;
    public virtual DateTimeOffset? UpdatedAt { get; set; }
    public virtual bool IsDeleted { get; set; }
    public virtual long Index { get; set; }
    public virtual TKey? ParentId { get; set; }
    public virtual string? Path { get; set; }
    public virtual int Level { get; set; }
}
/* Nhớ bô sung các cấu hình sau
 * public new int? ParentId { get; set; }
 * builder.Property(e => e.ParentId).HasConversion(toDb => toDb == 0 ? null : toDb, fromDb => fromDb);
*/
