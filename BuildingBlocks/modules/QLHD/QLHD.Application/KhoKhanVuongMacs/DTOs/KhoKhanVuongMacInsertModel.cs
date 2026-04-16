using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QLHD.Application.KhoKhanVuongMacs.DTOs;

public class KhoKhanVuongMacInsertModel
{
    /// <summary>
    /// If null or empty → Add new. If has value → Update existing.
    /// </summary>
    [DefaultValue("00000000-0000-0000-0000-000000000000")]
    public Guid? Id { get; set; }

    [Required]
    public Guid HopDongId { get; set; }

    public Guid? TienDoId { get; set; }

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
}