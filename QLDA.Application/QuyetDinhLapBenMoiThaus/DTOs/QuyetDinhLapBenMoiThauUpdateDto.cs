using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;

namespace QLDA.Application.QuyetDinhLapBenMoiThaus.DTOs;

public class QuyetDinhLapBenMoiThauUpdateDto : IMayHaveTepDinhKemDto {
    public Guid Id { get; set; }
    public string? SoQuyetDinh { get; set; }
    public DateTimeOffset? NgayQuyetDinh { get; set; }
    public string? TrichYeu { get; set; }
    public string? NoiDung { get; set; }
    public DateTimeOffset? NgayKy { get; set; }
    public string? NguoiKy { get; set; }
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}