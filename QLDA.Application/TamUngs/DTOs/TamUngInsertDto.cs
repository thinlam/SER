using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;
using QLDA.Domain.Interfaces;

namespace QLDA.Application.TamUngs.DTOs;

public class TamUngInsertDto : IMayHaveTepDinhKemInsertDto, ITienDo {
    /// <summary>
    /// Khoá ngoại tham chiếu đến Dự án
    /// </summary>
    public Guid DuAnId { get; set; }

    /// <summary>
    /// Khoá ngoại tham chiếu đến Bước (công đoạn)
    /// </summary>
    public int? BuocId { get; set; }

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

    public List<TepDinhKemInsertDto>? DanhSachTepDinhKem { get; set; }
}