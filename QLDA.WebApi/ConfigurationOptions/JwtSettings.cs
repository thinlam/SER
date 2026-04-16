namespace QLDA.WebApi.ConfigurationOptions;

public class JwtSettings {
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public string Key { get; set; } = null!;
    public int ExpiryMinutes { get; set; } = 120;

    /// <summary>
    /// Thời gian sống của access token (đọc từ cấu hình)
    /// Access token lifetime (read from configuration)
    /// </summary>
    public int AccessTokenExpiryMinutes { get; set; } = 5;

    /// <summary>
    /// Thời gian sống ngắn của refresh token (đọc từ cấu hình)
    /// Short refresh token lifetime (read from configuration)
    /// </summary>
    public int RefreshTokenShortExpiryMinutes { get; set; } = 120;
    /// <summary>
    /// Thời gian sống dài của refresh token khi người dùng chọn "ghi nhớ" (đọc từ cấu hình)
    /// Long refresh token lifetime when user chooses "remember me" (read from configuration)
    /// </summary>
    public int RefreshTokenRememberExpiryDays { get; set; } = 30;
    public string PasswordKey { get; set; } = "QLDA_Default_Password_Key_2024";
    public bool RequireUserIdHeader { get; set; } = false;
}
