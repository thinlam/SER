using System.ComponentModel;
using QLDA.Domain.Interfaces;
using QLDA.WebApi.Models.TepDinhKems;
using SequentialGuid;

namespace QLDA.WebApi.Models.PhuLucHopDongs;

public class PhuLucHopDongModel : IHasKey<Guid?>, IMustHaveId<Guid>, IMayHaveTepDinhKemModel, ITienDo {
    [DefaultValue(null)] public Guid? Id { get; set; }

    public Guid GetId() {
        Id ??= SequentialGuidGenerator.Instance.NewGuid();
        return (Guid)Id;
    }

    public Guid DuAnId { get; set; }
    public int? BuocId { get; set; }
    public string? Ten { get; set; }
    public string? SoPhuLucHopDong { get; set; }
    public string? NoiDung { get; set; }
    public DateTimeOffset? Ngay { get; set; }
    public Guid? HopDongId { get; set; }
    public long? GiaTri { get; set; }
    public DateTimeOffset? NgayDuKienKetThuc { get; set; }

    public List<TepDinhKemModel>? DanhSachTepDinhKem { get; set; }
}