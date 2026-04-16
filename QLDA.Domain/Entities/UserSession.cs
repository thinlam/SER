using QLDA.Domain.Enums;

namespace QLDA.Domain.Entities;

/// <summary>
/// Bảng lưu trữ phiên đăng nhập của người dùng
/// </summary>
public class UserSession : IHasKey<Guid>, IAggregateRoot, ICreatedAt {
    /// <summary>
    /// Id của phiên
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Thời gian tạo
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    public string UserName { get; set; } = string.Empty;
    /// <summary>
    /// Thông tin platform
    /// </summary>
    public EPlatform Platform { get; set; } = EPlatform.Unknown;

    /// <summary>
    /// Tên thiết bị
    /// </summary>
    public string? DeviceName { get; set; }

    /// <summary>
    /// User agent
    /// </summary>
    public string? UserAgent { get; set; }

    /// <summary>
    /// Refresh token
    /// </summary>
    public string RefreshToken { get; set; } = string.Empty;

    /// <summary>
    /// Hạn refresh token
    /// </summary>
    public DateTimeOffset RefreshTokenExpiresAt { get; set; }

    /// <summary>
    /// Ghi nhớ đăng nhập
    /// </summary>
    public bool IsRemembered { get; set; }

    /// <summary>
    /// Thời gian hoạt động cuối cùng
    /// </summary>
    public DateTimeOffset LastActivityAt { get; set; }

    /// <summary>
    /// IP address
    /// </summary>
    public string? IpAddress { get; set; }

    /// <summary>
    /// Phiên đã bị thu hồi
    /// </summary>
    public bool IsRevoked { get; set; }

    /// <summary>
    /// Thông tin user được serialize để tối ưu performance
    /// User information serialized for performance optimization
    /// </summary>
    public string? UserInfoJson { get; set; }

    /// <summary>
    /// Thông tin auth (roles, permissions) serialized for performance optimization
    /// </summary>
    public string? UserAuthInfoJson { get; set; }
}
