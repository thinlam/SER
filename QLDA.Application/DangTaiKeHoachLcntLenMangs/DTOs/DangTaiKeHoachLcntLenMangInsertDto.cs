using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;
using QLDA.Domain.Enums;
using QLDA.Domain.Interfaces;

namespace QLDA.Application.DangTaiKeHoachLcntLenMangs.DTOs;

public class DangTaiKeHoachLcntLenMangInsertDto : IMayHaveTepDinhKemDto, ITienDo {
    [DefaultValue(null)] public Guid? Id { get; set; }
    public Guid DuAnId { get; set; }
    public int? BuocId { get; set; }
    public Guid KeHoachLuaChonNhaThauId { get; set; }
    public DateTimeOffset? NgayEHSMT { get; set; }
    public ETrangThaiMoiThau TrangThaiId { get; set; }
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}