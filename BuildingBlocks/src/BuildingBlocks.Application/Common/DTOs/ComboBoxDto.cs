using System.Text.Json.Serialization;

namespace BuildingBlocks.Application.Common.DTOs;

public class ComboBoxDto<T> {
    public T Id { get; set; } = default!;
    /// <summary>
    /// Tên
    /// </summary>
    public string? Ten { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Ma { get; set; }
}
