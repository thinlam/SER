using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BuildingBlocks.Domain.ValueTypes;

namespace QLHD.Application.DuAn_XuatHoaDons.DTOs;

/// <summary>
/// Model tạo kế hoạch xuất hóa đơn theo dự án (chỉ trường kế hoạch).
/// DuAnId được lấy từ context cha (DuAn).
/// HopDongId và các trường thực tế được set sau khi có hợp đồng.
/// </summary>
public class DuAn_XuatHoaDonInsertModel
{
    /// <summary>
    /// Nếu null hoặc empty → Thêm mới. <br/>
    /// Có giá trị → Cập nhật.
    /// </summary>
    [DefaultValue("00000000-0000-0000-0000-000000000000")]
    public Guid? Id { get; set; }

    #region Kế hoạch (required)

    [Required]
    public int LoaiThanhToanId { get; set; }

    /// <summary>
    /// Thời gian kế hoạch
    /// </summary>
    [Required]
    public MonthYear ThoiGianKeHoach { get; set; }

    /// <summary>
    /// Phần trăm kế hoạch (0-100)
    /// </summary>
    [Required]
    public decimal PhanTramKeHoach { get; set; }

    /// <summary>
    /// Giá trị kế hoạch
    /// </summary>
    public decimal GiaTriKeHoach { get; set; }

    /// <summary>
    /// Ghi chú kế hoạch
    /// </summary>
    public string? GhiChuKeHoach { get; set; }

    /// <summary>
    /// Ghi chú thực tế
    /// </summary>
    public string? GhiChuThucTe { get; set; }

    #endregion
}