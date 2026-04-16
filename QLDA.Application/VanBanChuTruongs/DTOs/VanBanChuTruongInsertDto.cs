using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;
using QLDA.Domain.Interfaces;

namespace QLDA.Application.VanBanChuTruongs.DTOs;

public class VanBanChuTruongInsertDto : IMayHaveTepDinhKemDto, ITienDo {
    public Guid DuAnId { get; set; }
    public int? BuocId { get; set; }
    public string? SoVanBan { get; set; } = string.Empty;
    public DateTimeOffset? NgayVanBan { get; set; }
    public int? LoaiVanBanId { get; set; }
    public DateTimeOffset? NgayKy { get; set; }
    public string? NguoiKy { get; set; } = string.Empty;
    public string? TrichYeu { get; set; } = string.Empty;
    public int? ChucVuId { get; set; }
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}