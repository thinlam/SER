using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;

namespace QLDA.Application.QuyetDinhDuyetQuyetToans.DTOs;

public class QuyetDinhDuyetQuyetToanUpdateDto : IMayHaveTepDinhKemDto {
    public Guid Id { get; set; }
    public string? SoQuyetDinh { get; set; }
    public DateTimeOffset? NgayQuyetDinh { get; set; }
    public string? CoQuanQuyetDinh { get; set; }
    public string? TrichYeu { get; set; }
    public DateTimeOffset? NgayKy { get; set; }
    public string? NguoiKy { get; set; }
    public long? GiaTri { get; set; }
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}