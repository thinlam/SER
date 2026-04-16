using BuildingBlocks.Domain.DTOs;

namespace QLHD.Application.Common.DTOs;

/// <summary>
/// Base search model cho các danh sách hợp đồng có kế hoạch (ThuTien, XuatHoaDon, ChiPhi)
/// </summary>
public abstract record HopDongKeHoachSearchModel : AggregateRootSearch, ISearchString
{
    /// <summary>
    /// Lọc theo ID hợp đồng
    /// </summary>
    public Guid? HopDongId { get; set; }

    /// <summary>
    /// Tìm kiếm theo số hợp đồng (LIKE %SoHopDong%)
    /// </summary>
    public string? SoHopDong { get; set; }

    /// <summary>
    /// Lọc theo ID dự án
    /// </summary>
    public Guid? DuAnId { get; set; }

    /// <summary>
    /// Lọc theo ngày kế hoạch từ (KeHoach.ThoiGian &gt;=)
    /// </summary>
    public DateOnly? TuNgayKeHoach { get; set; }

    /// <summary>
    /// Lọc theo ngày kế hoạch đến (KeHoach.ThoiGian &lt;=)
    /// </summary>
    public DateOnly? DenNgayKeHoach { get; set; }

    /// <summary>
    /// Lọc theo ngày hợp đồng từ (HopDong.NgayKy &gt;=)
    /// </summary>
    public DateOnly? TuNgayHopDong { get; set; }

    /// <summary>
    /// Lọc theo ngày hợp đồng đến (HopDong.NgayKy &lt;=)
    /// </summary>
    public DateOnly? DenNgayHopDong { get; set; }

    /// <summary>
    /// Lọc theo trạng thái hợp đồng (HopDong.TrangThaiId)
    /// </summary>
    public int? TrangThaiId { get; set; }

    /// <summary>
    /// Lọc theo người theo dõi (DuAn.NguoiTheoDoiId)
    /// </summary>
    public int? NguoiTheoDoiId { get; set; }

    /// <summary>
    /// Lọc theo người phụ trách chính (DuAn.NguoiPhuTrachChinhId)
    /// </summary>
    public int? NguoiPhuTrachChinhId { get; set; }

    /// <summary>
    /// Lọc theo phòng ban phụ trách chính (HopDong.PhongBanPhuTrachChinhId)
    /// </summary>
    public long? PhongBanPhuTrachChinhId { get; set; }

    /// <summary>
    /// Lọc theo khách hàng (HopDong.KhachHangId)
    /// </summary>
    public Guid? KhachHangId { get; set; }

    /// <summary>
    /// Lọc theo giám đốc (DuAn.GiamDocId)
    /// </summary>
    public int? GiamDocId { get; set; }
}