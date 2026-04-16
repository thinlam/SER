using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;

namespace QLDA.Application.NghiemThus.DTOs;

public class NghiemThuUpdateDto : IMayHaveTepDinhKemInsertOrUpdateDto {
    public Guid Id { get; set; }
    public Guid HopDongId { get; set; }
    public string? SoBienBan { get; set; }
    public string? Dot { get; set; }
    public DateTimeOffset? Ngay { get; set; }
    public string? NoiDung { get; set; }

    #region  Issue 9211
    /// <summary>
    /// Giá trị
    /// </summary>
    public long GiaTri { get; set; }

    #endregion
    public List<Guid>? PhuLucHopDongIds { get; set; }
    public List<TepDinhKemInsertOrUpdateDto>? DanhSachTepDinhKem { get; set; }
}