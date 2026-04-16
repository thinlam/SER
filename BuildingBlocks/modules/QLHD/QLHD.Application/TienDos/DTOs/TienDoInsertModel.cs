using System.ComponentModel.DataAnnotations;

namespace QLHD.Application.TienDos.DTOs;

public class TienDoInsertModel
{
    [Required]
    public Guid HopDongId { get; set; }

    [Required]
    [MaxLength(500)]
    public string Ten { get; set; } = string.Empty;

    [Range(0, 100)]
    public decimal PhanTramKeHoach { get; set; }

    public DateOnly? NgayBatDauKeHoach { get; set; }
    public DateOnly? NgayKetThucKeHoach { get; set; }

    [MaxLength(2000)]
    public string? MoTa { get; set; }

    public int? TrangThaiId { get; set; }
}