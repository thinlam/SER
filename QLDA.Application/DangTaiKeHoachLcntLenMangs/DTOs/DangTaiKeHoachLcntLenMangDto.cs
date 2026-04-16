using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;
using QLDA.Domain.Enums;
using QLDA.Domain.Interfaces;
using SequentialGuid;

namespace QLDA.Application.DangTaiKeHoachLcntLenMangs.DTOs;

public class DangTaiKeHoachLcntLenMangDto : IHasKey<Guid?>, IMustHaveId<Guid>, IMayHaveTepDinhKemDto, ITienDo {
    [DefaultValue(null)] public Guid? Id { get; set; }

    public Guid GetId() {
        Id ??= SequentialGuidGenerator.Instance.NewGuid();
        return (Guid)Id;
    }

    public Guid DuAnId { get; set; }
    public int? BuocId { get; set; }
    public Guid? KeHoachLuaChonNhaThauId { get; set; }
    public ETrangThaiMoiThau TrangThaiId { get; set; }
    public DateTimeOffset? NgayEHSMT { get; set; }
    
    
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}