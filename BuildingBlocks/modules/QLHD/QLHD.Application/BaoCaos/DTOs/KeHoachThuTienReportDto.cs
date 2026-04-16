namespace QLHD.Application.BaoCaos.DTOs;

public class KeHoachThuTienReportDto {
    /// <summary>
    /// Tổng tiền kế hoạch
    /// </summary>
    public decimal KeHoach { get; set; }
    /// <summary>
    /// Tổng tiền thực tế
    /// </summary>
    public decimal ThucTe { get; set; }
    public required PaginatedList<KeHoachThuTienDto> PaginatedList { get; set; }
}

public class KeHoachThuTienDto {
    public Guid HopDongId { get; set; }
    public Guid KhachHangId { get; set; }
    /// <summary>
    /// Số hợp đồng
    /// </summary>
    public string SoHopDong { get; set; } = string.Empty;
    /// <summary>
    /// Tên khách hàng
    /// </summary>
    public string TenKhachHang { get; set; } = string.Empty;
    /// <summary>
    /// Tên hợp đồng
    /// </summary>
    public string TenHopDong { get; set; } = string.Empty;
    /// <summary>
    /// Ngày hợp đồng
    /// </summary>
    public DateOnly NgayKy { get; set; }
    /// <summary>
    /// Giá trị hợp đồng
    /// </summary>
    public decimal GiaTri { get; set; }
}