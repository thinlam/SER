using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;

namespace QLDA.Application.TamUngs.DTOs;

public class TamUngUpdateDto : IHasKey<Guid>, IMayHaveTepDinhKemInsertOrUpdateDto {
    public Guid Id { get; set; }
    /// <summary>
    /// Hợp đồng/ biên bản nghiệm thu
    /// </summary>
    public Guid HopDongId { get; set; }

    /// <summary>
    /// Số phiếu chi
    /// </summary>
    public string? SoPhieuChi { get; set; }

    /// <summary>
    /// Giá trị tạm ứng
    /// </summary>
    public long? GiaTri { get; set; }

    public string? NoiDung { get; set; }
    public DateTimeOffset? NgayTamUng { get; set; }

    #region Issue 9213
    /// <summary>
    /// Số bảo lãnh
    /// </summary>
    public string? SoBaoLanh { get; set; }
    /// <summary>
    /// Ngày bảo lãnh
    /// </summary>
    public DateTimeOffset? NgayBaoLanh { get; set; }
    /// <summary>
    /// Ngày kết thúc bảo lãnh
    /// </summary>
    public DateTimeOffset? NgayKetThucBaoLanh { get; set; }
    #endregion

    public List<TepDinhKemInsertOrUpdateDto>? DanhSachTepDinhKem { get; set; }
}