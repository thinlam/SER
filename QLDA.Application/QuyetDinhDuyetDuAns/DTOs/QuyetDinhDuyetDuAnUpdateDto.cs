using QLDA.Application.Common.Interfaces;
using QLDA.Application.QuyetDinhDuyetDuAnNguonVons.DTOs;
using QLDA.Application.TepDinhKems.DTOs;

namespace QLDA.Application.QuyetDinhDuyetDuAns.DTOs;

public class QuyetDinhDuyetDuAnUpdateDto : IMayHaveTepDinhKemDto {
    public Guid Id { get; set; }
    public string? SoQuyetDinh { get; set; }
    public DateTimeOffset? NgayQuyetDinh { get; set; }
    public string? TrichYeu { get; set; }
    public string? CoQuanQuyetDinhDauTu { get; set; }
    public List<QuyetDinhDuyetDuAnNguonVonDto>? NguonVons { get; set; }
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}