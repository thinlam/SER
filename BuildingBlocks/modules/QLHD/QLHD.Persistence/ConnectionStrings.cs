namespace QLHD.Persistence;

public class ConnectionStrings
{
    public string DefaultConnection { get; set; } = string.Empty;
    /// <summary>Database schema name. Default: "dbo" (staging), "dev" (development).</summary>
    public string? Schema { get; set; }
}