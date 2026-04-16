using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Domain.Entities;

/// <summary>
/// Bảng khó khăn vướng mắc <br/>
/// Note: bảng này có 2 loại file là KetQuaXuLyKhoKhanVuongMac và KhoKhanVuongMac dựa theo groupId(Guid) và type
/// </summary>
public class BaoCaoKhoKhanVuongMac : BaoCao {
    /// <summary>
    /// Mức độ khó khăn
    /// </summary>
    public int? MucDoKhoKhanId { get; set; }
    /// <summary>
    /// Tình trạng khó khăn
    /// </summary>
    public int? TinhTrangId { get; set; }
    /// <summary>
    /// Hướng xử lý
    /// </summary>
    public string? HuongXuLy { get; set; }

    #region Kết quả xử lý

    public string? KetQuaXuLy { get; set; }
    public DateTimeOffset? NgayXuLy { get; set; }

    #endregion

    #region Navigation Properties

    public DanhMucTinhTrangKhoKhan? TinhTrang { get; set; }
    public DanhMucMucDoKhoKhan? MucDo { get; set; }

    #endregion
}