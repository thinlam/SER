namespace QLHD.Domain.Interfaces;

/// <summary>
/// Interface đánh dấu có các trường thực tế (ThoiGianThucTe, GiaTriThucTe, GhiChuThucTe)
/// - Dùng để đảm bảo các entity và DTO có nhóm trường thực tế đều implement interface này
/// - Áp dụng cho cả entities và DTOs vì kiểu dữ liệu giống nhau (nullable)
/// - Entities: HopDong_ThuTien, DuAn_ThuTien, HopDong_XuatHoaDon, DuAn_XuatHoaDon, HopDong_ChiPhi
/// - DTOs: ThuTienDto, XuatHoaDonDto, ChiPhiDto
/// </summary>
public interface IThucTe
{
    /// <summary>
    /// Thời gian thực tế (nullable - điền khi thực hiện)
    /// </summary>
    DateOnly? ThoiGianThucTe { get; set; }

    /// <summary>
    /// Giá trị thực tế (nullable - điền khi thực hiện)
    /// </summary>
    decimal? GiaTriThucTe { get; set; }

    /// <summary>
    /// Ghi chú thực tế
    /// </summary>
    string? GhiChuThucTe { get; set; }
}