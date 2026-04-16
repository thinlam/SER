using System.Text.Json.Serialization;

namespace QLDA.Application.DanhMucNhaThaus.DTOs;

public class DanhMucNhaThauInsertModel : DanhMucDto<int> {

    [JsonIgnore]
    public override int Id { get; set; }
    public string? DiaChi { get; set; }
    public string? MaSoThue { get; set; }
    public string? Email { get; set; }
    public string? SoDienThoai { get; set; }
    public string? NguoiDaiDien { get; set; }

    /// <summary>
    /// Danh sách người dùng thuộc nhà thầu
    /// </summary>
    public List<long> NguoiDungIds { get; set; } = [];
}
