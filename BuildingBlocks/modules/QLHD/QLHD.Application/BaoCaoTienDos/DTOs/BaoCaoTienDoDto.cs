namespace QLHD.Application.BaoCaoTienDos.DTOs;

public class BaoCaoTienDoDto : IHasKey<Guid>
{
    public Guid Id { get; set; }
    public Guid TienDoId { get; set; }
    public string? TenTienDo { get; set; }
    public DateOnly NgayBaoCao { get; set; }
    public long NguoiBaoCaoId { get; set; }
    public string TenNguoiBaoCao { get; set; } = string.Empty;
    public decimal PhanTramThucTe { get; set; }
    public string? NoiDungDaLam { get; set; }
    public string? KeHoachTiepTheo { get; set; }
    public string? GhiChu { get; set; }

    // Approval
    public bool CanDuyet { get; set; }
    public bool DaDuyet { get; set; }
    public long? NguoiDuyetId { get; set; }
    public string? TenNguoiDuyet { get; set; }
    public DateOnly? NgayDuyet { get; set; }

    // Computed
    public string TrangThaiDuyet => !CanDuyet ? "Không cần duyệt" : DaDuyet ? "Đã duyệt" : "Chờ duyệt";
}