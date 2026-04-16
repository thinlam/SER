namespace QLDA.WebApi.ConfigurationOptions;

public class AppSettings {
    public ConnectionStrings ConnectionStrings { get; set; } = new ConnectionStrings();
    public string AllowedHosts { get; set; } = string.Empty;
    public JwtSettings Jwt { get; set; } = new JwtSettings();
    public string? SwaggerPathBase { get; set; }
}