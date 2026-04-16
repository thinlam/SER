namespace QLDA.Application.Common.DTOs;

public class MinimalDanhMucVietInfoDto {
    public long Id { get; set; }
    [DefaultValue(null)] public long? ParentId { get; set; }

    /// <summary>
    /// Tên
    /// </summary>
    public string? Ten { get; set; }
}