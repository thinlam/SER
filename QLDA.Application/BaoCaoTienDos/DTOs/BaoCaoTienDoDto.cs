using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;
using QLDA.Domain.Interfaces;
using SequentialGuid;

namespace QLDA.Application.BaoCaoTienDos.DTOs;

public class BaoCaoTienDoDto : IHasKey<Guid?>, IMustHaveId<Guid>,ITienDo, IMayHaveTepDinhKemDto {
    [DefaultValue(null)] public Guid? Id { get; set; }
    public Guid GetId() {
        Id ??= SequentialGuidGenerator.Instance.NewGuid();
        return (Guid)Id;
    }

    public Guid DuAnId { get; set; }
    public int? BuocId { get; set; }
    public DateTimeOffset? Ngay { get; set; }
    public string? NoiDung { get; set; }
    
    public long? NguoiBaoCaoId { get; set; }

    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}