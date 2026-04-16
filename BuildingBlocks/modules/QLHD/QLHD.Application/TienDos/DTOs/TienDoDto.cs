namespace QLHD.Application.TienDos.DTOs;

public class TienDoDto : IHasKey<Guid>
{
    public Guid Id { get; set; }
    public Guid HopDongId { get; set; }
    public string Ten { get; set; } = string.Empty;
    public decimal PhanTramKeHoach { get; set; }
    public DateOnly? NgayBatDauKeHoach { get; set; }
    public DateOnly? NgayKetThucKeHoach { get; set; }
    public string? MoTa { get; set; }
    public int TrangThaiId { get; set; }
    public string? TenTrangThai { get; set; }

    // Denormalized
    public decimal PhanTramThucTe { get; set; }
    public DateOnly? NgayCapNhatGanNhat { get; set; }
}