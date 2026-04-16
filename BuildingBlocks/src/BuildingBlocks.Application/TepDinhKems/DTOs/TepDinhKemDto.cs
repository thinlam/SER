using System.Text.Json.Serialization;

namespace BuildingBlocks.Application.TepDinhKems.DTOs;

public class TepDinhKemDto
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public Guid? ParentId { get; set; }
    [JsonIgnore]
    public string? GroupId { get; set; }
    [JsonIgnore]
    public string? GroupType { get; set; }

    /// <summary>
    /// Loại tệp
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Tên tệp mới
    /// </summary>
    public string? FileName { get; set; }

    /// <summary>
    /// Tên tệp gốc
    /// </summary>
    public string? OriginalName { get; set; }

    /// <summary>
    /// Đường dẫn lưu tệp
    /// </summary>
    public string? Path { get; set; }

    /// <summary>
    /// Kích thước
    /// </summary>
    public long Size { get; set; }
}
