using System.ComponentModel.DataAnnotations;

namespace QLHD.Application.KhoKhanVuongMacs.DTOs;

public class KhoKhanVuongMacUpdateModel
{
    [Required]
    [MaxLength(2000)]
    public string NoiDung { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? MucDo { get; set; }

    [Required]
    public DateOnly NgayPhatHien { get; set; }

    public DateOnly? NgayGiaiQuyet { get; set; }

    [MaxLength(2000)]
    public string? BienPhapKhacPhuc { get; set; }

    public int? TrangThaiId { get; set; }

    public Guid? TienDoId { get; set; }
}