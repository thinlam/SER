using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;
using QLDA.Domain.Enums;

namespace QLDA.Application.DangTaiKeHoachLcntLenMangs.DTOs;

public class DangTaiKeHoachLcntLenMangUpdateDto : IMayHaveTepDinhKemDto {
    public Guid Id { get; set; }
    public Guid KeHoachLuaChonNhaThauId { get; set; }
    public DateTimeOffset? NgayEHSMT { get; set; }
    public ETrangThaiMoiThau TrangThaiId { get; set; }
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}