using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BuildingBlocks.Domain.ValueTypes;

namespace QLHD.Application.DuAn_XuatHoaDons.DTOs;

/// <summary>
/// Model thêm mới/cập nhật xuất hóa đơn theo dự án (gộp kế hoạch + thực tế).
/// DuAnId được lấy từ context cha (DuAn).
/// HopDongId được set sau khi có hợp đồng thực hiện xuất hóa đơn.
/// </summary>
public class DuAn_XuatHoaDonInsertOrUpdateModel
{
    /// <summary>
    /// Khi null -> insert mới <br/>
    /// Có giá trị -> cập nhật
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

    #region Thực tế (optional)

    /// <summary>
    /// Thời gian thực tế
    /// </summary>
    public DateOnly? ThoiGianThucTe { get; set; }

    /// <summary>
    /// Giá trị thực tế
    /// </summary>
    public decimal? GiaTriThucTe { get; set; }

    /// <summary>
    /// Số hóa đơn
    /// </summary>
    public string? SoHoaDon { get; set; }

    /// <summary>
    /// Ký hiệu hóa đơn
    /// </summary>
    public string? KyHieuHoaDon { get; set; }

    /// <summary>
    /// Ngày hóa đơn
    /// </summary>
    public DateOnly? NgayHoaDon { get; set; }

    #endregion
}