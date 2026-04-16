using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using System.IdentityModel.Tokens.Jwt;
using BuildingBlocks.Domain.DTOs;
using BuildingBlocks.Domain.Providers;
using BuildingBlocks.Domain.Constants;

namespace BuildingBlocks.Application.Common.Services;

public class UserProvider : IUserProvider
{
    private readonly Serilog.ILogger _logger = Serilog.Log.ForContext<UserProvider>();
    private UserInfo? _userInfo;
    private UserAuthInfo? _userAuthInfo;

    /// <summary>
    /// System user ID for background jobs
    /// </summary>
    private const long SystemUserId = 0;

    /// <summary>
    /// User ID - từ JWT token, hoặc SystemUserId (0) cho background jobs
    /// </summary>
    public long Id => _userInfo?.UserID ?? SystemUserId;

    /// <summary>
    /// User information - cached với lazy loading
    /// </summary>
    public UserInfo Info => _userInfo ?? throw new UnauthorizedAccessException(ErrorMessageConstants.UnauthorizedAccess);

    /// <summary>
    /// Authentication and role information - cached với lazy loading
    /// </summary>
    public UserAuthInfo AuthInfo => _userAuthInfo ?? throw new UnauthorizedAccessException(ErrorMessageConstants.UnauthorizedAccess);

    /// <summary>
    /// Constructor - khởi tạo từ HTTP context với JWT token parsing
    /// </summary>
    /// <param name="serviceProvider">Service provider để inject dependencies</param>
    public UserProvider(IServiceProvider serviceProvider)
    {
        var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
        var httpContext = httpContextAccessor.HttpContext;
        if (httpContext?.Request == null)
            return;


        if (httpContext.Request.Headers.TryGetValue("Authorization", out StringValues token))
        {
            if (!ReadPayloadJwtToken(token.FirstOrDefault()))
                _logger.Warning("Không thể đọc payload từ JWT token");

        }
    }

    /// <summary>
    /// Reads and parses JWT token payload to extract user information
    /// </summary>
    /// <param name="token">JWT token string</param>
    /// <returns>UserInfo object or null if parsing fails</returns>
    private bool ReadPayloadJwtToken(string? token)
    {
        try
        {
            if (string.IsNullOrEmpty(token))
                return false;

            var tokenHandler = new JwtSecurityTokenHandler();
            token = token.Replace("Bearer ", string.Empty);

            var jwtTokenObj = tokenHandler.ReadJwtToken(token);
            if (jwtTokenObj?.Claims == null) return false;

            var strUserId = jwtTokenObj.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value ?? "0";
            var strDonViId = jwtTokenObj.Claims.FirstOrDefault(x => x.Type == "UnitId")?.Value ?? "0";
            var strPhongBanId = jwtTokenObj.Claims.FirstOrDefault(x => x.Type == "PhongBanId")?.Value ?? "0";
            var roles = jwtTokenObj.Claims.Where(x => x.Type == "Roles").Select(x => x.Value).ToList() ?? [];
            var permissions = jwtTokenObj.Claims.Where(x => x.Type == "Permissions").Select(x => x.Value).ToList() ?? [];

            _ = long.TryParse(strUserId, out var userId);
            _ = long.TryParse(strDonViId, out var donViId);
            _ = long.TryParse(strPhongBanId, out var phongBanId);

            _userInfo = new UserInfo
            {
                UserID = userId,
                DonViID = donViId,
                PhongBanID = phongBanId
            };
            _userAuthInfo = new UserAuthInfo
            {
                Roles = roles,
                Permissions = permissions
            };
            return _userInfo.UserID > 0;
        }
        catch
        {
            return false;
        }
    }
}
