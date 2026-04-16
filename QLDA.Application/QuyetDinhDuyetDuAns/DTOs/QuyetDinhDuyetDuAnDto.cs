using QLDA.Application.Common.Interfaces;
using QLDA.Application.QuyetDinhDuyetDuAnNguonVons.DTOs;
using QLDA.Application.TepDinhKems.DTOs;
using QLDA.Domain.Interfaces;

namespace QLDA.Application.QuyetDinhDuyetDuAns.DTOs;

public class QuyetDinhDuyetDuAnDto : IHasKey<Guid?>, IMayHaveTepDinhKemDto, ITienDo {
    [DefaultValue(null)] public Guid? Id { get; set; }
    public Guid DuAnId { get; set; }
    public int? BuocId { get; set; }
    public string? SoQuyetDinh { get; set; }
    public DateTimeOffset? NgayQuyetDinh { get; set; }
    public string? TrichYeu { get; set; }
    public string? CoQuanQuyetDinhDauTu { get; set; }
    public List<QuyetDinhDuyetDuAnNguonVonDto>? NguonVons { get; set; }
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}