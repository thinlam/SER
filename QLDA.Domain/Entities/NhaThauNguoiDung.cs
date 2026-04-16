using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Domain.Entities;

/// <summary>
/// Cấu hình người dùng thuộc nhà thầu
/// </summary>
public class NhaThauNguoiDung : Entity<int>, IAggregateRoot {
    public Guid NhaThauId { get; set; }
    public long NguoiDungId { get; set; }

    #region Navigation Properties

    public DanhMucNhaThau? NhaThau { get; set; }

    #endregion
}
