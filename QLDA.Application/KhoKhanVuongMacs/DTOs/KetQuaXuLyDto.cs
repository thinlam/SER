using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;

namespace QLDA.Application.KhoKhanVuongMacs.DTOs;

public class KetQuaXuLyDto : IMayHaveTepDinhKemDto {
    
    public string? KetQuaXuLy { get; set; }
    public DateTimeOffset? NgayXuLy { get; set; }
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}