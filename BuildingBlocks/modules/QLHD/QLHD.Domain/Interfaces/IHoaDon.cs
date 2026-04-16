namespace QLHD.Domain.Interfaces;

/// <summary>
/// Interface đánh dấu có các trường hóa đơn (SoHoaDon, KyHieuHoaDon, NgayHoaDon)
/// - Dùng để đảm bảo các entity và DTO có nhóm trường hóa đơn đều implement interface này
/// - Áp dụng cho cả entities và DTOs vì kiểu dữ liệu giống nhau (nullable)
/// - Entities: HopDong_ThuTien, DuAn_ThuTien, HopDong_XuatHoaDon, DuAn_XuatHoaDon (KHÔNG có ChiPhi)
/// - DTOs: ThuTienDto, XuatHoaDonDto (KHÔNG có ChiPhiDto vì chi phí không có hóa đơn)
/// </summary>
public interface IHoaDon
{
    /// <summary>
    /// Số hóa đơn
    /// </summary>
    string? SoHoaDon { get; set; }

    /// <summary>
    /// Ký hiệu hóa đơn
    /// </summary>
    string? KyHieuHoaDon { get; set; }

    /// <summary>
    /// Ngày hóa đơn
    /// </summary>
    DateOnly? NgayHoaDon { get; set; }
}