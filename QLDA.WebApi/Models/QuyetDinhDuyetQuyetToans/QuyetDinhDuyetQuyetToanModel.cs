using System.ComponentModel;
using QLDA.Domain.Interfaces;
using QLDA.WebApi.Models.TepDinhKems;
using SequentialGuid;

namespace QLDA.WebApi.Models.QuyetDinhDuyetQuyetToans;

public class QuyetDinhDuyetQuyetToanModel : IHasKey<Guid?>, IMustHaveId<Guid>, IMayHaveTepDinhKemModel, ITienDo {
    [DefaultValue(null)] public Guid? Id { get; set; }

    public Guid GetId() {
        Id ??= SequentialGuidGenerator.Instance.NewGuid();
        return (Guid)Id;
    }
    
    public Guid DuAnId { get; set; }
    public int? BuocId { get; set; }
    public string? SoQuyetDinh { get; set; }
    public DateTimeOffset? NgayQuyetDinh { get; set; }
    public string? CoQuanQuyetDinh { get; set; }
    public string? TrichYeu { get; set; }
    public DateTimeOffset? NgayKy { get; set; }
    public string? NguoiKy { get; set; }
    public long? GiaTri { get; set; }

    public List<TepDinhKemModel>? DanhSachTepDinhKem { get; set; }
}