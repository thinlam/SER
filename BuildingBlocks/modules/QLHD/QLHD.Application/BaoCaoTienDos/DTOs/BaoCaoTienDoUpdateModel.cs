using System.ComponentModel.DataAnnotations;

namespace QLHD.Application.BaoCaoTienDos.DTOs;

public class BaoCaoTienDoUpdateModel
{
    [Required]
    public DateOnly NgayBaoCao { get; set; }

    [Range(0, 100)]
    public decimal PhanTramThucTe { get; set; }

    [MaxLength(4000)]
    public string? NoiDungDaLam { get; set; }

    [MaxLength(4000)]
    public string? KeHoachTiepTheo { get; set; }

    [MaxLength(1000)]
    public string? GhiChu { get; set; }
}