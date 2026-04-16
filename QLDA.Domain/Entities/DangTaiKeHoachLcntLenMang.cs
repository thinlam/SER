using QLDA.Domain.Enums;
using QLDA.Domain.Interfaces;

namespace QLDA.Domain.Entities;

public class DangTaiKeHoachLcntLenMang : Entity<Guid>, IAggregateRoot, ITienDo {
    public Guid DuAnId { get; set; }
    public int? BuocId { get; set; }
    public Guid KeHoachLuaChonNhaThauId { get; set; }

    public DateTimeOffset? NgayEHSMT { get; set; }

    /// <summary>
    /// Đã đăng lên/ chưa đăng lên
    /// </summary>
    public ETrangThaiMoiThau TrangThaiId { get; set; }

    #region Navigation Properties

    public KeHoachLuaChonNhaThau KeHoachLuaChonNhaThau { get; set; } = null!;
    public DuAnBuoc? DuAnBuoc { get; set; }

    #endregion
}