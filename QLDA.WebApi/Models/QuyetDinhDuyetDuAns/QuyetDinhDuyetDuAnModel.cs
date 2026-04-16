using System.ComponentModel;
using QLDA.Domain.Interfaces;
using QLDA.WebApi.Models.QuyetDinhDuyetDuAnHangMucs;
using QLDA.WebApi.Models.TepDinhKems;
using SequentialGuid;

namespace QLDA.WebApi.Models.QuyetDinhDuyetDuAns;

public class QuyetDinhDuyetDuAnModel : IHasKey<Guid?>, IMustHaveId<Guid>, IMayHaveTepDinhKemModel, ITienDo {
    [DefaultValue(null)] public Guid? Id { get; set; }

    public Guid GetId() {
        Id ??= SequentialGuidGenerator.Instance.NewGuid();
        return (Guid)Id;
    }
    
    public Guid DuAnId { get; set; }
    public int? BuocId { get; set; }
    public string? SoQuyetDinh { get; set; }
    public DateTimeOffset? NgayQuyetDinh { get; set; }
    public string? TrichYeu { get; set; }
    public string? CoQuanQuyetDinhDauTu { get; set; }
    
    public List<QuyetDinhDuyetDuAnHangMucModel>? HangMucs { get; set; }
    
    public List<TepDinhKemModel>? DanhSachTepDinhKem { get; set; }
}