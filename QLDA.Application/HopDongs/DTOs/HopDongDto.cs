using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;
using QLDA.Domain.Interfaces;

namespace QLDA.Application.HopDongs.DTOs;

public class HopDongDto : IHasKey<Guid?>, IMustHaveId<Guid>, IMayHaveTepDinhKemDto, ITienDo {
    [DefaultValue(null)] public Guid? Id { get; set; }

    public Guid GetId() {
        Id ??= BuildingBlocks.CrossCutting.ExtensionMethods.GuidExtensions.GetSequentialGuidId();
        return (Guid)Id;
    }

    public Guid DuAnId { get; set; }
    public int? BuocId { get; set; }
    public Guid? GoiThauId { get; set; }

    #region Thông tin thanh toán

    public List<Guid>? ThanhToanIds { get; set; }
    #endregion

    #region Thông tin tạm ứng

    public Guid? TamUngId { get; set; }
    public string? SoPhieuChi { get; set; }

    #endregion

    public string? Ten { get; set; }
    public string? SoHopDong { get; set; }
    public string? NoiDung { get; set; }
    public DateTimeOffset? NgayKy { get; set; }
    public long? GiaTri { get; set; }
    public DateTimeOffset? NgayHieuLuc { get; set; }
    public DateTimeOffset? NgayDuKienKetThuc { get; set; }
    public int? LoaiHopDongId { get; set; }
    public bool IsBienBan { get; set; }

    /// <summary>
    /// Đơn vị thực hiện
    /// </summary>
    public Guid? DonViThucHienId { get; set; }



    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}