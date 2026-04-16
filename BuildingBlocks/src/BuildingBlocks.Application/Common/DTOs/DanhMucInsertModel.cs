namespace BuildingBlocks.Application.Common.DTOs;

public class DanhMucInsertModel
{

    /// <summary>
    /// Mã
    /// </summary>
    [DefaultValue(null)]
    public string? Ma { get; set; }

    /// <summary>
    /// Tên
    /// </summary>
    [DefaultValue(null)]
    public string? Ten { get; set; }

    /// <summary>
    /// Mô tả
    /// </summary>
    [DefaultValue(null)]
    public string? MoTa { get; set; }
}
