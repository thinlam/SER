using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;
using QLDA.Domain.Interfaces;

namespace QLDA.Application.PhuLucHopDongs.DTOs;

public class PhuLucHopDongInsertDto : IMayHaveTepDinhKemDto, ITienDo {
    public Guid DuAnId { get; set; }
    public int? BuocId { get; set; }
    public string? Ten { get; set; }
    public string? SoPhuLucHopDong { get; set; }
    public string? NoiDung { get; set; }
    public DateTimeOffset? Ngay { get; set; }
    public Guid? HopDongId { get; set; }
    public long? GiaTri { get; set; }
    public DateTimeOffset? NgayDuKienKetThuc { get; set; }
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}