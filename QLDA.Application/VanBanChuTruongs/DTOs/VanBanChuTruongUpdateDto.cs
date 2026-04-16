using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;

namespace QLDA.Application.VanBanChuTruongs.DTOs;

public class VanBanChuTruongUpdateDto : IMayHaveTepDinhKemDto {
    public Guid Id { get; set; }
    public string? SoVanBan { get; set; } = string.Empty;
    public DateTimeOffset? NgayVanBan { get; set; }
    public int? LoaiVanBanId { get; set; }
    public DateTimeOffset? NgayKy { get; set; }
    public string? NguoiKy { get; set; } = string.Empty;
    public string? TrichYeu { get; set; } = string.Empty;
    public int? ChucVuId { get; set; }
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}