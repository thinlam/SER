using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;
using QLDA.Domain.Interfaces;
using SequentialGuid;

namespace QLDA.Application.NghiemThus.DTOs;

public class NghiemThuDto : IHasKey<Guid?>, IMustHaveId<Guid>, IMayHaveTepDinhKemDto, ITienDo {
    [DefaultValue(null)] public Guid? Id { get; set; }

    public Guid GetId() {
        Id ??= SequentialGuidGenerator.Instance.NewGuid();
        return (Guid)Id;
    }
    /// <summary>
    /// Nếu có dữ liệu => nghiệm thu đã thanh toán không cho nghiệm thu nữa
    /// </summary>
    public Guid? ThanhToanId { get; set; }
    public Guid DuAnId { get; set; }
    public int? BuocId { get; set; }
    public Guid? HopDongId { get; set; }
    public string? SoBienBan { get; set; }
    public string? Dot { get; set; }
    public DateTimeOffset? Ngay { get; set; }
    public string? NoiDung { get; set; }

    #region  Issue 9211
    /// <summary>
    /// Giá trị
    /// </summary>
    public long GiaTri { get; set; }

    #endregion
    public List<Guid>? PhuLucHopDongIds { get; set; }
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}