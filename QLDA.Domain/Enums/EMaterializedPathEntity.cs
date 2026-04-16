using System.Text.Json.Serialization;

namespace QLDA.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EMaterializedPathEntity {
    DanhMucBuoc,
    DuAn
}