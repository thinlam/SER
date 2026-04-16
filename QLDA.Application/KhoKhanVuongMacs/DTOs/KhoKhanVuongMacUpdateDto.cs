using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;

namespace QLDA.Application.KhoKhanVuongMacs.DTOs;

public class KhoKhanVuongMacUpdateDto : IMayHaveTepDinhKemDto {
    public Guid Id { get; set; }
    public DateTimeOffset? Ngay { get; set; }
    public string? NoiDung { get; set; }
    public int? TinhTrangId { get; set; }
    public int? MucDoKhoKhanId { get; set; }
    public string? HuongXuLy { get; set; }
    public string? KetQuaXuLy { get; set; }
    public DateTimeOffset? NgayXuLy { get; set; }
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}