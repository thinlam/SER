namespace QLHD.Domain.Interfaces;

/// <summary>
/// Interface đánh dấu có trường NgayKy (ngày ký hợp đồng)
/// - Dùng để đảm bảo các DTO có trường NgayKy đều implement interface này, giúp việc filter theo ngày ký hợp đồng trong các query trở nên dễ dàng và nhất quán hơn
/// - Tránh việc phải check kiểu và cast nhiều lần trong các query handler khi cần filter theo ngày ký hợp đồng
/// </summary>
public interface INgayHopDong {
    DateOnly NgayKy { get; set; }
}