using System.ComponentModel.DataAnnotations;

namespace QLHD.Application.BaoCaoTienDos.DTOs;

public class BaoCaoTienDoInsertModel
{
    [Required]
    public Guid TienDoId { get; set; }

    [Required]
    public DateOnly NgayBaoCao { get; set; }

    /// <summary>
    /// UserPortalId of the reporter - Name fetched from USER_MASTER
    /// </summary>
    public long NguoiBaoCaoId { get; set; }

    [Range(0, 100)]
    public decimal PhanTramThucTe { get; set; }

    [MaxLength(4000)]
    public string? NoiDungDaLam { get; set; }

    [MaxLength(4000)]
    public string? KeHoachTiepTheo { get; set; }

    [MaxLength(1000)]
    public string? GhiChu { get; set; }

    /// <summary>
    /// If true, report requires approval before being effective
    /// </summary>
    public bool CanDuyet { get; set; }

    /// <summary>
    /// Required if CanDuyet = true. UserPortalId of the approver - Name fetched from USER_MASTER
    /// </summary>
    public long? NguoiDuyetId { get; set; }
}