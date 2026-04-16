using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;
using QLDA.Domain.Interfaces;

namespace QLDA.Application.NghiemThus.DTOs;

public class NghiemThuInsertDto : IMayHaveTepDinhKemInsertDto, ITienDo {
    public Guid DuAnId { get; set; }
    public int? BuocId { get; set; }
    public Guid HopDongId { get; set; }
    public string? SoBienBan { get; set; }
    public required string Dot { get; set; }
    public DateTimeOffset? Ngay { get; set; }
    public string? NoiDung { get; set; }

    #region  Issue 9211
    /// <summary>
    /// Giá trị
    /// </summary>
    public long GiaTri { get; set; }

    #endregion
    public List<Guid>? PhuLucHopDongIds { get; set; }
    public List<TepDinhKemInsertDto>? DanhSachTepDinhKem { get; set; }
}