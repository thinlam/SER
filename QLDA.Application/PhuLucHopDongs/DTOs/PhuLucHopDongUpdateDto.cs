using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;

namespace QLDA.Application.PhuLucHopDongs.DTOs;

public class PhuLucHopDongUpdateDto : IMayHaveTepDinhKemDto {
    public Guid Id { get; set; }
    public string? Ten { get; set; }
    public string? SoPhuLucHopDong { get; set; }
    public string? NoiDung { get; set; }
    public DateTimeOffset? Ngay { get; set; }
    public Guid? HopDongId { get; set; }
    public long? GiaTri { get; set; }
    public DateTimeOffset? NgayDuKienKetThuc { get; set; }
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}