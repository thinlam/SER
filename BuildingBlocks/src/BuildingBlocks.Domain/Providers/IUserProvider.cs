using BuildingBlocks.Domain.DTOs;

namespace BuildingBlocks.Domain.Providers;

public interface IUserProvider {
    public long Id { get; }
    /// <summary>
    /// Lấy từ hdUserInfo
    /// </summary>
    public UserInfo Info { get; }
    /// <summary>
    /// UserAuthInfo - lazy load khi cần, ưu tiên Auth token
    /// </summary>
    public UserAuthInfo AuthInfo { get; }
}
