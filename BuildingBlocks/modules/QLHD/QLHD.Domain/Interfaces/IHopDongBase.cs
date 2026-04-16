namespace QLHD.Domain.Interfaces;

/// <summary>
/// Interface đánh dấu có đầy đủ các trường cơ bản của hợp đồng dùng trong DTO danh sách
/// - Kế thừa IHasKey&lt;Guid&gt; để có property Id
/// - Kế thừa INgayHopDong để có property NgayKy
/// - Kế thừa các interface nhỏ: ISoHopDong, ITen, IDuAnKey, IKhachHangKey, IGiaTri, ITrangThai
/// - Áp dụng cho: HopDongThuTienDto, HopDongXuatHoaDonDto, HopDongCoChiPhiDto
/// - Dùng để đảm bảo consistency giữa các DTO hiển thị hợp đồng trong các màn hình danh sách
/// </summary>
public interface IHopDongBase : IHasKey<Guid>, INgayHopDong, ISoHopDong, ITen, IDuAnKey, IKhachHangKey, IGiaTri, ITrangThai
{
}
