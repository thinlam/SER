using QLHD.Domain.Constants;

namespace QLHD.Application.BaoCaos.DTOs;

public record PhongBanReportDto {
    public long PhongBanId { get; set; }
    public string TenPhongBan { get; set; } = string.Empty;
    public Guid Id { get; set; }  // DuAn.Id or HopDong.Id
    /// <summary>
    /// Tên dự án hoặc hợp đồng
    /// </summary>
    public string? Ten { get; set; }
    /// <summary>
    /// Loại: DU_AN or HOP_DONG (use LoaiDuAnHopDongConstants)
    /// </summary>
    public string Loai { get; set; } = string.Empty;
    /// <summary>
    /// Doanh số
    /// </summary>
    public decimal GiaTri { get; set; }
    /// <summary>
    /// Thu tiền/ xuất hoá đơn/ chi phí
    /// </summary>
    public decimal KeHoach { get; set; }
    /// <summary>
    /// Thu tiền/ xuất hoá đơn/ chi phí
    /// </summary>
    public decimal ThucTe { get; set; }
    /// <summary>
    /// Lãi gop
    /// </summary>
    public decimal LaiGop { get; set; }
    /// <summary>
    /// Report type: DOANH_SO, THU_TIEN, XUAT_HOA_DON, CHI_PHI.
    /// Use PhongBanReportTypeConstants for values.
    /// </summary>
    public string Type { get; set; } = string.Empty;

}