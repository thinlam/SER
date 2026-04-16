using QLDA.Domain.Interfaces;

namespace QLDA.Domain.Entities;

public class BaoCao : Entity<Guid>, IAggregateRoot, ITienDo, IBaoCao, IEntityType {
    public Guid DuAnId { get; set; }
    public int? BuocId { get; set; }

    public DateTimeOffset? Ngay { get; set; }
    public string? NoiDung { get; set; }
    public string? Loai { get; set; }

    #region Navigation Properties

    public DuAn? DuAn { get; set; }
    public DuAnBuoc? DuAnBuoc { get; set; }

    #endregion
}