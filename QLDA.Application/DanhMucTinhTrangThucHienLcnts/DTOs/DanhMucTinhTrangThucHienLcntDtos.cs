namespace QLDA.Application.DanhMucTinhTrangThucHienLcnts.DTOs;

/// <summary>
/// DTO for creating new DanhMucTinhTrangThucHienLcnt
/// </summary>
public class DanhMucTinhTrangThucHienLcntInsertDto
{
    public string? Ma { get; set; }
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public int? Stt { get; set; }
    public bool Used { get; set; } = true;
}

/// <summary>
/// DTO for updating existing DanhMucTinhTrangThucHienLcnt
/// </summary>
public class DanhMucTinhTrangThucHienLcntUpdateDto
{
    public int Id { get; set; }
    public string? Ma { get; set; }
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public int? Stt { get; set; }
    public bool Used { get; set; }
}
