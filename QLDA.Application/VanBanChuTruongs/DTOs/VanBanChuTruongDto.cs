using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;
using QLDA.Domain.Interfaces;
using SequentialGuid;

namespace QLDA.Application.VanBanChuTruongs.DTOs;

public class VanBanChuTruongDto : IHasKey<Guid?>, IMustHaveId<Guid>, IMayHaveTepDinhKemDto, ITienDo {
    [DefaultValue(null)] public Guid? Id { get; set; }

    /// <summary>
    /// Nếu có id => cập nhật, ngược lại là tạo mới
    /// </summary>
    /// <returns></returns>
    public Guid GetId() {
        Id ??= SequentialGuidGenerator.Instance.NewGuid();
        return (Guid)Id;
    }
    public Guid DuAnId { get; set; }
    public int? BuocId { get; set; }
    public string? SoVanBan { get; set; } = string.Empty;
    public string? TrichYeu { get; set; } = string.Empty;
    public DateTimeOffset? NgayVanBan { get; set; }
    public int? LoaiVanBanId { get; set; }
    public DateTimeOffset? NgayKy { get; set; }
    public string? NguoiKy { get; set; } = string.Empty;

    /// <summary>
    /// Danh mục chức vụ
    /// </summary>
    public int? ChucVuId { get; set; }

    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}