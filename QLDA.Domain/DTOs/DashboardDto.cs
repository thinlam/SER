namespace QLDA.Domain.DTOs;

/// <summary>
/// DTO tổng số dự án theo năm
/// </summary>
public class DashboardTongDto {
    /// <summary>
    /// Năm thống kê
    /// </summary>
    public int Nam { get; set; }

    /// <summary>
    /// Tổng số dự án
    /// </summary>
    public int TongSoDuAn { get; set; }
}

/// <summary>
/// DTO thống kê theo loại dự án (KCM/CT/TD)
/// </summary>
public class DashboardLoaiDuAnDto {
    /// <summary>
    /// Năm thống kê
    /// </summary>
    public int Nam { get; set; }

    /// <summary>
    /// ID loại dự án theo năm
    /// </summary>
    public int? LoaiDuAnTheoNamId { get; set; }

    /// <summary>
    /// Mã loại dự án (KCM, CT, TD)
    /// </summary>
    public string? Ma { get; set; }

    /// <summary>
    /// Tên loại dự án
    /// </summary>
    public string? Ten { get; set; }

    /// <summary>
    /// Số lượng dự án
    /// </summary>
    public int SoLuong { get; set; }
}

/// <summary>
/// DTO thống kê theo bước
/// </summary>
public class DashboardTheoBuocDto {
    /// <summary>
    /// ID bước (DuAnBuoc.Id, không phải DanhMucBuoc.Id)
    /// </summary>
    public int? BuocId { get; set; }

    /// <summary>
    /// Tên bước
    /// </summary>
    public string? TenBuoc { get; set; }

    /// <summary>
    /// Số lượng dự án
    /// </summary>
    public int SoLuong { get; set; }
}

/// <summary>
/// DTO thống kê theo giai đoạn
/// </summary>
public class DashboardTheoGiaiDoanDto {
    /// <summary>
    /// ID giai đoạn
    /// </summary>
    public int? GiaiDoanId { get; set; }

    /// <summary>
    /// Tên giai đoạn
    /// </summary>
    public string? TenGiaiDoan { get; set; }

    /// <summary>
    /// Số lượng dự án
    /// </summary>
    public int SoLuong { get; set; }
}

/// <summary>
/// DTO tổng hợp tất cả thống kê dashboard trong 1 lần gọi API
/// </summary>
public class DashboardTongHopDto {
    /// <summary>
    /// Năm thống kê
    /// </summary>
    public int Nam { get; set; }

    /// <summary>
    /// Tổng số dự án trong năm
    /// </summary>
    public int TongSoDuAn { get; set; }

    /// <summary>
    /// Số dự án khởi công mới (KCM)
    /// </summary>
    public int SoKhoiCongMoi { get; set; }

    /// <summary>
    /// Số dự án chuyển tiếp (CT)
    /// </summary>
    public int SoChuyenTiep { get; set; }

    /// <summary>
    /// Số dự án tồn đọng (TD)
    /// </summary>
    public int SoTonDong { get; set; }

    /// <summary>
    /// Chi tiết thống kê theo loại dự án
    /// </summary>
    public List<DashboardLoaiDuAnDto> TheoLoai { get; set; } = [];

    /// <summary>
    /// Thống kê theo bước hiện tại
    /// </summary>
    public List<DashboardTheoBuocDto> TheoBuoc { get; set; } = [];

    /// <summary>
    /// Thống kê theo giai đoạn hiện tại
    /// </summary>
    public List<DashboardTheoGiaiDoanDto> TheoGiaiDoan { get; set; } = [];
}