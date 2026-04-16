using QLDA.Application.NhaThauNguoiDungs.DTOs;

namespace QLDA.WebApi.Models.DanhMucNhaThaus;

public class DanhMucNhaThauModel : DanhMucDto<Guid?>, IMustHaveId<Guid> {
    public Guid GetId()
        => Id ?? SequentialGuid.SequentialGuidGenerator.Instance.NewGuid();

    public string? DiaChi { get; set; }
    public string? MaSoThue { get; set; }
    public string? Email { get; set; }
    public string? SoDienThoai { get; set; }
    public string? NguoiDaiDien { get; set; }

    /// <summary>
    /// Danh sách người dùng thuộc nhà thầu
    /// </summary>
    public List<long> NguoiDungIds { get; set; } = [];

    /// <summary>
    /// Chi tiết người dùng (chỉ dùng khi trả về)
    /// </summary>
    public List<NhaThauNguoiDungDto> NguoiDungs { get; set; } = [];
}