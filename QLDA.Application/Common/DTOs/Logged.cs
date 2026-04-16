namespace QLDA.Application.Common.DTOs; 
/// <summary>
/// Đã đăng nhập - trả về token nếu cần
/// </summary>
public class Logged {
    public string Token { get; set; } = string.Empty;
    public long ExpiredTime { get; set; }
}
