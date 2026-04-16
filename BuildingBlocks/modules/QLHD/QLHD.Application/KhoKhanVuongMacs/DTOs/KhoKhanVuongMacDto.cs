namespace QLHD.Application.KhoKhanVuongMacs.DTOs;

public class KhoKhanVuongMacDto : IHasKey<Guid>
{
    public Guid Id { get; set; }
    public Guid HopDongId { get; set; }
    public Guid? TienDoId { get; set; }
    public string? TenTienDo { get; set; }
    public string NoiDung { get; set; } = string.Empty;
    public string? MucDo { get; set; }
    public DateOnly NgayPhatHien { get; set; }
    public DateOnly? NgayGiaiQuyet { get; set; }
    public string? BienPhapKhacPhuc { get; set; }
    public int TrangThaiId { get; set; }
    public string? TenTrangThai { get; set; }
}