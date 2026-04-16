using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;

namespace QLDA.Application.BaoCaoTienDos.DTOs;

public class BaoCaoTienDoUpdateDto : IMayHaveTepDinhKemDto {
    public Guid Id { get; set; }
    public DateTimeOffset? Ngay { get; set; }
    public string? NoiDung { get; set; }
    public long? NguoiBaoCaoId { get; set; }
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}