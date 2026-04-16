
using BuildingBlocks.Domain.Interfaces;

namespace BuildingBlocks.Domain.Entities.Abstractions;

public abstract class MaterializedPathDanhMuc<TKey> : MaterializedPathEntity<TKey>, IMayHaveMa, IMayHaveTen, IMayHaveMoTa, IHasUsed {
    /// <summary>
    /// Mã
    /// </summary>
    public virtual string? Ma { get; set; }

    /// <summary>
    /// Tên
    /// </summary>
    public virtual string? Ten { get; set; }

    /// <summary>
    /// Mô tả
    /// </summary>
    public virtual string? MoTa { get; set; }

    public virtual bool Used { get; set; }
}
