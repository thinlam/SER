
using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;

namespace QLDA.Application.HopDongs.DTOs;

public class HopDongUpdateDto : IMayHaveTepDinhKemInsertOrUpdateDto {
    public Guid Id { get; set; }
    public Guid GoiThauId { get; set; }
    public string? Ten { get; set; }
    public string? SoHopDong { get; set; }
    public string? NoiDung { get; set; }
    public Guid? DonViThucHienId { get; set; }
    public DateTimeOffset? NgayKy { get; set; }
    public long? GiaTri { get; set; }
    public DateTimeOffset? NgayHieuLuc { get; set; }
    public DateTimeOffset? NgayDuKienKetThuc { get; set; }
    public int? LoaiHopDongId { get; set; }

    /// <summary>
    /// Là hợp đồng hay biên bản giao nhiệm vụ
    /// </summary>
    [DefaultValue(true)]
    public bool IsBienBan { get; set; } = true;

    public List<TepDinhKemInsertOrUpdateDto>? DanhSachTepDinhKem { get; set; }
}