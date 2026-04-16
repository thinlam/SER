using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;

namespace QLDA.Application.Common.DTOs;

public class DanhMucUpdateDto : IMayHaveTepDinhKemDto {
    public int Id { get; set; }
    public string? Ma { get; set; }
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public int? Stt { get; set; }
    public bool Used { get; set; } = true;
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}