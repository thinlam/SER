namespace QLHD.Domain.Interfaces;

/// <summary>
/// Interface đánh dấu có trường KhachHangId (ID khách hàng)
/// - Required vì mọi hợp đồng phải có khách hàng
/// - Dùng để đảm bảo consistency khi cần truy cập ID khách hàng trong các DTO
/// </summary>
public interface IKhachHangKey
{
    Guid KhachHangId { get; set; }
}
