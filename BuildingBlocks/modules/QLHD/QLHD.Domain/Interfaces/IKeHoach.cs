namespace QLHD.Domain.Interfaces;

/// <summary>
/// Interface đánh dấu có các trường kế hoạch (ThoiGianKeHoach, PhanTramKeHoach, GiaTriKeHoach, GhiChuKeHoach)
/// - Dùng để đảm bảo các entity có nhóm trường kế hoạch đều implement interface này
/// - Áp dụng cho: HopDong_ThuTien, DuAn_ThuTien, HopDong_XuatHoaDon, DuAn_XuatHoaDon, HopDong_ChiPhi
/// - Lưu ý: DTOs KHÔNG implement interface này vì dùng MonthYear thay vì DateOnly cho ThoiGianKeHoach
/// </summary>
public interface IKeHoach
{
    /// <summary>
    /// Thời gian kế hoạch (DateOnly - chỉ dùng cho entities)
    /// </summary>
    DateOnly ThoiGianKeHoach { get; set; }

    /// <summary>
    /// Phần trăm kế hoạch (0-100)
    /// </summary>
    decimal PhanTramKeHoach { get; set; }

    /// <summary>
    /// Giá trị kế hoạch
    /// </summary>
    decimal GiaTriKeHoach { get; set; }

    /// <summary>
    /// Ghi chú kế hoạch
    /// </summary>
    string? GhiChuKeHoach { get; set; }
}