using System.ComponentModel;
using QLDA.Domain.Interfaces;
using QLDA.WebApi.Models.TepDinhKems;

namespace QLDA.WebApi.Models.DangTaiKeHoachLcntLenMangs;

using SequentialGuid;

public class DangTaiKeHoachLcntLenMangModel : IHasKey<Guid?>, IMustHaveId<Guid>, IMayHaveTepDinhKemModel, ITienDo {
    [DefaultValue(null)] public Guid? Id { get; set; }

    public Guid GetId() {
        Id ??= SequentialGuidGenerator.Instance.NewGuid();
        return (Guid)Id;
    }

    public Guid DuAnId { get; set; }
    public int? BuocId { get; set; }
    public Guid KeHoachLuaChonNhaThauId { get; set; }
    public DateTimeOffset? NgayEHSMT { get; set; }
    /// <summary>
    /// Trạng thái đã/chưa đăng hồ sơ mời thầu lên Hệ thống mạng đấu thầu quốc gia
    /// </summary>
    public ETrangThaiMoiThau TrangThaiId { get; set; }

    public List<TepDinhKemModel>? DanhSachTepDinhKem { get; set; }
}